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
    public partial class PhProfile : Form
    {
        public string UserID { get; set; }
        public PhProfile()
        {
            InitializeComponent();
        }

        private void PhProfile_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserID))
            {
                MessageBox.Show("User ID is not provided.");
                this.Close();
                return;
            }
            ProfilInfoOnScreen();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                                UPDATE dbo.Pharmacists
                                SET PhName = @name, 
                                PhSurname = @surname, 
                                PhTelephone = @telephone, 
                                PharmacyName = @pharmacy
                                WHERE PhID = @id";
                    using (SqlCommand cmd = new SqlCommand(updateDoctorsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                        cmd.Parameters.AddWithValue("@telephone", txtTel.Text);
                        cmd.Parameters.AddWithValue("@pharmacy", txtPharmacy.Text);
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
                    string query = "SELECT u.ID, u.Password, p.PhName, p.PhSurname, p.PhTelephone, p.PharmacyName FROM dbo.Users u " +
                        "INNER JOIN dbo.Pharmacists p ON u.ID = p.PhID WHERE u.ID = @c1";

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
                            txtName.Text = reader["PhName"].ToString();
                            txtSurname.Text = reader["PhSurname"].ToString();
                            txtTel.Text = reader["PhTelephone"].ToString();
                            txtPharmacy.Text = reader["PharmacyName"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Pharmacist profile not found.");
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
