using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DemoAppCSharp
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            // โหลดรายชื่อ Form ในโปรเจค ยกเว้น FormMenu และ FormLogin
            var formTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Form))
                            && t != typeof(FormMenu)
                            && t != typeof(Form0))
                .ToList();

            foreach (var formType in formTypes)
            {
                comboForms.Items.Add(formType.Name);
            }

            if (comboForms.Items.Count > 0)
                comboForms.SelectedIndex = 0;
        }

        private void btnOpenForm_Click(object sender, EventArgs e)
        {
            if (comboForms.SelectedItem != null)
            {
                var formName = comboForms.SelectedItem.ToString();
                var type = Assembly.GetExecutingAssembly().GetType($"{this.GetType().Namespace}.{formName}");
                if (type != null)
                {
                    var form = (Form)Activator.CreateInstance(type);
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close();
                    form.Show();
                }
            }
        }
        private void btnOpenForm1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
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
}
