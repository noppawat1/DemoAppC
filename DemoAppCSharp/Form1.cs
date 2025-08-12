using DemoAppCSharp.Model;
using MongoDB.Bson;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using MongoDB.Driver;
namespace DemoAppCSharp
{
    public partial class Form1 : Form
    {
        private readonly MongoService _service = new MongoService();
        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // ผูก event กับปุ่มและ DataGridView
            btnLoad.Click += btnLoad_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || !int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง");
                return;
            }

            if (age <= 0)
            {
                MessageBox.Show("อายุไม่ควรติดลบหรือเป็น 0");
                return;
            }

            // ตรวจสอบชื่อและอายุซ้ำกันใน DB
            if (_service.Exists(txtName.Text.Trim(), age))
            {
                MessageBox.Show("ชื่อนี้และอายุนี้มีในระบบแล้ว");
                return;
            }

            var p = new Person { Name = txtName.Text.Trim(), Age = age };
            _service.Create(p);
            btnLoad_Click(null, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกแถวที่จะอัพเดท");
                return;
            }

            var id = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("กรุณากรอกอายุให้ถูกต้อง");
                return;
            }

            if (age <= 0)
            {
                MessageBox.Show("อายุไม่ควรติดลบหรือเป็น 0");
                return;
            }

            if (_service.Exists(txtName.Text.Trim(), age, id))
            {
                MessageBox.Show("ชื่อนี้และอายุนี้มีในระบบแล้ว");
                return;
            }

            var p = new Person { Id = id, Name = txtName.Text.Trim(), Age = age };
            _service.Update(id, p);
            btnLoad_Click(null, null);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกแถวที่จะลบ");
                return;
            }

            var id = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
            var confirm = MessageBox.Show("ต้องการลบข้อมูลหรือไม่?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _service.Delete(id);
                btnLoad_Click(null, null);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value?.ToString();
                txtAge.Text = dataGridView1.Rows[e.RowIndex].Cells["Age"].Value?.ToString();
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
