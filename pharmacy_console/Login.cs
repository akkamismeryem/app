using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_console
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True");
        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            string userType = radioButton3.Checked ? "Doctor" : "Pharmacist"; // Kullanıcı tipi (doktor / eczacı)
            if (userType == "Doctor")
            {
                DrSignUp drSignUp = new DrSignUp();
                drSignUp.ShowDialog();
            }
            else if (userType == "Pharmacist")
            {
                PhSignUp phSignUp = new PhSignUp(); 
                phSignUp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please specify your user type");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginInfo();
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginInfo()
        {
            string userID = txtID.Text.Trim();
            string password = txtPassword.Text.Trim();
            string userType = radioButton1.Checked ? "Doctor" : "Pharmacist";

            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both ID and Password.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT ID, Type FROM dbo.Users WHERE ID = @id AND Password = @password AND Type = @type";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userID);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@type", userType);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            string loggedInID = reader["ID"].ToString();
                            string loggedInType = reader["Type"].ToString();

                            reader.Close();

                            this.Hide(); // Login formunu gizle

                            if (loggedInType == "Doctor")
                            {
                                DrForm drForm = new DrForm
                                {
                                    UserID = loggedInID // Kullanıcı ID'sini gönderiyoruz
                                };
                                drForm.ShowDialog();
                            }
                            else if (loggedInType == "Pharmacist")
                            {
                                PhForm phForm = new PhForm
                                {
                                    UserID = loggedInID
                                };
                                phForm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid ID, Password, or User Type.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginInfo();
            }
        }
    }
}
