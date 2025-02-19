namespace pharmacy_console
{
    partial class AddStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStock));
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.dataGridUpdateMedicines = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ShadowPanel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.txtIsReport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtMedID = new System.Windows.Forms.TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.txtStockAmount = new System.Windows.Forms.TextBox();
            this.txtPublicPaid = new System.Windows.Forms.TextBox();
            this.txtPublicPrice = new System.Windows.Forms.TextBox();
            this.txtPrescriptionType = new System.Windows.Forms.TextBox();
            this.txtMedicineType = new System.Windows.Forms.TextBox();
            this.txtActiveIngredient = new System.Windows.Forms.TextBox();
            this.txtMedicineName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseOfPharmacyDataSet1 = new pharmacy_console.DatabaseOfPharmacyDataSet1();
            this.medicinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicinesTableAdapter = new pharmacy_console.DatabaseOfPharmacyDataSet1TableAdapters.MedicinesTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpdateMedicines)).BeginInit();
            this.guna2ShadowPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOfPharmacyDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guna2ShadowPanel2.Controls.Add(this.dataGridUpdateMedicines);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(25, 302);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(935, 302);
            this.guna2ShadowPanel2.TabIndex = 1;
            // 
            // dataGridUpdateMedicines
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridUpdateMedicines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridUpdateMedicines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridUpdateMedicines.ColumnHeadersHeight = 25;
            this.dataGridUpdateMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridUpdateMedicines.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridUpdateMedicines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridUpdateMedicines.Location = new System.Drawing.Point(6, 3);
            this.dataGridUpdateMedicines.Name = "dataGridUpdateMedicines";
            this.dataGridUpdateMedicines.RowHeadersVisible = false;
            this.dataGridUpdateMedicines.RowHeadersWidth = 51;
            this.dataGridUpdateMedicines.RowTemplate.Height = 24;
            this.dataGridUpdateMedicines.Size = new System.Drawing.Size(922, 291);
            this.dataGridUpdateMedicines.TabIndex = 0;
            this.dataGridUpdateMedicines.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridUpdateMedicines.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridUpdateMedicines.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridUpdateMedicines.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridUpdateMedicines.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridUpdateMedicines.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridUpdateMedicines.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridUpdateMedicines.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridUpdateMedicines.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridUpdateMedicines.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridUpdateMedicines.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridUpdateMedicines.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridUpdateMedicines.ThemeStyle.HeaderStyle.Height = 25;
            this.dataGridUpdateMedicines.ThemeStyle.ReadOnly = false;
            this.dataGridUpdateMedicines.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridUpdateMedicines.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridUpdateMedicines.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridUpdateMedicines.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridUpdateMedicines.ThemeStyle.RowsStyle.Height = 24;
            this.dataGridUpdateMedicines.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridUpdateMedicines.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridUpdateMedicines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUpdateMedicines_CellContentClick);
            // 
            // guna2ShadowPanel3
            // 
            this.guna2ShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guna2ShadowPanel3.Controls.Add(this.txtIsReport);
            this.guna2ShadowPanel3.Controls.Add(this.label1);
            this.guna2ShadowPanel3.Controls.Add(this.textBox1);
            this.guna2ShadowPanel3.Controls.Add(this.txtMedID);
            this.guna2ShadowPanel3.Controls.Add(this.guna2Button1);
            this.guna2ShadowPanel3.Controls.Add(this.txtStockAmount);
            this.guna2ShadowPanel3.Controls.Add(this.txtPublicPaid);
            this.guna2ShadowPanel3.Controls.Add(this.txtPublicPrice);
            this.guna2ShadowPanel3.Controls.Add(this.txtPrescriptionType);
            this.guna2ShadowPanel3.Controls.Add(this.txtMedicineType);
            this.guna2ShadowPanel3.Controls.Add(this.txtActiveIngredient);
            this.guna2ShadowPanel3.Controls.Add(this.txtMedicineName);
            this.guna2ShadowPanel3.Controls.Add(this.label9);
            this.guna2ShadowPanel3.Controls.Add(this.label8);
            this.guna2ShadowPanel3.Controls.Add(this.label7);
            this.guna2ShadowPanel3.Controls.Add(this.label6);
            this.guna2ShadowPanel3.Controls.Add(this.label5);
            this.guna2ShadowPanel3.Controls.Add(this.label4);
            this.guna2ShadowPanel3.Controls.Add(this.label2);
            this.guna2ShadowPanel3.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel3.Location = new System.Drawing.Point(207, 25);
            this.guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            this.guna2ShadowPanel3.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel3.Size = new System.Drawing.Size(568, 239);
            this.guna2ShadowPanel3.TabIndex = 3;
            // 
            // txtIsReport
            // 
            this.txtIsReport.AutoSize = true;
            this.txtIsReport.Location = new System.Drawing.Point(429, 23);
            this.txtIsReport.Name = "txtIsReport";
            this.txtIsReport.Size = new System.Drawing.Size(61, 16);
            this.txtIsReport.TabIndex = 20;
            this.txtIsReport.Text = "Is Report";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Medicine ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(409, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 18;
            // 
            // txtMedID
            // 
            this.txtMedID.Location = new System.Drawing.Point(267, 42);
            this.txtMedID.Name = "txtMedID";
            this.txtMedID.Size = new System.Drawing.Size(100, 22);
            this.txtMedID.TabIndex = 17;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(310, 165);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 16;
            this.guna2Button1.Text = "Add ";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // txtStockAmount
            // 
            this.txtStockAmount.Location = new System.Drawing.Point(267, 122);
            this.txtStockAmount.Name = "txtStockAmount";
            this.txtStockAmount.Size = new System.Drawing.Size(100, 22);
            this.txtStockAmount.TabIndex = 15;
            // 
            // txtPublicPaid
            // 
            this.txtPublicPaid.Location = new System.Drawing.Point(126, 174);
            this.txtPublicPaid.Name = "txtPublicPaid";
            this.txtPublicPaid.Size = new System.Drawing.Size(100, 22);
            this.txtPublicPaid.TabIndex = 14;
            // 
            // txtPublicPrice
            // 
            this.txtPublicPrice.Location = new System.Drawing.Point(126, 136);
            this.txtPublicPrice.Name = "txtPublicPrice";
            this.txtPublicPrice.Size = new System.Drawing.Size(100, 22);
            this.txtPublicPrice.TabIndex = 13;
            // 
            // txtPrescriptionType
            // 
            this.txtPrescriptionType.Location = new System.Drawing.Point(409, 119);
            this.txtPrescriptionType.Name = "txtPrescriptionType";
            this.txtPrescriptionType.Size = new System.Drawing.Size(100, 22);
            this.txtPrescriptionType.TabIndex = 12;
            // 
            // txtMedicineType
            // 
            this.txtMedicineType.Location = new System.Drawing.Point(126, 97);
            this.txtMedicineType.Name = "txtMedicineType";
            this.txtMedicineType.Size = new System.Drawing.Size(100, 22);
            this.txtMedicineType.TabIndex = 11;
            // 
            // txtActiveIngredient
            // 
            this.txtActiveIngredient.Location = new System.Drawing.Point(126, 58);
            this.txtActiveIngredient.Name = "txtActiveIngredient";
            this.txtActiveIngredient.Size = new System.Drawing.Size(100, 22);
            this.txtActiveIngredient.TabIndex = 10;
            // 
            // txtMedicineName
            // 
            this.txtMedicineName.Location = new System.Drawing.Point(126, 23);
            this.txtMedicineName.Name = "txtMedicineName";
            this.txtMedicineName.Size = new System.Drawing.Size(100, 22);
            this.txtMedicineName.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Stock Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Public Paid";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Public Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(406, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Prescription Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Medicine Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Active Ingredient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Medicine Name";
            // 
            // databaseOfPharmacyDataSet1
            // 
            this.databaseOfPharmacyDataSet1.DataSetName = "DatabaseOfPharmacyDataSet1";
            this.databaseOfPharmacyDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // medicinesBindingSource
            // 
            this.medicinesBindingSource.DataMember = "Medicines";
            this.medicinesBindingSource.DataSource = this.databaseOfPharmacyDataSet1;
            // 
            // medicinesTableAdapter
            // 
            this.medicinesTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Medicines";
            // 
            // AddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2ShadowPanel3);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddStock";
            this.guna2ShadowPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUpdateMedicines)).EndInit();
            this.guna2ShadowPanel3.ResumeLayout(false);
            this.guna2ShadowPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOfPharmacyDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicinesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel3;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.TextBox txtStockAmount;
        private System.Windows.Forms.TextBox txtPublicPaid;
        private System.Windows.Forms.TextBox txtPublicPrice;
        private System.Windows.Forms.TextBox txtPrescriptionType;
        private System.Windows.Forms.TextBox txtMedicineType;
        private System.Windows.Forms.TextBox txtActiveIngredient;
        private System.Windows.Forms.TextBox txtMedicineName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMedID;
        private System.Windows.Forms.Label txtIsReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridUpdateMedicines;
        private DatabaseOfPharmacyDataSet1 databaseOfPharmacyDataSet1;
        private System.Windows.Forms.BindingSource medicinesBindingSource;
        private DatabaseOfPharmacyDataSet1TableAdapters.MedicinesTableAdapter medicinesTableAdapter;
        private System.Windows.Forms.Label label3;
    }
}