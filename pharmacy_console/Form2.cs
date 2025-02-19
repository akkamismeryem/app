using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml.Linq;

namespace pharmacy_console
{
    public partial class Form2 : Form
    {
        private string prescriptionId;
        private string patientId;

        public Form2(string prescriptionId, string patientId)
        {
            InitializeComponent();
            this.prescriptionId = prescriptionId;
            this.patientId = patientId;
            LoadMedicines();
        }
        private void LoadMedicines()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = @"
                    SELECT BarcodeNo,PrescriptionID, MedicineID, Pcs, Dose
                    FROM MedicinesOnPresicriptions
                    WHERE PrescriptionID = @PrescriptionID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionId);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridMedicines.DataSource = dt;

                        InitializeDataGridViewColumns();
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
            // Eğer sütunlar zaten database'den geliyorsa, manuel eklemek yerine özellikleri ayarlayabilirsiniz
            dataGridMedicines.Columns["Pcs"].ReadOnly = false; // Pcs kolonu düzenlenebilir olacak
            dataGridMedicines.Columns["Pcs"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//Ortada dursun diye

            // Checkbox Kolonu
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Name = "SelectColumn"
            };
            dataGridMedicines.Columns.Add(checkBoxColumn);

            // İlaç Bilgisi Butonu
            DataGridViewButtonColumn medicineInfoButton = new DataGridViewButtonColumn
            {
                HeaderText = "Medicine Info",
                Text = "Info",
                UseColumnTextForButtonValue = true,
                Name = "MedicineInfoButton"
            };
            dataGridMedicines.Columns.Add(medicineInfoButton);

            // Rapor Bilgisi Butonu
            DataGridViewButtonColumn reportInfoButton = new DataGridViewButtonColumn
            {
                HeaderText = "Report Info",
                Text = "Report",
                UseColumnTextForButtonValue = true,
                Name = "ReportInfoButton"
            };
            dataGridMedicines.Columns.Add(reportInfoButton);
        }

        private void dataGridMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // İlaç Bilgisi Butonuna tıklanırsa
            if (e.ColumnIndex == dataGridMedicines.Columns["MedicineInfoButton"].Index && e.RowIndex >= 0)
            {
                string medicineId = dataGridMedicines.Rows[e.RowIndex].Cells["MedicineID"].Value.ToString();
                ShowMedicineInfo(medicineId); // İlaç bilgisi göster
            }

            // Rapor Bilgisi Butonuna tıklanırsa
            if (e.ColumnIndex == dataGridMedicines.Columns["ReportInfoButton"].Index && e.RowIndex >= 0)
            {
                string patientId = "PatientID"; // Hasta ID'sini uygun bir değişkenden alın
                string medicineId = dataGridMedicines.Rows[e.RowIndex].Cells["MedicineID"].Value.ToString();
                ShowReportInfo(patientId, medicineId); // Rapor bilgisi göster
            }
        }

        private void ShowMedicineInfo(string medicineId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT a.MedicineID, m.MedID, m.MedicineName, m.ActiveIngredient, m.MedicineType, m.PresicriptionType, m.PublicPrice, m.PublicPaid, m.StockAmount " +
                        "FROM dbo.MedicinesOnPresicriptions a " +
                        "INNER JOIN dbo.Medicines m ON a.MedicineID = m.MedID WHERE m.MedID = @c1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@c1", medicineId);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Formdaki textBoxlara bilgileri yazdır
                            //txtMedicineID.Text = reader["MedID"].ToString();
                            txtMedicineName.Text = reader["MedicineName"].ToString();
                            txtActiveIngredient.Text = reader["ActiveIngredient"].ToString();
                            txtMedicineType.Text = reader["MedicineType"].ToString();
                            txtPrescriptionType.Text = reader["PresicriptionType"].ToString();
                            txtPublicPrice.Text = reader["PublicPrice"].ToString();
                            txtPublicPaid.Text = reader["PublicPaid"].ToString();
                            txtStockAmount.Text = reader["StockAmount"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Doctor profile not found.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        

        private void ShowReportInfo(string patientId, string medicineId)
        {
            try
            {
              
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = @"
                                SELECT 
                                u.PreID,             
                                u.DoctorID,        
                                u.PatientID,  
                                u.CreationAt,        
                                d.BarcodeNo,  
                                d.MedicineID,  
                                d.Pcs AS PrescriptionPcs,  
                                d.Dose,
                                r.Pcs AS ReportPcs,
                                r.ReID,
                                r.Diagnose,
                                r.CreationDate,
                                r.EndDate
                            FROM   
                                dbo.Prescriptions u  
                            INNER JOIN   
                                dbo.MedicinesOnPresicriptions d ON u.PreID = d.PrescriptionID
                            INNER JOIN
                                dbo.Reports r ON u.PatientID = r.PatientID
                            WHERE
                                r.MedicineID = @c2 AND r.PatientID = @c3
                                AND r.EndDate >= GETDATE()
                                ORDER BY r.CreationDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@c2", medicineId);
                        cmd.Parameters.AddWithValue("@c3", this.patientId);


                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Formdaki textBoxlara bilgileri yazdır
                            txtReportID.Text = reader["ReID"].ToString();
                            txtPcs.Text = reader["ReportPcs"].ToString();
                            txtDose.Text = reader["Dose"].ToString();
                            txtDiagnose.Text = reader["Diagnose"].ToString();
                            txtCreationDate.Text = reader["CreationDate"].ToString();
                            txtEndDate.Text = reader["EndDate"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Report not found.");
                        }
                    }


                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)//ADDSFORSALE BUTTON
        {
            try
            {
                List<MedicineInfo> selectedMedicines = new List<MedicineInfo>();

                foreach (DataGridViewRow row in dataGridMedicines.Rows)
                {
                    DataGridViewCheckBoxCell checkBox = row.Cells["SelectColumn"] as DataGridViewCheckBoxCell;

                    if (checkBox != null && checkBox.Value != null && (bool)checkBox.Value)
                    {
                       
                        string medicineId = row.Cells["MedicineID"].Value?.ToString();
                        int requestedQuantity = Convert.ToInt32(row.Cells["Pcs"].Value ?? "0");

                        bool isEligible = false;
                        string errorMessage = string.Empty;

                        // 5.SP çağrısı ile kontrol
                        using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("CheckMedicineReport", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@PatientID", this.patientId); // Hasta ID'sini dinamik alın
                                cmd.Parameters.AddWithValue("@MedicineID", medicineId);
                                cmd.Parameters.AddWithValue("@RequestedPcs", requestedQuantity);

                                cmd.Parameters.Add(new SqlParameter("@IsEligible", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                                cmd.Parameters.Add(new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output });

                                cmd.ExecuteNonQuery();

                                isEligible = Convert.ToBoolean(cmd.Parameters["@IsEligible"].Value);
                                errorMessage = cmd.Parameters["@ErrorMessage"].Value.ToString();
                            }
                        }
                        if (!isEligible)
                        {
                            MessageBox.Show($"İlaç (ID: {medicineId}) satışı reddedildi: {errorMessage}");
                            continue;
                        }

                        

                        string barcode = row.Cells["BarcodeNo"].Value?.ToString();
                        string prescriptionId = row.Cells["PrescriptionID"].Value?.ToString();
                       // string medicineId = row.Cells["MedicineID"].Value?.ToString();
                        int pcs = Convert.ToInt32(row.Cells["Pcs"].Value ?? "0");

                        

                        float totalPrice = 0;
                        float totalPaid = 0;

                        // 4.Stored Procedure çağrısı
                        using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("CalculateMedicineCost", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@MedicineID", medicineId);
                                cmd.Parameters.AddWithValue("@Pcs", pcs);

                                cmd.Parameters.Add(new SqlParameter("@TotalPrice", SqlDbType.Float)
                                {
                                    Direction = ParameterDirection.Output
                                });

                                cmd.Parameters.Add(new SqlParameter("@TotalPaid", SqlDbType.Float)
                                {
                                    Direction = ParameterDirection.Output
                                });

                                cmd.ExecuteNonQuery();

                                totalPrice = Convert.ToSingle(cmd.Parameters["@TotalPrice"].Value);
                                totalPaid = Convert.ToSingle(cmd.Parameters["@TotalPaid"].Value);
                            }
                        }

                        selectedMedicines.Add(new MedicineInfo
                        {
                            Barcode = barcode,
                            PrescriptionID = prescriptionId,
                            MedicineID = medicineId,
                            //Pcs = pcs.ToString(),
                            Pcs = requestedQuantity.ToString(),
                            PublicPrice = totalPrice,
                            PublicPaid = totalPaid
                        });

                        
                    }
                }

                // Seçilen ilaçları Sales formuna gönder
                if (selectedMedicines.Count > 0)
                {
                    if (this.Owner is Sales parentForm)
                    {
                        foreach (var medicine in selectedMedicines)
                        {
                            parentForm.AddMedicineToGrid(medicine); // SP çağırarak hesaplanan ilaçları gönder
                        }

                        MessageBox.Show("Seçilen ilaçlar satışa gönderildi.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Parent form bulunamadı. Lütfen Sales formu üzerinden tekrar deneyin.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen en az bir ilaç seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        public class MedicineInfo
        {
            public string Barcode { get; set; }
            public string PrescriptionID { get; set; }
            public string MedicineID { get; set; }
            public string Pcs { get; set; }
            public float PublicPrice { get; set; }
            public float PublicPaid { get; set; }
        }

       

        
    }

}

