using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace pharmacy_console
{
    public partial class Invoince : Form
    {
        public Invoince()
        {
            InitializeComponent();
        }
        public void SetInvoinceData(long saleId, long prescriptionId, string patientId, float totalPrice, DateTime saleDate)
        {
            txtSaleID.Text = saleId.ToString();
            txtPrescriptionID.Text = prescriptionId.ToString();
            txtPatientID.Text = patientId;
            txtTotalPrice.Text = totalPrice.ToString("F2");
            txtInvoinceDate.Text = saleDate.ToShortDateString();

            // Satış detaylarını DataGridView'e yükleme
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    string query = "SELECT * FROM AddForSales";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridSalesDetails.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)//PRINT BUTTON
        {
            try
            {
                

                // PDF oluştur
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Fatura Kaydet"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    CreatePdf(filePath);

                    MessageBox.Show("Fatura başarıyla oluşturuldu.");
                    // AddForSales tablosunu temizleme
                    using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM AddForSales";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                // AddForSales tablosunu temizle
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand deleteAll = new SqlCommand("DELETE FROM AddForSales", conn);
                    deleteAll.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void CreatePdf(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // PDF'e genel bilgiler ekle
                pdfDoc.Add(new Paragraph("Fatura Bilgileri"));
                pdfDoc.Add(new Paragraph("Sale ID: " + txtSaleID.Text));
                pdfDoc.Add(new Paragraph("Prescription ID: " + txtPrescriptionID.Text));
                pdfDoc.Add(new Paragraph("Patient ID: " + txtPatientID.Text));
                pdfDoc.Add(new Paragraph("Total Price: " + txtTotalPrice.Text + " TL"));
                pdfDoc.Add(new Paragraph("Sale Date: " + txtInvoinceDate.Text));
                pdfDoc.Add(new Paragraph("\n")); // Boşluk eklemek için

                // DataGridView verilerini PDF'e ekle
                PdfPTable table = new PdfPTable(dataGridSalesDetails.Columns.Count);
                table.WidthPercentage = 100;

                // Tablo başlıklarını ekle
                foreach (DataGridViewColumn column in dataGridSalesDetails.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY // Başlık için arka plan rengi
                    };
                    table.AddCell(cell);
                }

                // Tablo satırlarını ekle
                foreach (DataGridViewRow row in dataGridSalesDetails.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString() ?? ""); // Hücre değeri null ise boş string ekle
                        }
                    }
                }

                pdfDoc.Add(table); // Tabloyu PDF'e ekle

                pdfDoc.Close();
                writer.Close();
            }
        }

        private void Invoince_Load(object sender, EventArgs e)
        {
            // Invoice verilerini kaydet
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
            {
                conn.Open();
                string insertQuery = @"
                INSERT INTO Invoinces (SaleID, PrescriptionID, PatientID, TotalPrice, InvoinceDate) 
                VALUES (@SaleID, @PrescriptionID, @PatientID, @TotalPrice, @InvoinceDate);
                ";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@SaleID", Convert.ToInt64(txtSaleID.Text));
                    cmd.Parameters.AddWithValue("@PrescriptionID", Convert.ToInt64(txtPrescriptionID.Text));
                    cmd.Parameters.AddWithValue("@PatientID", txtPatientID.Text);
                    cmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDecimal(txtTotalPrice.Text));
                    cmd.Parameters.AddWithValue("@InvoinceDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Invoince_FormClosing(object sender, FormClosingEventArgs e)
        {
            // AddForSales tablosunu temizle
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-THDLSQ6F;Initial Catalog=DatabaseOfPharmacy;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand deleteAll = new SqlCommand("DELETE FROM AddForSales", conn);
                deleteAll.ExecuteNonQuery();
            }

        }
    }
}
