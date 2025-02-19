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
    public partial class CAS : Form
    {
        public CAS()
        {
            InitializeComponent();
        }

        

        private void CAS_Load(object sender, EventArgs e)
        {
            
            LoadCASTable();
        }

        private void LoadCASTable()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT * FROM CAS"; // CAS tablosunu sorgula

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridCAS1.DataSource = dt; // DataGridView'e bağla
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dataGridCAS1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
