using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls.UI;

namespace SpaManagementV3.View.Template
{
    public partial class FrmAlarm : RadForm
    {

        public FrmAlarm()
        {
            InitializeComponent();
            btnDismiss.Click += btnDismiss_Click;
            btnSnooze.Click += btnSnooze_Click;
            btnDismissAll.Click += btnDismissAll_Click;
        }

        private void btnDismissAll_Click(object sender, EventArgs e)
        {
            foreach (RadListDataItem item in this.radListBox1.Items)
            {
                Program.Reminder.Dismiss((int)item.Value);
            }
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            foreach (RadListDataItem item in this.radListBox1.SelectedItems)
            {
                Program.Reminder.Snooze((int)item.Value);
            }
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            foreach (RadListDataItem item in this.radListBox1.SelectedItems)
            {
                Program.Reminder.Dismiss((int)item.Value);
            }
        }

        public void Init(int id, string content)
        {
            RadListDataItem item = new RadListDataItem(content);
            item.Value = id;
            radListBox1.Items.Add(item);

        }
    }
}
