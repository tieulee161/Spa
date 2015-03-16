namespace SpaManagementV3.View
{
    partial class FrmSystemData
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtBill = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtDatabase = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtFolder = new Telerik.WinControls.UI.RadBrowseEditor();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.spinPeriod = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.txtBill);
            this.radGroupBox1.Controls.Add(this.txtDatabase);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.HeaderText = "Email";
            this.radGroupBox1.Location = new System.Drawing.Point(16, 16);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(424, 97);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Email";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // txtBill
            // 
            this.txtBill.Location = new System.Drawing.Point(95, 57);
            this.txtBill.MaskType = Telerik.WinControls.UI.MaskType.EMail;
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(300, 22);
            this.txtBill.TabIndex = 24;
            this.txtBill.TabStop = false;
            this.txtBill.ThemeName = "TelerikMetro";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(95, 29);
            this.txtDatabase.MaskType = Telerik.WinControls.UI.MaskType.EMail;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(300, 22);
            this.txtDatabase.TabIndex = 23;
            this.txtDatabase.TabStop = false;
            this.txtDatabase.ThemeName = "TelerikMetro";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(26, 58);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(29, 19);
            this.radLabel7.TabIndex = 22;
            this.radLabel7.Text = "Bill :";
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(26, 30);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(63, 19);
            this.radLabel6.TabIndex = 20;
            this.radLabel6.Text = "Database :";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.txtFolder);
            this.radGroupBox2.Controls.Add(this.radLabel3);
            this.radGroupBox2.Controls.Add(this.spinPeriod);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.HeaderText = "Back up";
            this.radGroupBox2.Location = new System.Drawing.Point(16, 119);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(424, 97);
            this.radGroupBox2.TabIndex = 2;
            this.radGroupBox2.Text = "Back up";
            this.radGroupBox2.ThemeName = "TelerikMetro";
            // 
            // txtFolder
            // 
            this.txtFolder.DialogType = Telerik.WinControls.UI.BrowseEditorDialogType.FolderBrowseDialog;
            this.txtFolder.Location = new System.Drawing.Point(95, 26);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(300, 23);
            this.txtFolder.TabIndex = 26;
            this.txtFolder.Text = "radBrowseEditor1";
            this.txtFolder.ThemeName = "TelerikMetro";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(159, 58);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(46, 19);
            this.radLabel3.TabIndex = 25;
            this.radLabel3.Text = "( days )";
            // 
            // spinPeriod
            // 
            this.spinPeriod.Location = new System.Drawing.Point(95, 57);
            this.spinPeriod.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinPeriod.Name = "spinPeriod";
            this.spinPeriod.Size = new System.Drawing.Size(58, 22);
            this.spinPeriod.TabIndex = 24;
            this.spinPeriod.TabStop = false;
            this.spinPeriod.ThemeName = "TelerikMetro";
            this.spinPeriod.ThousandsSeparator = true;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(26, 58);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(48, 19);
            this.radLabel1.TabIndex = 22;
            this.radLabel1.Text = "Period :";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(26, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(47, 19);
            this.radLabel2.TabIndex = 20;
            this.radLabel2.Text = "Folder :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = global::SpaManagementV3.Properties.Resources.Save;
            this.btnUpdate.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdate.Location = new System.Drawing.Point(330, 227);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 24);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.ThemeName = "TelerikMetro";
            // 
            // FrmSystemData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 257);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSystemData";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Data";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.FrmSystemData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadMaskedEditBox txtBill;
        private Telerik.WinControls.UI.RadMaskedEditBox txtDatabase;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadBrowseEditor txtFolder;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadSpinEditor spinPeriod;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnUpdate;
    }
}
