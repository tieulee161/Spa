namespace SpaManagementV3.View.Template
{
    partial class FrmAlarm
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
            this.btnDismiss = new Telerik.WinControls.UI.RadButton();
            this.btnSnooze = new Telerik.WinControls.UI.RadButton();
            this.btnDismissAll = new Telerik.WinControls.UI.RadButton();
            this.radListBox1 = new Telerik.WinControls.UI.RadListControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnDismiss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSnooze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDismissAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDismiss
            // 
            this.btnDismiss.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDismiss.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDismiss.Location = new System.Drawing.Point(0, 157);
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Size = new System.Drawing.Size(102, 24);
            this.btnDismiss.TabIndex = 4;
            this.btnDismiss.Text = "Dismiss";
            this.btnDismiss.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDismiss.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDismiss.ThemeName = "TelerikMetro";
            // 
            // btnSnooze
            // 
            this.btnSnooze.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnooze.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSnooze.Location = new System.Drawing.Point(422, 157);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(102, 24);
            this.btnSnooze.TabIndex = 5;
            this.btnSnooze.Text = "Snooze";
            this.btnSnooze.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnooze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSnooze.ThemeName = "TelerikMetro";
            // 
            // btnDismissAll
            // 
            this.btnDismissAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDismissAll.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDismissAll.Location = new System.Drawing.Point(108, 157);
            this.btnDismissAll.Name = "btnDismissAll";
            this.btnDismissAll.Size = new System.Drawing.Size(102, 24);
            this.btnDismissAll.TabIndex = 6;
            this.btnDismissAll.Text = "Dismiss All";
            this.btnDismissAll.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDismissAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDismissAll.ThemeName = "TelerikMetro";
            // 
            // radListBox1
            // 
            this.radListBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radListBox1.Location = new System.Drawing.Point(0, 0);
            this.radListBox1.Name = "radListBox1";
            this.radListBox1.Size = new System.Drawing.Size(524, 151);
            this.radListBox1.TabIndex = 7;
            this.radListBox1.ThemeName = "TelerikMetro";
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 186);
            this.Controls.Add(this.radListBox1);
            this.Controls.Add(this.btnDismissAll);
            this.Controls.Add(this.btnSnooze);
            this.Controls.Add(this.btnDismiss);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAlarm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = " Booking";
            this.ThemeName = "TelerikMetro";
            ((System.ComponentModel.ISupportInitialize)(this.btnDismiss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSnooze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDismissAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadButton btnDismiss;
        private Telerik.WinControls.UI.RadButton btnSnooze;
        private Telerik.WinControls.UI.RadButton btnDismissAll;
        private Telerik.WinControls.UI.RadListControl radListBox1;
    }
}