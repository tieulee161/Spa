namespace SpaManagementV3.View
{
    partial class FrmTest
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
            this.ucBillTemplate1 = new SpaManagementV3.View.Template.UCBillTemplate();
            this.SuspendLayout();
            // 
            // ucBillTemplate1
            // 
            this.ucBillTemplate1.BackColor = System.Drawing.Color.White;
            this.ucBillTemplate1.Location = new System.Drawing.Point(13, 13);
            this.ucBillTemplate1.Name = "ucBillTemplate1";
            this.ucBillTemplate1.Size = new System.Drawing.Size(876, 584);
            this.ucBillTemplate1.TabIndex = 0;
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 402);
            this.Controls.Add(this.ucBillTemplate1);
            this.Name = "FrmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Template.UCBillTemplate ucBillTemplate1;


    }
}