using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Telerik.WinControls.UI;
using SpaCommon;
using SpaDatabase.Model.Entities;

namespace SpaManagementV3.View
{
    public partial class FrmPersonnel : Telerik.WinControls.UI.RadForm
    {
        public FrmPersonnel()
        {
            InitializeComponent();

            InitializeGridview(dtgKTV);
            InitializeGridview(dtgService);
            InitializeGridview(dtgExperience);

            InitializeGridview(dtgPersonnel);
        }

        #region graphics
        private void Row_Formatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void dtgService_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
        }

        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
        }
        #endregion

        #region event
        private void FrmPersonnel_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();
        }
        private void pageMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageMain.SelectedPage.Equals(pageKTVExperience))
            {
                List<Personnel> personnels = Program.Server.GetKTVs();

                dtgKTV.SelectionChanged -= dtgKTV_SelectionChanged;
                dtgKTV.Rows.Clear();
                for (int j = 0; j < personnels.Count; j++)
                {
                    dtgKTV.Rows.Add(new object[] { personnels[j].Id, personnels[j].Name, personnels[j].Code });
                }
                dtgKTV.SelectionChanged += dtgKTV_SelectionChanged;

            }
        }

        private void dtgKTV_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgKTV.SelectedRows.Count > 0)
            {
                string ktvCode = (string)dtgKTV.SelectedRows[0].Cells[2].Value;
                List<Service> services = Program.Server.GetKTVExperiences(ktvCode);
                dtgExperience.Rows.Clear();
                for (int j = 0; j < services.Count; j++)
                {
                    dtgExperience.Rows.Add(new object[] { services[j].Id, services[j].Code });
                }

            }
        }

        private void Personnel_Click(object sender, EventArgs e)
        {
            string name = txtPersonnelName.Text.Trim();
            int ktvId = (int)spinKTVId.Value;
            Gender gender = (Gender)cbbxGender.SelectedIndex;
            DateTime DOB = dateDOB.Value;
            string phone = txtPhone.Text.Trim();
            DateTime joinDate = dateJoinDate.Value;
            JobPosition position = (JobPosition)cbbxPosition.SelectedIndex;
            int charge = (int)spinCharge.Value;
            string idNumber = txtIdNumber.Text.Trim();
            MaritalStatus status = (MaritalStatus)cbbxMaritalStatus.SelectedIndex;
            string address = txtAddress.Text.Trim();
            KTVStatus ktvStatus = (chkDeactive.Checked == true) ? KTVStatus.Deactive : KTVStatus.Active;

            if (sender.Equals(btnAddPersonnel))
            {
                if (name == "")
                {
                    MessageHandler.MessageManager(this, ErrorCode.FULFIllDATA_NAME);
                }
                else
                {
                    Personnel personnel = null;
                    ErrorCode error = Program.Server.AddNewPersonnel(name, ktvId, gender, DOB, phone, joinDate, position, charge, idNumber, status, address, out personnel);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgPersonnel.Rows.Add(new object[] { personnel.Id, name, personnel.Code, ktvId, gender.ToString(), DOB, phone, joinDate, position.ToString(), charge, idNumber, status, address, false });
                        PrepareForAddNewPersonnel();
                    }
                }
            }
            else if (sender.Equals(btnUpdatePersonnel))
            {
                if (dtgPersonnel.SelectedRows.Count > 0)
                {
                    if (name == "")
                    {
                        MessageHandler.MessageManager(this, ErrorCode.FULFIllDATA_NAME);
                    }
                    else
                    {
                        int id = (int)(decimal)dtgPersonnel.SelectedRows[0].Cells[0].Value;
                        ErrorCode error = Program.Server.UpdatePersonnel(id, name, ktvId, gender, DOB, phone, joinDate, position, charge, idNumber, status, address, ktvStatus);
                        MessageHandler.MessageManager(this, error);
                        if (error == ErrorCode.OK)
                        {
                            dtgPersonnel.SelectedRows[0].Cells[1].Value = name;
                            dtgPersonnel.SelectedRows[0].Cells[3].Value = ktvId;
                            dtgPersonnel.SelectedRows[0].Cells[4].Value = gender.ToString();
                            dtgPersonnel.SelectedRows[0].Cells[5].Value = DOB;
                            dtgPersonnel.SelectedRows[0].Cells[6].Value = phone;
                            dtgPersonnel.SelectedRows[0].Cells[7].Value = joinDate;
                            dtgPersonnel.SelectedRows[0].Cells[8].Value = position.ToString();
                            dtgPersonnel.SelectedRows[0].Cells[9].Value = charge;
                            dtgPersonnel.SelectedRows[0].Cells[10].Value = idNumber;
                            dtgPersonnel.SelectedRows[0].Cells[11].Value = status.ToString();
                            dtgPersonnel.SelectedRows[0].Cells[12].Value = address.ToString();
                            dtgPersonnel.SelectedRows[0].Cells[13].Value = (ktvStatus == KTVStatus.Deactive) ? true : false;
                            PrepareForAddNewPersonnel();
                        }
                    }
                }
            }
            else if (sender.Equals(btnDeletePersonnel))
            {
                if (dtgPersonnel.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgPersonnel.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeletePersonnel(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgPersonnel.SelectedRows[0].Delete();
                        PrepareForAddNewPersonnel();
                    }
                }
            }
            else if (sender.Equals(dtgPersonnel))
            {
                if (dtgPersonnel.SelectedRows.Count > 0)
                {
                    txtPersonnelName.Text = (string)dtgPersonnel.SelectedRows[0].Cells[1].Value;
                    spinKTVId.Value = (decimal)dtgPersonnel.SelectedRows[0].Cells[3].Value;
                    cbbxGender.SelectedIndex = cbbxGender.Items.IndexOf((string)dtgPersonnel.SelectedRows[0].Cells[4].Value);
                    dateDOB.Value = (DateTime)dtgPersonnel.SelectedRows[0].Cells[5].Value;
                    txtPhone.Text = (string)dtgPersonnel.SelectedRows[0].Cells[6].Value;
                    dateJoinDate.Value = (DateTime)dtgPersonnel.SelectedRows[0].Cells[7].Value;
                    cbbxPosition.SelectedIndex = cbbxPosition.Items.IndexOf((string)dtgPersonnel.SelectedRows[0].Cells[8].Value);
                    spinCharge.Value = (decimal)dtgPersonnel.SelectedRows[0].Cells[9].Value;
                    txtIdNumber.Text = (string)dtgPersonnel.SelectedRows[0].Cells[10].Value;
                    cbbxMaritalStatus.SelectedIndex = cbbxMaritalStatus.Items.IndexOf((string)dtgPersonnel.SelectedRows[0].Cells[11].Value);
                    txtAddress.Text = (string)dtgPersonnel.SelectedRows[0].Cells[12].Value;
                    chkDeactive.Checked = (bool)dtgPersonnel.SelectedRows[0].Cells[13].Value;

                }
            }
        }

        private void Experience_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnAddExperience))
            {
                if ((dtgKTV.SelectedRows.Count > 0) && (dtgService.SelectedRows.Count > 0))
                {
                    string ktvCode = (string)dtgKTV.SelectedRows[0].Cells[2].Value;
                    for (int j = 0; j < dtgService.SelectedRows.Count; j++)
                    {
                        string serviceCode = (string)dtgService.SelectedRows[j].Cells[1].Value;
                        Service service = null;
                        ErrorCode error = Program.Server.AddNewPersonnelExperience(ktvCode, serviceCode, out service);
                        if (error == ErrorCode.OK)
                        {
                            dtgExperience.Rows.Add(new object[] { service.Id, service.Code });
                        }
                    }

                }
            }
            else if (sender.Equals(btnRemoveExperience))
            {
                if ((dtgKTV.SelectedRows.Count > 0) && (dtgExperience.SelectedRows.Count > 0))
                {
                    string ktvCode = (string)dtgKTV.SelectedRows[0].Cells[2].Value;
                    int count = dtgExperience.SelectedRows.Count;
                    for (int j = count - 1; j >= 0; j--)
                    {
                        string serviceCode = (string)dtgExperience.SelectedRows[j].Cells[1].Value;
                        ErrorCode error = Program.Server.DeletePersonnelExperience(ktvCode, serviceCode);
                        if (error == ErrorCode.OK)
                        {
                            dtgExperience.SelectedRows[0].Delete();
                        }
                    }
                   
                }
            }
            else if (sender.Equals(btnUpdateBonusPerOrder))
            {
                int bonusPerCustomerOrder = (int)spinCustomerOrder.Value;
                int bonusPerCompanyOrder = (int)spinCompanyOrder.Value;

                ErrorCode error = Program.Server.UpdatePeronnelSetting(bonusPerCustomerOrder, bonusPerCompanyOrder);
                MessageHandler.MessageManager(this, error);
            }
        }
        #endregion

        #region method
        private void InitEvent()
        {
            btnAddPersonnel.Click += Personnel_Click;
            btnUpdatePersonnel.Click += Personnel_Click;
            btnDeletePersonnel.Click += Personnel_Click;
            dtgPersonnel.Click += Personnel_Click;

            btnAddExperience.Click += Experience_Click;
            btnRemoveExperience.Click += Experience_Click;
            btnUpdateBonusPerOrder.Click += Experience_Click;

        }

        private void LoadData()
        {
            cbbxGender.Items.Clear();
            cbbxGender.Items.Add(Gender.Female.ToString());
            cbbxGender.Items.Add(Gender.Male.ToString());
            cbbxGender.Items.Add(Gender.Others.ToString());
            for (int j = 0; j < cbbxGender.Items.Count; j++)
            {
                cbbxGender.Items[j].Font = new Font(this.Font.FontFamily, (float)9);
            }
            cbbxGender.SelectedIndex = 0;

            cbbxPosition.Items.Clear();
            cbbxPosition.Items.Add(JobPosition.KTV.ToString());

            for (int j = 0; j < cbbxPosition.Items.Count; j++)
            {
                cbbxPosition.Items[j].Font = new Font(this.Font.FontFamily, (float)9);
            }
            cbbxPosition.SelectedIndex = 0;

            cbbxMaritalStatus.Items.Clear();
            cbbxMaritalStatus.Items.Add(MaritalStatus.Single.ToString());
            cbbxMaritalStatus.Items.Add(MaritalStatus.Married.ToString());
            for (int j = 0; j < cbbxMaritalStatus.Items.Count; j++)
            {
                cbbxMaritalStatus.Items[j].Font = new Font(this.Font.FontFamily, (float)9);
            }
            cbbxMaritalStatus.SelectedIndex = 0;

            dateJoinDate.Value = DateTime.Now;
            dateDOB.Value = DateTime.Now;

            List<Personnel> personnels = Program.Server.GetPersonnels();
            for (int j = 0; j < personnels.Count; j++)
            {
                dtgPersonnel.Rows.Add(new object[] { personnels[j].Id,
                                                     personnels[j].Name,
                                                     personnels[j].Code,
                                                     personnels[j].KTVId,
                                                     personnels[j].Gender.ToString(),
                                                     personnels[j].DOB,
                                                     personnels[j].Phone,
                                                     personnels[j].JoinDate,
                                                     personnels[j].Position,
                                                     personnels[j].Charge,
                                                     personnels[j].IdNumber,
                                                     personnels[j].MaritalStatus,
                                                     personnels[j].Address,
                                                     (personnels[j].Status == KTVStatus.Deactive)? true:false,
                                                    });
            }



            List<Service> services = Program.Server.GetServices();
            dtgService.Rows.Clear();
            for (int j = 0; j < services.Count; j++)
            {
                dtgService.Rows.Add(new object[] { services[j].Id, services[j].Code });
            }

            PersonnelSetting setting = Program.Server.GetPeronnelSetting();
            if (setting != null)
            {
                spinCustomerOrder.Value = setting.BonusPerCustomerOrder;
                spinCompanyOrder.Value = setting.BonusPerCompanyOrder;
            }

        }

        private void PrepareForAddNewPersonnel()
        {
            txtPersonnelName.Clear();
            spinKTVId.Value = 0;
            txtPhone.Clear();
            txtIdNumber.Clear();
            txtAddress.Clear();
            spinCharge.Value = 0;
            chkDeactive.Checked = false;
        }

        #endregion


    }
}
