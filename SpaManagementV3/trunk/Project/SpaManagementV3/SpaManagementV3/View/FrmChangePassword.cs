using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using SpaCommon;

namespace SpaManagementV3.View
{
    public partial class FrmChangePassword : Telerik.WinControls.UI.RadForm
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            InitEvent();
        }

        private void InitEvent()
        {
            btnUpdate.Click += Button_Click;
            btnCancel.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if(sender.Equals(btnUpdate))
            {
                string userName = txtUserName.Text.Trim();
                string oldPassword = txtCurrentPassword.Text.Trim();
                string newPassword = txtNewPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();

                if(newPassword != confirmPassword)
                {
                    MessageHandler.ConfirmPasswordMismatch();
                }
                else
                {
                    ErrorCode error = Program.Server.ChangePassword(userName,oldPassword,newPassword);
                    MessageHandler.MessageManager(this, error);
                    if(error == ErrorCode.OK)
                    {
                        Close();
                    }
                   
                }
            }
            else if(sender.Equals(btnCancel))
            {
                Close();
            }
        }
    }
}
