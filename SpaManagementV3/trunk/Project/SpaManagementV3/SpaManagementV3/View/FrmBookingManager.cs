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
    public partial class FrmBookingManager : Telerik.WinControls.UI.RadForm
    {
        public FrmBookingManager()
        {
            InitializeComponent();
            calendar.MultiViewRows = 3;
            calendar.SelectedDate = DateTime.Now;
            InitializeGridview(dtgBooking);
       
        }

        #region property
        public bool IsNew { get; set; }

        #endregion

        #region event
        private void dtgBooking_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void dtgBooking_CreateCell(object sender, Telerik.WinControls.UI.GridViewCreateCellEventArgs e)
        {

        }

        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
        }

        private void FrmBooking_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnNewBooking))
            {
               
            }
            else if (sender.Equals(contextCancel))
            {

            }
            else if (sender.Equals(contextDelete))
            {

            }
         
        }

        private void calendar_SelectionChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region method
        private void InitEvent()
        {
            btnNewBooking.Click += Button_Click;
            contextCancel.Click += Button_Click;
            contextDelete.Click += Button_Click;

            dtgBooking.RowFormatting += dtgBooking_RowFormatting;
            dtgBooking.CreateCell += dtgBooking_CreateCell;

            calendar.SelectionChanged += calendar_SelectionChanged;
        }

        private void LoadData()
        {
            
        }
        #endregion
    }
}
