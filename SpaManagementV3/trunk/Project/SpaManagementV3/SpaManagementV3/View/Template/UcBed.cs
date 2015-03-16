using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SpaCommon;
using SpaDatabase.Model.Entities;

namespace SpaManagementV3.View.Template
{
    public enum BedStatus
    {
        Available,
        Busy
    }
    public partial class UcBed : UserControl
    {
        #region properties
        private BedTransaction _BedTransaction;
        public BedTransaction BedTransaction
        {
            get
            {
                return _BedTransaction;
            }
            set
            {
                _BedTransaction = value;
                if (_BedTransaction != null)
                {
                    this.StartTime = _BedTransaction.StartTime;
                    this.Duration = _BedTransaction.Duration;
                    List<int> ktvs = new List<int>();
                    foreach (Personnel ktv in _BedTransaction.KTVs)
                    {
                        ktvs.Add(ktv.KTVId);
                    }
                    this.KTV = string.Join(",", ktvs);
                    CheckRemainTime();
                    Display();
                }
            }
        }

        public bool IsActive = false; // use for development process

        private int _BedID = 0;
        public int BedID
        {
            get
            {
                return _BedID;
            }
            set
            {
                if (value < 0) value = 0;
                _BedID = value;
                Display();
            }
        }

        public string Room { get; set; }

        public Branch Branch { get; set; }

        private int _Duration = 0;
        public int Duration
        {
            get
            {
                return _Duration;
            }
            set
            {
                if (value < 0) value = 0;
                _Duration = value;
                progressTimeLeft.Maximum = Duration;
                Display();

            }
        }

        private DateTime _StartTime;
        public DateTime StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
                Display();
            }
        }

        private string _KTV = "";
        public string KTV
        {
            get
            {
                return _KTV;
            }
            set
            {
                _KTV = value;
                Display();
            }
        }

        public BedStatus Status
        {
            get
            {
                BedStatus res = BedStatus.Available;
                if (Remain > 0)
                {
                    res = BedStatus.Busy;
                }
                return res;
            }
        }

        private int _Remain = 0;
        public int Remain
        {
            get
            {
                return _Remain;
            }
            set
            {
                if (value <= 0) value = 0;
                _Remain = value;
                ShowRemainingStatus();

                if (Remain > Duration) Remain = Duration;

                if (Remain == 0)
                {
                    Display();
                    if (BedTransaction != null)
                    {
                        Program.Server.StopBedTransaction(BedTransaction.Id);
                    }

                    if (IsActive)
                    {
                        // inform to user
                        MessageHandler.Inform(string.Format("Bed {0} - Room {1} - KTV {2} is out of time", BedID, Room, KTV));
                    }
                    contextNewTransaction.Enabled = true;
                    contextStopTransaction.Enabled = false;
                }
                else
                {
                    contextNewTransaction.Enabled = false;
                    contextStopTransaction.Enabled = true;
                }
            }
        }

        public DateTime EndTime
        {
            get
            {
                return StartTime.AddMinutes(Duration);
            }
        }

        #endregion

        #region ctor
        public UcBed()
        {
            InitializeComponent();

            BedID = 0;
            Room = "";
            Duration = 0;
            Remain = 0;
            StartTime = DateTime.Now;
            KTV = "";

            contextNewTransaction.Click += Element_Click;
            contextStopTransaction.Click += Element_Click;
        }


        #endregion

        #region method
        private void Display()
        {
            if (this.Status == BedStatus.Busy)
            {
                if (KTV != "")
                {
                    progressTimeLeft.Text = string.Format("Bed {0}-KTV:{1}", BedID, KTV);
                }
                else
                {
                    progressTimeLeft.Text = string.Format("Bed {0}", BedID);
                }
              

                lbStartTime.Text = string.Format("Start: {0}H{1}'", StartTime.Hour.ToString("00"), StartTime.Minute.ToString("00"));

                lbDuration.Text = string.Format("({0}')", Duration);
            }
            else
            {
                progressTimeLeft.Text = string.Format("Bed {0}", BedID);
                lbStartTime.Text = string.Format("-----");
                lbDuration.Text = "";
            }
        }

        private void ShowRemainingStatus()
        {
            progressTimeLeft.Value1 = Remain;
        }

        public void LoadTransaction()
        {
            BedTransaction = Program.Server.GetCurrentBedTransacation(Room, Branch, BedID);
        }

        public void CheckRemainTime()
        {
            DateTime endTime = EndTime;
            DateTime now = DateTime.Now;

            if (endTime >= now)
            {
                Remain = (int)Math.Round((endTime - now).TotalMinutes);
            }
            else
            {
                Remain = 0;
            }
        }
        #endregion

        #region event
        private void Element_Click(object sender, EventArgs e)
        {
            if (sender.Equals(contextNewTransaction))
            {
                FrmBedSetting f = new FrmBedSetting();
                f.UcBed = this;
                f.ShowDialog();
            }
            else if (sender.Equals(contextStopTransaction))
            {
                if (BedTransaction != null)
                {
                    if (Program.Server.StopBedTransaction(BedTransaction.Id) == ErrorCode.OK)
                    {
                        this.Remain = 0;
                    }
                }
            }

        }
        #endregion
    }
}
