namespace DemoAppCSharp
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboForms;
        private System.Windows.Forms.Button btnOpenForm;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.comboForms = new System.Windows.Forms.ComboBox();
            this.btnOpenForm = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboForms
            // 
            this.comboForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboForms.FormattingEnabled = true;
            this.comboForms.Location = new System.Drawing.Point(30, 30);
            this.comboForms.Name = "comboForms";
            this.comboForms.Size = new System.Drawing.Size(200, 21);
            // 
            // btnOpenForm
            // 
            this.btnOpenForm.Location = new System.Drawing.Point(250, 28);
            this.btnOpenForm.Name = "btnOpenForm";
            this.btnOpenForm.Size = new System.Drawing.Size(100, 23);
            this.btnOpenForm.TabIndex = 1;
            this.btnOpenForm.Text = "เปิดฟอร์ม";
            this.btnOpenForm.UseVisualStyleBackColor = true;
            this.btnOpenForm.Click += new System.EventHandler(this.btnOpenForm_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(30, 70);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "ออกจากระบบ";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.comboForms);
            this.Controls.Add(this.btnOpenForm);
            this.Controls.Add(this.btnLogout);
            this.Name = "FormMenu";
            this.Text = "เมนู";
            this.ResumeLayout(false);

        }
        #endregion
    }
}
