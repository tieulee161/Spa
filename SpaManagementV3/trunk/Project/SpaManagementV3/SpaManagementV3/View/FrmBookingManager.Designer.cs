namespace SpaManagementV3.View
{
    partial class FrmBookingManager
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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject1 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.calendar = new Telerik.WinControls.UI.RadCalendar();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnEndBooking = new Telerik.WinControls.UI.RadButton();
            this.btnCancelBooking = new Telerik.WinControls.UI.RadButton();
            this.btnDeleteBooking = new Telerik.WinControls.UI.RadButton();
            this.btnEditBooking = new Telerik.WinControls.UI.RadButton();
            this.btnNewBooking = new Telerik.WinControls.UI.RadButton();
            this.dtgBooking = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEndBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBooking.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.calendar);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radGroupBox1.HeaderText = "Calendar";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 36);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 30, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(287, 574);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Calendar";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // calendar
            // 
            this.calendar.AllowMultipleView = true;
            this.calendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.calendar.Location = new System.Drawing.Point(2, 30);
            this.calendar.Name = "calendar";
            this.calendar.ShowOtherMonthsDays = false;
            this.calendar.Size = new System.Drawing.Size(283, 530);
            this.calendar.TabIndex = 0;
            this.calendar.Text = "radCalendar1";
            this.calendar.ThemeName = "TelerikMetro";
            this.calendar.ZoomFactor = 1.2F;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnEndBooking);
            this.radPanel1.Controls.Add(this.btnCancelBooking);
            this.radPanel1.Controls.Add(this.btnDeleteBooking);
            this.radPanel1.Controls.Add(this.btnEditBooking);
            this.radPanel1.Controls.Add(this.btnNewBooking);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1036, 36);
            this.radPanel1.TabIndex = 3;
            this.radPanel1.ThemeName = "TelerikMetro";
            // 
            // btnEndBooking
            // 
            this.btnEndBooking.Image = global::SpaManagementV3.Properties.Resources.Check;
            this.btnEndBooking.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEndBooking.Location = new System.Drawing.Point(528, 6);
            this.btnEndBooking.Name = "btnEndBooking";
            this.btnEndBooking.Size = new System.Drawing.Size(123, 24);
            this.btnEndBooking.TabIndex = 5;
            this.btnEndBooking.Text = "End Booking";
            this.btnEndBooking.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEndBooking.ThemeName = "TelerikMetro";
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Image = global::SpaManagementV3.Properties.Resources.Recycle;
            this.btnCancelBooking.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelBooking.Location = new System.Drawing.Point(399, 6);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(123, 24);
            this.btnCancelBooking.TabIndex = 4;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelBooking.ThemeName = "TelerikMetro";
            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.Image = global::SpaManagementV3.Properties.Resources.Delete;
            this.btnDeleteBooking.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteBooking.Location = new System.Drawing.Point(270, 6);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(123, 24);
            this.btnDeleteBooking.TabIndex = 3;
            this.btnDeleteBooking.Text = "Delete Booking";
            this.btnDeleteBooking.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteBooking.ThemeName = "TelerikMetro";
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.Image = global::SpaManagementV3.Properties.Resources.Edit;
            this.btnEditBooking.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditBooking.Location = new System.Drawing.Point(141, 6);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(123, 24);
            this.btnEditBooking.TabIndex = 2;
            this.btnEditBooking.Text = "Edit Booking";
            this.btnEditBooking.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditBooking.ThemeName = "TelerikMetro";
            // 
            // btnNewBooking
            // 
            this.btnNewBooking.Image = global::SpaManagementV3.Properties.Resources.Add;
            this.btnNewBooking.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewBooking.Location = new System.Drawing.Point(12, 6);
            this.btnNewBooking.Name = "btnNewBooking";
            this.btnNewBooking.Size = new System.Drawing.Size(123, 24);
            this.btnNewBooking.TabIndex = 1;
            this.btnNewBooking.Text = "New Booking";
            this.btnNewBooking.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewBooking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewBooking.ThemeName = "TelerikMetro";
            // 
            // dtgBooking
            // 
            this.dtgBooking.BackColor = System.Drawing.Color.White;
            this.dtgBooking.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgBooking.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtgBooking.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgBooking.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgBooking.Location = new System.Drawing.Point(287, 36);
            // 
            // dtgBooking
            // 
            this.dtgBooking.MasterTemplate.AllowAddNewRow = false;
            this.dtgBooking.MasterTemplate.AllowCellContextMenu = false;
            this.dtgBooking.MasterTemplate.AllowDeleteRow = false;
            this.dtgBooking.MasterTemplate.AllowRowResize = false;
            this.dtgBooking.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
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
            conditionalFormattingObject1.ApplyToRow = true;
            conditionalFormattingObject1.CellBackColor = System.Drawing.Color.Silver;
            conditionalFormattingObject1.CellFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            conditionalFormattingObject1.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.Name = "Cancelled";
            conditionalFormattingObject1.RowBackColor = System.Drawing.Color.Silver;
            conditionalFormattingObject1.RowFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            conditionalFormattingObject1.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject1.TValue1 = "Cancelled";
            gridViewComboBoxColumn1.ConditionalFormattingObjectList.Add(conditionalFormattingObject1);
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.HeaderText = "Status";
            gridViewComboBoxColumn1.Name = "column7";
            gridViewComboBoxColumn1.Width = 65;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatString = "{0:HH:mm}";
            gridViewDateTimeColumn1.HeaderText = "Time";
            gridViewDateTimeColumn1.Name = "column1";
            gridViewDateTimeColumn1.Width = 54;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "Customer";
            gridViewTextBoxColumn1.Name = "column2";
            gridViewTextBoxColumn1.Width = 80;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Location";
            gridViewTextBoxColumn2.Name = "colLocation";
            gridViewTextBoxColumn2.Width = 87;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "KTV";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 91;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "Room";
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.Width = 85;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "Service";
            gridViewTextBoxColumn5.Name = "column5";
            gridViewTextBoxColumn5.Width = 94;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "Package";
            gridViewTextBoxColumn6.Name = "column6";
            gridViewTextBoxColumn6.Width = 98;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "Note";
            gridViewTextBoxColumn7.Name = "column8";
            gridViewTextBoxColumn7.Width = 83;
            this.dtgBooking.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewComboBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.dtgBooking.MasterTemplate.EnableGrouping = false;
            this.dtgBooking.MasterTemplate.EnableSorting = false;
            this.dtgBooking.MasterTemplate.ShowHeaderCellButtons = true;
            sortDescriptor1.PropertyName = "colName";
            this.dtgBooking.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.dtgBooking.Name = "dtgBooking";
            this.dtgBooking.ReadOnly = true;
            this.dtgBooking.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgBooking.ShowHeaderCellButtons = true;
            this.dtgBooking.Size = new System.Drawing.Size(749, 574);
            this.dtgBooking.TabIndex = 70;
            this.dtgBooking.ThemeName = "TelerikMetro";
            // 
            // FrmBookingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 610);
            this.Controls.Add(this.dtgBooking);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmBookingManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking Manager";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEndBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBooking.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnNewBooking;
        private Telerik.WinControls.UI.RadCalendar calendar;
        private Telerik.WinControls.UI.RadGridView dtgBooking;
        private Telerik.WinControls.UI.RadButton btnDeleteBooking;
        private Telerik.WinControls.UI.RadButton btnEditBooking;
        private Telerik.WinControls.UI.RadButton btnCancelBooking;
        private Telerik.WinControls.UI.RadButton btnEndBooking;
    }
}
