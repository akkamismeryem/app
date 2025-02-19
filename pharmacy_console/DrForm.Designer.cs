namespace pharmacy_console
{
    partial class DrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCreatePrescription = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreatePrescription1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrescriptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateReport1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMedicines = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPatients = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreatePrescription,
            this.menuCreateReport,
            this.menuMedicines,
            this.menuPatients,
            this.menuProfile,
            this.menuLogout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1380, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCreatePrescription
            // 
            this.menuCreatePrescription.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreatePrescription1,
            this.menuPrescriptions});
            this.menuCreatePrescription.Image = ((System.Drawing.Image)(resources.GetObject("menuCreatePrescription.Image")));
            this.menuCreatePrescription.Name = "menuCreatePrescription";
            this.menuCreatePrescription.Size = new System.Drawing.Size(183, 39);
            this.menuCreatePrescription.Text = "Create Prescription";
            // 
            // menuCreatePrescription1
            // 
            this.menuCreatePrescription1.Name = "menuCreatePrescription1";
            this.menuCreatePrescription1.Size = new System.Drawing.Size(224, 26);
            this.menuCreatePrescription1.Text = "Create ";
            this.menuCreatePrescription1.Click += new System.EventHandler(this.menuCreatePrescription1_Click);
            // 
            // menuPrescriptions
            // 
            this.menuPrescriptions.Name = "menuPrescriptions";
            this.menuPrescriptions.Size = new System.Drawing.Size(224, 26);
            this.menuPrescriptions.Text = "Prescriptions";
            this.menuPrescriptions.Click += new System.EventHandler(this.menuPrescriptions_Click);
            // 
            // menuCreateReport
            // 
            this.menuCreateReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreateReport1,
            this.menuReports});
            this.menuCreateReport.Image = ((System.Drawing.Image)(resources.GetObject("menuCreateReport.Image")));
            this.menuCreateReport.Name = "menuCreateReport";
            this.menuCreateReport.Size = new System.Drawing.Size(150, 39);
            this.menuCreateReport.Text = "Create Report";
            // 
            // menuCreateReport1
            // 
            this.menuCreateReport1.Name = "menuCreateReport1";
            this.menuCreateReport1.Size = new System.Drawing.Size(224, 26);
            this.menuCreateReport1.Text = "Create";
            this.menuCreateReport1.Click += new System.EventHandler(this.menuCreateReport1_Click);
            // 
            // menuReports
            // 
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(224, 26);
            this.menuReports.Text = "Reports";
            this.menuReports.Click += new System.EventHandler(this.menuReports_Click);
            // 
            // menuMedicines
            // 
            this.menuMedicines.Image = ((System.Drawing.Image)(resources.GetObject("menuMedicines.Image")));
            this.menuMedicines.Name = "menuMedicines";
            this.menuMedicines.Size = new System.Drawing.Size(125, 39);
            this.menuMedicines.Text = "Medicines";
            this.menuMedicines.Click += new System.EventHandler(this.menuMedicines_Click);
            // 
            // menuPatients
            // 
            this.menuPatients.Image = ((System.Drawing.Image)(resources.GetObject("menuPatients.Image")));
            this.menuPatients.Name = "menuPatients";
            this.menuPatients.Size = new System.Drawing.Size(109, 39);
            this.menuPatients.Text = "Patients";
            this.menuPatients.Click += new System.EventHandler(this.menuPatients_Click);
            // 
            // menuProfile
            // 
            this.menuProfile.Image = ((System.Drawing.Image)(resources.GetObject("menuProfile.Image")));
            this.menuProfile.Name = "menuProfile";
            this.menuProfile.Size = new System.Drawing.Size(101, 39);
            this.menuProfile.Text = "Profile";
            this.menuProfile.Click += new System.EventHandler(this.menuProfile_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Image = ((System.Drawing.Image)(resources.GetObject("menuLogout.Image")));
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(111, 39);
            this.menuLogout.Text = "Log Out";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // DrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 768);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DrForm";
            this.Text = "DrForm";
            this.Load += new System.EventHandler(this.DrForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCreatePrescription;
        private System.Windows.Forms.ToolStripMenuItem menuCreatePrescription1;
        private System.Windows.Forms.ToolStripMenuItem menuPrescriptions;
        private System.Windows.Forms.ToolStripMenuItem menuCreateReport;
        private System.Windows.Forms.ToolStripMenuItem menuMedicines;
        private System.Windows.Forms.ToolStripMenuItem menuPatients;
        private System.Windows.Forms.ToolStripMenuItem menuProfile;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuCreateReport1;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
    }
}