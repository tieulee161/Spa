using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using SpaManagementV3.View.Template;
using SpaDatabase.Model.Entities;

namespace SpaManagementV3.View
{
    public partial class FrmRoomManagement9C : Telerik.WinControls.UI.RadForm
    {

        #region properties
        private List<UcBed> Beds { get; set; }
        #endregion

        #region ctor
        public FrmRoomManagement9C()
        {
            InitializeComponent();
        }
        #endregion

        #region method
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            #region init bed
            Beds = new List<UcBed>();
            Beds.Add(UCVIP1_1);
            Beds.Add(UCVIP1_2);

            Beds.Add(UCVIP2_1);
            Beds.Add(UCVIP2_2);

            Beds.Add(UCBody1_1);
            Beds.Add(UCBody1_2);
            Beds.Add(UCBody1_3);
            Beds.Add(UCBody1_4);
            Beds.Add(UCBody1_5);

            Beds.Add(UCBody2_1);
            Beds.Add(UCBody2_2);
            Beds.Add(UCBody2_3);

            Beds.Add(UCBody3_1);
            Beds.Add(UCBody3_2);
            Beds.Add(UCBody3_3);
            Beds.Add(UCBody3_4);
            Beds.Add(UCBody3_5);

            Beds.Add(UCBody4_1);
            Beds.Add(UCBody4_2);
            Beds.Add(UCBody4_3);

            Beds.Add(UCFoot_1);
            Beds.Add(UCFoot_2);
            Beds.Add(UCFoot_3);
            Beds.Add(UCFoot_4);

            Beds.Add(UCThai_1);
            Beds.Add(UCThai_2);
            Beds.Add(UCThai_3);
            Beds.Add(UCThai_4);
            Beds.Add(UCThai_5);

         //   Program.Server.FixBadBedTransaction();

            foreach(UcBed bed in Beds)
            {
                bed.IsActive = true;
                bed.LoadTransaction();
            }

            timer1.Enabled = true;
            #endregion
        }

        #endregion

        #region event
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (UcBed bed in Beds)
            {
                if(bed.Status == Template.BedStatus.Busy)
                {
                    bed.CheckRemainTime();
                }
            }
        }

        #endregion
    }
}
