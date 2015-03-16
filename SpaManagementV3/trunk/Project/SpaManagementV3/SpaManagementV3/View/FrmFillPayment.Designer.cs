namespace SpaManagementV3.View
{
    partial class FrmFillPayment
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
            this.listBill = new Telerik.WinControls.UI.RadListControl();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.spinBillNumber = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel32 = new Telerik.WinControls.UI.RadLabel();
            this.spinTotal = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel35 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.spinVisa = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.spinUSD = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.spinVND = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel33 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtNote = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.chkErrorBill = new Telerik.WinControls.UI.RadCheckBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.listBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinBillNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinVisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUSD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVND)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErrorBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // listBill
            // 
            this.listBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBill.Location = new System.Drawing.Point(2, 25);
            this.listBill.Name = "listBill";
            this.listBill.Size = new System.Drawing.Size(109, 147);
            this.listBill.TabIndex = 0;
            this.listBill.ThemeName = "TelerikMetro";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.listBill);
            this.radGroupBox1.HeaderText = "Not Fullfil Bill";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 25, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(113, 174);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.Text = "Not Fullfil Bill";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // spinBillNumber
            // 
            this.spinBillNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinBillNumber.Location = new System.Drawing.Point(207, 1);
            this.spinBillNumber.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinBillNumber.Name = "spinBillNumber";
            this.spinBillNumber.ShowUpDownButtons = false;
            this.spinBillNumber.Size = new System.Drawing.Size(82, 26);
            this.spinBillNumber.TabIndex = 44;
            this.spinBillNumber.TabStop = false;
            this.spinBillNumber.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinBillNumber.ThemeName = "TelerikMetro";
            this.spinBillNumber.ThousandsSeparator = true;
            // 
            // radLabel32
            // 
            this.radLabel32.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel32.Location = new System.Drawing.Point(124, 4);
            this.radLabel32.Name = "radLabel32";
            this.radLabel32.Size = new System.Drawing.Size(77, 19);
            this.radLabel32.TabIndex = 43;
            this.radLabel32.Text = "Bill Number :";
            // 
            // spinTotal
            // 
            this.spinTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinTotal.Location = new System.Drawing.Point(401, 1);
            this.spinTotal.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinTotal.Name = "spinTotal";
            this.spinTotal.ReadOnly = true;
            this.spinTotal.ShowUpDownButtons = false;
            this.spinTotal.Size = new System.Drawing.Size(82, 26);
            this.spinTotal.TabIndex = 55;
            this.spinTotal.TabStop = false;
            this.spinTotal.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinTotal.ThemeName = "TelerikMetro";
            this.spinTotal.ThousandsSeparator = true;
            // 
            // radLabel35
            // 
            this.radLabel35.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel35.Location = new System.Drawing.Point(355, 4);
            this.radLabel35.Name = "radLabel35";
            this.radLabel35.Size = new System.Drawing.Size(40, 19);
            this.radLabel35.TabIndex = 54;
            this.radLabel35.Text = "Total :";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.spinVisa);
            this.radGroupBox3.Controls.Add(this.radLabel2);
            this.radGroupBox3.Controls.Add(this.spinUSD);
            this.radGroupBox3.Controls.Add(this.radLabel1);
            this.radGroupBox3.Controls.Add(this.spinVND);
            this.radGroupBox3.Controls.Add(this.radLabel33);
            this.radGroupBox3.HeaderText = "Cash";
            this.radGroupBox3.Location = new System.Drawing.Point(122, 29);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Padding = new System.Windows.Forms.Padding(2, 25, 2, 2);
            this.radGroupBox3.Size = new System.Drawing.Size(574, 63);
            this.radGroupBox3.TabIndex = 6;
            this.radGroupBox3.Text = "Cash";
            this.radGroupBox3.ThemeName = "TelerikMetro";
            // 
            // spinVisa
            // 
            this.spinVisa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinVisa.Location = new System.Drawing.Point(474, 28);
            this.spinVisa.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinVisa.Name = "spinVisa";
            this.spinVisa.Size = new System.Drawing.Size(82, 26);
            this.spinVisa.TabIndex = 61;
            this.spinVisa.TabStop = false;
            this.spinVisa.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinVisa.ThemeName = "TelerikMetro";
            this.spinVisa.ThousandsSeparator = true;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(433, 29);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(35, 19);
            this.radLabel2.TabIndex = 60;
            this.radLabel2.Text = "Visa :";
            // 
            // spinUSD
            // 
            this.spinUSD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinUSD.Location = new System.Drawing.Point(279, 28);
            this.spinUSD.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinUSD.Name = "spinUSD";
            this.spinUSD.Size = new System.Drawing.Size(82, 26);
            this.spinUSD.TabIndex = 59;
            this.spinUSD.TabStop = false;
            this.spinUSD.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinUSD.ThemeName = "TelerikMetro";
            this.spinUSD.ThousandsSeparator = true;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(237, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(36, 19);
            this.radLabel1.TabIndex = 58;
            this.radLabel1.Text = "USD :";
            // 
            // spinVND
            // 
            this.spinVND.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinVND.Location = new System.Drawing.Point(85, 28);
            this.spinVND.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.spinVND.Name = "spinVND";
            this.spinVND.Size = new System.Drawing.Size(82, 26);
            this.spinVND.TabIndex = 57;
            this.spinVND.TabStop = false;
            this.spinVND.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinVND.ThemeName = "TelerikMetro";
            this.spinVND.ThousandsSeparator = true;
            // 
            // radLabel33
            // 
            this.radLabel33.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel33.Location = new System.Drawing.Point(41, 29);
            this.radLabel33.Name = "radLabel33";
            this.radLabel33.Size = new System.Drawing.Size(38, 19);
            this.radLabel33.TabIndex = 56;
            this.radLabel33.Text = "VND :";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.txtNote);
            this.radGroupBox4.Controls.Add(this.radLabel8);
            this.radGroupBox4.Controls.Add(this.chkErrorBill);
            this.radGroupBox4.HeaderText = "";
            this.radGroupBox4.Location = new System.Drawing.Point(122, 98);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Padding = new System.Windows.Forms.Padding(2, 25, 2, 2);
            this.radGroupBox4.Size = new System.Drawing.Size(574, 77);
            this.radGroupBox4.TabIndex = 57;
            this.radGroupBox4.ThemeName = "TelerikMetro";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNote.Location = new System.Drawing.Point(75, 39);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(490, 26);
            this.txtNote.TabIndex = 69;
            this.txtNote.ThemeName = "TelerikMetro";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radLabel8.Location = new System.Drawing.Point(17, 40);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(52, 19);
            this.radLabel8.TabIndex = 68;
            this.radLabel8.Text = "Reason :";
            // 
            // chkErrorBill
            // 
            this.chkErrorBill.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkErrorBill.Location = new System.Drawing.Point(15, 14);
            this.chkErrorBill.Name = "chkErrorBill";
            this.chkErrorBill.Size = new System.Drawing.Size(140, 24);
            this.chkErrorBill.TabIndex = 39;
            this.chkErrorBill.Text = "Mark as error bill";
            this.chkErrorBill.ThemeName = "TelerikMetro";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::SpaManagementV3.Properties.Resources.Save;
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(599, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 24);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.ThemeName = "TelerikMetro";
            // 
            // FrmFillPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 207);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radGroupBox4);
            this.Controls.Add(this.spinTotal);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radLabel35);
            this.Controls.Add(this.spinBillNumber);
            this.Controls.Add(this.radLabel32);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFillPayment";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fill Payment";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.listBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinBillNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            this.radGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinVisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUSD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinVND)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            this.radGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkErrorBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadListControl listBill;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadSpinEditor spinBillNumber;
        private Telerik.WinControls.UI.RadLabel radLabel32;
        private Telerik.WinControls.UI.RadSpinEditor spinTotal;
        private Telerik.WinControls.UI.RadLabel radLabel35;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadSpinEditor spinVisa;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadSpinEditor spinUSD;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadSpinEditor spinVND;
        private Telerik.WinControls.UI.RadLabel radLabel33;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadTextBox txtNote;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadCheckBox chkErrorBill;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}
