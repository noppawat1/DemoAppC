using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DemoAppCSharp
{
    public partial class FormMenu : Form
    {
        private readonly string currentUserRole;
        public FormMenu(string userRole)
        {
            InitializeComponent();
            currentUserRole = userRole;
            // โหลดรายชื่อ Form ในโปรเจค ยกเว้น FormMenu และ FormLogin
            var formTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Form))
                            && t != typeof(FormMenu)
                            && t != typeof(Form0))
                .ToList();

            foreach (var formType in formTypes)
            {
                if (formType.Name == "Form5" && currentUserRole != "Admin")
                    continue;
                string displayName = formType.Name;
                if (formType.Name == "Form1")
                {
                    displayName = "Manage";
                }
                else if (formType.Name == "Form2")
                {
                    displayName = "Export CSV";
                }
                else if (formType.Name == "Form3")
                {
                    displayName = "Import CSV";
                }
                else if (formType.Name == "Form4")
                {
                    displayName = "DashBoard";
                }
                else if (formType.Name == "Form5")
                {
                    displayName = "User Management";
                }
                // ใส่ object ที่เก็บชื่อแสดงและ Type
                comboForms.Items.Add(new FormItem
                {
                    DisplayName = displayName,
                    FormType = formType
                });
            }

            if (comboForms.Items.Count > 0)
                comboForms.SelectedIndex = 0;
        }

        private void btnOpenForm_Click(object sender, EventArgs e)
        {
            if (comboForms.SelectedItem is FormItem selectedItem)
            {
                Form form;

                // รายชื่อฟอร์มที่ต้องส่ง userRole เข้า constructor
                var formsRequireRole = new[] { typeof(Form1), typeof(Form5) };

                if (formsRequireRole.Contains(selectedItem.FormType))
                {
                    form = (Form)Activator.CreateInstance(selectedItem.FormType, currentUserRole);
                }
                else
                {
                    form = (Form)Activator.CreateInstance(selectedItem.FormType, currentUserRole);
                }

                this.Hide();
                form.FormClosed += (s, args) => this.Close();
                form.Show();
            }
        }





        private void btnOpenForm1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(currentUserRole);
            form1.Show();
            this.Hide(); // ซ่อนเมนู ไม่ปิด
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // กลับไปหน้า Login
            Form0 login = Application.OpenForms["Form0"] as Form0;
            if (login != null)
            {
                login.Show();
            }
            this.Close(); // ปิดเมนู
        }
    }

    public class FormItem
    {
        public string DisplayName { get; set; }
        public Type FormType { get; set; }

        public override string ToString()
        {
            return DisplayName;  // ให้แสดงชื่อที่เราต้องการใน ComboBox
        }
    }
}
