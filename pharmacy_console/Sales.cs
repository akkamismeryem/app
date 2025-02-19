using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pharmacy_console.Form2;

namespace pharmacy_console
{
    public partial class Sales : Form
    {
        public string UserID { get; set; }

        private object medicineID1;

        public Sales()
        {
            InitializeComponent();
        }
        private void Sales_Load(object sender, EventArgs e)
        {
            // DataGridView'e kolonları ekliyoruz
            dataGridAddsForSale.Columns.Add("Barcode", "Barcode");
            dataGridAddsForSale.Columns.Add("PrescriptionID", "Prescription ID");
            dataGridAddsForSale.Columns.Add("MedicineID", "Medicine ID");
            dataGridAddsForSale.Columns.Add("Pcs", "Pcs");
            dataGridAddsForSale.Columns.Add("PublicPrice", "Public Price");
            dataGridAddsForSale.Columns.Add("PublicPaid", "Public Paid");
        }

        private void txtSearchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadSalesData(txtSearchID.Text.Trim());
            }
        }
        private void LoadSalesData(string searchID)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query;
                    if (searchID == "*")
                    {
                        query = "SELECT * FROM dbo.Prescriptions";
                    }
                    else
                    {
                        query = @"SELECT * FROM dbo.Prescriptions
                                  WHERE PatientID LIKE @search + '%' OR
                                        PreID LIKE @search + '%'";

                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", searchID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridSales.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private bool IsPrescriptionExpired(string prescriptionId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) 
                FROM ExpiredPrescriptions 
                WHERE PreID = @prescriptionId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prescriptionId", prescriptionId);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Zamanı geçen reçete varsa true döner
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        private bool IsPrescriptionAlreadySold(string prescriptionId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) 
                FROM Sales 
                WHERE PrescriptionID = @prescriptionId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prescriptionId", prescriptionId);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Daha önce satış yapılmışsa true döner
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void dataGridSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string prescriptionId = dataGridSales.Rows[e.RowIndex].Cells["PreID"].Value.ToString();
                string patientId = dataGridSales.Rows[e.RowIndex].Cells["PatientID"].Value.ToString();

                if (IsPrescriptionExpired(prescriptionId))
                {
                    MessageBox.Show("Reçete bulunamadı veya zamanı geçmiş.");
                    return;
                }
                else
                {
                    // Reçete daha önce satıldı mı kontrol et
                    if (IsPrescriptionAlreadySold(prescriptionId))
                    {
                        MessageBox.Show("Bu reçeteye ait satış kaydı zaten mevcut. Tekrar satış yapılamaz.");
                        return;
                    }
                    else
                    {

                        Form2 form2 = new Form2(prescriptionId, patientId)
                        {
                            Owner = this
                        };
                        form2.ShowDialog();
                    }
                }
            
            }
            
        }
        public void AddMedicineToGrid(MedicineInfo medicine)
        {
            dataGridAddsForSale.Rows.Add(
                medicine.Barcode,
                medicine.PrescriptionID,
                medicine.MedicineID,
                medicine.Pcs,
                medicine.PublicPrice,
                medicine.PublicPaid
            );
        }

        private void guna2Button2_Click(object sender, EventArgs e)//SALE BUTTON
        {

            CompleteSale();

        }

        private void CompleteSale()
        {
            try
            {
                long prescriptionId = 0; // PrescriptionID (bigint)

                // 1. DataGrid'deki verileri kaydet
                SaveDataToDatabase();
                // Seçilen ilaçların toplam fiyatını hesapla
                //float totalPrice = 0;

                // DataGridView'den PrescriptionID ve PublicPaid toplamını al
                foreach (DataGridViewRow row in dataGridAddsForSale.Rows)
                {

                    if (row.Cells["PrescriptionID"].Value != null)
                    {
                        // PrescriptionID bigint olduğu için long olarak dönüştür
                        prescriptionId = Convert.ToInt64(row.Cells["PrescriptionID"].Value);
                        break;
                    }

                }



                float totalPriceForNonPrescription = CalculateTotalPrice(null); // Reçetesiz
                float totalPriceForPrescription = CalculateTotalPrice(prescriptionId); // Reçeteli

                float grandTotal = totalPriceForNonPrescription + totalPriceForPrescription;

                MessageBox.Show("Toplam Fiyat: " + grandTotal);




                string patientId = "";

                DateTime saleDate = dateTimeSale.Value;

                


                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT PatientID FROM Prescriptions WHERE PreID = @PrescriptionID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            patientId = reader["PatientID"].ToString();
                        }
                    }
                }

                //Satış Kaydı EklemE
                long saleId = 0;
                // Sales tablosuna ekleme işlemi
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string insertQuery = @"
                                        INSERT INTO Sales (PharmacistID, PrescriptionID, PatientID, TotalPrice, SaleDate) 
                                        VALUES (@PharmacistID, @PrescriptionID, @PatientID, @TotalPrice, @SaleDate)
                                        SELECT SCOPE_IDENTITY()";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PharmacistID", UserID);
                        cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId);
                        cmd.Parameters.AddWithValue("@PatientID", patientId);
                        cmd.Parameters.AddWithValue("@TotalPrice", grandTotal);
                        cmd.Parameters.AddWithValue("@SaleDate", saleDate);

                        //cmd.ExecuteNonQuery();
                        saleId = Convert.ToInt64(cmd.ExecuteScalar());

                    }


                }
                

                MessageBox.Show("Satış işlemi başarıyla tamamlandı.");


                // Sales formunu kapatıp Invoice formunu aç
                Invoince invoince = new Invoince();
                invoince.SetInvoinceData(saleId, prescriptionId, patientId, grandTotal, saleDate);
                invoince.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)//ADD MEDICINE FOR SALE
        {
            WhitePrescriptions whitePrescriptions = new WhitePrescriptions
            {
                Owner = this // WhitePrescriptions formunun Owner özelliği olarak Sales formunu belirle
            };
            whitePrescriptions.ShowDialog();
        }
        private void SaveDataToDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridAddsForSale.Rows)
                    {
                        
                        if (row.Cells["MedicineID"].Value != null) // Boş satırları atla
                        {
                            medicineID1 = row.Cells["MedicineID"].Value.ToString();
                            string query = @"
                        INSERT INTO AddForSales (MedicineID, PrecscriptionID, Pcs, PublicPrice, PublicPaid)
                        VALUES (@MedicineID, @PrescriptionID, @Pcs, @PublicPrice, @PublicPaid)";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MedicineID", row.Cells["MedicineID"].Value);
                                cmd.Parameters.AddWithValue("@PrescriptionID",
                                   row.Cells["PrescriptionID"].Value ?? (object)DBNull.Value); // NULL için kontrol
                                cmd.Parameters.AddWithValue("@Pcs", row.Cells["Pcs"].Value);
                                cmd.Parameters.AddWithValue("@PublicPrice", row.Cells["PublicPrice"].Value);
                                cmd.Parameters.AddWithValue("@PublicPaid", row.Cells["PublicPaid"].Value);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("DataGrid'deki veriler başarıyla veritabanına kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private float CalculateTotalPrice(long? prescriptionId = null)
        {
            float totalPrice = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "SELECT dbo.CalculateTotalPrice(@PrescriptionID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId ?? (object)DBNull.Value); // NULL kontrolü

                        totalPrice = Convert.ToSingle(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            return totalPrice;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // DataGridView'de bir satır seçilmiş mi kontrol et
            if (dataGridAddsForSale.SelectedRows.Count > 0)
            {
                try
                {
                    // Seçilen satırı DataGridView'den kaldır
                    dataGridAddsForSale.Rows.RemoveAt(dataGridAddsForSale.SelectedRows[0].Index);
                    MessageBox.Show("Satır başarıyla silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.");
            }
        }
        

        private void dataGridAddsForSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satıra tıklanmış mı kontrol et
            {
                // Tıklanan satırı seçili hale getir
                dataGridAddsForSale.Rows[e.RowIndex].Selected = true;
            }
        }

        private void Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridAddsForSale.Rows.Count > 0) // Eğer satır varsa
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                    {
                        conn.Open();

                        // AddForSales tablosunu temizle
                        SqlCommand deleteAll = new SqlCommand("DELETE FROM AddForSales", conn);
                        deleteAll.ExecuteNonQuery();

                        MessageBox.Show("Unsold medicines were removed from the AddForSales table.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred while clearing AddForSales: {ex.Message}");
                }
            }
        }
    }
}
