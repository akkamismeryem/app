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
    public partial class Prescriptions : Form
    {
        public Prescriptions()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPrescriptionData(txtSearchID.Text.Trim());
            }
        }

        private void LoadPrescriptionData(string searchID)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query;
                    if (searchID == "*")
                    {
                        query = "SELECT u.PreID, u.DoctorID, u.PatientID, u.CreationAt, d.BarcodeNo, d.MedicineID, d.Pcs, d.Dose " +
                            "FROM dbo.Prescriptions u " +
                            "INNER JOIN  dbo.MedicinesOnPresicriptions d ON u.PreID = d.PrescriptionID";
                    }
                    else
                    {
                        query = @"SELECT u.PreID, u.DoctorID, u.PatientID, u.CreationAt, d.BarcodeNo, d.MedicineID, d.Pcs, d.Dose 
                                  FROM dbo.Prescriptions u  
                                  INNER JOIN  dbo.MedicinesOnPresicriptions d ON u.PreID = d.PrescriptionID
                                  WHERE PatientID LIKE @search + '%' OR
                                        PreID LIKE @search + '%'";

                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", searchID);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridPrescriptions.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Prescriptions_Load(object sender, EventArgs e)
        {
           

        }

        private void guna2Button1_Click(object sender, EventArgs e)//EXPIRED PRESCRIPTIONS
        {
            ShowExpiredPrescriptions();
        }
        private void ShowExpiredPrescriptions()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT u.PreID, u.DoctorID, u.PatientID, u.CreationAt, " +
                        "d.BarcodeNo, d.MedicineID, d.Pcs, d.Dose " +
                        "FROM ExpiredPrescriptions u " +
                        "INNER JOIN  dbo.MedicinesOnPresicriptions d ON u.PreID = d.PrescriptionID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridPrescriptions.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
