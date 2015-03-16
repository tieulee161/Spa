using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using SpaDatabase.Model.Entities;
using SpaCommon;

namespace SpaManagementV3.View
{
    public partial class FrmLogin : Telerik.WinControls.UI.RadForm
    {
        public User LoginUser = null;

        public FrmLogin()
        {
            InitializeComponent();
            txtUserName.Text = "admin";
            txtPassword.Text = "noname";
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InitEvent();
        }

        private void InitEvent()
        {
            btnLogin.Click += btnLogin_Click;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            LoginUser = Program.Server.GetUser(userName, password);
            if (LoginUser != null)
            {
                Close();
            }
            else
            {
                MessageHandler.ErrorOnLogin();
            }
        }

    }
}
