namespace SpaManagementV3.View
{
    partial class FrmConditionForReport
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitKTV = new Telerik.WinControls.UI.SplitPanel();
            this.splitCustomer = new Telerik.WinControls.UI.SplitPanel();
            this.splitDate = new Telerik.WinControls.UI.SplitPanel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.dtgKTV = new Telerik.WinControls.UI.RadGridView();
            this.dtgCustomer = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.lbCustomerName = new Telerik.WinControls.UI.RadLabel();
            this.dateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dateTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitKTV)).BeginInit();
            this.splitKTV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCustomer)).BeginInit();
            this.splitCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDate)).BeginInit();
            this.splitDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKTV.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomer.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitKTV);
            this.radSplitContainer1.Controls.Add(this.splitCustomer);
            this.radSplitContainer1.Controls.Add(this.splitDate);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.EnableCollapsing = true;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radSplitContainer1.Size = new System.Drawing.Size(992, 411);
            this.radSplitContainer1.SplitterWidth = 8;
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.ThemeName = "TelerikMetro";
            this.radSplitContainer1.UseSplitterButtons = true;
            // 
            // splitKTV
            // 
            this.splitKTV.Controls.Add(this.dtgKTV);
            this.splitKTV.Location = new System.Drawing.Point(0, 0);
            this.splitKTV.Name = "splitKTV";
            // 
            // 
            // 
            this.splitKTV.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitKTV.Size = new System.Drawing.Size(398, 411);
            this.splitKTV.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.07445354F, 0F);
            this.splitKTV.SizeInfo.SplitterCorrection = new System.Drawing.Size(65, 0);
            this.splitKTV.TabIndex = 0;
            this.splitKTV.TabStop = false;
            this.splitKTV.ThemeName = "TelerikMetro";
            // 
            // splitCustomer
            // 
            this.splitCustomer.Controls.Add(this.dtgCustomer);
            this.splitCustomer.Location = new System.Drawing.Point(406, 0);
            this.splitCustomer.Name = "splitCustomer";
            // 
            // 
            // 
            this.splitCustomer.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitCustomer.Size = new System.Drawing.Size(391, 411);
            this.splitCustomer.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.06728142F, 0F);
            this.splitCustomer.SizeInfo.SplitterCorrection = new System.Drawing.Size(57, 0);
            this.splitCustomer.TabIndex = 1;
            this.splitCustomer.TabStop = false;
            this.splitCustomer.Text = "splitPanel2";
            this.splitCustomer.ThemeName = "TelerikMetro";
            // 
            // splitDate
            // 
            this.splitDate.Controls.Add(this.radGroupBox1);
            this.splitDate.Location = new System.Drawing.Point(805, 0);
            this.splitDate.Name = "splitDate";
            // 
            // 
            // 
            this.splitDate.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.splitDate.Size = new System.Drawing.Size(187, 411);
            this.splitDate.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.141735F, 0F);
            this.splitDate.SizeInfo.SplitterCorrection = new System.Drawing.Size(-122, 0);
            this.splitDate.TabIndex = 2;
            this.splitDate.TabStop = false;
            this.splitDate.Text = "splitPanel3";
            this.splitDate.ThemeName = "TelerikMetro";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Controls.Add(this.btnOK);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 411);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(992, 40);
            this.radPanel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::SpaManagementV3.Properties.Resources.Delete;
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(902, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.ThemeName = "TelerikMetro";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = global::SpaManagementV3.Properties.Resources.Check;
            this.btnOK.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOK.Location = new System.Drawing.Point(814, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.ThemeName = "TelerikMetro";
            // 
            // dtgKTV
            // 
            this.dtgKTV.BackColor = System.Drawing.Color.White;
            this.dtgKTV.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgKTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgKTV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtgKTV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgKTV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgKTV.Location = new System.Drawing.Point(0, 0);
            // 
            // dtgKTV
            // 
            this.dtgKTV.MasterTemplate.AllowAddNewRow = false;
            this.dtgKTV.MasterTemplate.AllowDeleteRow = false;
            this.dtgKTV.MasterTemplate.AllowRowResize = false;
            this.dtgKTV.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
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
            gridViewCheckBoxColumn1.Checked = Telerik.WinControls.Enumerations.ToggleState.Off;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "colSelect";
            gridViewCheckBoxColumn1.Width = 52;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Code";
            gridViewTextBoxColumn1.Name = "colCode";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 83;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "KTV Name";
            gridViewTextBoxColumn2.Name = "column1";
            gridViewTextBoxColumn2.Width = 245;
            this.dtgKTV.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.dtgKTV.MasterTemplate.EnableGrouping = false;
            this.dtgKTV.MasterTemplate.EnableSorting = false;
            this.dtgKTV.MasterTemplate.ShowHeaderCellButtons = true;
            sortDescriptor1.PropertyName = "colName";
            this.dtgKTV.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgKTV.Name = "dtgKTV";
            this.dtgKTV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgKTV.ShowHeaderCellButtons = true;
            this.dtgKTV.Size = new System.Drawing.Size(398, 411);
            this.dtgKTV.TabIndex = 70;
            this.dtgKTV.ThemeName = "TelerikMetro";
            // 
            // dtgCustomer
            // 
            this.dtgCustomer.BackColor = System.Drawing.Color.White;
            this.dtgCustomer.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtgCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgCustomer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgCustomer.Location = new System.Drawing.Point(0, 0);
            // 
            // dtgCustomer
            // 
            this.dtgCustomer.MasterTemplate.AllowAddNewRow = false;
            this.dtgCustomer.MasterTemplate.AllowDeleteRow = false;
            this.dtgCustomer.MasterTemplate.AllowRowResize = false;
            this.dtgCustomer.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn2.DecimalPlaces = 0;
            gridViewDecimalColumn2.EnableExpressionEditor = false;
            gridViewDecimalColumn2.HeaderText = "Id";
            gridViewDecimalColumn2.IsVisible = false;
            gridViewDecimalColumn2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn2.Name = "colId";
            gridViewCheckBoxColumn2.Checked = Telerik.WinControls.Enumerations.ToggleState.Off;
            gridViewCheckBoxColumn2.EnableExpressionEditor = false;
            gridViewCheckBoxColumn2.EnableHeaderCheckBox = false;
            gridViewCheckBoxColumn2.MinWidth = 20;
            gridViewCheckBoxColumn2.Name = "colSelect";
            gridViewCheckBoxColumn2.Width = 51;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "Code";
            gridViewTextBoxColumn3.Name = "colCode";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 81;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Customer Name";
            gridViewTextBoxColumn4.Name = "column1";
            gridViewTextBoxColumn4.Width = 241;
            this.dtgCustomer.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn2,
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.dtgCustomer.MasterTemplate.EnableGrouping = false;
            this.dtgCustomer.MasterTemplate.EnableSorting = false;
            this.dtgCustomer.MasterTemplate.ShowHeaderCellButtons = true;
            sortDescriptor2.PropertyName = "colName";
            this.dtgCustomer.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
            this.dtgCustomer.Name = "dtgCustomer";
            this.dtgCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgCustomer.ShowHeaderCellButtons = true;
            this.dtgCustomer.Size = new System.Drawing.Size(391, 411);
            this.dtgCustomer.TabIndex = 71;
            this.dtgCustomer.ThemeName = "TelerikMetro";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.dateTo);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.dateFrom);
            this.radGroupBox1.Controls.Add(this.lbCustomerName);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Date";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(187, 411);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Date";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // lbCustomerName
            // 
            this.lbCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbCustomerName.Location = new System.Drawing.Point(5, 35);
            this.lbCustomerName.Name = "lbCustomerName";
            this.lbCustomerName.Size = new System.Drawing.Size(56, 26);
            this.lbCustomerName.TabIndex = 1;
            this.lbCustomerName.Text = "From :";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yy";
            this.dateFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(67, 32);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(103, 29);
            this.dateFrom.TabIndex = 2;
            this.dateFrom.TabStop = false;
            this.dateFrom.Text = "08/04/15";
            this.dateFrom.ThemeName = "TelerikMetro";
            this.dateFrom.Value = new System.DateTime(2015, 4, 8, 19, 35, 37, 978);
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd/MM/yy";
            this.dateTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(67, 67);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(103, 29);
            this.dateTo.TabIndex = 4;
            this.dateTo.TabStop = false;
            this.dateTo.Text = "08/04/15";
            this.dateTo.ThemeName = "TelerikMetro";
            this.dateTo.Value = new System.DateTime(2015, 4, 8, 19, 35, 37, 978);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radLabel1.Location = new System.Drawing.Point(5, 70);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 26);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "To :";
            // 
            // FrmConditionForReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 451);
            this.Controls.Add(this.radSplitContainer1);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmConditionForReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condition";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitKTV)).EndInit();
            this.splitKTV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCustomer)).EndInit();
            this.splitCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDate)).EndInit();
            this.splitDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKTV.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomer.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitKTV;
        private Telerik.WinControls.UI.SplitPanel splitCustomer;
        private Telerik.WinControls.UI.SplitPanel splitDate;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadGridView dtgKTV;
        private Telerik.WinControls.UI.RadGridView dtgCustomer;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lbCustomerName;
        private Telerik.WinControls.UI.RadDateTimePicker dateTo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker dateFrom;
    }
}
