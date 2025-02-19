using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pharmacy_console.Form2;

namespace pharmacy_console
{
    public partial class PhForm : Form
    {
        private const int SimdikiWidth = 1380;
        private const int SimdikiHeight = 768;
        


        public string UserID { get; set; }
        //public bool medicines { get; private set; }

        public PhForm()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }

        private void PhForm_Load(object sender, EventArgs e)
        {
            SetFormSizeAndPosition();
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
            PhProfile phProfile = new PhProfile()
            {
                UserID = this.UserID // Login'den gelen ID'yi gönderiyoruz
            };
            phProfile.ShowDialog();
        }

        private void menuPrescrictions_Click(object sender, EventArgs e)
        {
            Prescriptions prescriptions = new Prescriptions();
            prescriptions.ShowDialog();
        }

        private void menuReports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void menuMedicines_Click(object sender, EventArgs e)
        {
            Medicines medicines = new Medicines();
            medicines.ShowDialog();
        }

        private void menuPatients_Click(object sender, EventArgs e)
        {
            Patients patients = new Patients();
            patients.ShowDialog();
        }

        private void menuDoctors_Click(object sender, EventArgs e)
        {
            Doctors doctors = new Doctors();
            doctors.ShowDialog();
        }

        private void menuSales_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales() 
            {
                
                UserID = this.UserID // Login'den gelen ID'yi gönderiyoruz
            
            };
            sales.ShowDialog();
        }

        private void menuInvoince_Click(object sender, EventArgs e)
        {
            Invoince invoince = new Invoince();
            invoince.ShowDialog();
        }

        private void menuStock_Click(object sender, EventArgs e)
        {
            StockInfo stockInfo = new StockInfo();
            stockInfo.ShowDialog();
        }

        private void menuCAS_Click(object sender, EventArgs e)
        {
            CAS cas = new CAS();
            cas.ShowDialog();
        }
    }
}
