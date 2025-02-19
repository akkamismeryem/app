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

namespace pharmacy_console
{
    public partial class AddStock : Form
    {
        //SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True");

        public AddStock()
        {
            InitializeComponent();
            LoadMedicines();
            InitializeDataGridViewColumns();

        }

        private void LoadMedicines()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))

                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.Medicines";
                    

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        
                        
                        dataGridUpdateMedicines.DataSource = dt;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }
        

        private void InitializeDataGridViewColumns()
        {
            // İlaç Bilgisi Butonu
            DataGridViewTextBoxColumn txtAmount = new DataGridViewTextBoxColumn
            {
                HeaderText = "Amount",
                Name = "TextAmount"
            };
            dataGridUpdateMedicines.Columns.Add(txtAmount);



            // İlaç Bilgisi Butonu
            DataGridViewButtonColumn addButton = new DataGridViewButtonColumn
            {
                HeaderText = "Add Button",
                Text = "Add",
                UseColumnTextForButtonValue = true,
                Name = "AddButton"
            };
            dataGridUpdateMedicines.Columns.Add(addButton);

            
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // TextBox'ı güncelle




            string medicineName = txtMedicineName.Text.Trim();
            string activeIngredient = txtActiveIngredient.Text.Trim();
            string medicineType = txtMedicineType.Text.Trim();
            string presicriptionType = txtPrescriptionType.Text.Trim();
            float publicPrice = 0;
            float publicPaid = 0;
            string isReport = txtIsReport.Text.Trim();
            string stockAmount = txtStockAmount.Text.Trim();
            string medicineID = txtMedID.Text.Trim();

            if (!float.TryParse(txtPublicPrice.Text.Trim(), out publicPrice))
            {
                MessageBox.Show("Public Price should be a valid number.");
                return; // Hatalı giriş varsa işlem yapmadan çık
            }
            else
            {
                // İki basamaklı format
                txtPublicPrice.Text = publicPrice.ToString("F2");
                
            }

            // Trigger PublicPaid hesapladığından, burası gerekli olmayabilir
            if (!float.TryParse(txtPublicPaid.Text.Trim(), out publicPaid))
            {
                MessageBox.Show("Public Paid should be a valid number.");
                return; // Hatalı giriş varsa işlem yapmadan çık
            }
            else
            {
               
                // İki basamaklı format
                txtPublicPaid.Text = publicPaid.ToString("F2");
                
            }


            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))

                {
                    conn.Open();

                    // 6.Stored Procedure çağırma
                    using (SqlCommand cmd = new SqlCommand("sp_AddMedicines", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        // Parametreleri ekle
                        cmd.Parameters.AddWithValue("@medicineID", medicineID);
                        cmd.Parameters.AddWithValue("@medicineName", medicineName);
                        cmd.Parameters.AddWithValue("@activeIngredient", activeIngredient);
                        cmd.Parameters.AddWithValue("@medicineType", medicineType);
                        cmd.Parameters.AddWithValue("@presicriptionType", presicriptionType);
                        cmd.Parameters.AddWithValue("@publicPrice", publicPrice);
                        cmd.Parameters.AddWithValue("@publicPaid", publicPaid);
                        cmd.Parameters.AddWithValue("@isReport", isReport);
                        cmd.Parameters.AddWithValue("@stockAmount", stockAmount);

                        cmd.ExecuteNonQuery(); // Prosedürü çalıştır
                    }
                }


                MessageBox.Show("Saved Successfully!");
                LoadMedicines(); // Veriyi yeniden yükle

                txtMedicineName.Text = "";
                txtActiveIngredient.Text = "";
                txtMedicineType.Text = "";
                txtPrescriptionType.Text = "";
                txtPublicPrice.Text = "";
                txtPublicPaid.Text = "";
                txtIsReport.Text = "";
                txtStockAmount.Text = "";
                txtMedID.Text = "";



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }




        }
        


        private void dataGridUpdateMedicines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridUpdateMedicines.Columns[e.ColumnIndex].Name == "AddButton")
            {
                try
                {
                    string medicineID = dataGridUpdateMedicines.Rows[e.RowIndex].Cells["MedID"].Value.ToString();
                    string amountToAdd = dataGridUpdateMedicines.Rows[e.RowIndex].Cells["TextAmount"].Value?.ToString() ?? "0";
                    using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))

                    {
                        if (int.TryParse(amountToAdd, out int parsedAmount) && parsedAmount > 0)
                        {
                            conn.Open();
                            //Trigger tetikleniyor
                            string query = "UPDATE Medicines SET StockAmount = StockAmount + @Amount WHERE MedID = @MedicineID";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Amount", parsedAmount);
                                cmd.Parameters.AddWithValue("@MedicineID", medicineID);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Stock updated successfully!");


                            LoadMedicines(); // Veriyi yeniden yükle


                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid amount.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
               
            }
        }
    }
}
