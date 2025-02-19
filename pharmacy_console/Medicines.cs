using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_console
{
    public partial class Medicines : Form
    {
        
        public Medicines()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadMedicineData(txtMedicineInfo.Text.Trim());
            }
        }

        private void LoadMedicineData(string searchText) 
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query;
                    if (searchText == "*")
                    {
                        query = "SELECT MedID, MedicineName, ActiveIngredient, MedicineType, PresicriptionType, IsReport, PublicPrice, PublicPaid FROM dbo.Medicines";
                    }
                    else
                    {
                        query = @"SELECT MedID, MedicineName, ActiveIngredient, MedicineType, PresicriptionType, IsReport, PublicPrice, PublicPaid
                              FROM dbo.Medicines
                              WHERE MedID LIKE @search + '%' OR
                                    MedicineName LIKE @search + '%' OR
                                    ActiveIngredient LIKE @search + '%'";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", searchText);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridMedicines.DataSource = dt;
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
