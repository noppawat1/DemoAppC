using DemoAppCSharp.Model;
using System;
using System.Windows.Forms;

namespace DemoAppCSharp
{
    public partial class Form0 : Form
    {
        private readonly MongoService _service;

        public Form0()
        {
            InitializeComponent();
            _service = new MongoService();

            // bind events
            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;
            chkShow.CheckedChanged += ChkShow_CheckedChanged;
        }

        private void ChkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShow.Checked;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUser.Text.Trim();
            var password = txtPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("กรุณากรอก username และ password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_service.ValidateUser(username, password, out User user))
            {
                // Login สำเร็จ — เปิดฟอร์มหลัก (Form1) หรือ return DialogResult
                MessageBox.Show($"Welcome {user.Username}", "Login success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ถ้าต้องการเปิด Form1:
                var main = new FormMenu();
                this.Hide();
                main.FormClosed += (s, args) => this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
