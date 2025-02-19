namespace pharmacy_console
{
    partial class PhForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPrescriptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedicines = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoctors = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSales = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInvoince = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCAS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrescriptions,
            this.menuReports,
            this.menuMedicines,
            this.menuPatients,
            this.menuDoctors,
            this.menuSales,
            this.menuInvoince,
            this.menuStock,
            this.menuCAS,
            this.menuProfile,
            this.menuLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1380, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuPrescriptions
            // 
            this.menuPrescriptions.Image = ((System.Drawing.Image)(resources.GetObject("menuPrescriptions.Image")));
            this.menuPrescriptions.Name = "menuPrescriptions";
            this.menuPrescriptions.Size = new System.Drawing.Size(142, 39);
            this.menuPrescriptions.Text = "Prescriptions";
            this.menuPrescriptions.Click += new System.EventHandler(this.menuPrescrictions_Click);
            // 
            // menuReports
            // 
            this.menuReports.Image = ((System.Drawing.Image)(resources.GetObject("menuReports.Image")));
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(94, 24);
            this.menuReports.Text = "Reports";
            this.menuReports.Click += new System.EventHandler(this.menuReports_Click);
            // 
            // menuMedicines
            // 
            this.menuMedicines.Image = ((System.Drawing.Image)(resources.GetObject("menuMedicines.Image")));
            this.menuMedicines.Name = "menuMedicines";
            this.menuMedicines.Size = new System.Drawing.Size(110, 24);
            this.menuMedicines.Text = "Medicines";
            this.menuMedicines.Click += new System.EventHandler(this.menuMedicines_Click);
            // 
            // menuPatients
            // 
            this.menuPatients.Image = ((System.Drawing.Image)(resources.GetObject("menuPatients.Image")));
            this.menuPatients.Name = "menuPatients";
            this.menuPatients.Size = new System.Drawing.Size(94, 24);
            this.menuPatients.Text = "Patients";
            this.menuPatients.Click += new System.EventHandler(this.menuPatients_Click);
            // 
            // menuDoctors
            // 
            this.menuDoctors.Image = ((System.Drawing.Image)(resources.GetObject("menuDoctors.Image")));
            this.menuDoctors.Name = "menuDoctors";
            this.menuDoctors.Size = new System.Drawing.Size(95, 24);
            this.menuDoctors.Text = "Doctors";
            this.menuDoctors.Click += new System.EventHandler(this.menuDoctors_Click);
            // 
            // menuSales
            // 
            this.menuSales.Image = ((System.Drawing.Image)(resources.GetObject("menuSales.Image")));
            this.menuSales.Name = "menuSales";
            this.menuSales.Size = new System.Drawing.Size(77, 24);
            this.menuSales.Text = "Sales";
            this.menuSales.Click += new System.EventHandler(this.menuSales_Click);
            // 
            // menuInvoince
            // 
            this.menuInvoince.Image = ((System.Drawing.Image)(resources.GetObject("menuInvoince.Image")));
            this.menuInvoince.Name = "menuInvoince";
            this.menuInvoince.Size = new System.Drawing.Size(112, 24);
            this.menuInvoince.Text = "E-Invoince";
            this.menuInvoince.Click += new System.EventHandler(this.menuInvoince_Click);
            // 
            // menuStock
            // 
            this.menuStock.Image = ((System.Drawing.Image)(resources.GetObject("menuStock.Image")));
            this.menuStock.Name = "menuStock";
            this.menuStock.Size = new System.Drawing.Size(109, 24);
            this.menuStock.Text = "Stock Info";
            this.menuStock.Click += new System.EventHandler(this.menuStock_Click);
            // 
            // menuCAS
            // 
            this.menuCAS.Image = ((System.Drawing.Image)(resources.GetObject("menuCAS.Image")));
            this.menuCAS.Name = "menuCAS";
            this.menuCAS.Size = new System.Drawing.Size(70, 24);
            this.menuCAS.Text = "CAS";
            this.menuCAS.Click += new System.EventHandler(this.menuCAS_Click);
            // 
            // menuProfile
            // 
            this.menuProfile.Image = ((System.Drawing.Image)(resources.GetObject("menuProfile.Image")));
            this.menuProfile.Name = "menuProfile";
            this.menuProfile.Size = new System.Drawing.Size(86, 24);
            this.menuProfile.Text = "Profile";
            this.menuProfile.Click += new System.EventHandler(this.menuProfile_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Image = ((System.Drawing.Image)(resources.GetObject("menuLogout.Image")));
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(96, 24);
            this.menuLogout.Text = "Log Out";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // PhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 768);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PhForm";
            this.Text = "PhForm";
            this.Load += new System.EventHandler(this.PhForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPrescriptions;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.ToolStripMenuItem menuMedicines;
        private System.Windows.Forms.ToolStripMenuItem menuPatients;
        private System.Windows.Forms.ToolStripMenuItem menuDoctors;
        private System.Windows.Forms.ToolStripMenuItem menuSales;
        private System.Windows.Forms.ToolStripMenuItem menuStock;
        private System.Windows.Forms.ToolStripMenuItem menuInvoince;
        private System.Windows.Forms.ToolStripMenuItem menuCAS;
        private System.Windows.Forms.ToolStripMenuItem menuProfile;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
    }
}