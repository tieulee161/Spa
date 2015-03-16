namespace SpaManagementV3.View.Template
{
    partial class UcBed
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.progressTimeLeft = new Telerik.WinControls.UI.RadProgressBar();
            this.lbDuration = new Telerik.WinControls.UI.RadLabel();
            this.lbStartTime = new Telerik.WinControls.UI.RadLabel();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.contextNewTransaction = new Telerik.WinControls.UI.RadMenuItem();
            this.contextStopTransaction = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressTimeLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbStartTime)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.progressTimeLeft);
            this.radPanel1.Controls.Add(this.lbDuration);
            this.radPanel1.Controls.Add(this.lbStartTime);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.radPanel1.Size = new System.Drawing.Size(160, 50);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPanel1.ThemeName = "TelerikMetro";
            // 
            // progressTimeLeft
            // 
            this.progressTimeLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressTimeLeft.Location = new System.Drawing.Point(1, 1);
            this.progressTimeLeft.Name = "progressTimeLeft";
            this.radContextMenuManager1.SetRadContextMenu(this.progressTimeLeft, this.radContextMenu1);
            this.progressTimeLeft.Size = new System.Drawing.Size(158, 21);
            this.progressTimeLeft.TabIndex = 7;
            this.progressTimeLeft.Text = "Bed 1";
            this.progressTimeLeft.ThemeName = "TelerikMetro";
            this.progressTimeLeft.Value1 = 100;
            this.progressTimeLeft.Value2 = 100;
            // 
            // lbDuration
            // 
            this.lbDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDuration.Location = new System.Drawing.Point(86, 25);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(45, 24);
            this.lbDuration.TabIndex = 5;
            this.lbDuration.Text = "(120\')";
            // 
            // lbStartTime
            // 
            this.lbStartTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStartTime.Location = new System.Drawing.Point(3, 25);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(89, 24);
            this.lbStartTime.TabIndex = 3;
            this.lbStartTime.Text = "Start: 20h30";
            // 
            // radContextMenu1
            // 
            this.radContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.contextNewTransaction,
            this.contextStopTransaction});
            this.radContextMenu1.ThemeName = "TelerikMetro";
            // 
            // contextNewTransaction
            // 
            this.contextNewTransaction.AccessibleDescription = "New transaction";
            this.contextNewTransaction.AccessibleName = "New transaction";
            this.contextNewTransaction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextNewTransaction.Image = global::SpaManagementV3.Properties.Resources.Add;
            this.contextNewTransaction.Name = "contextNewTransaction";
            this.contextNewTransaction.Text = "New transaction";
            this.contextNewTransaction.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // contextStopTransaction
            // 
            this.contextStopTransaction.AccessibleDescription = "Stop";
            this.contextStopTransaction.AccessibleName = "Stop";
            this.contextStopTransaction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextStopTransaction.Image = global::SpaManagementV3.Properties.Resources.Delete;
            this.contextStopTransaction.Name = "contextStopTransaction";
            this.contextStopTransaction.Text = "Stop";
            this.contextStopTransaction.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // UcBed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Name = "UcBed";
            this.Size = new System.Drawing.Size(160, 50);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressTimeLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbStartTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadLabel lbDuration;
        private Telerik.WinControls.UI.RadLabel lbStartTime;
        private Telerik.WinControls.UI.RadProgressBar progressTimeLeft;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadMenuItem contextNewTransaction;
        private Telerik.WinControls.UI.RadMenuItem contextStopTransaction;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
    }
}
