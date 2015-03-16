namespace SpaManagementV3.View.Template
{
    partial class FrmBedSetting
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
            this.spinDuration = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel33 = new Telerik.WinControls.UI.RadLabel();
            this.timeStart = new Telerik.WinControls.UI.RadTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cbbxService = new Telerik.WinControls.UI.RadDropDownList();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.autoCompleteKTV = new Telerik.WinControls.UI.RadAutoCompleteBox();
            this.btnStart = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoCompleteKTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // spinDuration
            // 
            this.spinDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinDuration.Location = new System.Drawing.Point(84, 46);
            this.spinDuration.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.spinDuration.Name = "spinDuration";
            this.spinDuration.Size = new System.Drawing.Size(109, 26);
            this.spinDuration.TabIndex = 59;
            this.spinDuration.TabStop = false;
            this.spinDuration.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.spinDuration.ThemeName = "TelerikMetro";
            this.spinDuration.ThousandsSeparator = true;
            // 
            // radLabel33
            // 
            this.radLabel33.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel33.Location = new System.Drawing.Point(3, 48);
            this.radLabel33.Name = "radLabel33";
            this.radLabel33.Size = new System.Drawing.Size(75, 24);
            this.radLabel33.TabIndex = 58;
            this.radLabel33.Text = "Duration :";
            // 
            // timeStart
            // 
            this.timeStart.Location = new System.Drawing.Point(84, 12);
            this.timeStart.MaxValue = new System.DateTime(2215, 1, 27, 0, 0, 0, 0);
            this.timeStart.MinValue = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.timeStart.Name = "timeStart";
            this.timeStart.Size = new System.Drawing.Size(109, 28);
            this.timeStart.TabIndex = 60;
            this.timeStart.TabStop = false;
            this.timeStart.Text = "radTimePicker1";
            this.timeStart.ThemeName = "TelerikMetro";
            this.timeStart.Value = new System.DateTime(2014, 11, 5, 22, 0, 42, 584);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(3, 16);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(64, 24);
            this.radLabel1.TabIndex = 61;
            this.radLabel1.Text = "Start at :";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(3, 80);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(63, 24);
            this.radLabel2.TabIndex = 62;
            this.radLabel2.Text = "Service :";
            // 
            // cbbxService
            // 
            this.cbbxService.AllowShowFocusCues = false;
            this.cbbxService.AutoCompleteDisplayMember = null;
            this.cbbxService.AutoCompleteValueMember = null;
            this.cbbxService.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cbbxService.Location = new System.Drawing.Point(84, 78);
            this.cbbxService.Name = "cbbxService";
            this.cbbxService.Size = new System.Drawing.Size(165, 26);
            this.cbbxService.TabIndex = 63;
            this.cbbxService.ThemeName = "TelerikMetro";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radLabel4);
            this.radPanel1.Controls.Add(this.autoCompleteKTV);
            this.radPanel1.Controls.Add(this.radLabel3);
            this.radPanel1.Controls.Add(this.cbbxService);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.radLabel2);
            this.radPanel1.Controls.Add(this.timeStart);
            this.radPanel1.Controls.Add(this.spinDuration);
            this.radPanel1.Controls.Add(this.radLabel33);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(258, 157);
            this.radPanel1.TabIndex = 64;
            this.radPanel1.ThemeName = "TelerikMetro";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(3, 118);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(42, 24);
            this.radLabel4.TabIndex = 74;
            this.radLabel4.Text = "KTV :";
            // 
            // autoCompleteKTV
            // 
            this.autoCompleteKTV.Location = new System.Drawing.Point(84, 110);
            this.autoCompleteKTV.Name = "autoCompleteKTV";
            this.autoCompleteKTV.Size = new System.Drawing.Size(165, 32);
            this.autoCompleteKTV.TabIndex = 73;
            this.autoCompleteKTV.ThemeName = "TelerikMetro";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Image = global::SpaManagementV3.Properties.Resources.Start_small;
            this.btnStart.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStart.Location = new System.Drawing.Point(84, 163);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 40);
            this.btnStart.TabIndex = 71;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStart.ThemeName = "TelerikMetro";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(200, 48);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(49, 24);
            this.radLabel3.TabIndex = 70;
            this.radLabel3.Text = "(mins)";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::SpaManagementV3.Properties.Resources.Delete;
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(170, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 40);
            this.btnCancel.TabIndex = 72;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.ThemeName = "TelerikMetro";
            // 
            // FrmBedSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 205);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBedSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bed Setting";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.spinDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbxService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoCompleteKTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadSpinEditor spinDuration;
        private Telerik.WinControls.UI.RadLabel radLabel33;
        private Telerik.WinControls.UI.RadTimePicker timeStart;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList cbbxService;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnStart;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadAutoCompleteBox autoCompleteKTV;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
