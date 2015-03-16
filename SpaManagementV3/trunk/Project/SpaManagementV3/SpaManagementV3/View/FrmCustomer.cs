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
    public partial class FrmCustomer : Telerik.WinControls.UI.RadForm
    {
        public FrmCustomer()
        {
            InitializeComponent();

            InitializeGridview(dtgJob);
            InitializeGridview(dtgNationality);
            InitializeGridview(dtgMember);
            InitializeGridview(dtgCustomer);
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

        private void PrepareForAddNewJob()
        {
            txtJob.Clear();
            spinJobDiscount.Value = 0;
            chkJobPercent.Checked = true;
        }
        private void PrepareForAddNewNationality()
        {
            txtNationality.Clear();
            spinNationalityDiscount.Value = 0;
            chkNationalityPercent.Checked = true;
        }

        private void PrepareForAddNewMember()
        {
            txtMember.Clear();
            spinMemberDiscount.Value = 0;
            chkMemberPercent.Checked = true;
        }

        private void PrepareForAddNewCustomer()
        {
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtCompany.Clear();
            txtAddress.Clear();
            txtTax.Clear();
            txtMemberCardSeri.Clear();
        }
        #endregion



        #region event
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();
        }

        private void Job_Click(object sender, EventArgs e)
        {
            string name = txtJob.Text.Trim();
            int discount = (int)spinJobDiscount.Value;
            bool percent = chkJobPercent.Checked;

            if (sender.Equals(btnAddJob))
            {
                Job job = null;
                ErrorCode error = Program.Server.AddNewJob(name, discount, percent, out job);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgJob.Rows.Add(new object[] { job.Id, name, discount, percent });
                    PrepareForAddNewJob();
                }
            }
            else if (sender.Equals(btnUpdateJob))
            {
                if (dtgJob.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgJob.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateJob(id, name, discount, percent);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgJob.SelectedRows[0].Cells[1].Value = name;
                        dtgJob.SelectedRows[0].Cells[2].Value = discount;
                        dtgJob.SelectedRows[0].Cells[3].Value = percent;
                        PrepareForAddNewJob();
                    }
                }
            }
            else if (sender.Equals(btnDeleteJob))
            {
                if (dtgJob.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgJob.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteJob(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgJob.SelectedRows[0].Delete();
                        PrepareForAddNewJob();
                    }
                }
            }
            else if (sender.Equals(dtgJob))
            {
                if (dtgJob.SelectedRows.Count > 0)
                {
                    txtJob.Text = (string)dtgJob.SelectedRows[0].Cells[1].Value;
                    spinJobDiscount.Value = (decimal)dtgJob.SelectedRows[0].Cells[2].Value;
                    chkJobPercent.Checked = (bool)dtgJob.SelectedRows[0].Cells[3].Value;
                }
            }
        }

        private void Nationality_Click(object sender, EventArgs e)
        {
            string name = txtNationality.Text.Trim();
            int discount = (int)spinNationalityDiscount.Value;
            bool percent = chkNationalityPercent.Checked;

            if (sender.Equals(btnAddNationality))
            {
                Nationality nationality = null;
                ErrorCode error = Program.Server.AddNewNationality(name, discount, percent, out nationality);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgNationality.Rows.Add(new object[] { nationality.Id, name, discount, percent });
                    PrepareForAddNewNationality();
                }
            }
            else if (sender.Equals(btnUpdateNationality))
            {
                if (dtgNationality.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgNationality.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateNationality(id, name, discount, percent);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgNationality.SelectedRows[0].Cells[1].Value = name;
                        dtgNationality.SelectedRows[0].Cells[2].Value = discount;
                        dtgNationality.SelectedRows[0].Cells[3].Value = percent;
                        PrepareForAddNewNationality();
                    }
                }
            }
            else if (sender.Equals(btnDeleteNationality))
            {
                if (dtgNationality.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgNationality.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteNationality(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgNationality.SelectedRows[0].Delete();
                        PrepareForAddNewNationality();
                    }
                }
            }
            else if (sender.Equals(dtgNationality))
            {
                if (dtgNationality.SelectedRows.Count > 0)
                {
                    txtNationality.Text = (string)dtgNationality.SelectedRows[0].Cells[1].Value;
                    spinNationalityDiscount.Value = (decimal)dtgNationality.SelectedRows[0].Cells[2].Value;
                    chkNationalityPercent.Checked = (bool)dtgNationality.SelectedRows[0].Cells[3].Value;
                }
            }
        }

        private void Member_Click(object sender, EventArgs e)
        {
            string name = txtMember.Text.Trim();
            int discount = (int)spinMemberDiscount.Value;
            bool percent = chkMemberPercent.Checked;

            if (sender.Equals(btnAddMember))
            {
                Member member = null;
                ErrorCode error = Program.Server.AddNewMember(name, discount, percent, out member);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgMember.Rows.Add(new object[] { member.Id, name, discount, percent });
                    PrepareForAddNewMember();
                }
            }
            else if (sender.Equals(btnUpdateMember))
            {
                if (dtgMember.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgMember.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateMember(id, name, discount, percent);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgMember.SelectedRows[0].Cells[1].Value = name;
                        dtgMember.SelectedRows[0].Cells[2].Value = discount;
                        dtgMember.SelectedRows[0].Cells[3].Value = percent;
                        PrepareForAddNewMember();
                    }
                }
            }
            else if (sender.Equals(btnDeleteMember))
            {
                if (dtgMember.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgMember.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteMember(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgMember.SelectedRows[0].Delete();
                        PrepareForAddNewMember();
                    }
                }
            }
            else if (sender.Equals(dtgMember))
            {
                if (dtgMember.SelectedRows.Count > 0)
                {
                    txtMember.Text = (string)dtgMember.SelectedRows[0].Cells[1].Value;
                    spinMemberDiscount.Value = (decimal)dtgMember.SelectedRows[0].Cells[2].Value;
                    chkMemberPercent.Checked = (bool)dtgMember.SelectedRows[0].Cells[3].Value;
                }
            }
        }

        private void VIPLevel_Click(object sender, EventArgs e)
        {
            int visit = (int)spinVisit.Value;
            int acc = (int)spinSpent.Value;
            ErrorCode error = Program.Server.UpdateVIPSetting(visit, acc);
            MessageHandler.MessageManager(this, error);
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text.Trim();
            string memberCardSeri = txtMemberCardSeri.Text.Trim();
            Gender gender = (Gender)cbbxGender.SelectedIndex;
            DateTime DOB = dateDOB.Value;
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string company = txtCompany.Text.Trim();
            string address = txtAddress.Text.Trim();
            string taxNumber = txtTax.Text.Trim();
            string job = cbbxJob.SelectedItem != null ? cbbxJob.SelectedItem.Text : "";
            string nationality = cbbxNationality.SelectedItem != null ? cbbxNationality.SelectedItem.Text : "";
            string member = cbbxMember.SelectedItem != null ? cbbxMember.SelectedItem.Text : "";

            if (sender.Equals(btnAddCustomer))
            {
                if (name == "")
                {
                    MessageHandler.MessageManager(this, ErrorCode.FULFIllDATA_NAME);
                }
                else
                {
                    Customer customer = null;
                    ErrorCode error = Program.Server.AddNewCustomer(name, memberCardSeri, gender, DOB, phone, email, company, address, taxNumber, job, nationality, member, out customer);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgCustomer.Rows.Add(new object[] { customer.Id, name, customer.Code, gender, DOB, phone, email, member, memberCardSeri, job, nationality, company, taxNumber, address });
                        PrepareForAddNewCustomer();
                    }
                }
            }
            else if (sender.Equals(btnUpdateCustomer))
            {
                if (dtgCustomer.SelectedRows.Count > 0)
                {
                    if (name == "")
                    {
                        MessageHandler.MessageManager(this, ErrorCode.FULFIllDATA_NAME);
                    }
                    else
                    {
                        int id = (int)(decimal)dtgCustomer.SelectedRows[0].Cells[0].Value;
                        ErrorCode error = Program.Server.UpdateCustomer(id, name, memberCardSeri, gender, DOB, phone, email, company, address, taxNumber, job, nationality, member);
                        MessageHandler.MessageManager(this, error);
                        if (error == ErrorCode.OK)
                        {
                            dtgCustomer.SelectedRows[0].Cells[1].Value = name;
                           
                            dtgCustomer.SelectedRows[0].Cells[3].Value = gender.ToString();
                            dtgCustomer.SelectedRows[0].Cells[4].Value = DOB;
                            dtgCustomer.SelectedRows[0].Cells[5].Value = phone;
                            dtgCustomer.SelectedRows[0].Cells[6].Value = email;
                            dtgCustomer.SelectedRows[0].Cells[7].Value = member;
                            dtgCustomer.SelectedRows[0].Cells[8].Value = memberCardSeri;
                            dtgCustomer.SelectedRows[0].Cells[9].Value = job;
                            dtgCustomer.SelectedRows[0].Cells[10].Value = nationality;
                            dtgCustomer.SelectedRows[0].Cells[11].Value = company;
                            dtgCustomer.SelectedRows[0].Cells[12].Value = taxNumber;
                            dtgCustomer.SelectedRows[0].Cells[13].Value = address;
                            PrepareForAddNewCustomer();
                        }
                    }
                }
            }
            else if (sender.Equals(btnDeleteCustomer))
            {
                if (dtgCustomer.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgCustomer.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteCustomer(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgCustomer.SelectedRows[0].Delete();
                        PrepareForAddNewCustomer();
                    }
                }
            }
            else if (sender.Equals(dtgCustomer))
            {
                if (dtgCustomer.SelectedRows.Count > 0)
                {
                    txtCustomerName.Text = (string)dtgCustomer.SelectedRows[0].Cells[1].Value;
                  
                    cbbxGender.SelectedIndex = cbbxGender.Items.IndexOf((string)dtgCustomer.SelectedRows[0].Cells[3].Value);
                    dateDOB.Value = (DateTime)dtgCustomer.SelectedRows[0].Cells[4].Value;
                    txtPhone.Text = (string)dtgCustomer.SelectedRows[0].Cells[5].Value;
                    txtEmail.Text = (string)dtgCustomer.SelectedRows[0].Cells[6].Value;
                    cbbxMember.SelectedIndex = cbbxMember.Items.IndexOf((string)dtgCustomer.SelectedRows[0].Cells[7].Value);
                    txtMemberCardSeri.Text = (string)dtgCustomer.SelectedRows[0].Cells[8].Value;
                    cbbxJob.SelectedIndex = cbbxJob.Items.IndexOf((string)dtgCustomer.SelectedRows[0].Cells[9].Value);
                    cbbxNationality.SelectedIndex = cbbxNationality.Items.IndexOf((string)dtgCustomer.SelectedRows[0].Cells[10].Value);
                    txtCompany.Text = (string)dtgCustomer.SelectedRows[0].Cells[11].Value;
                    txtTax.Text = (string)dtgCustomer.SelectedRows[0].Cells[12].Value;
                    txtAddress.Text = (string)dtgCustomer.SelectedRows[0].Cells[13].Value;
                }
            }
        }

        private void pageMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageMain.SelectedPage.Equals(pageCustomer))
            {
                List<Job> jobs = Program.Server.GetJobs();
                List<Nationality> nationalities = Program.Server.GetNationlities();
                List<Member> members = Program.Server.GetMembers();

                for (int j = 0; j < jobs.Count; j++)
                {
                    RadListDataItem item = new RadListDataItem(jobs[j].Name);
                    item.Font = new Font(this.Font.FontFamily, (float)9);
                    cbbxJob.Items.Add(item);
                }

                for (int j = 0; j < nationalities.Count; j++)
                {
                    RadListDataItem item = new RadListDataItem(nationalities[j].Name);
                    item.Font = new Font(this.Font.FontFamily, (float)9);
                    cbbxNationality.Items.Add(item);
                }

                for (int j = 0; j < members.Count; j++)
                {
                    RadListDataItem item = new RadListDataItem(members[j].Name);
                    item.Font = new Font(this.Font.FontFamily, (float)9);
                    cbbxMember.Items.Add(item);
                }
            }
        }
        #endregion

        #region method
        private void LoadData()
        {
            #region job
            List<Job> jobs = Program.Server.GetJobs();
            for (int j = 0; j < jobs.Count; j++)
            {
                dtgJob.Rows.Add(new object[] {  jobs[j].Id, 
                                                jobs[j].Name,
                                                jobs[j].Discount, 
                                                jobs[j].Percent });
            }
            #endregion

            #region natonality
            List<Nationality> nationalities = Program.Server.GetNationlities();
            for (int j = 0; j < nationalities.Count; j++)
            {
                dtgNationality.Rows.Add(new object[] {  nationalities[j].Id, 
                                                        nationalities[j].Name,
                                                        nationalities[j].Discount, 
                                                        nationalities[j].Percent });
            }
            #endregion

            #region member
            List<Member> members = Program.Server.GetMembers();
            for (int j = 0; j < members.Count; j++)
            {
                dtgMember.Rows.Add(new object[] {  members[j].Id, 
                                                   members[j].Name,
                                                   members[j].Discount, 
                                                   members[j].Percent });
            }
            #endregion

            #region VIPSetting
            VIPSetting setting = Program.Server.GetVIPSetting();
            if (setting != null)
            {
                spinVisit.Value = (int)setting.Visit;
                spinSpent.Value = (int)setting.Account;
            }
            #endregion

            #region customer
            cbbxGender.Items.Clear();
            cbbxGender.Items.Add(Gender.Female.ToString());
            cbbxGender.Items.Add(Gender.Male.ToString());
            cbbxGender.Items.Add(Gender.Others.ToString());
            for (int j = 0; j < cbbxGender.Items.Count; j++)
            {
                cbbxGender.Items[j].Font = new Font(this.Font.FontFamily, (float)9);
            }



            List<Customer> customers = Program.Server.GetCustomers();
            for (int j = 0; j < customers.Count; j++)
            {
                dtgCustomer.Rows.Add(new object[] { customers[j].Id,
                                                    customers[j].Name,
                                                    customers[j].Code,
                                                    customers[j].Gender.ToString(),
                                                    customers[j].DOB,
                                                    customers[j].Phone,
                                                    customers[j].Email,
                                                    customers[j].Member != null? customers[j].Member.Name:"",
                                                    customers[j].MemberCardSeri,
                                                    customers[j].Job != null? customers[j].Job.Name:"",
                                                    customers[j].Nationality != null? customers[j].Nationality.Name:"",
                                                    customers[j].Company,
                                                    customers[j].TaxNumber,
                                                    customers[j].Address
                                                    });
            }
            #endregion
        }
        private void InitEvent()
        {
            btnAddJob.Click += Job_Click;
            btnUpdateJob.Click += Job_Click;
            btnDeleteJob.Click += Job_Click;
            dtgJob.Click += Job_Click;

            btnAddNationality.Click += Nationality_Click;
            btnUpdateNationality.Click += Nationality_Click;
            btnDeleteNationality.Click += Nationality_Click;
            dtgNationality.Click += Nationality_Click;

            btnAddMember.Click += Member_Click;
            btnUpdateMember.Click += Member_Click;
            btnDeleteMember.Click += Member_Click;
            dtgMember.Click += Member_Click;

            btnUpdateVIPLevel.Click += VIPLevel_Click;

            btnAddCustomer.Click += Customer_Click;
            btnUpdateCustomer.Click += Customer_Click;
            btnDeleteCustomer.Click += Customer_Click;
            dtgCustomer.Click += Customer_Click;
        }




        #endregion





    }
}
