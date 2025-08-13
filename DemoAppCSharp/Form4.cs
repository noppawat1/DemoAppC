using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DemoAppCSharp
{
    public partial class Form4 : Form
    {
        private readonly MongoService _service = new MongoService();
        private string currentUserRole;
        public Form4(string userRole)
        {
            InitializeComponent();
            LoadDashboard();
            currentUserRole = userRole;
        }

        private void LoadDashboard()
        {
            var people = _service.GetAll();

            if (people == null || !people.Any())
            {
                MessageBox.Show("ไม่มีข้อมูลสำหรับแสดง Dashboard");
                return;
            }

            // คำนวณสถิติ
            int minAge = people.Min(p => p.Age);
            int maxAge = people.Max(p => p.Age);
            double avgAge = people.Average(p => p.Age);

            lblMinAge.Text = $"อายุต่ำสุด: {minAge}";
            lblMaxAge.Text = $"อายุสูงสุด: {maxAge}";
            lblAvgAge.Text = $"อายุเฉลี่ย: {avgAge:F1}";

            // สร้างข้อมูลช่วงอายุ
            var ageGroups = new[]
            {
                new { Label = "0-18", Count = people.Count(p => p.Age >= 0 && p.Age <= 18) },
                new { Label = "19-30", Count = people.Count(p => p.Age >= 19 && p.Age <= 30) },
                new { Label = "31-50", Count = people.Count(p => p.Age >= 31 && p.Age <= 50) },
                new { Label = "51+", Count = people.Count(p => p.Age >= 51) },
            };

            // เคลียร์ข้อมูลเก่าก่อน
            chart1.Series["AgeSeries"].Points.Clear();

            // เติมข้อมูลกราฟ
            foreach (var group in ageGroups)
            {
                chart1.Series["AgeSeries"].Points.AddXY(group.Label, group.Count);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu menu = new FormMenu(currentUserRole);
            menu.Show();
        }
    }
}
