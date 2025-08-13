using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DemoAppCSharp
{
    public partial class Form3 : Form
    {
        private string currentUserRole;
        public Form3(string userRole)
        {
            InitializeComponent();
            currentUserRole = userRole;
        }

        private void btnImportCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "เลือกไฟล์ CSV"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (StreamReader sr = new StreamReader(openFile.FileName))
                    {
                        bool isFirstRow = true;
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');

                            // สร้างคอลัมน์จากแถวแรก
                            if (isFirstRow)
                            {
                                foreach (string col in rows)
                                {
                                    dt.Columns.Add(col);
                                }
                                isFirstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add(rows);
                            }
                        }
                    }

                    dgvCsvData.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menu = new FormMenu(currentUserRole);
            menu.Show();
        }
    }
}
