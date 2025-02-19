using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_console
{
    public partial class CreatePrescription : Form
    {
        public string UserID { get; set; }
        public CreatePrescription()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True");
        private void guna2Button1_Click(object sender, EventArgs e)//save button
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    // Reçete bilgilerini kaydet
                    string insertPrescriptionQuery = @"
                                                    INSERT INTO Prescriptions (DoctorID, PatientID, CreationAt) 
                                                    OUTPUT INSERTED.PreID 
                                                    VALUES (@DoctorID, @PatientID, @CreationAt)";

                    int preID;
                    using (SqlCommand cmd = new SqlCommand(insertPrescriptionQuery, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@DoctorID", txtDoctorID.Text.Trim());
                        
                        cmd.Parameters.AddWithValue("@PatientID", txtPatientID.Text.Trim());
                        cmd.Parameters.AddWithValue("@CreationAt", dateTimeCreate.Value);
                        preID = Convert.ToInt32(cmd.ExecuteScalar()); // PreID alınıyor
                        
                    }

                    // İlaç bilgilerini kaydet
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string insertMedicineQuery = @"
                                                     INSERT INTO MedicinesOnPresicriptions (PrescriptionID, MedicineID, Pcs, Dose) 
                                                     VALUES (@PreID, @MedicineID, @Pcs, @Dose)";

                        using (SqlCommand medicineCmd = new SqlCommand(insertMedicineQuery, conn))
                        {
                            medicineCmd.Parameters.AddWithValue("@PreID", preID);
                            medicineCmd.Parameters.AddWithValue("@MedicineID", row.Cells["txtMedicineID"].Value ?? DBNull.Value);
                            medicineCmd.Parameters.AddWithValue("@Pcs", row.Cells["cmbPcs"].Value ?? DBNull.Value);
                            medicineCmd.Parameters.AddWithValue("@Dose", row.Cells["cmbDose"].Value ?? DBNull.Value);
                            medicineCmd.ExecuteNonQuery();
                        }
                    }

                    // Reçete oluşturulduktan sonra DataGridView'i güncelle
                    LoadPrescriptionsForDoctor();
                }

                MessageBox.Show("Prescription saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnAdd"].Index)
            {
                // Satır ekleme işlemi
                dataGridView1.Rows.Add();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["btnRemove"].Index)
            {
                // Satır silme işlemi
                if (e.RowIndex >= 0)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void CreatePrescription_Load(object sender, EventArgs e)
        {
            LoadPrescriptionsForDoctor();
        }

        private void LoadPrescriptionsForDoctor()
        {
            try
            {
                conn.Open();

                // 3.Saklı prosedür çağrılıyor
                SqlCommand cmd = new SqlCommand("GetPrescriptionsByDoctor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorID", UserID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // DataGridView'e verileri doldur
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
    }
    
}
