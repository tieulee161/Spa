namespace SpaManagementV3.View
{
    partial class FrmPayment
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
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.panelBrowser = new Telerik.WinControls.UI.SplitPanel();
            this.dateSearch = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.treeBrowser = new Telerik.WinControls.UI.RadTreeView();
            this.panelInfo = new Telerik.WinControls.UI.SplitPanel();
            this.panelPayment = new Telerik.WinControls.UI.SplitPanel();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnDestroyBill = new Telerik.WinControls.UI.RadButton();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.txtReason = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSavePayment = new Telerik.WinControls.UI.RadButton();
            this.spinVisa = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.spinUSD = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.spinVND = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel33 = new Telerik.WinControls.UI.RadLabel();
            this.billInfo = new SpaManagementV3.View.Template.UCBillTemplate();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBrowser)).BeginInit();
            this.panelBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfo)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPayment)).BeginInit();
            this.panelPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDestroyBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.panelBrowser);
            this.radSplitContainer1.Controls.Add(this.panelInfo);
            this.radSplitContainer1.Controls.Add(this.panelPayment);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.radSplitContainer1.Size = new System.Drawing.Size(1272, 675);
            this.radSplitContainer1.TabIndex = 0;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            this.radSplitContainer1.ThemeName = "TelerikMetro";
            // 
            // panelBrowser
            // 
            this.panelBrowser.Controls.Add(this.dateSearch);
            this.panelBrowser.Controls.Add(this.radLabel1);
            this.panelBrowser.Controls.Add(this.treeBrowser);
            this.panelBrowser.Location = new System.Drawing.Point(0, 0);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            // 
            // 
            // 
            this.panelBrowser.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.panelBrowser.Size = new System.Drawing.Size(150, 675);
            this.panelBrowser.SizeInfo.AbsoluteSize = new System.Drawing.Size(150, 200);
            this.panelBrowser.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.2138713F, 0F);
            this.panelBrowser.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Absolute;
            this.panelBrowser.SizeInfo.SplitterCorrection = new System.Drawing.Size(-320, 0);
            this.panelBrowser.TabIndex = 0;
            this.panelBrowser.TabStop = false;
            this.panelBrowser.Text = "splitPanel1";
            this.panelBrowser.ThemeName = "TelerikMetro";
            // 
            // dateSearch
            // 
            this.dateSearch.CustomFormat = "MM/yyyy";
            this.dateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateSearch.Location = new System.Drawing.Point(57, 8);
            this.dateSearch.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dateSearch.Name = "dateSearch";
            this.dateSearch.Size = new System.Drawing.Size(86, 26);
            this.dateSearch.TabIndex = 2;
            this.dateSearch.TabStop = false;
            this.dateSearch.Text = "01/2015";
            this.dateSearch.ThemeName = "TelerikMetro";
            this.dateSearch.Value = new System.DateTime(2015, 1, 26, 20, 16, 27, 623);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel1.Location = new System.Drawing.Point(4, 10);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(47, 24);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Date :";
            // 
            // treeBrowser
            // 
            this.treeBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBrowser.Location = new System.Drawing.Point(0, 40);
            this.treeBrowser.Name = "treeBrowser";
            this.treeBrowser.Size = new System.Drawing.Size(150, 635);
            this.treeBrowser.TabIndex = 0;
            this.treeBrowser.ThemeName = "TelerikMetro";
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.billInfo);
            this.panelInfo.Location = new System.Drawing.Point(154, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.panelInfo.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.panelInfo.Size = new System.Drawing.Size(893, 675);
            this.panelInfo.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.2996422F, 0F);
            this.panelInfo.SizeInfo.SplitterCorrection = new System.Drawing.Size(733, 0);
            this.panelInfo.TabIndex = 1;
            this.panelInfo.TabStop = false;
            this.panelInfo.Text = "splitPanel2";
            this.panelInfo.ThemeName = "TelerikMetro";
            // 
            // panelPayment
            // 
            this.panelPayment.Controls.Add(this.radGroupBox4);
            this.panelPayment.Controls.Add(this.radGroupBox3);
            this.panelPayment.Location = new System.Drawing.Point(1051, 0);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.panelPayment.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.panelPayment.Size = new System.Drawing.Size(221, 675);
            this.panelPayment.SizeInfo.AbsoluteSize = new System.Drawing.Size(221, 200);
            this.panelPayment.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.30322F, 0F);
            this.panelPayment.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Absolute;
            this.panelPayment.SizeInfo.SplitterCorrection = new System.Drawing.Size(-413, 0);
            this.panelPayment.TabIndex = 2;
            this.panelPayment.TabStop = false;
            this.panelPayment.Text = "splitPanel3";
            this.panelPayment.ThemeName = "TelerikMetro";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.btnDestroyBill);
            this.radGroupBox4.Controls.Add(this.radLabel8);
            this.radGroupBox4.Controls.Add(this.txtReason);
            this.radGroupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox4.HeaderText = "";
            this.radGroupBox4.Location = new System.Drawing.Point(5, 187);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Padding = new System.Windows.Forms.Padding(2, 30, 2, 54);
            this.radGroupBox4.Size = new System.Drawing.Size(211, 272);
            this.radGroupBox4.TabIndex = 58;
            this.radGroupBox4.ThemeName = "TelerikMetro";
            // 
            // btnDestroyBill
            // 
            this.btnDestroyBill.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDestroyBill.Image = global::SpaManagementV3.Properties.Resources.Delete;
            this.btnDestroyBill.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDestroyBill.Location = new System.Drawing.Point(46, 224);
            this.btnDestroyBill.Name = "btnDestroyBill";
            this.btnDestroyBill.Size = new System.Drawing.Size(142, 40);
            this.btnDestroyBill.TabIndex = 70;
            this.btnDestroyBill.Text = "Destroy bill";
            this.btnDestroyBill.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDestroyBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDestroyBill.ThemeName = "TelerikMetro";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel8.Location = new System.Drawing.Point(5, 6);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(65, 24);
            this.radLabel8.TabIndex = 68;
            this.radLabel8.Text = "Reason :";
            // 
            // txtReason
            // 
            this.txtReason.AutoSize = false;
            this.txtReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReason.Location = new System.Drawing.Point(2, 30);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(207, 188);
            this.txtReason.TabIndex = 69;
            this.txtReason.ThemeName = "TelerikMetro";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.btnSavePayment);
            this.radGroupBox3.Controls.Add(this.spinVisa);
            this.radGroupBox3.Controls.Add(this.radLabel2);
            this.radGroupBox3.Controls.Add(this.spinUSD);
            this.radGroupBox3.Controls.Add(this.radLabel3);
            this.radGroupBox3.Controls.Add(this.spinVND);
            this.radGroupBox3.Controls.Add(this.radLabel33);
            this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox3.HeaderText = "Payment";
            this.radGroupBox3.Location = new System.Drawing.Point(5, 5);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Padding = new System.Windows.Forms.Padding(2, 25, 2, 2);
            this.radGroupBox3.Size = new System.Drawing.Size(211, 182);
            this.radGroupBox3.TabIndex = 7;
            this.radGroupBox3.Text = "Payment";
            this.radGroupBox3.ThemeName = "TelerikMetro";
            // 
            // btnSavePayment
            // 
            this.btnSavePayment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePayment.Image = global::SpaManagementV3.Properties.Resources.Save;
            this.btnSavePayment.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSavePayment.Location = new System.Drawing.Point(82, 133);
            this.btnSavePayment.Name = "btnSavePayment";
            this.btnSavePayment.Size = new System.Drawing.Size(106, 40);
            this.btnSavePayment.TabIndex = 62;
            this.btnSavePayment.Text = "Save";
            this.btnSavePayment.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSavePayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSavePayment.ThemeName = "TelerikMetro";
            // 
            // spinVisa
            // 
            this.spinVisa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinVisa.Location = new System.Drawing.Point(82, 100);
            this.spinVisa.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinVisa.Name = "spinVisa";
            this.spinVisa.Size = new System.Drawing.Size(106, 26);
            this.spinVisa.TabIndex = 61;
            this.spinVisa.TabStop = false;
            this.spinVisa.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinVisa.ThemeName = "TelerikMetro";
            this.spinVisa.ThousandsSeparator = true;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(29, 101);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(43, 24);
            this.radLabel2.TabIndex = 60;
            this.radLabel2.Text = "Visa :";
            // 
            // spinUSD
            // 
            this.spinUSD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinUSD.Location = new System.Drawing.Point(82, 68);
            this.spinUSD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinUSD.Name = "spinUSD";
            this.spinUSD.Size = new System.Drawing.Size(106, 26);
            this.spinUSD.TabIndex = 59;
            this.spinUSD.TabStop = false;
            this.spinUSD.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinUSD.ThemeName = "TelerikMetro";
            this.spinUSD.ThousandsSeparator = true;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(29, 69);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(45, 24);
            this.radLabel3.TabIndex = 58;
            this.radLabel3.Text = "USD :";
            // 
            // spinVND
            // 
            this.spinVND.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinVND.Location = new System.Drawing.Point(82, 35);
            this.spinVND.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinVND.Name = "spinVND";
            this.spinVND.Size = new System.Drawing.Size(106, 26);
            this.spinVND.TabIndex = 57;
            this.spinVND.TabStop = false;
            this.spinVND.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinVND.ThemeName = "TelerikMetro";
            this.spinVND.ThousandsSeparator = true;
            // 
            // radLabel33
            // 
            this.radLabel33.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel33.Location = new System.Drawing.Point(29, 37);
            this.radLabel33.Name = "radLabel33";
            this.radLabel33.Size = new System.Drawing.Size(47, 24);
            this.radLabel33.TabIndex = 56;
            this.radLabel33.Text = "VND :";
            // 
            // billInfo
            // 
            this.billInfo.BackColor = System.Drawing.Color.White;
            this.billInfo.Bill = null;
            this.billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billInfo.Location = new System.Drawing.Point(5, 5);
            this.billInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.billInfo.Name = "billInfo";
            this.billInfo.Size = new System.Drawing.Size(883, 665);
            this.billInfo.TabIndex = 0;
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 675);
            this.Controls.Add(this.radSplitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmPayment";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBrowser)).EndInit();
            this.panelBrowser.ResumeLayout(false);
            this.panelBrowser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelInfo)).EndInit();
            this.panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelPayment)).EndInit();
            this.panelPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDestroyBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel panelBrowser;
        private Telerik.WinControls.UI.RadDateTimePicker dateSearch;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTreeView treeBrowser;
        private Telerik.WinControls.UI.SplitPanel panelInfo;
        private Telerik.WinControls.UI.SplitPanel panelPayment;
        private Template.UCBillTemplate billInfo;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadSpinEditor spinVisa;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadSpinEditor spinUSD;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadSpinEditor spinVND;
        private Telerik.WinControls.UI.RadLabel radLabel33;
        private Telerik.WinControls.UI.RadButton btnSavePayment;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadButton btnDestroyBill;
        private Telerik.WinControls.UI.RadTextBox txtReason;
        private Telerik.WinControls.UI.RadLabel radLabel8;
    }
}
