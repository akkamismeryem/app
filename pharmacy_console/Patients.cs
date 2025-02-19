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
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPatientData(txtPatientID.Text.Trim());
            }
        }

        private void LoadPatientData(string patientID) //ID YAZINCA GRIDE VERİ YÜKLEME
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query;
                    if (patientID == "*")
                    {
                        query = "SELECT * FROM dbo.Patients";
                    }
                    else
                    {
                        query = "SELECT * FROM dbo.Patients WHERE PtID LIKE @id + '%'";
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
                        dataGridPatients.DataSource = dt;
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
