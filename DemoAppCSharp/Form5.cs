using DemoAppCSharp.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemoAppCSharp
{
    public partial class Form5 : Form
    {
        private readonly MongoService _service;
        private List<User> _users;
        private string currentUserRole;
        public Form5(string userRole)
        {
            InitializeComponent();
            _service = new MongoService();
            currentUserRole = userRole;
            // Bind events
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnUpdateRole.Click += BtnUpdateRole_Click;
            btnRefresh.Click += BtnRefresh_Click;
            lvUsers.SelectedIndexChanged += LvUsers_SelectedIndexChanged;

            LoadUsers();
        }

        private void LoadUsers()
        {
            _users = _service.GetUsers();
            lvUsers.Items.Clear();

            foreach (var user in _users)
            {
                var item = new ListViewItem(user.Username);
                item.SubItems.Add(user.Role);
                lvUsers.Items.Add(item);
            }

            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cbRole.SelectedIndex = -1;
            lvUsers.SelectedItems.Clear();
        }

        private void LvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsers.SelectedIndices.Count == 0) return;

            int index = lvUsers.SelectedIndices[0];
            var selectedUser = _users[index];

            txtUsername.Text = selectedUser.Username;
            txtPassword.Text = ""; // ไม่แสดง password เดิม
            cbRole.SelectedItem = selectedUser.Role;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_service.UserExists(username))
            {
                MessageBox.Show("ชื่อผู้ใช้นี้มีอยู่แล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new User
            {
                Username = username,
                Password = password,  // แนะนำให้ hash password จริงๆ
                Role = role
            };

            _service.AddUser(newUser);
            MessageBox.Show("เพิ่มผู้ใช้สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedIndices.Count == 0)
            {
                MessageBox.Show("โปรดเลือกผู้ใช้ที่จะลบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = lvUsers.SelectedIndices[0];
            var userToDelete = _users[index];

            var confirm = MessageBox.Show($"คุณแน่ใจจะลบผู้ใช้ {userToDelete.Username}?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _service.DeleteUser(userToDelete.Id);
                MessageBox.Show("ลบผู้ใช้สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
        }

        private void BtnUpdateRole_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedIndices.Count == 0)
            {
                MessageBox.Show("โปรดเลือกผู้ใช้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = lvUsers.SelectedIndices[0];
            var userToUpdate = _users[index];
            string newRole = cbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show("โปรดเลือก role", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            userToUpdate.Role = newRole;
            _service.UpdateUserRole(userToUpdate.Id, newRole);

            MessageBox.Show("อัปเดต role สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
        }   

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            // สมมติ Menu คือเปิดฟอร์มเมนูหลัก
            var mainMenuForm = new FormMenu(currentUserRole); // แก้ชื่อฟอร์มเมนูจริงตามโปรเจกต์
            mainMenuForm.Show();
            this.Close(); // หรือ this.Hide(); ตามต้องการ
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var mainMenuForm = new FormMenu(currentUserRole);
            mainMenuForm.Show();
            this.Hide();  // ซ่อนฟอร์มปัจจุบัน
        }


    }
}
