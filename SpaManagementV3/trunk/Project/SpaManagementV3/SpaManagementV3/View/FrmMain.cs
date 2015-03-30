using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using System.Linq;
using Telerik.WinControls.UI;
using SpaCommon;
using SpaDatabase.Model.Entities;
using SpaDatabase.Services;
using SpaManagementV3.View.Template;

namespace SpaManagementV3.View
{
    public partial class FrmMain : Telerik.WinControls.UI.RadForm
    {
        public FrmMain()
        {
            Telerik.WinControls.Themes.TelerikMetroTheme theme = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ThemeResolutionService.ApplicationThemeName = theme.ThemeName;
            InitializeComponent();

            if (Login())
            {
                InitializeForm();
                InitializeEvent();
            }
            else
            {
                Close();
            }
        }

        #region Field/Property
        public User User { get; set; }
        BillMain _BillMain { get; set; }
        List<Customer> _Customers { get; set; }
        Branch _Branch { get { return (Branch)Properties.Settings.Default.MHSpaID; } }
        int _ServiceChargePercent { get { return Properties.Settings.Default.ServiceCharge; } }

        int _BillRawTotal
        {
            get
            {
                int res = 0;
                for (int j = 0; j < dtgBillDetail.Rows.Count; j++)
                {
                    res += (int)(decimal)dtgBillDetail.Rows[j].Cells["colTotal"].Value;
                }
                if (res < 0) res = 0;
                return res;
            }
        }
        int _BillRawTotalDiscount
        {
            get
            {
                int res = 0;
                for (int j = 0; j < dtgBillDetail.Rows.Count; j++)
                {
                    if (dtgBillDetail.Rows[j].Cells["colDiscount"].Value != null)
                    {
                        res += (int)(decimal)dtgBillDetail.Rows[j].Cells["colDiscount"].Value;
                    }
                }
                if (res < 0) res = 0;
                return res;
            }
        }
        int _BillVoucher
        {
            get
            {
                int res = 0;
                for (int j = 0; j < dtgVoucher.Rows.Count; j++)
                {
                    res += (int)(decimal)dtgVoucher.Rows[j].Cells["colPay"].Value;
                }
                if (res < 0) res = 0;
                return res;
            }
        }
        int _BillServiceCharge
        {
            get
            {
                return (int)spinServiceCharge.Value;
            }
            set
            {
                spinServiceCharge.Value = value;
            }
        }
        int _BillTotalDiscount
        {
            get
            {
                int res = 0;
                if (rdTotalDiscountPercent.IsChecked)
                {
                    int temp = (spinTotalDiscount.Value > 100) ? 100 : (int)spinTotalDiscount.Value;
                    res = (_BillRawTotal - _BillRawTotalDiscount + _BillServiceCharge) * temp / 100;
                }
                else
                {
                    res = (int)spinTotalDiscount.Value;
                }
                if (res < 0) res = 0;
                return res;
            }
        }
        int _BillVAT
        {
            get
            {
                int res = 0;
                res = (_BillRawTotal - _BillRawTotalDiscount + _BillServiceCharge - _BillTotalDiscount) / 10;
                if (res < 0) res = 0;
                return res;
            }
        }
        int _Total
        {
            get
            {
                int res = 0;
                res = _BillRawTotal + _BillServiceCharge - _BillRawTotalDiscount - _BillTotalDiscount + ((chkIncludeVAT.Checked == true) ? _BillVAT : 0);
                if (res < 0) res = 0;
                return res;
            }
        }



        #endregion

        #region method
        private void InitEvent()
        {
            btnAddServiceToBill.Click += Button_Click;
            btnServiceAddKTV.Click += Button_Click;
            btnServiceRemoveKTV.Click += Button_Click;
            btnPackageAddKTV.Click += Button_Click;
            btnPackageRemoveKTV.Click += Button_Click;
            btnNewBill.Click += Button_Click;
            btnPrint.Click += Button_Click;
            btnAddVoucher.Click += Button_Click;
            btnRemoveVoucher.Click += Button_Click;
            btnFillPayment.Click += Button_Click;

            dtgPromotion.Click += dtgPromotion_Click;
            chkDiscountApply.CheckStateChanged += chkDiscountApply_CheckStateChanged;
            rdTotalDiscountPercent.CheckStateChanged += chkDiscountApply_CheckStateChanged;
            chkIncludeVAT.CheckStateChanged += chkDiscountApply_CheckStateChanged;
            rdDiscountPercent.CheckStateChanged += chkDiscountApply_CheckStateChanged;

            spinServiceCharge.ValueChanged += spinServiceCharge_ValueChanged;
            spinTotalDiscount.ValueChanged += spinServiceCharge_ValueChanged;
            spinVoucherSeri.ValueChanged += spinServiceCharge_ValueChanged;
            cbbxPayer.PopupOpening += cbbxPayer_PopupOpening;
        }

        private bool Login()
        {
            bool res = false;
            FrmLogin f = new FrmLogin();
            f.ShowDialog();
            if (f.LoginUser != null)
            {
                this.User = f.LoginUser;
                this.Show();
                LoadUser();
                res = true;
            }
            return res;
        }

        private void Logout()
        {
            this.User = null;
            this.Hide();
            Login();
        }

        private void LoadData()
        {
            LoadCustomer();
            LoadService();
            LoadPackage();
            LoadRoom();
            LoadCertificate();
            LoadOtherService();
            LoadPromotion();
            LoadVoucher();
            LoadBooking();
            LoadNewBill();
        }

        private void LoadCustomer()
        {
            #region customer
            List<Customer> customers = Program.Server.GetCustomers();
            customers.Add(null);
            BindingSource bs = new BindingSource();
            bs.DataSource = customers;
            bs.MoveLast();

            cbbxCustomerName.DataSource = bs;
            cbbxCustomerName.DisplayMember = "Name";
            cbbxCustomerName.AutoCompleteDataSource = bs;
            cbbxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxCustomerName.AutoCompleteDisplayMember = "Name";

            cbbxCustomerCode.DataSource = bs;
            cbbxCustomerCode.DisplayMember = "Code";
            cbbxCustomerCode.AutoCompleteDataSource = bs;
            cbbxCustomerCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxCustomerCode.AutoCompleteDisplayMember = "Code";

            txtCustomerMember.DataBindings.Clear();
            txtCustomerMember.DataBindings.Add("Text", bs, "Member.Name");

            cbbxMemberCardSeri.DataSource = bs;
            cbbxMemberCardSeri.DisplayMember = "MemberCardSeri";
            cbbxMemberCardSeri.AutoCompleteDataSource = bs;
            cbbxMemberCardSeri.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxMemberCardSeri.AutoCompleteDisplayMember = "MemberCardSeri";

            #endregion
        }

        private void LoadService()
        {
            #region service
            List<Service> services = Program.Server.GetServices();
            services.Add(null);
            BindingSource bs = new BindingSource();
            bs.DataSource = services;
            bs.MoveLast();
            bs.PositionChanged += ServiceBindingSource_SelectionChanged;

            cbbxServiceName.DataSource = bs;
            cbbxServiceName.DisplayMember = "Name";
            cbbxServiceName.AutoCompleteDataSource = bs;
            cbbxServiceName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxServiceName.AutoCompleteDisplayMember = "Name";

            cbbxServiceCode.DataSource = bs;
            cbbxServiceCode.DisplayMember = "Code";
            cbbxServiceCode.AutoCompleteDataSource = bs;
            cbbxServiceCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxServiceCode.AutoCompleteDisplayMember = "Code";

            spinServicePrice.DataBindings.Clear();
            spinServicePrice.DataBindings.Add("Value", bs, "Price", true);
            #endregion
        }

        private void LoadRoom()
        {
            #region room
            Branch branch = (Branch)Properties.Settings.Default.MHSpaID;
            List<Room> rooms = Program.Server.GetRooms(branch);
            rooms.Add(null);

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = rooms;
            bs1.MoveLast();

            BindingSource bs2 = new BindingSource();
            bs2.DataSource = rooms;
            bs2.MoveLast();

            cbbxServiceRoom.DataSource = bs1;
            cbbxServiceRoom.DisplayMember = "Code";

            cbbxPackageServiceRoom.DataSource = bs2;
            cbbxPackageServiceRoom.DisplayMember = "Code";
            #endregion
        }

        private void LoadPackage()
        {
            #region package
            List<Package> packages = Program.Server.GetPackages();
            packages.Add(null);

            BindingSource bs = new BindingSource();
            bs.DataSource = packages;
            bs.MoveLast();
            bs.PositionChanged += PackageBindingSource_SelectionChanged;

            cbbxPackageName.DataSource = bs;
            cbbxPackageName.DisplayMember = "Name";
            //cbbxPackageName.AutoCompleteDataSource = bs;
            //cbbxPackageName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbxPackageName.AutoCompleteDisplayMember = "Name";

            cbbxPackageCode.DataSource = bs;
            cbbxPackageCode.DisplayMember = "Code";
            //cbbxPackageCode.AutoCompleteDataSource = bs;
            //cbbxPackageCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbxPackageCode.AutoCompleteDisplayMember = "Code";

            spinPackagePrice.DataBindings.Clear();
            spinPackagePrice.DataBindings.Add("Value", bs, "Price", true);
            #endregion
        }

        private void LoadCertificate()
        {
            #region certificate
            List<Certificate> certificates = Program.Server.GetCertificates();
            certificates.Add(null);

            BindingSource bs = new BindingSource();
            bs.DataSource = certificates;
            bs.MoveLast();
            bs.PositionChanged += CertificateBindingSource_SelectionChanged;

            cbbxCertificateName.DataSource = bs;
            cbbxCertificateName.DisplayMember = "Name";
            cbbxCertificateName.AutoCompleteDataSource = bs;
            cbbxCertificateName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxCertificateName.AutoCompleteDisplayMember = "Name";

            cbbxCertificateCode.DataSource = bs;
            cbbxCertificateCode.DisplayMember = "Code";
            cbbxCertificateCode.AutoCompleteDataSource = bs;
            cbbxCertificateCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxCertificateCode.AutoCompleteDisplayMember = "Code";

            spinCertificatePrice.DataBindings.Clear();
            spinCertificatePrice.DataBindings.Add("Value", bs, "Price", true);
            #endregion
        }

        private void LoadOtherService()
        {
            #region other service
            List<OtherService> others = Program.Server.GetOtherServices();
            others.Add(null);

            BindingSource bs = new BindingSource();
            bs.DataSource = others;
            bs.MoveLast();

            cbbxOthersName.DataSource = bs;
            cbbxOthersName.DisplayMember = "Name";
            cbbxOthersName.AutoCompleteDataSource = bs;
            cbbxOthersName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxOthersName.AutoCompleteDisplayMember = "Name";

            cbbxOthersCode.DataSource = bs;
            cbbxOthersCode.DisplayMember = "Code";
            cbbxOthersCode.AutoCompleteDataSource = bs;
            cbbxOthersCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxOthersCode.AutoCompleteDisplayMember = "Code";

            spinOthersPrice.DataBindings.Clear();
            spinOthersPrice.DataBindings.Add("Value", bs, "Price", true);

            #endregion
        }

        private void LoadPromotion()
        {
            List<Promotion> promotions = Program.Server.GetCurrentPromotion();
            dtgPromotion.Rows.Clear();
            for (int j = 0; j < promotions.Count; j++)
            {
                dtgPromotion.Rows.Add(new object[] {promotions[j].Id,
                                                    promotions[j].Code, 
                                                    promotions[j].Discount,
                                                    promotions[j].IsPercent,
                                                    false,
                                     });
            }
        }

        private void LoadVoucher()
        {
            #region voucher
            List<Certificate> certificates = Program.Server.GetCertificates();
            BindingSource bs = new BindingSource();
            bs.DataSource = certificates;

            cbbxVoucherCode.DataSource = bs;
            cbbxVoucherCode.DisplayMember = "Code";
            cbbxVoucherCode.AutoCompleteDataSource = bs;
            cbbxVoucherCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbxVoucherCode.AutoCompleteDisplayMember = "Code";

            cbbxVoucherCode.Text = "";
            spinVoucherSeri.Value = 1;
            spinRemain.Value = 0;
            spinPay.Value = 0;
            btnAddVoucher.Enabled = false;
            #endregion
        }

        private void LoadBooking()
        {
            List<Book> books = Program.Server.GetBooks(DateTime.Now);
            HDReminder.InitReminder();
            foreach(Book book in books)
            {
                HDReminder.AddAppoiment(book);
            }
            HDReminder.Start();
        }

        private void LoadNewBill()
        {
            _BillMain = new BillMain();
            _BillMain.BillDetails = new List<BillDetail>();
            _BillMain.BillServices = new List<BillService>();
            _BillMain.BillPackages = new List<BillPackage>();
            _BillMain.BillCertificates = new List<BillCertificate>();
            _BillMain.BillOtherServices = new List<BillOtherService>();
            _BillMain.BillNumber = Program.Server.GetNewBillNumber(_Branch);
            _Customers = new List<Customer>();
            lbNotPayedBillCount.Text = string.Format("({0})", Program.Server.GetNumberOfNotPayedBill());

            ClearInput();

            dtgBillDetail.Rows.Clear();
            dtgVoucher.Rows.Clear();
            spinBillNumber.Value = _BillMain.BillNumber;
            spinTotal.Value = 0;
            cbbxPayer.Text = "";
            txtNote.Text = "";
            spinPersons.Value = 1;
            chkIncludeVAT.Checked = false;
            spinServiceCharge.Value = 0;
            spinTotalDiscount.Value = 0;
        }

        private void LoadUser()
        {
            if (User != null)
            {
                lbUser.Text = string.Format("Welcome {0}!", User.FullName);
                cbbxCashier.Items.Clear();
                cbbxCashier.Items.Add(User.FullName);
                cbbxCashier.SelectedIndex = 0;
            }
        }

        private void ClearInput()
        {
            // service
            if (cbbxServiceCode.DataSource != null)
            {
                ((BindingSource)cbbxServiceCode.DataSource).MoveLast();
            }
            spinServiceQty.Value = 1;
            spinServicePrice.Value = 0;
            dtgServiceKTV.Rows.Clear();

            // package
            if (cbbxPackageCode.DataSource != null)
            {
                ((BindingSource)cbbxPackageCode.DataSource).MoveLast();
            }
            spinPackagePrice.Value = 0;
            dtgPackageKTV.Rows.Clear();

            // certificate
            if (cbbxCertificateCode.DataSource != null)
            {
                ((BindingSource)cbbxCertificateCode.DataSource).MoveLast();
            }
            txtCertificateSeri.Clear();

            // others
            if (cbbxOthersCode.DataSource != null)
            {
                ((BindingSource)cbbxOthersCode.DataSource).MoveLast();
            }
            spinOthersQty.Value = 1;

            // discount
            spinDiscount.Value = 0;
            chkDiscountApply.Checked = false;
        }

        private void SendEmail(string textBill, string customer, int billNumber)
        {
            string email = Program.Server.GetEmailBill();
            if (email != "")
            {
                try
                {
                    Helper.Email.Receiver = email;
                    string subject = string.Format("MHSpa{2} - BILL {0} - {1}", billNumber.ToString("000000"), customer, Properties.Settings.Default.MHSpaID);
                    string body = textBill;
                    Helper.Email e = new Helper.Email(subject, body);
                }
                catch (Exception ex)
                {
                    MessageHandler.Error(ex.Message);
                }

            }
        }

        #endregion

        #region graphics
        private void InitializeForm()
        {
            try
            {
                ribbonMenu.Expanded = false;
                panelLogo.Visible = true;
                InitializeGridview(dtgBillDetail);
                InitializeGridview(dtgVoucher);
            }
            catch (Exception)
            { }

        }

        private void InitializeEvent()
        {
            menuBooking.Click += Menu_Click;
            menuRoom.Click += Menu_Click;
            menuService.Click += Menu_Click;
            menuCustomer.Click += Menu_Click;
            menuPersonnel.Click += Menu_Click;
            menuLogistics.Click += Menu_Click;
            menuReport.Click += Menu_Click;
            menuUser.Click += Menu_Click;
            menuEmail.Click += Menu_Click;
            menuHelp.Click += Menu_Click;
            menuAbout.Click += Menu_Click;

            menuBillManagement.Click += Menu_Click;
            menuKTVManagement.Click += Menu_Click;
            menuRoomManagement.Click += Menu_Click;
            menuBookingManagement.Click += Menu_Click;

            menuBackup.Click += Menu_Click;
            menuRestore.Click += Menu_Click;

            menuLogin.Click += Menu_Click;
            menuLogout.Click += Menu_Click;
            menuChangePassword.Click += Menu_Click;
        }

        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
        }

        #endregion

        #region event
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            #region tab Data
            if (sender.Equals(menuService))
            {
                FrmService f = new FrmService();
                f.Show();
            }
            else if (sender.Equals(menuBooking))
            {
                FrmBooking f = new FrmBooking();
                f.ShowDialog();
            }
            else if (sender.Equals(menuRoom))
            {
                if (SpaManagementV3.Properties.Settings.Default.MHSpaID == 1)
                {
                    FrmRoomManagement9C f = new FrmRoomManagement9C();
                    f.Show();
                }
                else if (SpaManagementV3.Properties.Settings.Default.MHSpaID == 2)
                {
                    FrmRoomManagement2A f = new FrmRoomManagement2A();
                    f.Show();
                }
            }
            else if (sender.Equals(menuPersonnel))
            {
                FrmPersonnel f = new FrmPersonnel();
                f.ShowDialog();
            }
            else if (sender.Equals(menuCustomer))
            {
                FrmCustomer f = new FrmCustomer();
                f.ShowDialog();
            }
            else if (sender.Equals(menuLogistics))
            {
                FrmLogistics f = new FrmLogistics();
                f.ShowDialog();
            }
            else if (sender.Equals(menuReport))
            {
                FrmBooking f = new FrmBooking();
                f.ShowDialog();
            }
            else if (sender.Equals(menuUser))
            {
                FrmUser f = new FrmUser();
                f.ShowDialog();
            }
            else if (sender.Equals(menuEmail))
            {
                FrmSystemData f = new FrmSystemData();
                f.ShowDialog();
            }
            else if (sender.Equals(menuHelp))
            {

            }
            else if (sender.Equals(menuAbout))
            {

            }
            #endregion

            #region tab Management
            else if (sender.Equals(menuRoomManagement))
            {

            }
            else if (sender.Equals(menuBillManagement))
            {

            }
            else if (sender.Equals(menuBookingManagement))
            {
                FrmBookingManager f = new FrmBookingManager();
                f.Show();
            }
            else if (sender.Equals(menuKTVManagement))
            {

            }
            #endregion

            #region tab Tool
            else if (sender.Equals(menuBackup))
            {

            }
            else if (sender.Equals(menuRestore))
            {

            }
            #endregion

            #region tab User
            else if (sender.Equals(menuLogin))
            {
                FrmLogin f = new FrmLogin();
                f.ShowDialog();
            }
            else if (sender.Equals(menuLogout))
            {
                Logout();
            }
            else if (sender.Equals(menuChangePassword))
            {
                FrmChangePassword f = new FrmChangePassword();
                f.ShowDialog();
            }
            #endregion
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnNewBill))
            {
                LoadData();
            }
            else if (sender.Equals(btnAddServiceToBill))
            {
                Customer customer = (Customer)((BindingSource)(cbbxCustomerCode.DataSource)).Current;

                #region tab service
                if (pageMain.SelectedPage.Equals(pageService))
                {
                    Service service = (Service)((BindingSource)cbbxServiceCode.DataSource).Current;
                    Room room = (Room)((BindingSource)(cbbxServiceRoom.DataSource)).Current;
                    int qty = (int)spinServiceQty.Value;

                    if ((service != null) && (service.Code == cbbxServiceCode.Text) && (room != null) && (dtgServiceKTV.Rows.Count > 0))
                    {
                        BillService billService = new BillService();
                        billService.BillPackageId = null;
                        billService.Service = service;
                        billService.ServiceId = service.Id;
                        billService.Qty = qty;
                        billService.Price = service.Price;
                        billService.Tour = service.Tour;
                        billService.ServiceChargePercent = _ServiceChargePercent;
                        billService.Room = room;
                        billService.RoomId = room.Id;
                        billService.RoomChargePercent = room.Charge;

                        _BillMain.NumberOfService += billService.Qty;
                        _BillMain.BillServices.Add(billService);
                        billService.BillMain = _BillMain;
                        _BillServiceCharge += billService.ServiceChargeValue;

                        #region ktv
                        billService.BillKTVs = new List<BillKTV>();
                        for (int j = 0; j < dtgServiceKTV.Rows.Count; j++)
                        {
                            int ktvId = (int)(decimal)dtgServiceKTV.Rows[j].Cells[0].Value;
                            bool isCustomerOrder = (bool)dtgServiceKTV.Rows[j].Cells[2].Value;
                            bool isCompanyOrder = (bool)dtgServiceKTV.Rows[j].Cells[3].Value;
                            Personnel ktv = Program.Server.GetPersonnel(ktvId);

                            BillKTV billKTV = new BillKTV();
                            billKTV.Personnel = ktv;
                            billKTV.PersonnelId = ktv.Id;
                            billKTV.IsCompanyOrder = isCompanyOrder;
                            billKTV.IsCustomerOrder = isCustomerOrder;
                            billKTV.ChargePercent = ktv.Charge;
                            billService.BillKTVs.Add(billKTV);
                            billKTV.BillService = billService;
                        }
                        #endregion

                        #region customer
                        if ((customer != null) && (customer.Code == cbbxCustomerCode.Text))
                        {
                            billService.Customer = customer;
                            billService.CustomerId = customer.Id;
                            billService.CustomerDiscountPercent = (customer.Member.Percent == true) ? customer.Member.Discount : 0;
                            billService.CustomerDiscountVND = (customer.Member.Percent == true) ? 0 : customer.Member.Discount;
                            _Customers.Add(customer);
                        }
                        #endregion

                        #region discount

                        billService.DiscountPercent = 0;
                        billService.DiscountVND = 0;
                        if (chkDiscountApply.Checked)
                        {
                            if (rdDiscountPercent.IsChecked)
                            {
                                int temp = (spinDiscount.Value > 100) ? 100 : (int)spinDiscount.Value;
                                billService.DiscountPercent = temp;
                                billService.DiscountVND = 0;
                            }
                            else
                            {
                                billService.DiscountPercent = 0;
                                billService.DiscountVND = (int)spinDiscount.Value;
                            }
                        }
                        #endregion

                        #region promotion
                        for (int j = 0; j < dtgPromotion.Rows.Count; j++)
                        {
                            bool isApply = (bool)dtgPromotion.Rows[j].Cells[4].Value;
                            if (isApply)
                            {
                                int promotionId = (int)(decimal)dtgPromotion.Rows[j].Cells[0].Value;
                                billService.PromotionId = promotionId;
                                billService.Promotion = Program.Server.GetPromotion(promotionId);

                                int discount = (int)(decimal)dtgPromotion.Rows[j].Cells[2].Value;
                                bool isPercent = (bool)dtgPromotion.Rows[j].Cells[3].Value;
                                if (isPercent == true)
                                {
                                    billService.PromotionPercent = discount;
                                    billService.PromotionVND = 0;
                                }
                                else
                                {
                                    billService.PromotionPercent = 0;
                                    billService.PromotionVND = discount;
                                }
                                break;
                            }
                        }

                        #endregion

                        #region display to gridview
                        spinServiceCharge.Value += billService.ServiceChargeValue;

                        string ktvs = "";
                        for (int j = 0; j < billService.BillKTVs.Count; j++)
                        {
                            ktvs += ((List<BillKTV>)billService.BillKTVs)[j].Personnel.KTVId + ",";
                        }
                        if (ktvs.Length > 1)
                        {
                            ktvs = ktvs.Substring(0, ktvs.Length - 1); // remove ',' at the end of the list
                        }

                        dtgBillDetail.Rows.Add(new object[] { billService.Service.Name, 
                                                              billService.Service.Code, 
                                                              ktvs, 
                                                              billService.Price, 
                                                              billService.Qty, 
                                                              billService.Total,
                                                              billService.DiscountValue});
                        foreach (BillKTV billKTV in billService.BillKTVs)
                        {
                            if (billKTV.ChargeValue > 0)
                            {
                                dtgBillDetail.Rows.Add(new object[] { string.Format("KTV charge +{0}%", billKTV.ChargePercent), "KTVC", billKTV.Personnel.KTVId, 0, 0, billKTV.ChargeValue, 0 });
                            }
                        }

                        if (billService.RoomChargePercent > 0)
                        {
                            dtgBillDetail.Rows.Add(new object[] { string.Format("Room charge +{0}%", billService.RoomChargePercent), "RoomC", "", 0, 0, billService.RoomChargeValue, 0 });
                        }

                        if (billService.PromotionValue > 0)
                        {
                            dtgBillDetail.Rows.Add(new object[] { billService.Promotion.Name, billService.Promotion.Code, "", 0, 0, 0, (int)billService.PromotionValue });
                        }

                        if (billService.CustomerDiscountValue > 0)
                        {
                            dtgBillDetail.Rows.Add(new object[] { string.Format("Member discount -{0}%", billService.CustomerDiscountPercent), "MemD", "", 0, 0, 0, (int)billService.CustomerDiscountValue });
                        }


                        #endregion


                    }
                    else
                    {
                        MessageHandler.Error("Please fulfill information below:\r\n1. Select service\r\n2.Select room\r\n3.Select KTV");
                    }

                }
                #endregion

                #region tab package
                else if (pageMain.SelectedPage.Equals(pagePackage))
                {
                    BillPackage billPackage = new BillPackage();
                    Package package = (Package)((BindingSource)cbbxPackageCode.DataSource).Current;

                    if ((package != null) && (package.Code == cbbxPackageCode.Text) && (dtgPackageKTV.Rows.Count > 0))
                    {
                        billPackage.Qty = 1;
                        billPackage.Price = package.Price;
                        billPackage.PackageId = package.Id;
                        billPackage.Package = package;
                        billPackage.ServiceChargePercent = _ServiceChargePercent;

                        _BillMain.NumberOfService++;
                        _BillMain.BillPackages.Add(billPackage);
                        billPackage.BillMain = _BillMain;


                        #region customer
                        if ((customer != null) && (customer.Code == cbbxCustomerCode.Text))
                        {
                            billPackage.Customer = customer;
                            billPackage.CustomerId = customer.Id;
                            billPackage.CustomerDiscountPercent = (customer.Member.Percent == true) ? customer.Member.Discount : 0;
                            billPackage.CustomerDiscountVND = (customer.Member.Percent == true) ? 0 : customer.Member.Discount;
                            _Customers.Add(customer);
                        }
                        #endregion

                        #region discount
                        billPackage.DiscountPercent = 0;
                        billPackage.DiscountVND = 0;
                        if (chkDiscountApply.Checked)
                        {
                            if (rdDiscountPercent.IsChecked)
                            {
                                int temp = (spinDiscount.Value > 100) ? 100 : (int)spinDiscount.Value;
                                billPackage.DiscountPercent = temp;
                                billPackage.DiscountVND = 0;
                            }
                            else
                            {
                                billPackage.DiscountPercent = 0;
                                billPackage.DiscountVND = (int)spinDiscount.Value;
                            }
                        }
                        #endregion

                        #region promotion
                        for (int j = 0; j < dtgPromotion.Rows.Count; j++)
                        {
                            bool isApply = (bool)dtgPromotion.Rows[j].Cells[4].Value;
                            if (isApply)
                            {
                                int promotionId = (int)(decimal)dtgPromotion.Rows[j].Cells[0].Value;
                                billPackage.PromotionId = promotionId;
                                billPackage.Promotion = Program.Server.GetPromotion(promotionId);

                                int discount = (int)(decimal)dtgPromotion.Rows[j].Cells[2].Value;
                                bool isPercent = (bool)dtgPromotion.Rows[j].Cells[3].Value;
                                if (isPercent == true)
                                {
                                    billPackage.PromotionPercent = discount;
                                    billPackage.PromotionVND = 0;
                                }
                                else
                                {
                                    billPackage.PromotionPercent = 0;
                                    billPackage.PromotionVND = discount;
                                }
                                break;
                            }
                        }
                        #endregion

                        #region billService
                        billPackage.BillServices = new List<BillService>();
                        for (int j = 0; j < dtgPackageKTV.Rows.Count; j++)
                        {
                            int serviceId = (int)(decimal)dtgPackageKTV.Rows[j].Cells[0].Value;
                            int ktvId = (int)(decimal)dtgPackageKTV.Rows[j].Cells[1].Value;
                            int roomId = (int)(decimal)dtgPackageKTV.Rows[j].Cells[2].Value;
                            bool isCustomerOrder = (bool)dtgPackageKTV.Rows[j].Cells[6].Value;
                            bool isCompanyOrder = (bool)dtgPackageKTV.Rows[j].Cells[7].Value;

                            Service service = Program.Server.GetService(serviceId);
                            Personnel ktv = Program.Server.GetPersonnel(ktvId);
                            Room room = Program.Server.GetRoom(roomId);


                            BillService billService = (from q in (billPackage.BillServices)
                                                       where q.ServiceId == serviceId
                                                       select q).FirstOrDefault();
                            if (billService == null)
                            {
                                billService = new BillService();
                                billService.ServiceId = serviceId;
                                billService.Service = service;
                                billService.Price = service.Price;
                                billService.Tour = service.Tour;
                                billService.Qty = 1;
                                billService.ServiceChargePercent = 0; // service charge will be apply to package, not apply to each its service
                                billService.Room = room;
                                billService.RoomId = room.Id;
                                billService.RoomChargePercent = room.Charge;

                                billPackage.BillServices.Add(billService);
                                billService.BillPackage = billPackage;
                            }

                            #region billKTV
                            if (billService.BillKTVs == null)
                            {
                                billService.BillKTVs = new List<BillKTV>();
                            }

                            BillKTV billKTV = new BillKTV();
                            billKTV.Personnel = ktv;
                            billKTV.PersonnelId = ktv.Id;
                            billKTV.IsCompanyOrder = isCompanyOrder;
                            billKTV.IsCustomerOrder = isCustomerOrder;
                            billKTV.ChargePercent = ktv.Charge;
                            billService.BillKTVs.Add(billKTV);
                            billKTV.BillService = billService;
                            #endregion


                        }

                        #endregion

                        #region display to gridview
                        _BillServiceCharge += billPackage.ServiceChargeValue;

                        string ktvs = "";
                        List<int> ktvIds = new List<int>();
                        foreach (BillService billService in billPackage.BillServices)
                        {
                            foreach (BillKTV billKTV in billService.BillKTVs)
                            {
                                int ktvId = billKTV.Personnel.KTVId;
                                if (!ktvIds.Contains(ktvId))
                                {
                                    ktvIds.Add(ktvId);
                                }
                            }
                        }
                        ktvs = string.Join(",", ktvIds);

                        dtgBillDetail.Rows.Add(new object[] { billPackage.Package.Name, 
                                                              billPackage.Package.Code, 
                                                              ktvs, 
                                                              billPackage.Price, 
                                                              billPackage.Qty, 
                                                              billPackage.Total,
                                                              billPackage.DiscountValue});
                        foreach (BillService billService in billPackage.BillServices)
                        {
                            foreach (BillKTV billKTV in billService.BillKTVs)
                            {
                                if (billKTV.ChargeValue > 0)
                                {
                                    dtgBillDetail.Rows.Add(new object[] { string.Format("KTV charge +{0}%", billKTV.ChargePercent), "KTVC", billKTV.Personnel.KTVId, 0, 0, billKTV.ChargeValue, 0 });
                                }
                            }

                            if (billService.RoomChargePercent > 0)
                            {
                                dtgBillDetail.Rows.Add(new object[] { string.Format("Room charge +{0}%", billService.RoomChargePercent), "RoomC", "", 0, 0, billService.RoomChargeValue, 0 });
                            }

                        }

                        if (billPackage.PromotionValue > 0)
                        {
                            dtgBillDetail.Rows.Add(new object[] { billPackage.Promotion.Name, billPackage.Promotion.Code, "", 0, 0, 0, (int)billPackage.PromotionValue });
                        }

                        if (billPackage.CustomerDiscountValue > 0)
                        {
                            dtgBillDetail.Rows.Add(new object[] { string.Format("Member discount -{0}%", billPackage.CustomerDiscountPercent), "MemD", "", 0, 0, 0, (int)billPackage.CustomerDiscountValue });
                        }

                        #endregion
                    }
                    else
                    {
                        MessageHandler.Error("Please fulfill information below:\r\n1. Select package\r\n2.Select service\r\n3.Select room\r\n4.Select KTV");
                    }
                }
                #endregion

                #region tabCertificate
                else if (pageMain.SelectedPage.Equals(pageCertificate))
                {
                    Certificate certificate = (Certificate)((BindingSource)cbbxCertificateCode.DataSource).Current;
                    List<int> series = SpaCommon.StringParser.GetSeries(txtCertificateSeri.Text.Trim());
                    List<CertificateSeri> certificateSeries = new List<CertificateSeri>();
                    List<int> missCertificateSeries = new List<int>();
                    for (int j = 0; j < series.Count; j++)
                    {
                        int seri = series[j];
                        CertificateSeri certificateSeri = (from q in certificate.CertificateSeries
                                                           where (q.Seri == seri) && (q.Status == (int)CertificateStatus.New)
                                                           select q).FirstOrDefault();
                        if (certificateSeri != null)
                        {
                            certificateSeries.Add(certificateSeri);
                        }
                        else
                        {
                            missCertificateSeries.Add(seri);
                        }
                    }
                    if ((certificate != null) && (cbbxCertificateCode.Text == certificate.Code) && (series.Count > 0))
                    {
                        if (missCertificateSeries.Count == 0)
                        {
                            BillCertificate billCertificate = new BillCertificate();
                            billCertificate.Certificate = certificate;
                            billCertificate.CertificateId = certificate.Id;
                            billCertificate.Price = certificate.Price;
                            billCertificate.CertificateSeries = certificateSeries;
                            _BillMain.BillCertificates.Add(billCertificate);
                            billCertificate.BillMain = _BillMain;

                            #region customer
                            if ((customer != null) && (customer.Code == cbbxCustomerCode.Text))
                            {
                                billCertificate.Customer = customer;
                                billCertificate.CustomerId = customer.Id;
                                _Customers.Add(customer);
                            }
                            #endregion

                            #region discount
                            billCertificate.DiscountPercent = 0;
                            billCertificate.DiscountVND = 0;
                            if (chkDiscountApply.Checked)
                            {
                                if (rdDiscountPercent.IsChecked)
                                {
                                    int temp = (spinDiscount.Value > 100) ? 100 : (int)spinDiscount.Value;
                                    billCertificate.DiscountPercent = temp;
                                    billCertificate.DiscountVND = 0;
                                }
                                else
                                {
                                    billCertificate.DiscountPercent = 0;
                                    billCertificate.DiscountVND = (int)spinDiscount.Value;
                                }
                            }
                            #endregion

                            #region promotion
                            for (int j = 0; j < dtgPromotion.Rows.Count; j++)
                            {
                                bool isApply = (bool)dtgPromotion.Rows[j].Cells[4].Value;
                                if (isApply)
                                {
                                    int promotionId = (int)(decimal)dtgPromotion.Rows[j].Cells[0].Value;
                                    billCertificate.PromotionId = promotionId;
                                    billCertificate.Promotion = Program.Server.GetPromotion(promotionId);

                                    int discount = (int)(decimal)dtgPromotion.Rows[j].Cells[2].Value;
                                    bool isPercent = (bool)dtgPromotion.Rows[j].Cells[3].Value;
                                    if (isPercent == true)
                                    {
                                        billCertificate.PromotionPercent = discount;
                                        billCertificate.PromotionVND = 0;
                                    }
                                    else
                                    {
                                        billCertificate.PromotionPercent = 0;
                                        billCertificate.PromotionVND = discount;
                                    }
                                    break;
                                }
                            }
                            #endregion

                            #region display to grid view
                            dtgBillDetail.Rows.Add(new object[] { certificate.Name, 
                                                              certificate.Code, 
                                                              "", 
                                                              billCertificate.Price, 
                                                              billCertificate.Qty, 
                                                              billCertificate.Total,
                                                              billCertificate.DiscountValue});
                            if (billCertificate.PromotionValue > 0)
                            {
                                dtgBillDetail.Rows.Add(new object[] { billCertificate.Promotion.Name, billCertificate.Promotion.Code, "", 0, 0, 0, (int)billCertificate.PromotionValue });
                            }
                            #endregion
                        }
                        else
                        {
                            string missSeries = string.Join(",", missCertificateSeries);
                            MessageHandler.Error(string.Format("These series don't exist or aleady saled : {0}", missSeries));
                        }

                    }
                    else
                    {
                        MessageHandler.Error("Please fulfill information below:\r\n1. Select certificate\r\n2.Fullfil certificate series");
                    }
                }
                #endregion

                #region others
                else if (pageMain.SelectedPage.Equals(pageOthers))
                {
                    OtherService otherSerice = (OtherService)((BindingSource)cbbxOthersCode.DataSource).Current;
                    if ((otherSerice != null) && (otherSerice.Code == cbbxOthersCode.Text))
                    {
                        BillOtherService billOtherService = new BillOtherService();
                        billOtherService.OtherService = otherSerice;
                        billOtherService.OtherServiceId = otherSerice.Id;
                        billOtherService.Price = otherSerice.Price;
                        billOtherService.Qty = (int)spinOthersQty.Value;
                        _BillMain.BillOtherServices.Add(billOtherService);

                        #region customer
                        if ((customer != null) && (customer.Code == cbbxCustomerCode.Text))
                        {
                            billOtherService.Customer = customer;
                            billOtherService.CustomerId = customer.Id;
                            _Customers.Add(customer);
                        }
                        #endregion

                        #region discount

                        billOtherService.DiscountPercent = 0;
                        billOtherService.DiscountVND = 0;
                        if (chkDiscountApply.Checked)
                        {
                            if (rdDiscountPercent.IsChecked)
                            {
                                int temp = (spinDiscount.Value > 100) ? 100 : (int)spinDiscount.Value;
                                billOtherService.DiscountPercent = temp;
                                billOtherService.DiscountVND = 0;
                            }
                            else
                            {
                                billOtherService.DiscountPercent = 0;
                                billOtherService.DiscountVND = (int)spinDiscount.Value;
                            }
                        }
                        #endregion

                        #region promotion
                        for (int j = 0; j < dtgPromotion.Rows.Count; j++)
                        {
                            bool isApply = (bool)dtgPromotion.Rows[j].Cells[4].Value;
                            if (isApply)
                            {
                                int promotionId = (int)(decimal)dtgPromotion.Rows[j].Cells[0].Value;
                                billOtherService.PromotionId = promotionId;
                                billOtherService.Promotion = Program.Server.GetPromotion(promotionId);

                                int discount = (int)(decimal)dtgPromotion.Rows[j].Cells[2].Value;
                                bool isPercent = (bool)dtgPromotion.Rows[j].Cells[3].Value;
                                if (isPercent == true)
                                {
                                    billOtherService.PromotionPercent = discount;
                                    billOtherService.PromotionVND = 0;
                                }
                                else
                                {
                                    billOtherService.PromotionPercent = 0;
                                    billOtherService.PromotionVND = discount;
                                }
                                break;
                            }
                        }

                        #endregion

                        #region display to gridview
                        dtgBillDetail.Rows.Add(new object[] { billOtherService.OtherService.Name, 
                                                              billOtherService.OtherService.Code, 
                                                              "", 
                                                              billOtherService.Price, 
                                                              billOtherService.Qty, 
                                                              billOtherService.Total,
                                                              billOtherService.DiscountValue});
                        if (billOtherService.PromotionValue > 0)
                        {
                            dtgBillDetail.Rows.Add(new object[] { billOtherService.Promotion.Name, billOtherService.Promotion.Code, "", 0, 0, 0, (int)billOtherService.PromotionValue });
                        }
                        #endregion
                    }
                }
                #endregion

                #region prepair for adding new one
                ClearInput();
                #endregion

                spinVAT.Value = _BillVAT;
                spinTotal.Value = _Total;
            }
            else if (sender.Equals(btnServiceAddKTV))
            {
                Personnel ktv = (Personnel)((BindingSource)cbbxServiceKTV.DataSource).Current;
                bool isCustomerOrder = chkServiceCustomerOrder.Checked;
                bool isCompanyOrder = chkServiceCompanyOrder.Checked;

                dtgServiceKTV.Rows.Add(new object[] { ktv.Id, ktv.KTVId, isCustomerOrder, isCompanyOrder });
            }
            else if (sender.Equals(btnServiceRemoveKTV))
            {
                if (dtgServiceKTV.SelectedRows.Count > 0)
                {
                    dtgServiceKTV.SelectedRows[0].Delete();
                }
            }
            else if (sender.Equals(btnPackageAddKTV))
            {
                Service service = null;
                Personnel ktv = null;
                Room room = null;
                if (cbbxPackageServiceCode.SelectedIndex >= 0)
                {
                    service = (Service)((BindingSource)cbbxPackageServiceCode.DataSource).Current;
                }
                if (cbbxPackageServiceKTV.SelectedIndex >= 0)
                {
                    ktv = (Personnel)((BindingSource)cbbxPackageServiceKTV.DataSource).Current;
                }
                if (cbbxPackageServiceRoom.SelectedIndex >= 0)
                {
                    room = (Room)((BindingSource)cbbxPackageServiceRoom.DataSource).Current;
                }

                if ((service != null) && (ktv != null) && (room != null))
                {
                    dtgPackageKTV.Rows.Add(new object[] { service.Id, ktv.Id, room.Id, service.Code, ktv.KTVId, room.Code, chkPackageCustomerOrder.Checked, chkCompanyOrder.Checked });
                }
                else
                {
                    MessageHandler.Error("Please select:\r\n1.Service code\r\n2.Room\r\n3.KTV");
                }
            }
            else if (sender.Equals(btnPackageRemoveKTV))
            {
                if (dtgPackageKTV.SelectedRows.Count > 0)
                {
                    dtgPackageKTV.SelectedRows[0].Delete();
                }
            }
            else if (sender.Equals(btnAddVoucher))
            {
                if (cbbxVoucherCode.DataSource != null)
                {
                    Certificate certificate = (Certificate)((BindingSource)cbbxVoucherCode.DataSource).Current;
                    if (certificate.Code == cbbxVoucherCode.Text)
                    {
                        bool isExisted = false;
                        for (int j = 0; j < dtgVoucher.Rows.Count; j++)
                        {
                            string certificateCode = (string)dtgVoucher.Rows[j].Cells[1].Value;
                            int seri = (int)(decimal)dtgVoucher.Rows[j].Cells[2].Value;
                            if ((certificateCode == certificate.Code) && (seri == spinVoucherSeri.Value))
                            {
                                isExisted = true;
                                break;
                            }
                        }
                        if (isExisted == false)
                        {
                            dtgVoucher.Rows.Add(new object[] { 0, certificate.Code, spinVoucherSeri.Value, spinPay.Value });
                        }
                        else
                        {
                            MessageHandler.Inform(this, "This voucher's already added!");
                        }

                    }
                }
            }
            else if (sender.Equals(btnRemoveVoucher))
            {
                if (dtgVoucher.SelectedRows.Count > 0)
                {
                    dtgVoucher.SelectedRows[0].Delete();
                    spinTotal.Value = _Total;
                }
            }
            else if (sender.Equals(btnPrint))
            {
                #region print bill
                if ((_BillMain != null) && (cbbxPayer.Text != ""))
                {
                    _BillMain.Shift = (int)spinShift.Value;
                    _BillMain.User = this.User;
                    _BillMain.UserId = this.User.Id;
                    _BillMain.CustomerName = cbbxPayer.Text;
                    _BillMain.Customer = _Customers[cbbxPayer.SelectedIndex];
                    _BillMain.CustomerId = (_Customers[cbbxPayer.SelectedIndex].Id >= 0) ? _Customers[cbbxPayer.SelectedIndex].Id : (int?)null;
                    _BillMain.NumberOfPerson = (int)spinPersons.Value;
                    _BillMain.VND = 0;
                    _BillMain.USD = 0;
                    _BillMain.Visa = 0;
                    _BillMain.Date = DateTime.Now;
                    _BillMain.Note = txtNote.Text;
                    _BillMain.Branch = _Branch;
                    _BillMain.ServiceCharge = _BillServiceCharge;
                    _BillMain.RawTotal = _BillRawTotal;
                    _BillMain.RawTotalDiscount = _BillRawTotalDiscount;
                    _BillMain.Voucher = _BillVoucher;
                    _BillMain.BillDiscount = _BillTotalDiscount;
                    _BillMain.VAT = chkIncludeVAT.Checked ? _BillVAT : 0;
                    _BillMain.FinalTotal = _Total;
                    if (_BillMain.Voucher >= _BillMain.FinalTotal)
                    {
                        _BillMain.Status = BillStatus.Payed;
                    }
                    else
                    {
                        _BillMain.Status = BillStatus.NotPayed;
                    }

                    for (int j = 0; j < dtgBillDetail.Rows.Count; j++)
                    {
                        BillDetail detail = new BillDetail();
                        detail.Description = (string)dtgBillDetail.Rows[j].Cells[0].Value;
                        detail.Code = (string)dtgBillDetail.Rows[j].Cells[1].Value;
                        detail.KTV = (string)dtgBillDetail.Rows[j].Cells[2].Value;
                        detail.Price = (int)(decimal)dtgBillDetail.Rows[j].Cells[3].Value;
                        detail.Qty = (int)(decimal)dtgBillDetail.Rows[j].Cells[4].Value;
                        detail.Total = (int)(decimal)dtgBillDetail.Rows[j].Cells[5].Value;
                        detail.Discount = (int)(decimal)dtgBillDetail.Rows[j].Cells[6].Value;
                        detail.BillMain = _BillMain;
                        _BillMain.BillDetails.Add(detail);
                    }

                    int billId = 0;
                    ErrorCode error = Program.Server.AddNewBillMain(_BillMain.BillNumber, _BillMain.Shift, _BillMain.UserId, _BillMain.CustomerId, _BillMain.CustomerName, _BillMain.NumberOfPerson, _BillMain.NumberOfService, _BillMain.Note, _BillMain.Branch, _BillMain.ServiceCharge, _BillMain.RawTotal, _BillMain.RawTotalDiscount, _BillMain.Voucher, _BillMain.BillDiscount, _BillMain.FinalTotal, _BillMain.VAT, _BillMain.Status, out billId);
                    if (error == ErrorCode.OK)
                    {
                        _BillMain.Id = billId;
                        #region add billServices
                        foreach (BillService billService in _BillMain.BillServices)
                        {
                            int billServiceId = -1;
                            billService.BillMainId = _BillMain.Id;
                            error += (int)Program.Server.AddNewBillService(billService.BillMainId, billService.BillPackageId, billService.ServiceId, billService.Price, billService.Qty, billService.ServiceChargePercent, billService.PromotionId, billService.PromotionPercent, billService.PromotionVND, billService.DiscountPercent, billService.DiscountVND, billService.RoomId, billService.RoomChargePercent, billService.CustomerId, billService.CustomerDiscountPercent, billService.CustomerDiscountVND, out billServiceId);
                            if (error == ErrorCode.OK)
                            {
                                billService.Id = billServiceId;
                                #region add billKTV
                                foreach (BillKTV billKTV in billService.BillKTVs)
                                {
                                    int billKTVId = -1;
                                    billKTV.BillServiceId = billService.Id;
                                    error += (int)Program.Server.AddNewBillKTV(billKTV.BillServiceId, billKTV.PersonnelId, billKTV.ChargePercent, billKTV.Tour, billKTV.IsCustomerOrder, billKTV.IsCompanyOrder, out billKTVId);
                                    if (error == ErrorCode.OK)
                                    {
                                        billKTV.Id = billKTVId;
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion

                        #region add billPackages
                        foreach (BillPackage billPackage in _BillMain.BillPackages)
                        {
                            int billPackageId = -1;
                            billPackage.BillMainId = _BillMain.Id;
                            error += (int)Program.Server.AddNewBillPackage(billPackage.BillMainId, billPackage.PackageId, billPackage.Price, billPackage.Qty, billPackage.ServiceChargePercent, billPackage.PromotionId, billPackage.PromotionPercent, billPackage.PromotionVND, billPackage.DiscountPercent, billPackage.DiscountVND, billPackage.CustomerId, billPackage.CustomerDiscountPercent, billPackage.CustomerDiscountVND, out billPackageId);
                            if (error == ErrorCode.OK)
                            {
                                billPackage.Id = billPackageId;
                                #region add billServices
                                foreach (BillService billService in billPackage.BillServices)
                                {
                                    int billServiceId = -1;
                                    billService.BillPackageId = billPackage.Id;
                                    error += (int)Program.Server.AddNewBillService(billService.BillMainId, billService.BillPackageId, billService.ServiceId, billService.Price, billService.Qty, billService.ServiceChargePercent, billService.PromotionId, billService.PromotionPercent, billService.PromotionVND, billService.DiscountPercent, billService.DiscountVND, billService.RoomId, billService.RoomChargePercent, billService.CustomerId, billService.CustomerDiscountPercent, billService.CustomerDiscountValue, out billServiceId);
                                    if (error == ErrorCode.OK)
                                    {
                                        billService.Id = billServiceId;
                                        #region add billKTV
                                        foreach (BillKTV billKTV in billService.BillKTVs)
                                        {
                                            int billKTVId = -1;
                                            billKTV.BillServiceId = billService.Id;
                                            error += (int)Program.Server.AddNewBillKTV(billKTV.BillServiceId, billKTV.PersonnelId, billKTV.ChargePercent, billKTV.Tour, billKTV.IsCustomerOrder, billKTV.IsCompanyOrder, out billKTVId);
                                            if (error == ErrorCode.OK)
                                            {
                                                billKTV.Id = billKTVId;
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #endregion
                            }
                        }

                        #endregion

                        #region add billCertificates
                        foreach (BillCertificate billCertificate in _BillMain.BillCertificates)
                        {
                            billCertificate.BillMainId = _BillMain.Id;
                            int billCertificateId = -1;
                            error += (int)Program.Server.AddNewBillCertificate(billCertificate.BillMainId, billCertificate.CertificateId, billCertificate.Price, billCertificate.PromotionId, billCertificate.PromotionPercent, billCertificate.PromotionVND, billCertificate.DiscountPercent, billCertificate.DiscountVND, billCertificate.CustomerId, billCertificate.Series, out billCertificateId);
                            if (error == ErrorCode.OK)
                            {
                                billCertificate.Id = billCertificateId;
                            }
                        }
                        #endregion

                        #region add billOthers
                        foreach (BillOtherService billOtherService in _BillMain.BillOtherServices)
                        {
                            billOtherService.BillMainId = _BillMain.Id;
                            int billOtherServiceId = -1;
                            error += (int)Program.Server.AddNewBillOtherService(billOtherService.BillMainId, billOtherService.OtherServiceId, billOtherService.Price, billOtherService.Qty, billOtherService.PromotionId, billOtherService.PromotionPercent, billOtherService.PromotionVND, billOtherService.DiscountPercent, billOtherService.DiscountVND, billOtherService.CustomerId, out billOtherServiceId);
                            if (error == ErrorCode.OK)
                            {
                                billOtherService.Id = billOtherServiceId;
                            }
                        }

                        #endregion

                        #region add bill Voucher Payment
                        for (int j = 0; j < dtgVoucher.Rows.Count; j++)
                        {
                            string certificateCode = (string)dtgVoucher.Rows[j].Cells[1].Value;
                            int seri = (int)(decimal)dtgVoucher.Rows[j].Cells[2].Value;
                            int pay = (int)(decimal)dtgVoucher.Rows[j].Cells[3].Value;
                            Program.Server.AddNewBillVoucherPayment(_BillMain.Id, certificateCode, seri, pay);
                        }

                        #endregion

                        #region add billDetails
                        foreach (BillDetail detail in _BillMain.BillDetails)
                        {
                            error = Program.Server.AddNewBillDetail(detail.Description, detail.Code, detail.KTV, detail.Price, detail.Qty, detail.Total, detail.Discount, _BillMain.Id);
                        }
                        #endregion

                        if (error == ErrorCode.OK)
                        {
                            // Print bill
                            Helper.PrintBill print = new Helper.PrintBill();
                            print.Bill = _BillMain;
                            string textBill = print.Print();

                            // Email bill
                            SendEmail(textBill, _BillMain.CustomerName, _BillMain.BillNumber);

                            // Prepare new bill
                            MessageHandler.Inform(this, "Save bill successfully ! Prepare for new bill !");

                        }
                        else
                        {
                            // remove recent billMain from database completely
                            Program.Server.DeleteBillMain(_BillMain.BillNumber, true);

                            // confirm to user
                            MessageHandler.Error("Fail to save bill !");
                        }

                    }

                }
                #endregion
            }
            else if (sender.Equals(btnFillPayment))
            {
                FrmPayment f = new FrmPayment();
                f.ShowDialog();
            }
        }

        private void dtgBillDetail_CreateCell(object sender, Telerik.WinControls.UI.GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
        }

        private void dtgBillDetail_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void ServiceBindingSource_SelectionChanged(object sender, EventArgs e)
        {
            cbbxServiceKTV.Items.Clear();

            BindingSource bs = (BindingSource)sender;
            Service service = (Service)bs.Current;
            if (service != null)
            {
                string serviceCode = service.Code;
                List<Personnel> ktvs = Program.Server.GetKTVs(serviceCode);

                BindingSource ktvSource = new BindingSource();
                ktvSource.DataSource = ktvs;

                cbbxServiceKTV.DataSource = ktvSource;
                cbbxServiceKTV.DisplayMember = "KTVId";
            }
        }

        private void PackageBindingSource_SelectionChanged(object sender, EventArgs e)
        {
            BindingSource packageSource = (BindingSource)sender;
            Package package = (Package)packageSource.Current;
            if (package != null)
            {
                string packageCode = package.Code;
                List<Service> services = Program.Server.GetServices(packageCode);
                services.Add(null);
                BindingSource bs = new BindingSource();
                bs.DataSource = services;
                bs.MoveLast();
                bs.PositionChanged += PackageService_PositionChanged;

                cbbxPackageServiceCode.DataSource = bs;
                cbbxPackageServiceCode.DisplayMember = "Code";
                cbbxPackageServiceCode.AutoCompleteDataSource = bs;
                cbbxPackageServiceCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbxPackageServiceCode.AutoCompleteDisplayMember = "Code";

                dtgPackageKTV.Rows.Clear();
            }
        }

        private void PackageService_PositionChanged(object sender, EventArgs e)
        {
            cbbxPackageServiceKTV.Items.Clear();

            BindingSource bs = (BindingSource)sender;
            Service service = (Service)bs.Current;

            if (service != null)
            {
                string serviceCode = service.Code;
                List<Personnel> ktvs = Program.Server.GetKTVs(serviceCode);

                BindingSource ktvSource = new BindingSource();
                ktvSource.DataSource = ktvs;

                cbbxPackageServiceKTV.DataSource = ktvSource;
                cbbxPackageServiceKTV.DisplayMember = "KTVId";
            }
        }

        private void CertificateBindingSource_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dtgPromotion_Click(object sender, EventArgs e)
        {
            if (dtgPromotion.SelectedRows.Count > 0)
            {
                chkDiscountApply.Checked = false;
                bool isApply = (bool)dtgPromotion.SelectedRows[0].Cells[4].Value;
                if (isApply == true)
                {
                    dtgPromotion.SelectedRows[0].Cells[4].Value = false;
                }
                else
                {
                    for (int j = 0; j < dtgPromotion.Rows.Count; j++)
                    {
                        dtgPromotion.Rows[j].Cells[4].Value = false;
                    }
                    dtgPromotion.SelectedRows[0].Cells[4].Value = true;
                }
            }
        }

        private void chkDiscountApply_CheckStateChanged(object sender, EventArgs e)
        {
            if (sender.Equals(chkDiscountApply))
            {
                if (chkDiscountApply.Checked == true)
                {
                    for (int j = 0; j < dtgPromotion.Rows.Count; j++)
                    {
                        dtgPromotion.Rows[j].Cells[4].Value = false;
                    }
                }
            }
            else if (sender.Equals(rdDiscountPercent))
            {
                spinDiscount.Value = 0;
            }
            else if (sender.Equals(rdTotalDiscountPercent))
            {
                spinTotalDiscount.Value = 0;
            }
            else if (sender.Equals(chkIncludeVAT))
            {
                spinTotal.Value = _Total;
            }


        }

        private void spinServiceCharge_ValueChanged(object sender, EventArgs e)
        {
            if (sender.Equals(spinVoucherSeri))
            {
                btnAddVoucher.Enabled = false;
                spinRemain.Value = 0;
                spinPay.Maximum = 0;
                spinPay.Value = 0;
                txtVoucherBoughtBy.Text = "";
                if (cbbxVoucherCode.DataSource != null)
                {
                    Certificate certificate = (Certificate)((BindingSource)cbbxVoucherCode.DataSource).Current;
                    if (certificate.Code == cbbxVoucherCode.Text)
                    {
                        var query = (from q in certificate.CertificateSeries
                                     where q.Seri == spinVoucherSeri.Value
                                     select q).FirstOrDefault();
                        if (query != null)
                        {
                            switch (query.Status)
                            {
                                case CertificateStatus.Saled:
                                    btnAddVoucher.Enabled = true;
                                    spinRemain.Value = query.Remain;
                                    spinPay.Maximum = query.Remain;
                                    spinPay.Value = query.Remain;
                                    txtVoucherBoughtBy.Text = query.BillCertificate.BillMain.CustomerName;
                                    break;
                                case CertificateStatus.New:
                                    MessageHandler.Inform(this, "This seri hasn't been saled!");
                                    break;
                                case CertificateStatus.Expiry:
                                    MessageHandler.Inform(this, "This seri is expired");
                                    break;
                                case CertificateStatus.Returned:
                                    MessageHandler.Inform(this, "This seri came back already!");
                                    break;
                            }

                        }
                    }
                }
            }
            else if (sender.Equals(spinServiceCharge) || sender.Equals(spinTotalDiscount))
            {
                spinVAT.Value = _BillVAT;
                spinTotal.Value = _Total;
            }

        }

        private void cbbxPayer_PopupOpening(object sender, CancelEventArgs e)
        {
            Customer cus = new Customer();
            cus.Name = "MR/MS";
            cus.Id = -1;
            _Customers.Add(cus);

            cbbxPayer.DataSource = _Customers;
            cbbxPayer.DisplayMember = "Name";
            cbbxPayer.ValueMember = "Id";
        }

        #endregion
    }
}



