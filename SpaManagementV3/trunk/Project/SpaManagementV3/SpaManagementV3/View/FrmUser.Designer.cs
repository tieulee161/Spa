namespace SpaManagementV3.View
{
    partial class FrmUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtFullName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chkShowPassword = new Telerik.WinControls.UI.RadCheckBox();
            this.cbbxPosition = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txtUserName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.btnAddUser = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnUpdateUser = new Telerik.WinControls.UI.CommandBarButton();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.btnDeleteUser = new Telerik.WinControls.UI.CommandBarButton();
            this.dtgUser = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtFullName);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.chkShowPassword);
            this.radGroupBox1.Controls.Add(this.cbbxPosition);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtPassword);
            this.radGroupBox1.Controls.Add(this.txtUserName);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "User";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 37);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(613, 147);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "User";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(107, 30);
            this.txtFullName.MaxLength = 20;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(252, 22);
            this.txtFullName.TabIndex = 28;
            this.txtFullName.ThemeName = "TelerikMetro";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(28, 33);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(68, 19);
            this.radLabel2.TabIndex = 29;
            this.radLabel2.Text = "Full Name :";
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Location = new System.Drawing.Point(251, 115);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(108, 19);
            this.chkShowPassword.TabIndex = 27;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.ThemeName = "TelerikMetro";
            // 
            // cbbxPosition
            // 
            this.cbbxPosition.AllowShowFocusCues = false;
            this.cbbxPosition.AutoCompleteDisplayMember = null;
            this.cbbxPosition.AutoCompleteValueMember = null;
            this.cbbxPosition.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxPosition.Location = new System.Drawing.Point(107, 114);
            this.cbbxPosition.Name = "cbbxPosition";
            this.cbbxPosition.Size = new System.Drawing.Size(137, 23);
            this.cbbxPosition.TabIndex = 2;
            this.cbbxPosition.ThemeName = "TelerikMetro";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(28, 114);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(56, 19);
            this.radLabel1.TabIndex = 25;
            this.radLabel1.Text = "Position :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 86);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(137, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.ThemeName = "TelerikMetro";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(107, 58);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(137, 22);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.ThemeName = "TelerikMetro";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(28, 89);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(64, 19);
            this.radLabel7.TabIndex = 22;
            this.radLabel7.Text = "Password :";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(28, 61);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(73, 19);
            this.radLabel6.TabIndex = 20;
            this.radLabel6.Text = "User Name :";
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(613, 37);
            this.radCommandBar1.TabIndex = 2;
            this.radCommandBar1.Text = "radCommandBar1";
            this.radCommandBar1.ThemeName = "TelerikMetro";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            this.commandBarRowElement1.Text = "";
            this.commandBarRowElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.EnableDragging = false;
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.btnAddUser,
            this.commandBarSeparator1,
            this.btnUpdateUser,
            this.commandBarSeparator2,
            this.btnDeleteUser});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // 
            // 
            this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            this.commandBarStripElement1.ShowHorizontalLine = false;
            this.commandBarStripElement1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.commandBarStripElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // btnAddUser
            // 
            this.btnAddUser.AccessibleDescription = "Add";
            this.btnAddUser.AccessibleName = "Add";
            this.btnAddUser.ClipDrawing = false;
            this.btnAddUser.ClipText = false;
            this.btnAddUser.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAddUser.DisplayName = "commandBarButton1";
            this.btnAddUser.DrawText = true;
            this.btnAddUser.Image = global::SpaManagementV3.Properties.Resources.Add;
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Text = "Add";
            this.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddUser.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnAddUser.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.AccessibleDescription = "Update";
            this.btnUpdateUser.AccessibleName = "Update";
            this.btnUpdateUser.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnUpdateUser.DisplayName = "commandBarButton2";
            this.btnUpdateUser.DrawText = true;
            this.btnUpdateUser.Image = global::SpaManagementV3.Properties.Resources.Save;
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Text = "Update";
            this.btnUpdateUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateUser.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnUpdateUser.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
            this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
            this.commandBarSeparator2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.commandBarSeparator2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.AccessibleDescription = "Delete";
            this.btnDeleteUser.AccessibleName = "Delete";
            this.btnDeleteUser.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnDeleteUser.DisplayName = "commandBarButton3";
            this.btnDeleteUser.DrawText = true;
            this.btnDeleteUser.Image = global::SpaManagementV3.Properties.Resources.Delete;
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteUser.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnDeleteUser.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // dtgUser
            // 
            this.dtgUser.BackColor = System.Drawing.Color.White;
            this.dtgUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgUser.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgUser.Location = new System.Drawing.Point(0, 184);
            // 
            // dtgUser
            // 
            this.dtgUser.MasterTemplate.AllowAddNewRow = false;
            this.dtgUser.MasterTemplate.AllowCellContextMenu = false;
            this.dtgUser.MasterTemplate.AllowDeleteRow = false;
            this.dtgUser.MasterTemplate.AllowEditRow = false;
            this.dtgUser.MasterTemplate.AllowRowResize = false;
            this.dtgUser.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DecimalPlaces = 0;
            gridViewDecimalColumn1.EnableExpressionEditor = false;
            gridViewDecimalColumn1.HeaderText = "Id";
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn1.Name = "colId";
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Full Name";
            gridViewTextBoxColumn1.Name = "colFullName";
            gridViewTextBoxColumn1.Width = 217;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Name";
            gridViewTextBoxColumn2.Name = "colName";
            gridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn2.Width = 134;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FormatString = "**********";
            gridViewTextBoxColumn3.HeaderText = "Password";
            gridViewTextBoxColumn3.Name = "colPass";
            gridViewTextBoxColumn3.Width = 123;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Position";
            gridViewTextBoxColumn4.Name = "colPosition";
            gridViewTextBoxColumn4.Width = 122;
            this.dtgUser.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dtgUser.MasterTemplate.EnableGrouping = false;
            this.dtgUser.MasterTemplate.EnableSorting = false;
            sortDescriptor1.PropertyName = "colName";
            this.dtgUser.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgUser.Name = "dtgUser";
            this.dtgUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgUser.Size = new System.Drawing.Size(613, 174);
            this.dtgUser.TabIndex = 3;
            this.dtgUser.Text = "radGridView1";
            this.dtgUser.ThemeName = "TelerikMetro";
            this.dtgUser.CreateCell += new Telerik.WinControls.UI.GridViewCreateCellEventHandler(this.dtgUser_CreateCell);
            this.dtgUser.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.dtgUser_RowFormatting);
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 358);
            this.Controls.Add(this.dtgUser);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radCommandBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmUser";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton btnAddUser;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarButton btnUpdateUser;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarButton btnDeleteUser;
        private Telerik.WinControls.UI.RadDropDownList cbbxPosition;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private Telerik.WinControls.UI.RadTextBox txtUserName;
        private Telerik.WinControls.UI.RadCheckBox chkShowPassword;
        private Telerik.WinControls.UI.RadGridView dtgUser;
        private Telerik.WinControls.UI.RadTextBox txtFullName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
    }
}
