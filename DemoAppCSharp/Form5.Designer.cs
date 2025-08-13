namespace DemoAppCSharp
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader chUsername;
        private System.Windows.Forms.ColumnHeader chRole;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdateRole;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelTop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lvUsers = new System.Windows.Forms.ListView();
            this.chUsername = new System.Windows.Forms.ColumnHeader();
            this.chRole = new System.Windows.Forms.ColumnHeader();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdateRole = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.panelTop = new System.Windows.Forms.Panel();
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        this.chUsername,
        this.chRole});
            this.lvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.TabIndex = 0;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;

            // 
            // chUsername
            // 
            this.chUsername.Text = "Username";
            this.chUsername.Width = 200;

            // 
            // chRole
            // 
            this.chRole.Text = "Role";
            this.chRole.Width = 150;

            // 
            // Labels
            // 
            this.lblUsername.Text = "Username:";
            this.lblPassword.Text = "Password:";
            this.lblRole.Text = "Role:";

            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRole.Dock = System.Windows.Forms.DockStyle.Fill;

            // 
            // TextBoxes & ComboBox
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.UseSystemPasswordChar = true;

            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Items.AddRange(new object[] { "Admin", "User" });
            this.cbRole.Dock = System.Windows.Forms.DockStyle.Fill;

            // 
            // Buttons
            // 
            this.btnAdd.Text = "Add User";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;

            this.btnUpdateRole.Text = "Update Role";
            this.btnUpdateRole.Size = new System.Drawing.Size(100, 35);
            this.btnUpdateRole.Anchor = System.Windows.Forms.AnchorStyles.None;

            this.btnDelete.Text = "Delete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;

            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelMain.RowCount = 6;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Username
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Password
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Role
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Buttons Panel
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // ListView
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F)); // Refresh button

            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(10);

            // Add controls to tableLayoutPanelMain (Label in col 0, input in col 1)
            this.tableLayoutPanelMain.Controls.Add(this.lblUsername, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.txtUsername, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.lblPassword, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.txtPassword, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.lblRole, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.cbRole, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panelButtons, 1, 3);
            this.tableLayoutPanelMain.Controls.Add(this.lvUsers, 0, 4);
            this.tableLayoutPanelMain.SetColumnSpan(this.lvUsers, 2);
            this.tableLayoutPanelMain.Controls.Add(this.btnRefresh, 1, 5);

            // 
            // panelButtons (holds 3 buttons horizontally)
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnUpdateRole);
            this.panelButtons.Controls.Add(this.btnDelete);

            this.btnAdd.Location = new System.Drawing.Point(0, 5);
            this.btnUpdateRole.Location = new System.Drawing.Point(110, 5);
            this.btnDelete.Location = new System.Drawing.Point(220, 5);

            this.panelButtons.Height = 45;
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(10);

            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 50;
            this.panelTop.Controls.Add(this.btnBack);
            // 
            // Form5
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.panelTop);
            this.Name = "Form5";
            this.Text = "User & Role Management";

            this.ResumeLayout(false);
        }

    }
}
