using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using SpaDatabase.Model;
using SpaDatabase.Model.Entities;
using System.Linq;
using Telerik.WinControls.UI;
using SpaCommon;

namespace SpaManagementV3.View
{
    public partial class FrmPayment : Telerik.WinControls.UI.RadForm
    {
        #region properties
        int _VND
        {
            get
            {
                return (int)spinVND.Value;
            }
            set
            {
                spinVND.Value = value;
            }
        }

        int _Visa
        {
            get
            {
                return (int)spinVisa.Value;
            }
            set
            {
                spinVisa.Value = value;
            }
        }

        int _USD
        {
            get
            {
                return (int)spinUSD.Value;
            }
            set
            {
                spinUSD.Value = value;
            }
        }

        int _ExchangeRate { get; set; }

        DateTime _CurrentDateSearch { get; set; }
        #endregion

        #region ctor
        public FrmPayment()
        {
            InitializeComponent();
        }
        #endregion

        #region method
        private void LoadData()
        {
            _ExchangeRate = Program.Server.GetExchangeRate();
            dateSearch.Value = DateTime.Now;
            _CurrentDateSearch = dateSearch.Value;
            LoadTreeBrowser();
        }

        private void InitEvent()
        {
            btnSavePayment.Click += Button_Click;
            btnDestroyBill.Click += Button_Click;
            dateSearch.ValueChanged += dateSearch_ValueChanged;
            treeBrowser.SelectedNodeChanged += treeBrowser_SelectedNodeChanged;
        }
        private void LoadTreeBrowser()
        {
            treeBrowser.Nodes.Clear();
            Dictionary<BillStatus, List<BillMain>> bills = Program.Server.GetClassifiedBills(_CurrentDateSearch);
            foreach (BillStatus status in bills.Keys)
            {
                RadTreeNode parentNode = new RadTreeNode();
                switch (status)
                {
                    case BillStatus.NotPayed:
                        parentNode.Text = "Not paid bill";
                        break;
                    case BillStatus.Payed:
                        parentNode.Text = "Paid bill";
                        break;
                    case BillStatus.Bad:
                        parentNode.Text = "Error bill";
                        break;
                }

                foreach (BillMain bill in bills[status])
                {
                    RadTreeNode childNode = new RadTreeNode(bill.BillNumber.ToString());
                    childNode.Value = bill;
                    parentNode.Nodes.Add(childNode);
                }

                treeBrowser.Nodes.Add(parentNode);
            }


        }

        #endregion

        #region event
        protected override void OnLoad(EventArgs e)
        {
            LoadData();
            InitEvent();
            base.OnLoad(e);
        }




        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnSavePayment))
            {
                if (billInfo.Bill != null)
                {
                    ErrorCode err = Program.Server.UpdateBillPayment(billInfo.Bill.BillNumber, _VND, _USD, _Visa);
                    if (err == ErrorCode.OK)
                    {
                        MessageHandler.UpdateInfoSuccessfully(this);
                        LoadTreeBrowser();
                    }
                    else
                    {
                        MessageHandler.ErrorOnUpdate(this);
                    }
                }
            }
            else if (sender.Equals(btnDestroyBill))
            {
                if (txtReason.Text != "")
                {
                    if (billInfo.Bill != null)
                    {
                        if(MessageHandler.Question("Are you sure you want to mark this bill as error one?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            ErrorCode err = Program.Server.DestroyBill(billInfo.Bill.BillNumber, txtReason.Text);
                            if (err == ErrorCode.OK)
                            {
                                MessageHandler.UpdateInfoSuccessfully(this);
                                LoadTreeBrowser();
                            }
                            else
                            {
                                MessageHandler.ErrorOnUpdate(this);
                            }
                        }
                        
                    }
                    else
                    {
                        MessageHandler.Inform(this, "Please choose the bill you want to update !");
                    }
                }
                else
                {
                    MessageHandler.Inform(this, "Type the reason why you destroy this bill!");
                }

            }
        }

        private void dateSearch_ValueChanged(object sender, EventArgs e)
        {
            if (_CurrentDateSearch.Month != dateSearch.Value.Month)
            {
                _CurrentDateSearch = dateSearch.Value;
                LoadTreeBrowser();
            }
        }

        private void treeBrowser_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if ((treeBrowser.SelectedNode != null) && (treeBrowser.SelectedNode.Level == 1))
            {
                BillMain bill = (BillMain)treeBrowser.SelectedNode.Value;
                billInfo.Bill = bill;
                _VND = bill.VND;
                _USD = bill.USD;
                _Visa = bill.Visa;
                txtReason.Text = bill.DeleteBillReason;
            }
        }
        #endregion
    }
}
