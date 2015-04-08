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
    public partial class FrmConditionForReport : Telerik.WinControls.UI.RadForm
    {
        public FrmConditionForReport()
        {
            InitializeComponent();
        }

        #region property
        public List<int> KTVs
        {
            get
            {
                List<int> res = new List<int>();
                for (int j = 0; j < dtgKTV.Rows.Count; j++)
                {
                    bool isChecked = (bool)dtgKTV.Rows[j].Cells[1].Value;
                    if (isChecked)
                    {
                        int ktvId = (int)(decimal)dtgKTV.SelectedRows[j].Cells[0].Value;
                        res.Add(ktvId);
                    }
                }
                return res;
            }
        }

        public List<int> Customers
        {
            get
            {
                List<int> res = new List<int>();
                for (int j = 0; j < dtgCustomer.Rows.Count; j++)
                {
                    bool isChecked = (bool)dtgCustomer.Rows[j].Cells[1].Value;
                    if (isChecked)
                    {
                        int customerId = (int)(decimal)dtgCustomer.SelectedRows[j].Cells[0].Value;
                        res.Add(customerId);
                    }
                }
                return res;
            }
        }

        public DateTime Datefrom
        {
            get
            {
                return dateFrom.Value.Date;
            }
        }

        public DateTime Dateto
        {
            get
            {
                return dateTo.Value.Date;
            }
        }

        public bool IsOK { get; set; }
        #endregion

        #region method
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeGridview(dtgCustomer);
            InitializeGridview(dtgKTV);

            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;

            LoadData();
        }

        private void WireEvents()
        {
            btnOK.Click += Button_Click;
            btnCancel.Click += Button_Click;
        }


        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
            grid.CreateCell += grid_CreateCell;
            grid.RowFormatting += grid_RowFormatting;
        }

        public void CollapseKTVPanel(bool isColappsed)
        {
            splitKTV.Collapsed = isColappsed;
        }

        public void CollapseCustomerPanel(bool isColappsed)
        {
            splitCustomer.Collapsed = isColappsed;
        }

        public void CollapseDatePanel(bool isColappsed)
        {
            splitDate.Collapsed = isColappsed;
        }

        private void LoadData()
        {
            List<Personnel> ktvs = Program.Server.GetKTVs();
            for (int j = 0; j < ktvs.Count; j++)
            {
                dtgKTV.Rows.Add(new object[] { ktvs[j].Id, false, ktvs[j].Code, ktvs[j].Name });
            }

            List<Customer> customers = Program.Server.GetCustomers();
            foreach (Customer cus in customers)
            {
                dtgCustomer.Rows.Add(new object[] { cus.Id, false, cus.Code, cus.Name });
            }
        }

        #endregion

        #region event
        void grid_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)10);
        }

        void grid_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnOK))
            {
                IsOK = true;
            }
            else if (sender.Equals(btnCancel))
            {
                IsOK = false;
            }

            Close();
        }
        #endregion
    }

}
