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
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDoctorData(txtDoctorID.Text.Trim());
            }
        }

        private void LoadDoctorData(string doctorID) //ID YAZINCA GRIDE VERİ YÜKLEME
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query;
                    if (doctorID == "*")
                    {
                        query = "SELECT * FROM dbo.Doctors";
                    }
                    else
                    {
                        query = "SELECT * FROM dbo.Doctors WHERE DrID LIKE @id + '%'";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (doctorID != "*")
                        {
                            cmd.Parameters.AddWithValue("@id", doctorID);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Verileri DataGridView'e bağla
                        dataGridDoctors.DataSource = dt;
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
