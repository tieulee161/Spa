using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Telerik.WinControls.UI;
using SpaDatabase.Model;
using SpaDatabase.Model.Entities;
using SpaCommon;

namespace SpaManagementV3.View
{
    public partial class FrmUser : Telerik.WinControls.UI.RadForm
    {
        public FrmUser()
        {
            InitializeComponent();

        }

        #region graphics
        private void dtgUser_CreateCell(object sender, Telerik.WinControls.UI.GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
        }

        private void dtgUser_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
        }

        private void PrepareLayout()
        {
            cbbxPosition.Items.Clear();
            cbbxPosition.Items.Add(JobPosition.KTV.ToString());
            cbbxPosition.Items.Add(JobPosition.Cashier.ToString());
            cbbxPosition.Items.Add(JobPosition.Accountant.ToString());
            cbbxPosition.Items.Add(JobPosition.ViceDirector.ToString());
            cbbxPosition.Items.Add(JobPosition.Director.ToString());
            cbbxPosition.Items.Add(JobPosition.Manager.ToString());
            for (int j = 0; j < cbbxPosition.Items.Count; j++)
            {
                cbbxPosition.Items[j].Font = new Font(this.Font.FontFamily, (float)9);
            }
            cbbxPosition.SelectedIndex = 1;

            InitializeGridview(dtgUser);

            List<User> users = Program.Server.GetUsers();
            foreach (User user in users)
            {
                dtgUser.Rows.Add(new object[] { user.Id, user.Name, user.Password, cbbxPosition.Items[user.JobPosition].Text });
            }

        }
        #endregion

        #region event
        private void FrmUser_Load(object sender, EventArgs e)
        {
            PrepareLayout();
            InitEvent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            JobPosition position = (JobPosition)(cbbxPosition.SelectedIndex != -1 ? cbbxPosition.SelectedIndex : 0);

            if (sender.Equals(btnAddUser))
            {
                if (!userName.Contains(" "))
                {
                    User user = null;
                    ErrorCode error = Program.Server.AddNewUser(fullName, userName, password, position, out user);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgUser.Rows.Add(new object[] { user.Id, user.FullName, user.Name, user.Password, position });
                        PrepareForCreatingNewUser();
                    }
                }
                else
                {
                    MessageHandler.ErrorUserDataInput(this);
                }
            }
            else if (sender.Equals(btnUpdateUser))
            {
                if (!userName.Contains(" "))
                {
                    if (dtgUser.SelectedRows.Count > 0)
                    {
                        int userId = (int)(decimal)dtgUser.SelectedRows[0].Cells[0].Value;
                        ErrorCode error = Program.Server.UpdateUser(userId, fullName, userName, password, position);
                        MessageHandler.MessageManager(this,error);
                        if (error == ErrorCode.OK)
                        {
                            dtgUser.SelectedRows[0].Cells[1].Value = fullName;
                            dtgUser.SelectedRows[0].Cells[2].Value = userName;
                            dtgUser.SelectedRows[0].Cells[3].Value = password;
                            dtgUser.SelectedRows[0].Cells[4].Value = position;
                            PrepareForCreatingNewUser();
                        }
                    }

                }
                else
                {
                    MessageHandler.ErrorUserDataInput(this);
                }
            }
            else if (sender.Equals(btnDeleteUser))
            {
                if (dtgUser.SelectedRows.Count > 0)
                {
                    int userId = (int)(decimal)dtgUser.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteUser(userId);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgUser.SelectedRows[0].Delete();
                        PrepareForCreatingNewUser();
                    }
                }
            }
            else if (sender.Equals(chkShowPassword))
            {
                if (chkShowPassword.Checked)
                {
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.PasswordChar = (char)0;
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
            }
            else if (sender.Equals(dtgUser))
            {
                if (dtgUser.SelectedRows.Count > 0)
                {
                    txtFullName.Text = (string)dtgUser.SelectedRows[0].Cells[1].Value;
                    txtUserName.Text = (string)dtgUser.SelectedRows[0].Cells[2].Value;
                    txtPassword.Text = (string)dtgUser.SelectedRows[0].Cells[3].Value;
                    cbbxPosition.SelectedIndex = cbbxPosition.Items.IndexOf((string)dtgUser.SelectedRows[0].Cells[4].Value);
                }
            }
        }
        #endregion

        #region method
        private void InitEvent()
        {
            btnAddUser.Click += Button_Click;
            btnUpdateUser.Click += Button_Click;
            btnDeleteUser.Click += Button_Click;
            dtgUser.Click += Button_Click;
            chkShowPassword.CheckStateChanged += Button_Click;
        }

        private void PrepareForCreatingNewUser()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            cbbxPosition.SelectedIndex = -1;
            cbbxPosition.Text = "";
        }



        #endregion
    }
}
