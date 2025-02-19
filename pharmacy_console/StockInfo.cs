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
    public partial class StockInfo : Form
    {
        public StockInfo()
        {
            InitializeComponent();
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
                        query = "SELECT * FROM dbo.Medicines";
                    }
                    else
                    {
                        query = @"SELECT *
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

        private void guna2Button1_Click(object sender, EventArgs e)//DOWNWARD BUTTON
        {
            try
            {
                // Az stoğu olan ilaçları en üste sıralar (küçükten büyüğe)
                (dataGridMedicines.DataSource as DataTable).DefaultView.Sort = "StockAmount ASC";
                // Filtreyi temizle
                (dataGridMedicines.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            
        }

        private void btnUpward_Click(object sender, EventArgs e)
        {
            try
            {
                // Çok stoğu olan ilaçları en üste sıralar (büyükten küçüğe)
                (dataGridMedicines.DataSource as DataTable).DefaultView.Sort = "StockAmount DESC";
                // Filtreyi temizle
                (dataGridMedicines.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnNoStock_Click(object sender, EventArgs e)
        {
            try
            {
                // Stoğu 0 olanları filtrele
                (dataGridMedicines.DataSource as DataTable).DefaultView.RowFilter = "StockAmount = 0";
                // Filtreyi temizle
                (dataGridMedicines.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

        private void btnAddStock_Click(object sender, EventArgs e)// ilaç
        {
            AddStock addStock = new AddStock();
            addStock.ShowDialog();
        }
    }
}
