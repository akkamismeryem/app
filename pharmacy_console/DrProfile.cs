using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_console
{
    public partial class DrProfile : Form
    {
        public string UserID { get; set; }
        public DrProfile()
        {
            InitializeComponent();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void DrProfile_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserID))
            {
                MessageBox.Show("User ID is not provided.");
                this.Close();
                return;
            }
            ProfilInfoOnScreen();
        }
     
        private void guna2Button1_Click(object sender, EventArgs e)//DRPROFILE SAVE BUTTON//PROFILE INFO UPDATE
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string updateUsersQuery = @"
                                UPDATE dbo.Users
                                SET Password=@password
                                WHERE ID=@id";
                    using (SqlCommand cmd = new SqlCommand(updateUsersQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.ExecuteNonQuery();
                    }
                    string updateDoctorsQuery = @"
                                UPDATE dbo.Doctors
                                SET DrName = @name, 
                                DrSurname = @surname, 
                                DrTelephone = @telephone, 
                                Branch = @branch, 
                                HospitalName = @hospital
                                WHERE DrID = @id";
                    using (SqlCommand cmd = new SqlCommand(updateDoctorsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                        cmd.Parameters.AddWithValue("@telephone", txtTel.Text);
                        cmd.Parameters.AddWithValue("@branch", txtBranch.Text);
                        cmd.Parameters.AddWithValue("@hospital", txtHospitalName.Text);
                        cmd.Parameters.AddWithValue("@id", txtID.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Profile updated successfully!");
                    ProfilInfoOnScreen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ProfilInfoOnScreen()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT u.ID, u.Password, d.DrName, d.DrSurname, d.DrTelephone, d.Branch, d.HospitalName FROM dbo.Users u " +
                        "INNER JOIN dbo.Doctors d ON u.ID = d.DrID WHERE u.ID = @c1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@c1", UserID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            // Formdaki textBoxlara bilgileri yazdır
                            txtID.Text = reader["ID"].ToString();
                            txtPassword.Text = reader["Password"].ToString();
                            txtName.Text = reader["DrName"].ToString();
                            txtSurname.Text = reader["DrSurname"].ToString();
                            txtTel.Text = reader["DrTelephone"].ToString();
                            txtBranch.Text = reader["Branch"].ToString();
                            txtHospitalName.Text = reader["HospitalName"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Doctor profile not found.");
                        }
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

