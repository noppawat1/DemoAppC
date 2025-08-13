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
        private string currentUserRole;
        public Form1(string userRole)
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // เปิดให้แก้ไขได้ (ยกเว้น Id)
            dataGridView1.ReadOnly = false;
            currentUserRole = userRole;
            // ถ้าคอลัมน์ Id ยังไม่ถูกสร้าง (โหลดข้อมูลมาแบบออโต้) ให้ตั้ง ReadOnly ของ Id หลังโหลดข้อมูล
            // แต่ถ้า column มีอยู่แล้ว ให้ตั้งตรงนี้ได้เลย:
            if (dataGridView1.Columns["Id"] != null)
            {
                dataGridView1.Columns["Id"].ReadOnly = true;
            }

            btnLoad.Click += btnLoad_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;

            this.lblName.Visible = false;
            this.lblAge.Visible = false;
            SetInputVisibility(false);
        }

        private void SetInputVisibility(bool visible)
        {
            txtName.Visible = visible;
            txtAge.Visible = visible;
            btnConfirm.Visible = visible;
            btnCancel.Visible = visible;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _service.GetAll();
            if (dataGridView1.Columns["Id"] != null)
            {
                dataGridView1.Columns["Id"].ReadOnly = true;  // ไม่ให้แก้ไข column Id
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // แสดงช่องกรอก และปุ่ม confirm/cancel
            SetInputVisibility(true);

            // ล้างค่าเก่าออก
            txtName.Text = "";
            txtAge.Text = "";
            this.lblName.Visible = true;
            this.lblAge.Visible = true;
            // ปิดปุ่ม Add ไว้ชั่วคราว (ไม่ให้กดซ้ำ)
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate input เหมือนเดิม
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

            if (_service.Exists(txtName.Text.Trim(), age))
            {
                MessageBox.Show("ชื่อนี้และอายุนี้มีในระบบแล้ว");
                return;
            }

            var p = new Person { Name = txtName.Text.Trim(), Age = age };
            _service.Create(p);

            // โหลดข้อมูลใหม่
            btnLoad_Click(null, null);

            // ซ่อนช่องกรอก และปุ่ม confirm/cancel
            SetInputVisibility(false);

            // เปิดปุ่ม Add กลับ
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            this.lblName.Visible = false;
            this.lblAge.Visible = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // ซ่อนช่องกรอกและปุ่ม confirm/cancel
            SetInputVisibility(false);

            // เปิดปุ่ม Add กลับ
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            this.lblName.Visible = false;
            this.lblAge.Visible = false;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกแถวที่จะอัพเดท");
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];

            var id = selectedRow.Cells["Id"].Value.ToString();
            var name = selectedRow.Cells["Name"].Value?.ToString().Trim();
            var ageStr = selectedRow.Cells["Age"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("กรุณากรอกชื่อให้ถูกต้อง");
                return;
            }

            if (!int.TryParse(ageStr, out int age))
            {
                MessageBox.Show("กรุณากรอกอายุให้ถูกต้อง");
                return;
            }

            if (age <= 0)
            {
                MessageBox.Show("อายุไม่ควรติดลบหรือเป็น 0");
                return;
            }

            if (_service.Exists(name, age, id))
            {
                MessageBox.Show("ชื่อนี้และอายุนี้มีในระบบแล้ว");
                return;
            }

            var p = new Person { Id = id, Name = name, Age = age };
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
            FormMenu menu = new FormMenu(currentUserRole);
            menu.Show(); // เปิดฟอร์มเมนูใหม่
        }




    }
}
