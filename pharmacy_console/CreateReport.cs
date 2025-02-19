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
    public partial class CreateReport : Form
    {
        public CreateReport()
        {
            InitializeComponent();
        }

        private void CreateReport_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)//Report save button
        {
            ReportSave();
        }

        private void ReportSave()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();

                    string query = @"
                INSERT INTO Reports (DoctorID, PatientID, MedicineID, Pcs, Dose, Diagnose, CreationDate, EndDate)
                VALUES (@doctorID, @patientID, @medicineID, @pcs, @dose, @diagnose, @creationDate, @endDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Parametreleri ekle
                        cmd.Parameters.AddWithValue("@doctorID", txtDrID.Text);
                        cmd.Parameters.AddWithValue("@patientID", txtPtID.Text);
                        cmd.Parameters.AddWithValue("@medicineID", txtMedicineID.Text);
                        cmd.Parameters.AddWithValue("@pcs", cmbPcs.Text);
                        cmd.Parameters.AddWithValue("@dose", cmbDose.Text);
                        cmd.Parameters.AddWithValue("@diagnose", txtDiagnose.Text);
                        cmd.Parameters.AddWithValue("@creationDate", dateTimeCreation.Value);
                        cmd.Parameters.AddWithValue("@endDate", dateTimeEnd.Value);

                        // Sorguyu çalıştır
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Report created successfully!");

                        
                        
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
