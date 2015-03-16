using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using SpaCommon;
using SpaDatabase.Model.Entities;

namespace SpaManagementV3.View
{
    public partial class FrmSystemData : Telerik.WinControls.UI.RadForm
    {
        public FrmSystemData()
        {
            InitializeComponent();
        }

        private void FrmSystemData_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();
        }

        private void InitEvent()
        {
            btnUpdate.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string mailBill = txtBill.Text;
            string mailDB = txtDatabase.Text;
            string backupFolder = txtFolder.Value;
            int period = (int)spinPeriod.Value;

            ErrorCode error = Program.Server.UpdateSystemData(mailDB, mailBill, backupFolder, period);
            MessageHandler.MessageManager(this, error);
            if (error == ErrorCode.OK)
            {
                Close();
            }

        }

        private void LoadData()
        {
            SystemData data = Program.Server.GetSystemData();
            if (data != null)
            {
                txtBill.Text = data.MailBill;
                txtDatabase.Text = data.MailDB;
                txtFolder.Value = data.BackupFolder;
                spinPeriod.Value = data.Period;
            }
        }
    }
}
