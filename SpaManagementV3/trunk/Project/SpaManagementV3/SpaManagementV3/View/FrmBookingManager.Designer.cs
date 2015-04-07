﻿namespace SpaManagementV3.View
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.ConditionalFormattingObject conditionalFormattingObject2 = new Telerik.WinControls.UI.ConditionalFormattingObject();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor2 = new Telerik.WinControls.Data.SortDescriptor();
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
        //    this.btnEndBooking.Image = global::SpaManagementV3.Properties.Resources.Check;
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
            conditionalFormattingObject2.ApplyToRow = true;
            conditionalFormattingObject2.CellBackColor = System.Drawing.Color.Silver;
            conditionalFormattingObject2.CellFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            conditionalFormattingObject2.CellForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.Name = "Cancelled";
            conditionalFormattingObject2.RowBackColor = System.Drawing.Color.Silver;
            conditionalFormattingObject2.RowFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            conditionalFormattingObject2.RowForeColor = System.Drawing.Color.Empty;
            conditionalFormattingObject2.TValue1 = "Cancelled";
            gridViewComboBoxColumn2.ConditionalFormattingObjectList.Add(conditionalFormattingObject2);
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.HeaderText = "Status";
            gridViewComboBoxColumn2.Name = "column7";
            gridViewComboBoxColumn2.Width = 65;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn2.FormatString = "{0:HH:mm}";
            gridViewDateTimeColumn2.HeaderText = "Time";
            gridViewDateTimeColumn2.Name = "column1";
            gridViewDateTimeColumn2.Width = 54;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.HeaderText = "Customer";
            gridViewTextBoxColumn8.Name = "column2";
            gridViewTextBoxColumn8.Width = 80;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.HeaderText = "Location";
            gridViewTextBoxColumn9.Name = "colLocation";
            gridViewTextBoxColumn9.Width = 87;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.HeaderText = "KTV";
            gridViewTextBoxColumn10.Name = "column3";
            gridViewTextBoxColumn10.Width = 91;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.HeaderText = "Room";
            gridViewTextBoxColumn11.Name = "column4";
            gridViewTextBoxColumn11.Width = 85;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.HeaderText = "Service";
            gridViewTextBoxColumn12.Name = "column5";
            gridViewTextBoxColumn12.Width = 94;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.HeaderText = "Package";
            gridViewTextBoxColumn13.Name = "column6";
            gridViewTextBoxColumn13.Width = 98;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.HeaderText = "Note";
            gridViewTextBoxColumn14.Name = "column8";
            gridViewTextBoxColumn14.Width = 83;
            this.dtgBooking.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn2,
            gridViewComboBoxColumn2,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.dtgBooking.MasterTemplate.EnableGrouping = false;
            this.dtgBooking.MasterTemplate.EnableSorting = false;
            this.dtgBooking.MasterTemplate.ShowHeaderCellButtons = true;
            sortDescriptor2.PropertyName = "colName";
            this.dtgBooking.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor2});
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
