using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using SpaDatabase.Model.Entities;
using SpaCommon;

namespace SpaManagementV3.View.Template
{
    public partial class FrmBedSetting : Telerik.WinControls.UI.RadForm
    {
        #region properties
        public UcBed UcBed { get; set; }
        #endregion

        #region ctor
        public FrmBedSetting()
        {
            InitializeComponent();
        }
        #endregion

        #region method

        #endregion

        #region event
        protected override void OnLoad(EventArgs e)
        {
            List<Service> services = Program.Server.GetServices();
            services.Add(null);
            BindingSource bs = new BindingSource();
            bs.DataSource = services;
            bs.MoveLast();

            cbbxService.DataSource = bs;
            cbbxService.DisplayMember = "Name";
            cbbxService.ValueMember = "Code";
            bs.PositionChanged += bs_PositionChanged;
            btnStart.Click += Button_Click;
            btnCancel.Click += Button_Click;

            timeStart.Value = DateTime.Now;

            base.OnLoad(e);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnStart))
            {
                if ((timeStart.Value != null) && (spinDuration.Value > 0) && (cbbxService.SelectedIndex >= 0) && (autoCompleteKTV.Items.Count > 0))
                {
                    DateTime startTime = (DateTime)timeStart.Value;
                    int duration = (int)spinDuration.Value;
                    Service service = (Service)((BindingSource)cbbxService.DataSource).Current;
                    string serviceCode = service.Code;
                    List<string> ktvCodes = new List<string>();
                    for (int j = 0; j < autoCompleteKTV.Items.Count; j++)
                    {
                        ktvCodes.Add((string)autoCompleteKTV.Items[j].Value);
                    }
                    BedTransaction transaction = null;
                    if (Program.Server.AddNewBedTransaction(UcBed.Room, UcBed.Branch, UcBed.BedID, startTime, duration, serviceCode, ktvCodes, out transaction) == SpaCommon.ErrorCode.OK)
                    {
                        UcBed.BedTransaction = transaction;
                     
                        Close();
                    }
                    else
                    {
                        UcBed.BedTransaction = null;
                        MessageHandler.ErrorOnAdd();
                    }
                }
                else
                {
                    MessageHandler.AsktoFulfillInput();
                }


            }
            else if (sender.Equals(btnCancel))
            {
                Close();
            }
        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            Service service = (Service)((BindingSource)cbbxService.DataSource).Current;
            if (service != null)
            {
                autoCompleteKTV.AutoCompleteDataSource = service.Personnels;
                autoCompleteKTV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                autoCompleteKTV.AutoCompleteDisplayMember = "KTVId";
                autoCompleteKTV.AutoCompleteValueMember = "Code";
            }
            else
            {
                autoCompleteKTV.AutoCompleteDataSource = null;
            }
        }

        #endregion
    }
}
