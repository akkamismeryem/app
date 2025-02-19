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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadReportData(txtPatientID.Text.Trim());
            }
        }

        private void LoadReportData(string patientID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query;
                    if (patientID == "*")
                    {
                        query = "SELECT * FROM dbo.Reports";
                    }
                    else
                    {
                        query = "SELECT * FROM dbo.Reports WHERE PatientID LIKE @id + '%'";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (patientID != "*")
                        {
                            cmd.Parameters.AddWithValue("@id", patientID);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Verileri DataGridView'e bağla
                        dataGridReports.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)//EXPIRED REPORTS
        {
            ShowExpiredReports();
        }
        private void ShowExpiredReports()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT * FROM ExpiredReports";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        //SqlDataReader reader = cmd.ExecuteReader();

                        // DataGridView veya ListBox gibi bir kontrolle raporları gösterin
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Verileri DataGridView'e bağla
                        dataGridReports.DataSource = dt;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
