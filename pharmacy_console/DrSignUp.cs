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
    public partial class DrSignUp : Form
    {
        public DrSignUp()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True");
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)//Save butonu
        {
            RegisterDrUser();
            this.Close();
        }
        
        private void RegisterDrUser()
        {
            string userId = txtID.Text.Trim();
            string password = txtPassword.Text.Trim();
           

            try
            {
                conn.Open();

                // 2.Stored Procedure çağırma
                using (SqlCommand cmd = new SqlCommand("sp_RegisterDrWithPhoneCheck", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@DrName", txtDrName.Text.Trim());
                    cmd.Parameters.AddWithValue("@DrSurname", txtDrSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@DrTelephone", txtDrTel.Text.Trim());
                    cmd.Parameters.AddWithValue("@Branch", txtBranch.Text.Trim());
                    cmd.Parameters.AddWithValue("@HospitalName", txtHospital.Text.Trim());

                    cmd.ExecuteNonQuery(); // Prosedürü çalıştır
                }

                

                MessageBox.Show("Saved Successfully!");

                txtID.Text = "";
                txtPassword.Text = "";
                txtDrName.Text = "";
                txtDrSurname.Text = "";
                txtDrTel.Text = "";
                txtBranch.Text = "";
                txtHospital.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void DrSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
