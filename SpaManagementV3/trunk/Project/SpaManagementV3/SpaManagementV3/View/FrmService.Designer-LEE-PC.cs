namespace SpaManagementV3.View
{
    partial class FrmService
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn2 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.pageMassage = new Telerik.WinControls.UI.RadPageViewPage();
            this.pagePackage = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageCertificate = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageMembership = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageOthers = new Telerik.WinControls.UI.RadPageViewPage();
            this.pagePromotion = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageRoom = new Telerik.WinControls.UI.RadPageViewPage();
            this.pageCurrency = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.txtMassageName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtMassageCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radSpinEditor1 = new Telerik.WinControls.UI.RadSpinEditor();
            this.radSpinEditor2 = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnAddService = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.pageMassage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassageName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.pageMassage);
            this.radPageView1.Controls.Add(this.pagePackage);
            this.radPageView1.Controls.Add(this.pageCertificate);
            this.radPageView1.Controls.Add(this.pageMembership);
            this.radPageView1.Controls.Add(this.pageOthers);
            this.radPageView1.Controls.Add(this.pagePromotion);
            this.radPageView1.Controls.Add(this.pageRoom);
            this.radPageView1.Controls.Add(this.pageCurrency);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.pageMassage;
            this.radPageView1.Size = new System.Drawing.Size(685, 381);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            this.radPageView1.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pageMassage
            // 
            this.pageMassage.Controls.Add(this.radGridView1);
            this.pageMassage.Controls.Add(this.radPanel1);
            this.pageMassage.ItemSize = new System.Drawing.SizeF(60F, 25F);
            this.pageMassage.Location = new System.Drawing.Point(5, 31);
            this.pageMassage.Name = "pageMassage";
            this.pageMassage.Size = new System.Drawing.Size(675, 345);
            this.pageMassage.Text = "Massage";
            // 
            // pagePackage
            // 
            this.pagePackage.ItemSize = new System.Drawing.SizeF(58F, 25F);
            this.pagePackage.Location = new System.Drawing.Point(0, 0);
            this.pagePackage.Name = "pagePackage";
            this.pagePackage.Size = new System.Drawing.Size(200, 100);
            this.pagePackage.Text = "Package";
            // 
            // pageCertificate
            // 
            this.pageCertificate.ItemSize = new System.Drawing.SizeF(141F, 25F);
            this.pageCertificate.Location = new System.Drawing.Point(0, 0);
            this.pageCertificate.Name = "pageCertificate";
            this.pageCertificate.Size = new System.Drawing.Size(200, 100);
            this.pageCertificate.Text = "Certificate/Gift Voucher";
            // 
            // pageMembership
            // 
            this.pageMembership.ItemSize = new System.Drawing.SizeF(81F, 25F);
            this.pageMembership.Location = new System.Drawing.Point(0, 0);
            this.pageMembership.Name = "pageMembership";
            this.pageMembership.Size = new System.Drawing.Size(200, 100);
            this.pageMembership.Text = "Membership";
            // 
            // pageOthers
            // 
            this.pageOthers.ItemSize = new System.Drawing.SizeF(49F, 25F);
            this.pageOthers.Location = new System.Drawing.Point(0, 0);
            this.pageOthers.Name = "pageOthers";
            this.pageOthers.Size = new System.Drawing.Size(200, 100);
            this.pageOthers.Text = "Others";
            // 
            // pagePromotion
            // 
            this.pagePromotion.ItemSize = new System.Drawing.SizeF(70F, 25F);
            this.pagePromotion.Location = new System.Drawing.Point(0, 0);
            this.pagePromotion.Name = "pagePromotion";
            this.pagePromotion.Size = new System.Drawing.Size(200, 100);
            this.pagePromotion.Text = "Promotion";
            // 
            // pageRoom
            // 
            this.pageRoom.ItemSize = new System.Drawing.SizeF(45F, 25F);
            this.pageRoom.Location = new System.Drawing.Point(0, 0);
            this.pageRoom.Name = "pageRoom";
            this.pageRoom.Size = new System.Drawing.Size(200, 100);
            this.pageRoom.Text = "Room";
            // 
            // pageCurrency
            // 
            this.pageCurrency.ItemSize = new System.Drawing.SizeF(61F, 25F);
            this.pageCurrency.Location = new System.Drawing.Point(0, 0);
            this.pageCurrency.Name = "pageCurrency";
            this.pageCurrency.Size = new System.Drawing.Size(200, 100);
            this.pageCurrency.Text = "Currency";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radButton2);
            this.radPanel1.Controls.Add(this.radButton1);
            this.radPanel1.Controls.Add(this.btnAddService);
            this.radPanel1.Controls.Add(this.radLabel6);
            this.radPanel1.Controls.Add(this.radLabel5);
            this.radPanel1.Controls.Add(this.radSpinEditor2);
            this.radPanel1.Controls.Add(this.radLabel4);
            this.radPanel1.Controls.Add(this.radSpinEditor1);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.txtMassageCode);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.txtMassageName);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(675, 154);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.ThemeName = "TelerikMetro";
            // 
            // txtMassageName
            // 
            this.txtMassageName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMassageName.Location = new System.Drawing.Point(62, 14);
            this.txtMassageName.Name = "txtMassageName";
            this.txtMassageName.Size = new System.Drawing.Size(347, 22);
            this.txtMassageName.TabIndex = 7;
            this.txtMassageName.ThemeName = "TelerikMetro";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(16, 16);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(45, 19);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Name :";
            // 
            // txtMassageCode
            // 
            this.txtMassageCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMassageCode.Location = new System.Drawing.Point(62, 40);
            this.txtMassageCode.Name = "txtMassageCode";
            this.txtMassageCode.Size = new System.Drawing.Size(100, 22);
            this.txtMassageCode.TabIndex = 9;
            this.txtMassageCode.ThemeName = "TelerikMetro";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(16, 42);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(41, 19);
            this.radLabel1.TabIndex = 8;
            this.radLabel1.Text = "Code :";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(16, 67);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(39, 19);
            this.radLabel3.TabIndex = 10;
            this.radLabel3.Text = "Price :";
            // 
            // radSpinEditor1
            // 
            this.radSpinEditor1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSpinEditor1.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.radSpinEditor1.Location = new System.Drawing.Point(62, 67);
            this.radSpinEditor1.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.radSpinEditor1.Name = "radSpinEditor1";
            this.radSpinEditor1.Size = new System.Drawing.Size(100, 22);
            this.radSpinEditor1.TabIndex = 11;
            this.radSpinEditor1.TabStop = false;
            this.radSpinEditor1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.radSpinEditor1.ThemeName = "TelerikMetro";
            this.radSpinEditor1.ThousandsSeparator = true;
            // 
            // radSpinEditor2
            // 
            this.radSpinEditor2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSpinEditor2.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.radSpinEditor2.Location = new System.Drawing.Point(62, 94);
            this.radSpinEditor2.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.radSpinEditor2.Name = "radSpinEditor2";
            this.radSpinEditor2.Size = new System.Drawing.Size(100, 22);
            this.radSpinEditor2.TabIndex = 13;
            this.radSpinEditor2.TabStop = false;
            this.radSpinEditor2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.radSpinEditor2.ThemeName = "TelerikMetro";
            this.radSpinEditor2.ThousandsSeparator = true;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(16, 94);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(38, 19);
            this.radLabel4.TabIndex = 12;
            this.radLabel4.Text = "Tour :";
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(168, 69);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(40, 19);
            this.radLabel5.TabIndex = 14;
            this.radLabel5.Text = "(VND)";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(168, 96);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(40, 19);
            this.radLabel6.TabIndex = 15;
            this.radLabel6.Text = "(VND)";
            // 
            // radButton2
            // 
            this.radButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton2.Image = global::SpaManagementV3.Properties.Resources.Delete;
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton2.Location = new System.Drawing.Point(230, 121);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(78, 24);
            this.radButton2.TabIndex = 18;
            this.radButton2.Text = "Delete";
            this.radButton2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton2.ThemeName = "TelerikMetro";
            // 
            // radButton1
            // 
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.Image = global::SpaManagementV3.Properties.Resources.Save;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(146, 121);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(78, 24);
            this.radButton1.TabIndex = 17;
            this.radButton1.Text = "Update";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.ThemeName = "TelerikMetro";
            // 
            // btnAddService
            // 
            this.btnAddService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.Image = global::SpaManagementV3.Properties.Resources.Add;
            this.btnAddService.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddService.Location = new System.Drawing.Point(62, 121);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(78, 24);
            this.btnAddService.TabIndex = 16;
            this.btnAddService.Text = "Add";
            this.btnAddService.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddService.ThemeName = "TelerikMetro";
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGridView1.Location = new System.Drawing.Point(0, 154);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn1.DecimalPlaces = 0;
            gridViewDecimalColumn1.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewDecimalColumn1.HeaderText = "Id";
            gridViewDecimalColumn1.IsVisible = false;
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn1.Name = "colId";
            gridViewTextBoxColumn1.HeaderText = "Name";
            gridViewTextBoxColumn1.Name = "colName";
            gridViewTextBoxColumn1.Width = 165;
            gridViewTextBoxColumn2.HeaderText = "Code";
            gridViewTextBoxColumn2.Name = "colCode";
            gridViewTextBoxColumn2.Width = 165;
            gridViewDecimalColumn2.DecimalPlaces = 0;
            gridViewDecimalColumn2.HeaderText = "Price";
            gridViewDecimalColumn2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn2.Name = "colPrice";
            gridViewDecimalColumn2.Step = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            gridViewDecimalColumn2.ThousandsSeparator = true;
            gridViewDecimalColumn2.Width = 165;
            gridViewDecimalColumn3.DecimalPlaces = 0;
            gridViewDecimalColumn3.HeaderText = "Tour";
            gridViewDecimalColumn3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn3.Name = "colTour";
            gridViewDecimalColumn3.Step = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            gridViewDecimalColumn3.ThousandsSeparator = true;
            gridViewDecimalColumn3.Width = 163;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn2,
            gridViewDecimalColumn3});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(675, 191);
            this.radGridView1.TabIndex = 1;
            this.radGridView1.Text = "radGridView1";
            this.radGridView1.ThemeName = "TelerikMetro";
            this.radGridView1.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.Row_Formatting);
            // 
            // FrmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 381);
            this.Controls.Add(this.radPageView1);
            this.Name = "FrmService";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.pageMassage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassageName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMassageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSpinEditor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage pageMassage;
        private Telerik.WinControls.UI.RadPageViewPage pagePackage;
        private Telerik.WinControls.UI.RadPageViewPage pageCertificate;
        private Telerik.WinControls.UI.RadPageViewPage pageMembership;
        private Telerik.WinControls.UI.RadPageViewPage pageOthers;
        private Telerik.WinControls.UI.RadPageViewPage pagePromotion;
        private Telerik.WinControls.UI.RadPageViewPage pageRoom;
        private Telerik.WinControls.UI.RadPageViewPage pageCurrency;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadTextBox txtMassageCode;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtMassageName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadSpinEditor radSpinEditor2;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadSpinEditor radSpinEditor1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadButton btnAddService;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
