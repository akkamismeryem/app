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
    public partial class WhitePrescriptions : Form
    {
        public WhitePrescriptions()
        {
            InitializeComponent();
        }

        private void InitializeDataGridViewColumns()
        {
            // Checkbox Kolonu
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Name = "SelectColumn"
            };
            dataGridWhiteMedicines.Columns.Add(checkBoxColumn);

            // İlaç Bilgisi Butonu
            DataGridViewButtonColumn medicineInfoButton = new DataGridViewButtonColumn
            {
                HeaderText = "Medicine Info",
                Text = "Info",
                UseColumnTextForButtonValue = true,
                Name = "MedicineInfoButton"
            };
            dataGridWhiteMedicines.Columns.Add(medicineInfoButton);


            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Pcs",
                Name = "PcsColumn"
            };
            dataGridWhiteMedicines.Columns.Add(textBoxColumn);
        }

        private void dataGridWhiteMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // İlaç Bilgisi Butonuna tıklanırsa
            if (e.ColumnIndex == dataGridWhiteMedicines.Columns["MedicineInfoButton"].Index && e.RowIndex >= 0)
            {
                string medicineId = dataGridWhiteMedicines.Rows[e.RowIndex].Cells["MedID"].Value.ToString();
                ShowMedicineInfo(medicineId); // İlaç bilgisi göster
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

        private void WhitePrescriptions_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewColumns();
            LoadWhitePrescriptionMedicines();
        }

        private void LoadWhitePrescriptionMedicines()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.GetWhitePrescriptionMedicines();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridWhiteMedicines.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AddForSaleWhite_Click(object sender, EventArgs e)
        {
            try
            {
                List<MedicineInfo> selectedMedicines = new List<MedicineInfo>();

                foreach (DataGridViewRow row in dataGridWhiteMedicines.Rows)
                {
                    DataGridViewCheckBoxCell checkBox = row.Cells["SelectColumn"] as DataGridViewCheckBoxCell;

                    if (checkBox != null && checkBox.Value != null && (bool)checkBox.Value)
                    {
                        
                        string medicineId = row.Cells["MedID"].Value?.ToString();
                        int pcs = Convert.ToInt32(row.Cells["PcsColumn"].Value ?? "0");

                        float totalPrice = 0;
                        float totalPaid = 0;

                        // 2. SQL Function çağrısı ile fiyat hesaplama
                        using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                        {
                            conn.Open();
                            string query = "SELECT * FROM dbo.CalculateWhitePrescriptionCost(@MedicineID, @Quantity);";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MedicineID", medicineId);
                                cmd.Parameters.AddWithValue("@Quantity", pcs);

                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    totalPrice = Convert.ToSingle(reader["TotalPublicPrice"]);
                                    totalPaid = Convert.ToSingle(reader["TotalPublicPaid"]);
                                }
                            }
                        }

                        selectedMedicines.Add(new MedicineInfo
                        {
                            MedicineID = medicineId,
                            Pcs = pcs.ToString(),
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

    }
}
