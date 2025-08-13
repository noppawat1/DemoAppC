namespace DemoAppCSharp
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMinAge;
        private System.Windows.Forms.Label lblMaxAge;
        private System.Windows.Forms.Label lblAvgAge;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.lblMinAge = new System.Windows.Forms.Label();
            this.lblMaxAge = new System.Windows.Forms.Label();
            this.lblAvgAge = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();

            // lblMinAge
            this.lblMinAge.AutoSize = true;
            this.lblMinAge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMinAge.Location = new System.Drawing.Point(20, 20);
            this.lblMinAge.Name = "lblMinAge";
            this.lblMinAge.Size = new System.Drawing.Size(120, 19);
            this.lblMinAge.Text = "อายุต่ำสุด: -";

            // lblMaxAge
            this.lblMaxAge.AutoSize = true;
            this.lblMaxAge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaxAge.Location = new System.Drawing.Point(180, 20);
            this.lblMaxAge.Name = "lblMaxAge";
            this.lblMaxAge.Size = new System.Drawing.Size(120, 19);
            this.lblMaxAge.Text = "อายุสูงสุด: -";

            // lblAvgAge
            this.lblAvgAge.AutoSize = true;
            this.lblAvgAge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvgAge.Location = new System.Drawing.Point(340, 20);
            this.lblAvgAge.Name = "lblAvgAge";
            this.lblAvgAge.Size = new System.Drawing.Size(120, 19);
            this.lblAvgAge.Text = "อายุเฉลี่ย: -";

            // chart1
            this.chart1.Location = new System.Drawing.Point(20, 60);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(600, 300);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";

            // *** เพิ่ม ChartArea และ Series ***
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            chartArea.Name = "MainChartArea";
            this.chart1.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series();
            series.Name = "AgeSeries";
            series.ChartArea = "MainChartArea";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.chart1.Series.Add(series);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(20, 380);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(120, 380);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 30);
            this.btnBack.Text = "Back to Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // Form4
            this.ClientSize = new System.Drawing.Size(650, 430);
            this.Controls.Add(this.lblMinAge);
            this.Controls.Add(this.lblMaxAge);
            this.Controls.Add(this.lblAvgAge);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBack);
            this.Name = "Form4";
            this.Text = "Dashboard - Age Statistics";

            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
