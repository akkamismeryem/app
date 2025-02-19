using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_console
{
    public partial class PhSignUp : Form
    {
        public PhSignUp()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True");

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegisterPhUser();
            this.Close();
        }

        private void RegisterPhUser()
        {
            string userId = txtID.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                conn.Open();

                // 1.Stored Procedure çağırma
                using (SqlCommand cmd = new SqlCommand("sp_RegisterPhWithPhoneCheck", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@PhName", txtPhName.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhSurname", txtPhSurname.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhTelephone", txtPhTel.Text.Trim());
                    cmd.Parameters.AddWithValue("@PharmacyName", txtPharmacy.Text.Trim());

                    cmd.ExecuteNonQuery(); // Prosedürü çalıştır
                }

                MessageBox.Show("Saved Successfully!");

                txtID.Text = "";
                txtPassword.Text = "";
                txtPhName.Text = "";
                txtPhSurname.Text = "";
                txtPhTel.Text = "";
                txtPharmacy.Text = "";
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

         
 

        private void PhSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
