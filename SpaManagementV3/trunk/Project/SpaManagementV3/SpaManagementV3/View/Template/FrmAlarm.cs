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
    public partial class FrmAlarm : RadForm, IAlarmForm
    {
        private BindingList<RadReminderBindableObject> reminderBindableObjects;
        private TimeSpan startNotification = new TimeSpan(0, 15, 0);

        public FrmAlarm()
        {
            InitializeComponent();
            this.reminderBindableObjects = new BindingList<RadReminderBindableObject>();
            this.radListBox1.DisplayMember = "Subject";
            this.radListBox1.ValueMember = "Subject";
            this.radListBox1.DataSource = this.reminderBindableObjects;

            this.FormClosing += FrmAlarm_FormClosing;
            btnDismiss.Click += btnDismiss_Click;
            btnSnooze.Click += btnSnooze_Click;
            btnDismissAll.Click += btnDismissAll_Click;
        }

        private void btnDismissAll_Click(object sender, EventArgs e)
        {
            for (int i = this.radListBox1.Items.Count - 1; i >= 0; i--)
            {
                RadListDataItem item = this.radListBox1.Items[i];
                DismissItem(item);
            }
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            List<int> selectedIndexes = this.GetSelectedIndexes();
            for (int i = selectedIndexes.Count - 1; i >= 0; i--)
            {
                int selectedIndex = selectedIndexes[i];
                RadListDataItem item = this.radListBox1.Items[selectedIndex];
                RadReminderBindableObject reminderBindableObject = item.DataBoundItem as RadReminderBindableObject;
                TimeSpan snooze = DateTime.Now.Subtract(reminderBindableObject.StartDateTime);
                reminderBindableObject.Snoozed = this.startNotification + snooze + (new TimeSpan(0, 1, 0));
                this.RemoveRemindObject(reminderBindableObject);
            }
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            List<int> selectedIndexes = this.GetSelectedIndexes();
            for (int i = selectedIndexes.Count - 1; i >= 0; i--)
            {
                int selectedIndex = selectedIndexes[i];
                RadListDataItem item = this.radListBox1.Items[selectedIndex];
                DismissItem(item);
            }
        }

        void FrmAlarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
            if (e.CloseReason != CloseReason.ApplicationExitCall &&
                e.CloseReason != CloseReason.FormOwnerClosing &&
                e.CloseReason != CloseReason.WindowsShutDown)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        #region IAlarmForm Members
        public event EventHandler<RadOpenItemArgs> ItemOpened;

        /// <summary>
        /// Gets the remind objects count.
        /// </summary>
        /// <value>The reminder bindable objects count.</value>
        public virtual int RemindObjectsCount
        {
            get
            {
                return this.reminderBindableObjects.Count;
            }
        }

        /// <summary>
        /// Determines whether [contains reminder bindable object] [the specified reminder bindable object].
        /// </summary>
        /// <param name="reminderBindableObject">The remind bindable object.</param>
        /// <returns>
        /// 	<c>true</c> if [contains reminder bindable object] [the specified reminder bindable object]; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool ContainsRemindObject(RadReminderBindableObject reminderBindableObject)
        {
            return this.reminderBindableObjects.Contains(reminderBindableObject);
        }

        /// <summary>
        /// Adds the reminder bindable object.
        /// </summary>
        /// <param name="reminderBindableObject">The reminder bindable object.</param>
        public virtual void AddRemindObject(RadReminderBindableObject reminderBindableObject)
        {
            this.reminderBindableObjects.Insert(0, reminderBindableObject);
        }

        /// <summary>
        /// Removes the reminder bindable object.
        /// </summary>
        /// <param name="reminderBindableObject">The reminder bindable object.</param>
        /// <returns></returns>
        public virtual bool RemoveRemindObject(RadReminderBindableObject reminderBindableObject)
        {
            bool res = this.reminderBindableObjects.Remove(reminderBindableObject);

            if (this.reminderBindableObjects.Count < 1)
            {
                this.Hide();
            }

            return res;
        }

        /// <summary>
        /// Shows the form.
        /// </summary>
        public virtual void ShowForm()
        {
            if (!this.Visible)
            {
                this.Show();
            }
        }

        /// <summary>
        /// Shows the form.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public virtual void ShowForm(IWin32Window owner)
        {
            if (!this.Visible)
            {
                this.Show(owner);
            }
        }

        /// <summary>
        /// In this override we reset the RootElement's BackColor property
        /// since the DocumentDesigner class sets the BackColor of the
        /// Form to Control when initializing and thus overrides the theme.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.UpdateDialogLocalization();
        }

        /// <summary>
        /// Updates the dialog localization.
        /// </summary>
        public void UpdateDialogLocalization()
        {
            //Apply the current localization provider.
        }

        /// <summary>
        /// Gets or sets the start notification.
        /// </summary>
        /// <value>The start notification.</value>
        public TimeSpan StartNotification
        {
            get
            {
                return this.startNotification;
            }
            set
            {
                this.startNotification = value;
            }
        }

        /// <summary>
        /// Clears the remind objects.
        /// </summary>
        public void ClearRemindObjects()
        {
            this.reminderBindableObjects.Clear();
        }

        /// <summary>
        /// Hides the form.
        /// </summary>
        public void HideForm()
        {
            this.Hide();
        }
        #endregion

        private void OnItemOpened(IRemindObject remidableObject)
        {
            if (this.ItemOpened != null)
            {
                this.ItemOpened(this, new RadOpenItemArgs(remidableObject));
            }
        }
        private void DismissItem(RadListDataItem item)
        {
            RadReminderBindableObject reminderBindableObject = item.DataBoundItem as RadReminderBindableObject;
            reminderBindableObject.Dismissed = true;
            this.RemoveRemindObject(reminderBindableObject);
        }

        private List<int> GetSelectedIndexes()
        {
            List<int> resList = new List<int>();
            int index;
            foreach (RadListDataItem item in this.radListBox1.SelectedItems)
            {
                index = this.radListBox1.Items.IndexOf(item);
                if (!resList.Contains(index) && index >= 0)
                {
                    resList.Add(index);
                }
            }
            resList.Sort(); return resList;
        }

    }
}
