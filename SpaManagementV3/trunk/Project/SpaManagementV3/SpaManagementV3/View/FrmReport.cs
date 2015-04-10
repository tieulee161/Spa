using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using Telerik.WinControls.UI;

namespace SpaManagementV3.View
{
    public partial class FrmReport : Telerik.WinControls.UI.RadForm
    {
        public FrmReport()
        {
            InitializeComponent();

        }

        #region property

        #endregion

        #region method
        private void WireEvents()
        {
            btnKTVRevenueSpecific.Click += KTVReport_Click;
            btnKTVRevenueDaily.Click += KTVReport_Click;
            btnKTVRevenueMonthly.Click += KTVReport_Click;
            btnKTVOrderSpecific.Click += KTVReport_Click;
            btnKTVOrderMonthly.Click += KTVReport_Click;
            btnKTVOrderDaily.Click += KTVReport_Click;

            btnCustomerKTVDaily.Click += CustomerReport_Click;
            btnCustomerKTVMonthly.Click += CustomerReport_Click;
            btnCustomerMember.Click += CustomerReport_Click;
            btnCustomerPromotion.Click += CustomerReport_Click;
            btnCustomerRevenueDaily.Click += CustomerReport_Click;
            btnCustomerRevenueMonthly.Click += CustomerReport_Click;
            btnCustomerRevenueSpecific.Click += CustomerReport_Click;
            btnCustomerVoucher.Click += CustomerReport_Click;

            btnShift.Click += DailyReport_Click;
            btnDay.Click += DailyReport_Click;
            btnRevenue.Click += DailyReport_Click;
            btnRevenueDaily.Click += DailyReport_Click;
            btnRevenueMonthly.Click += DailyReport_Click;

            btnImport.Click += WarehouseReport_Click;
            btnExport.Click += WarehouseReport_Click;
            btnInventory.Click += WarehouseReport_Click;

            btnRevenueServiceDaily.Click += ServiceReport_Click;
            btnRevenueServiceMonthly.Click += ServiceReport_Click;
            btnRevenueServicePromotion.Click += ServiceReport_Click;
            btnRevenueVoucher.Click += ServiceReport_Click;
        }

        #endregion

        #region event
        private void dtgVoucher_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void dtgVoucher_CreateCell(object sender, Telerik.WinControls.UI.GridViewCreateCellEventArgs e)
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            WireEvents();
        }

        private void KTVReport_Click(object sender, EventArgs e)
        {
            if(sender.Equals(btnKTVOrderDaily))
            {

            }
            else if (sender.Equals(btnKTVOrderMonthly))
            {

            }
            else if (sender.Equals(btnKTVOrderSpecific))
            {

            }
            else if (sender.Equals(btnKTVRevenueDaily))
            {

            }
            else if (sender.Equals(btnKTVRevenueMonthly))
            {

            }
            else if (sender.Equals(btnKTVRevenueSpecific))
            {

            }
        }

        private void CustomerReport_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnCustomerKTVDaily))
            {

            }
            else if (sender.Equals(btnCustomerKTVMonthly))
            {

            }
            else if (sender.Equals(btnCustomerMember))
            {

            }
            else if (sender.Equals(btnCustomerPromotion))
            {

            }
            else if (sender.Equals(btnCustomerRevenueDaily))
            {

            }
            else if (sender.Equals(btnCustomerRevenueMonthly))
            {

            }
            else if (sender.Equals(btnCustomerRevenueSpecific))
            {

            }
            else if (sender.Equals(btnCustomerVoucher))
            {

            }
        }

        private void DailyReport_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnShift))
            {

            }
            else if (sender.Equals(btnDay))
            {

            }
            else if (sender.Equals(btnRevenue))
            {
                FrmConditionForReport f = new FrmConditionForReport();
                f.CollapseCustomerPanel(true);
                f.CollapseKTVPanel(true);
                f.ShowDialog();
                if(f.IsOK)
                {

                }
            }
            else if (sender.Equals(btnRevenueDaily))
            {

            }
            else if (sender.Equals(btnRevenueMonthly))
            {

            }
        }

        private void WarehouseReport_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnImport))
            {

            }
            else if (sender.Equals(btnExport))
            {

            }
            else if (sender.Equals(btnInventory))
            {

            }
        }

        private void ServiceReport_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnRevenueServiceDaily))
            {

            }
            else if (sender.Equals(btnRevenueServiceMonthly))
            {

            }
            else if (sender.Equals(btnRevenueServicePromotion))
            {

            }
            else if (sender.Equals(btnRevenueVoucher))
            {

            }
        }

        #endregion
    }
}
