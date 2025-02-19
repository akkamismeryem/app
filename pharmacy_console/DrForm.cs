using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacy_console
{
    public partial class DrForm : Form
    {
        private const int SimdikiWidth = 1380;
        private const int SimdikiHeight = 768;

        public string UserID { get; set; }



        public DrForm()
        {
            InitializeComponent();
        }

        private void DrForm_Load(object sender, EventArgs e)
        {
            SetFormSizeAndPosition();
            //lblWelcome.Text = $"Welcome, Doctor {UserID}";
        }
        private void SetFormSizeAndPosition()
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            Rectangle clientResolution = Screen.GetBounds(Rectangle.Empty);
            float widthRatio = (float)clientResolution.Width / SimdikiWidth;
            float heightRatio = (float)clientResolution.Height / SimdikiHeight;

            this.Scale(new SizeF(widthRatio, heightRatio));
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuProfile_Click(object sender, EventArgs e)
        {
            // Kullanıcı profilini aç
            DrProfile drProfile = new DrProfile
            {
                UserID = this.UserID // Login'den gelen ID'yi gönderiyoruz
            };
            drProfile.ShowDialog();
        }

        private void menuPatients_Click(object sender, EventArgs e)
        {
            Patients patients = new Patients();
            patients.ShowDialog();
        }

        private void menuMedicines_Click(object sender, EventArgs e)
        {
            Medicines medicines = new Medicines();
            medicines.ShowDialog(); 
        }

        private void menuCreateReport1_Click(object sender, EventArgs e)
        {
            CreateReport createReport = new CreateReport();
            createReport.ShowDialog();
        }

        private void menuReports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void menuCreatePrescription1_Click(object sender, EventArgs e)
        {
            CreatePrescription createPrescription = new CreatePrescription 
            {
                UserID = this.UserID // Login'den gelen ID'yi gönderiyoruz
            };
            createPrescription.ShowDialog();
        }

        private void menuPrescriptions_Click(object sender, EventArgs e)
        {
            Prescriptions prescriptions = new Prescriptions();
            prescriptions.ShowDialog();
        }
    }
}
