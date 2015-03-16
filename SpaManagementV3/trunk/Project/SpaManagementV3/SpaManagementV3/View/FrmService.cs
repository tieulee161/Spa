
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
    public partial class FrmService : Telerik.WinControls.UI.RadForm
    {
        public FrmService()
        {
            InitializeComponent();

            InitializeGridview(dtgService);
            InitializeGridview(dtgPackage);
            InitializeGridview(dtgServiceForPackage);
            InitializeGridview(dtgCertificate);
            InitializeGridview(dtgOthers);
            InitializeGridview(dtgPromotion);
            InitializeGridview(dtgRoom);
            InitializeGridview(dtgBed);

        }

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



        #region graphics

        #endregion

        #region event
        private void FrmService_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();
        }
        private void pageMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageMain.SelectedPage.Equals(pagePackage))
            {
                List<Service> services = Program.Server.GetServices();
                BindingSource bs = new BindingSource();
                bs.DataSource = services;

                cbbxPackageService.DataSource = bs;
                cbbxPackageService.DisplayMember = "Name";
             
                cbbxServiceCode.DataSource = bs;
                cbbxServiceCode.DisplayMember = "Code";
               
            }
        }

        private void Service_Click(object sender, EventArgs e)
        {
            string name = txtServiceName.Text.Trim();
            string code = txtServiceCode.Text.Trim();
            int price = (int)spinServicePrice.Value;
            int tour = (int)spinServiceTour.Value;

            if (sender.Equals(btnAddService))
            {
                Service service = null;
                ErrorCode error = Program.Server.AddNewService(name, code, price, tour, out service);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgService.Rows.Add(new object[] { service.Id, name, code, price, tour });
                    PrepareForAddNewService();
                }
            }
            else if (sender.Equals(btnUpdateService))
            {
                if (dtgService.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgService.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateService(id, name, code, price, tour);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgService.SelectedRows[0].Cells[1].Value = name;
                        dtgService.SelectedRows[0].Cells[2].Value = code;
                        dtgService.SelectedRows[0].Cells[3].Value = price;
                        dtgService.SelectedRows[0].Cells[4].Value = tour;
                        PrepareForAddNewService();
                    }
                }
            }
            else if (sender.Equals(btnDeleteService))
            {
                if (dtgService.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgService.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteService(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgService.SelectedRows[0].Delete();
                        PrepareForAddNewService();
                    }
                }
            }
            else if (sender.Equals(dtgService))
            {
                if (dtgService.SelectedRows.Count > 0)
                {
                    txtServiceName.Text = (string)dtgService.SelectedRows[0].Cells[1].Value;
                    txtServiceCode.Text = (string)dtgService.SelectedRows[0].Cells[2].Value;
                    spinServicePrice.Value = (decimal)dtgService.SelectedRows[0].Cells[3].Value;
                    spinServiceTour.Value = (decimal)dtgService.SelectedRows[0].Cells[4].Value;
                }
            }
        }

        private void Package_Click(object sender, EventArgs e)
        {
            string name = txtPackageName.Text.Trim();
            string code = txtPackageCode.Text.Trim();
            int price = (int)spinPackagePrice.Value;

            if (sender.Equals(btnAddPackage))
            {
                Package package = null;
                ErrorCode error = Program.Server.AddNewPackage(name, code, price, out package);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgPackage.Rows.Add(new object[] { package.Id, name, code, price });
                    PrepareForAddNewPackage();
                }
            }
            else if (sender.Equals(btnUpdatePackage))
            {
                if (dtgPackage.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgPackage.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdatePackage(id, name, code, price);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgPackage.SelectedRows[0].Cells[1].Value = name;
                        dtgPackage.SelectedRows[0].Cells[2].Value = code;
                        dtgPackage.SelectedRows[0].Cells[3].Value = price;
                        PrepareForAddNewPackage();
                    }
                }
            }
            else if (sender.Equals(btnDeletePackage))
            {
                if (dtgPackage.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgPackage.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeletePackage(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgPackage.SelectedRows[0].Delete();
                        PrepareForAddNewPackage();
                    }
                }
            }
            else if (sender.Equals(dtgPackage))
            {
                if (dtgService.SelectedRows.Count > 0)
                {
                    txtPackageName.Text = (string)dtgPackage.SelectedRows[0].Cells[1].Value;
                    txtPackageCode.Text = (string)dtgPackage.SelectedRows[0].Cells[2].Value;
                    spinPackagePrice.Value = (decimal)dtgPackage.SelectedRows[0].Cells[3].Value;

                    int id = (int)(decimal)dtgPackage.SelectedRows[0].Cells[0].Value;
                    Package pack = Program.Server.GetPackage(id);
                    if (pack != null)
                    {
                        dtgServiceForPackage.Rows.Clear();
                        foreach (Service service in pack.Services)
                        {
                            dtgServiceForPackage.Rows.Add(new object[] { service.Id, service.Code, service.Name });
                        }
                    }
                }
            }
            else if (sender.Equals(btnAddServiceForPackage))
            {
                if ((dtgService.SelectedRows.Count > 0) && (cbbxServiceCode.SelectedIndex > -1))
                {
                    int id = (int)(decimal)dtgPackage.SelectedRows[0].Cells[0].Value;
                    string serviceCode = cbbxServiceCode.SelectedItem.Text;
                    Service service = null;
                    ErrorCode error = Program.Server.AddServiceToPackage(id, serviceCode, out service);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgServiceForPackage.Rows.Add(new object[] { service.Id, service.Code, service.Name });
                    }

                }
            }
            else if (sender.Equals(btnDeleteServiceFromPackage))
            {
                if ((dtgService.SelectedRows.Count > 0) && (dtgServiceForPackage.SelectedRows.Count > 0))
                {
                    int packageId = (int)(decimal)dtgPackage.SelectedRows[0].Cells[0].Value;
                    int serviceId = (int)(decimal)dtgServiceForPackage.SelectedRows[0].Cells[0].Value;

                    ErrorCode error = Program.Server.RemoveServiceFromPackage(packageId, serviceId);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgServiceForPackage.SelectedRows[0].Delete();
                    }
                }
            }
        }

        private void Certificate_Click(object sender, EventArgs e)
        {
            string name = txtCertificateName.Text.Trim();
            string code = txtCertificateCode.Text.Trim();
            int price = (int)spinCertificatePrice.Value;
            int duration = (int)spinDuration.Value;

            if (sender.Equals(btnAddCertificate))
            {
                Certificate certificate = null;
                ErrorCode error = Program.Server.AddNewCertificate(name, code, price, duration, out certificate);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgCertificate.Rows.Add(new object[] { certificate.Id, name, code, price, duration });
                    PrepareForAddNewCertificate();
                }
            }
            else if (sender.Equals(btnUpdateCertificate))
            {
                if (dtgCertificate.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgCertificate.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateCertificate(id, name, code, price, duration);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgCertificate.SelectedRows[0].Cells[1].Value = name;
                        dtgCertificate.SelectedRows[0].Cells[2].Value = code;
                        dtgCertificate.SelectedRows[0].Cells[3].Value = price;
                        dtgCertificate.SelectedRows[0].Cells[4].Value = duration;
                        PrepareForAddNewCertificate();
                    }
                }
            }
            else if (sender.Equals(btnDeleteCertificate))
            {
                if (dtgCertificate.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgCertificate.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteCertificate(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgCertificate.SelectedRows[0].Delete();
                        PrepareForAddNewCertificate();
                    }
                }
            }
            else if (sender.Equals(dtgCertificate))
            {
                if (dtgCertificate.SelectedRows.Count > 0)
                {
                    txtCertificateName.Text = (string)dtgCertificate.SelectedRows[0].Cells[1].Value;
                    txtCertificateCode.Text = (string)dtgCertificate.SelectedRows[0].Cells[2].Value;
                    spinCertificatePrice.Value = (decimal)dtgCertificate.SelectedRows[0].Cells[3].Value;
                    spinDuration.Value = (decimal)dtgCertificate.SelectedRows[0].Cells[4].Value;

                    int id = (int)(decimal)dtgCertificate.SelectedRows[0].Cells[0].Value;
                    Certificate certificate = Program.Server.GetCertificate(id);
                    if (certificate != null)
                    {
                        dtgCertificateSeri.Rows.Clear();
                        foreach (CertificateSeri seri in certificate.CertificateSeries)
                        {
                            dtgCertificateSeri.Rows.Add(new object[] { seri.Id, seri.Seri, seri.IssueDate, seri.ExpiryDate, seri.Remain, seri.Status });
                        }
                    }
                }
            }
        }

        private void Others_Click(object sender, EventArgs e)
        {
            string name = txtOthersName.Text.Trim();
            string code = txtOthersCode.Text.Trim();
            int price = (int)spinOthersPrice.Value;

            if (sender.Equals(btnAddOthers))
            {
                OtherService other = null;
                ErrorCode error = Program.Server.AddNewOtherService(name, code, price, out other);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgOthers.Rows.Add(new object[] { other.Id, name, code, price });
                    PrepareForAddNewOtherService();
                }
            }
            else if (sender.Equals(btnUpdateOthers))
            {
                if (dtgOthers.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgOthers.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateOtherService(id, name, code, price);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgOthers.SelectedRows[0].Cells[1].Value = name;
                        dtgOthers.SelectedRows[0].Cells[2].Value = code;
                        dtgOthers.SelectedRows[0].Cells[3].Value = price;
                        PrepareForAddNewOtherService();
                    }
                }
            }
            else if (sender.Equals(btnDeleteOthers))
            {
                if (dtgOthers.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgOthers.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteOtherService(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgOthers.SelectedRows[0].Delete();
                        PrepareForAddNewOtherService();
                    }
                }
            }
            else if (sender.Equals(dtgOthers))
            {
                if (dtgOthers.SelectedRows.Count > 0)
                {
                    txtOthersName.Text = (string)dtgOthers.SelectedRows[0].Cells[1].Value;
                    txtOthersCode.Text = (string)dtgOthers.SelectedRows[0].Cells[2].Value;
                    spinOthersPrice.Value = (decimal)dtgOthers.SelectedRows[0].Cells[3].Value;

                }
            }
        }

        private void Promotion_Click(object sender, EventArgs e)
        {
            string name = txtPromotionName.Text.Trim();
            string code = txtPromotionCode.Text.Trim();
            DateTime? issueDate = datePromotionFrom.NullableValue;
            DateTime? expiryDate = datePromotionTo.NullableValue;
            string note = txtPromotionNote.Text.Trim();
            int discount = (int)spinDiscount.Value;
            bool isPercent = chkPercent.Checked;
            DateTime? startTime = timePromotionStart.Value;
            DateTime? stopTime = timePromotionStop.Value;
            PromotionCondition type = PromotionCondition.NoCondition;
            if (rdByDate.IsChecked)
            {
                type = PromotionCondition.ByDate;
                startTime = null;
                stopTime = null;
            }
            else if (rdByTime.IsChecked)
            {
                type = PromotionCondition.ByTime;
                issueDate = null;
                expiryDate = null;
            }
            else
            {
                startTime = null;
                stopTime = null;
                issueDate = null;
                expiryDate = null;
            }

            if (sender.Equals(btnAddPromotion))
            {
                Promotion promotion = null;
                ErrorCode error = Program.Server.AddNewPromotion(name, code, discount, isPercent, type, issueDate, expiryDate, startTime, stopTime, note, out promotion);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgPromotion.Rows.Add(new object[] { promotion.Id, name, code, discount, isPercent, type, issueDate, expiryDate, startTime, stopTime, note });
                    PrepareForAddNewPromotion();
                }
            }
            else if (sender.Equals(btnUpdatePromotion))
            {
                if (dtgPromotion.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgPromotion.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdatePromotion(id, name, code, discount, isPercent, type, issueDate, expiryDate, startTime, stopTime, note);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgPromotion.SelectedRows[0].Cells[1].Value = name;
                        dtgPromotion.SelectedRows[0].Cells[2].Value = code;
                        dtgPromotion.SelectedRows[0].Cells[3].Value = discount;
                        dtgPromotion.SelectedRows[0].Cells[4].Value = isPercent;
                        dtgPromotion.SelectedRows[0].Cells[5].Value = type;
                        dtgPromotion.SelectedRows[0].Cells[6].Value = issueDate;
                        dtgPromotion.SelectedRows[0].Cells[7].Value = expiryDate;
                        dtgPromotion.SelectedRows[0].Cells[8].Value = startTime;
                        dtgPromotion.SelectedRows[0].Cells[9].Value = stopTime;
                        dtgPromotion.SelectedRows[0].Cells[10].Value = note;
                        PrepareForAddNewPromotion();
                    }
                }
            }
            else if (sender.Equals(btnDeletePromotion))
            {
                if (dtgPromotion.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgPromotion.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeletePromotion(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgPromotion.SelectedRows[0].Delete();
                        PrepareForAddNewPromotion();
                    }
                }
            }
            else if (sender.Equals(dtgPromotion))
            {
                if (dtgPromotion.SelectedRows.Count > 0)
                {
                    txtPromotionName.Text = (string)dtgPromotion.SelectedRows[0].Cells[1].Value;
                    txtPromotionCode.Text = (string)dtgPromotion.SelectedRows[0].Cells[2].Value;
                    spinDiscount.Value = (decimal)dtgPromotion.SelectedRows[0].Cells[3].Value;
                    chkPercent.Checked = (bool)dtgPromotion.SelectedRows[0].Cells[4].Value;
                    datePromotionFrom.NullableValue = (DateTime?)dtgPromotion.SelectedRows[0].Cells[6].Value;
                    datePromotionTo.NullableValue = (DateTime?)dtgPromotion.SelectedRows[0].Cells[7].Value;
                    timePromotionStart.Value = (DateTime?)dtgPromotion.SelectedRows[0].Cells[8].Value;
                    timePromotionStop.Value = (DateTime?)dtgPromotion.SelectedRows[0].Cells[9].Value;
                    txtPromotionNote.Text = (string)dtgPromotion.SelectedRows[0].Cells[10].Value;

                    PromotionCondition conditionType = (PromotionCondition)dtgPromotion.SelectedRows[0].Cells[5].Value;
                    switch (conditionType)
                    {
                        case PromotionCondition.NoCondition:
                            rdNoCondition.IsChecked = true;
                            break;
                        case PromotionCondition.ByDate:
                            rdByDate.IsChecked = true;
                            break;
                        case PromotionCondition.ByTime:
                            rdByTime.IsChecked = true;
                            break;
                    }


                }
            }


        }

        private void ExchangeRate_Click(object sender, EventArgs e)
        {
            int exchangeRate = (int)spinExchangeRate.Value;
            ErrorCode error = Program.Server.UpdateCurrency(exchangeRate);
            MessageHandler.MessageManager(this, error);
        }

        private void Room_Click(object sender, EventArgs e)
        {
            string name = txtRoomName.Text.Trim();
            string code = txtRoomCode.Text.Trim();
            int charge = (int)spinCharge.Value;
            Branch branch = (Branch)cbbxBranch.SelectedIndex;

            if (sender.Equals(btnAddRoom))
            {
                Room room = null;
                ErrorCode error = Program.Server.AddNewRoom(name, code, charge, branch, out room);
                MessageHandler.MessageManager(this, error);
                if (error == ErrorCode.OK)
                {
                    dtgRoom.Rows.Add(new object[] { room.Id, name, code, charge, branch.ToString() });
                    PrepareForAddNewRoom();
                }
            }
            else if (sender.Equals(btnUpdateRoom))
            {
                if (dtgRoom.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgRoom.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.UpdateRoom(id, name, code, charge, branch);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgRoom.SelectedRows[0].Cells[1].Value = name;
                        dtgRoom.SelectedRows[0].Cells[2].Value = code;
                        dtgRoom.SelectedRows[0].Cells[3].Value = charge;
                        dtgRoom.SelectedRows[0].Cells[4].Value = branch.ToString();
                        PrepareForAddNewRoom();
                    }
                }
            }
            else if (sender.Equals(btnDeleteRoom))
            {
                if (dtgRoom.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgRoom.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteRoom(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgRoom.SelectedRows[0].Delete();
                        PrepareForAddNewRoom();
                    }
                }
            }
            else if (sender.Equals(dtgRoom))
            {
                if (dtgRoom.SelectedRows.Count > 0)
                {
                    txtRoomName.Text = (string)dtgRoom.SelectedRows[0].Cells[1].Value;
                    txtRoomCode.Text = (string)dtgRoom.SelectedRows[0].Cells[2].Value;
                    spinCharge.Value = (decimal)dtgRoom.SelectedRows[0].Cells[3].Value;
                    cbbxBranch.SelectedIndex = cbbxBranch.Items.IndexOf((string)dtgRoom.SelectedRows[0].Cells[4].Value);

                    int id = (int)(decimal)dtgRoom.SelectedRows[0].Cells[0].Value;
                    Room room = Program.Server.GetRoom(id);
                    if (room != null)
                    {
                        dtgBed.Rows.Clear();
                        foreach (Bed bed in room.Beds)
                        {
                            dtgBed.Rows.Add(new object[] { bed.Id, bed.BedId });
                        }
                    }
                }
            }
            else if (sender.Equals(btnAddBed))
            {

                if (dtgRoom.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgRoom.SelectedRows[0].Cells[0].Value;
                    string roomCode = (string)dtgRoom.SelectedRows[0].Cells[2].Value;
                    int bedId = (int)spinBed.Value;
                    Bed bed = null;
                    ErrorCode error = Program.Server.AddNewBed(roomCode, bedId, out bed);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgBed.Rows.Add(new object[] { bed.Id, bed.BedId });
                    }

                }
            }
            else if (sender.Equals(btnDeleteBed))
            {
                if (dtgBed.SelectedRows.Count > 0)
                {
                    int id = (int)(decimal)dtgBed.SelectedRows[0].Cells[0].Value;
                    ErrorCode error = Program.Server.DeleteBed(id);
                    MessageHandler.MessageManager(this, error);
                    if (error == ErrorCode.OK)
                    {
                        dtgBed.SelectedRows[0].Delete();
                    }
                }
            }
        }

        #endregion

        #region method
        private void InitEvent()
        {
            pageMain.SelectedPageChanged += pageMain_SelectedPageChanged;

            #region service
            btnAddService.Click += Service_Click;
            btnUpdateService.Click += Service_Click;
            btnDeleteService.Click += Service_Click;
            dtgService.Click += Service_Click;
            #endregion

            #region package
            btnAddPackage.Click += Package_Click;
            btnUpdatePackage.Click += Package_Click;
            btnDeletePackage.Click += Package_Click;
            dtgPackage.Click += Package_Click;
            btnAddServiceForPackage.Click += Package_Click;
            btnDeleteServiceFromPackage.Click += Package_Click;
            #endregion

            #region certificate
            btnAddCertificate.Click += Certificate_Click;
            btnUpdateCertificate.Click += Certificate_Click;
            btnDeleteCertificate.Click += Certificate_Click;
            dtgCertificate.Click += Certificate_Click;
            #endregion

            #region other service
            btnAddOthers.Click += Others_Click;
            btnUpdateOthers.Click += Others_Click;
            btnDeleteOthers.Click += Others_Click;
            dtgOthers.Click += Others_Click;
            #endregion

            #region promotion
            btnAddPromotion.Click += Promotion_Click;
            btnUpdatePromotion.Click += Promotion_Click;
            btnDeletePromotion.Click += Promotion_Click;
            dtgPromotion.Click += Promotion_Click;

            #endregion

            #region currency
            btnUpdateExchangeRate.Click += ExchangeRate_Click;
            #endregion

            #region room
            btnAddRoom.Click += Room_Click;
            btnUpdateRoom.Click += Room_Click;
            btnDeleteRoom.Click += Room_Click;
            btnAddBed.Click += Room_Click;
            btnDeleteBed.Click += Room_Click;
            dtgRoom.Click += Room_Click;
            #endregion
        }

        private void LoadData()
        {
            #region service
            List<Service> services = Program.Server.GetServices();
            for (int j = 0; j < services.Count; j++)
            {
                dtgService.Rows.Add(new object[] { services[j].Id, 
                                                   services[j].Name, 
                                                   services[j].Code,
                                                   services[j].Price,
                                                   services[j].Tour });
            }
            #endregion

            #region package
            List<Package> packages = Program.Server.GetPackages();
            for (int j = 0; j < packages.Count; j++)
            {
                dtgPackage.Rows.Add(new object[] { packages[j].Id, 
                                                   packages[j].Name,
                                                   packages[j].Code, 
                                                   packages[j].Price });
            }
            #endregion

            #region certificate
            List<Certificate> certificates = Program.Server.GetCertificates();
            for (int j = 0; j < certificates.Count; j++)
            {
                dtgCertificate.Rows.Add(new object[] {  certificates[j].Id, 
                                                        certificates[j].Name,
                                                        certificates[j].Code, 
                                                        certificates[j].Price,
                                                        certificates[j].Duration
                                                        });
            }
            #endregion

            #region others
            List<OtherService> others = Program.Server.GetOtherServices();
            for (int j = 0; j < others.Count; j++)
            {
                dtgOthers.Rows.Add(new object[] {  others[j].Id, 
                                                   others[j].Name,
                                                   others[j].Code, 
                                                   others[j].Price,
                                                        });
            }
            #endregion

            #region promotion
            datePromotionFrom.NullableValue = null;
            datePromotionTo.NullableValue = null;
            timePromotionStart.Value = null;
            timePromotionStop.Value = null;

            DataTable tb = new DataTable();
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("Id", typeof(int));
            tb.Rows.Add(new object[] { "None", 0 });
            tb.Rows.Add(new object[] { "By date", 1 });
            tb.Rows.Add(new object[] { "By time", 2 });
            ((GridViewComboBoxColumn)dtgPromotion.Columns["colConditionType"]).DataSource = tb;
            ((GridViewComboBoxColumn)dtgPromotion.Columns["colConditionType"]).DisplayMember = "Name";
            ((GridViewComboBoxColumn)dtgPromotion.Columns["colConditionType"]).ValueMember = "Id";
            List<Promotion> promotions = Program.Server.GetPromotions();
            for (int j = 0; j < promotions.Count; j++)
            {
                dtgPromotion.Rows.Add(new object[] { promotions[j].Id,
                                                     promotions[j].Name,
                                                     promotions[j].Code, 
                                                     promotions[j].Discount,
                                                     promotions[j].IsPercent,
                                                     (int)promotions[j].Type,
                                                     promotions[j].IssueDate,
                                                     promotions[j].ExpiryDate,
                                                     promotions[j].StartTime,
                                                     promotions[j].StopTime,
                                                     promotions[j].Note });
            }
            dtgPromotion.Size = new Size(800, dtgPromotion.Size.Height);


            #endregion

            #region currency
            spinExchangeRate.Value = Program.Server.GetExchangeRate();
            #endregion

            #region room
            List<Room> rooms = Program.Server.GetRooms();
            for (int j = 0; j < rooms.Count; j++)
            {
                dtgRoom.Rows.Add(new object[] { rooms[j].Id, 
                                                rooms[j].Name, 
                                                rooms[j].Code,
                                                rooms[j].Charge,
                                                rooms[j].Branch.ToString() });
            }
            dtgRoom.Size = new System.Drawing.Size(900, dtgRoom.Size.Height);
            cbbxBranch.Items.Clear();
            cbbxBranch.Items.Add(Branch.MH9C.ToString());
            cbbxBranch.Items.Add(Branch.MH2A.ToString());
            cbbxBranch.SelectedIndex = 0;
            for (int j = 0; j < cbbxBranch.Items.Count; j++)
            {
                cbbxBranch.Items[j].Font = new Font(this.Font.FontFamily, (float)9);
            }

            #endregion
        }

        private void PrepareForAddNewService()
        {
            txtServiceName.Clear();
            txtServiceCode.Clear();
            spinServicePrice.Value = 0;
            spinServiceTour.Value = 0;
        }

        private void PrepareForAddNewPackage()
        {
            txtPackageName.Clear();
            txtPackageCode.Clear();
            spinPackagePrice.Value = 0;
        }

        private void PrepareForAddNewCertificate()
        {
            txtCertificateName.Clear();
            txtCertificateCode.Clear();
            spinCertificatePrice.Value = 0;
            spinDuration.Value = 3;
        }

        private void PrepareForAddNewOtherService()
        {
            txtOthersName.Clear();
            txtOthersCode.Clear();
            spinOthersPrice.Value = 0;
        }

        private void PrepareForAddNewPromotion()
        {
            txtPromotionName.Clear();
            txtPromotionCode.Clear();
            txtPromotionNote.Clear();
        }

        private void PrepareForAddNewPromotionDetail()
        {
            spinDiscount.Value = 0;
            chkPercent.Checked = true;
        }

        private void PrepareForAddNewRoom()
        {
            txtRoomName.Clear();
            txtRoomCode.Clear();
            spinCharge.Value = 0;
        }
        #endregion


    }
}
