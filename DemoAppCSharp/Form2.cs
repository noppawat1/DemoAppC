using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DemoAppCSharp.Model;

namespace DemoAppCSharp
{
    public partial class Form2 : Form
    {
        private MongoService _service;

        public Form2()
        {
            InitializeComponent();
            _service = new MongoService();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            var data = _service.GetAll();
            dgvData.DataSource = data;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("กรุณากรอกคำค้นหา");
                return;
            }

            var data = _service.GetAll()
                               .Where(p => p.Name.Contains(keyword))
                               .ToList();
            dgvData.DataSource = data;
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลให้ส่งออก");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "บันทึกไฟล์ CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // เขียนหัวตาราง
                    var headers = dgvData.Columns.Cast<DataGridViewColumn>();
                    writer.WriteLine(string.Join(",", headers.Select(h => h.HeaderText)));

                    // เขียนข้อมูล
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        writer.WriteLine(string.Join(",", cells.Select(c => c.Value?.ToString() ?? "")));
                    }
                }

                MessageBox.Show("บันทึก CSV สำเร็จ!");
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); // ซ่อนฟอร์มปัจจุบันก่อน
            FormMenu menu = new FormMenu();
            menu.Show(); // เปิดฟอร์มเมนูใหม่
        }
    }
}
