using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SpaDatabase.Model.Entities;
using SpaDatabase.Model;
using SpaDatabase.Services;

namespace SpaManagementV3.View.Template
{
    public partial class UCBillTemplate : UserControl
    {
        #region properties
        private BillMain _Bill;
        public BillMain Bill
        {
            get
            {
                return _Bill;
            }
            set
            {
                if (_Bill != value)
                {
                    _Bill = value;
                    Display();
                }
            }
        }

        #endregion

        #region ctor
        public UCBillTemplate()
        {
            InitializeComponent();
        }
        #endregion

        #region method
        private void Display()
        {
            if (Bill != null)
            {
                cbbxCashier.Text = Bill.User.FullName;
                cbbxCustomer.Text = Bill.CustomerName;
                spinBillNumber.Value = Bill.BillNumber;
                dateBill.Value = Bill.Date;

                dtgBillDetail.Rows.Clear();
                foreach (BillDetail detail in Bill.BillDetails)
                {
                    dtgBillDetail.Rows.Add(new object[] { detail.Description,
                                                          detail.Code,
                                                          detail.KTV,
                                                          detail.Price,
                                                          detail.Qty,
                                                          detail.Total,
                                                          detail.Discount
                                                        });
                }

                dtgVoucher.Rows.Clear();
                foreach (BillVoucherPayment voucher in Bill.BillVoucherPayments)
                {
                    dtgVoucher.Rows.Add(new object[] { 0, voucher.CertificateSeri.Certificate.Code, voucher.CertificateSeri.Seri, voucher.Pay });
                }

                spinRawTotal.Value = Bill.RawTotal;
                spinTotalDiscount.Value = Bill.RawTotalDiscount;
                spinVoucher.Value = Bill.Voucher;
                spinServiceCharge.Value = Bill.ServiceCharge;
                spinBillDiscount.Value = Bill.BillDiscount;
                spinVAT.Value = Bill.VAT;
                spinFinalTotal.Value = Bill.FinalTotal - Bill.Voucher;
            }
        }


        #endregion


    }
}
