namespace DemoAppCSharp
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCsvData;
        private System.Windows.Forms.Button btnImportCsv;
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
            this.dgvCsvData = new System.Windows.Forms.DataGridView();
            this.btnImportCsv = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCsvData
            // 
            this.dgvCsvData.AllowUserToAddRows = false;
            this.dgvCsvData.AllowUserToDeleteRows = false;
            this.dgvCsvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsvData.Location = new System.Drawing.Point(12, 50);
            this.dgvCsvData.Name = "dgvCsvData";
            this.dgvCsvData.ReadOnly = true;
            this.dgvCsvData.Size = new System.Drawing.Size(600, 300);
            // 
            // btnImportCsv
            // 
            this.btnImportCsv.Location = new System.Drawing.Point(12, 12);
            this.btnImportCsv.Name = "btnImportCsv";
            this.btnImportCsv.Size = new System.Drawing.Size(120, 30);
            this.btnImportCsv.Text = "Import CSV";
            this.btnImportCsv.UseVisualStyleBackColor = true;
            this.btnImportCsv.Click += new System.EventHandler(this.btnImportCsv_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(150, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(630, 370);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnImportCsv);
            this.Controls.Add(this.dgvCsvData);
            this.Text = "Import CSV";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsvData)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
