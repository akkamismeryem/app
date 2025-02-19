namespace pharmacy_console
{
    partial class Prescriptions
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prescriptions));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchID = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.dataGridPrescriptions = new Guna.UI2.WinForms.Guna2DataGridView();
            this.databaseOfPharmacyDataSet1 = new pharmacy_console.DatabaseOfPharmacyDataSet1();
            this.prescriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prescriptionsTableAdapter = new pharmacy_console.DatabaseOfPharmacyDataSet1TableAdapters.PrescriptionsTableAdapter();
            this.medicinesOnPresicriptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicinesOnPresicriptionsTableAdapter = new pharmacy_console.DatabaseOfPharmacyDataSet1TableAdapters.MedicinesOnPresicriptionsTableAdapter();
            this.databaseOfPharmacyDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicinesOnPresicriptionsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPrescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOfPharmacyDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesOnPresicriptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOfPharmacyDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesOnPresicriptionsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(22, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prescription ID";
            // 
            // txtSearchID
            // 
            this.txtSearchID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchID.DefaultText = "";
            this.txtSearchID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchID.Location = new System.Drawing.Point(128, 138);
            this.txtSearchID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchID.Name = "txtSearchID";
            this.txtSearchID.PasswordChar = '\0';
            this.txtSearchID.PlaceholderText = "";
            this.txtSearchID.SelectedText = "";
            this.txtSearchID.Size = new System.Drawing.Size(614, 53);
            this.txtSearchID.TabIndex = 1;
            this.txtSearchID.TextChanged += new System.EventHandler(this.txtSearchID_TextChanged);
            this.txtSearchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guna2TextBox1_KeyDown);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guna2ShadowPanel1.Controls.Add(this.dataGridPrescriptions);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(25, 207);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(929, 366);
            this.guna2ShadowPanel1.TabIndex = 2;
            // 
            // dataGridPrescriptions
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridPrescriptions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPrescriptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridPrescriptions.ColumnHeadersHeight = 20;
            this.dataGridPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridPrescriptions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridPrescriptions.GridColor = System.Drawing.Color.White;
            this.dataGridPrescriptions.Location = new System.Drawing.Point(3, 3);
            this.dataGridPrescriptions.Name = "dataGridPrescriptions";
            this.dataGridPrescriptions.RowHeadersVisible = false;
            this.dataGridPrescriptions.RowHeadersWidth = 51;
            this.dataGridPrescriptions.RowTemplate.Height = 24;
            this.dataGridPrescriptions.Size = new System.Drawing.Size(919, 356);
            this.dataGridPrescriptions.TabIndex = 0;
            this.dataGridPrescriptions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridPrescriptions.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridPrescriptions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridPrescriptions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridPrescriptions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridPrescriptions.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridPrescriptions.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dataGridPrescriptions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridPrescriptions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridPrescriptions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridPrescriptions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridPrescriptions.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridPrescriptions.ThemeStyle.HeaderStyle.Height = 20;
            this.dataGridPrescriptions.ThemeStyle.ReadOnly = false;
            this.dataGridPrescriptions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridPrescriptions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridPrescriptions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridPrescriptions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridPrescriptions.ThemeStyle.RowsStyle.Height = 24;
            this.dataGridPrescriptions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridPrescriptions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // databaseOfPharmacyDataSet1
            // 
            this.databaseOfPharmacyDataSet1.DataSetName = "DatabaseOfPharmacyDataSet1";
            this.databaseOfPharmacyDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prescriptionsBindingSource
            // 
            this.prescriptionsBindingSource.DataMember = "Prescriptions";
            this.prescriptionsBindingSource.DataSource = this.databaseOfPharmacyDataSet1;
            // 
            // prescriptionsTableAdapter
            // 
            this.prescriptionsTableAdapter.ClearBeforeFill = true;
            // 
            // medicinesOnPresicriptionsBindingSource
            // 
            this.medicinesOnPresicriptionsBindingSource.DataMember = "MedicinesOnPresicriptions";
            this.medicinesOnPresicriptionsBindingSource.DataSource = this.databaseOfPharmacyDataSet1;
            // 
            // medicinesOnPresicriptionsTableAdapter
            // 
            this.medicinesOnPresicriptionsTableAdapter.ClearBeforeFill = true;
            // 
            // databaseOfPharmacyDataSet1BindingSource
            // 
            this.databaseOfPharmacyDataSet1BindingSource.DataSource = this.databaseOfPharmacyDataSet1;
            this.databaseOfPharmacyDataSet1BindingSource.Position = 0;
            // 
            // medicinesOnPresicriptionsBindingSource1
            // 
            this.medicinesOnPresicriptionsBindingSource1.DataMember = "MedicinesOnPresicriptions";
            this.medicinesOnPresicriptionsBindingSource1.DataSource = this.databaseOfPharmacyDataSet1BindingSource;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(769, 138);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 50);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Expired Prescriptions";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(52, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Patient ID";
            // 
            // Prescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.txtSearchID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Prescriptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prescriptions";
            this.Load += new System.EventHandler(this.Prescriptions_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPrescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOfPharmacyDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prescriptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesOnPresicriptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOfPharmacyDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesOnPresicriptionsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchID;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridPrescriptions;
        private DatabaseOfPharmacyDataSet1 databaseOfPharmacyDataSet1;
        private System.Windows.Forms.BindingSource prescriptionsBindingSource;
        private DatabaseOfPharmacyDataSet1TableAdapters.PrescriptionsTableAdapter prescriptionsTableAdapter;
        private System.Windows.Forms.BindingSource medicinesOnPresicriptionsBindingSource;
        private DatabaseOfPharmacyDataSet1TableAdapters.MedicinesOnPresicriptionsTableAdapter medicinesOnPresicriptionsTableAdapter;
        private System.Windows.Forms.BindingSource medicinesOnPresicriptionsBindingSource1;
        private System.Windows.Forms.BindingSource databaseOfPharmacyDataSet1BindingSource;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label2;
    }
}