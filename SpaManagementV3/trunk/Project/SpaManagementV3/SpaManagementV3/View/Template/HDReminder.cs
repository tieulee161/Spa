using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Scheduler.Dialogs;
using SpaDatabase.Model.Entities;
using SpaDatabase.Model;
using SpaCommon;

namespace SpaManagementV3.View.Template
{
    public class HDReminder
    {
        //public Dictionary<int, Appointment> Appoiments = new Dictionary<int, Appointment>();

        //private static List<object> openedAlerts = new List<object>();
        //private RadScheduler _RadScheduler { get; set; }

        //private RadSchedulerReminder _SchedulerReminder { get; set; }

        //private FrmAlarm _CustomAlarmForm { get; set; }

        //public void AddAppoiment(Book book)
        //{
        //    if (book != null)
        //    {
        //        if (!Appoiments.ContainsKey(book.Id))
        //        {
        //            DateTime dtStart = book.BookingTime;
        //            DateTime dtEnd = dtStart.AddHours(1);
        //            string title = string.Format("{0} : {1}", book.BookingTime.ToString("dd/MM/yyyy HH:mm"), book.CustomerName);

        //            Appointment appointment = new Appointment(dtStart, dtEnd, title, "");
        //            appointment.Reminder = new TimeSpan(0, 2, 0);
        //            appointment.StatusId = (int)AppointmentStatus.Free;

        //            _RadScheduler.Appointments.BeginUpdate();
        //            _RadScheduler.Appointments.Add(appointment);
        //            _RadScheduler.Appointments.EndUpdate();

        //            Appoiments.Add(book.Id, appointment);
        //        }
        //    }


        //}

        //public void UpdateAppoiment(Book book)
        //{
        //    if (Appoiments.ContainsKey(book.Id))
        //    {
        //        DateTime dtStart = book.BookingTime;
        //        DateTime dtEnd = dtStart.AddHours(1);
        //        string title = string.Format("{0} : {1}", book.BookingTime.ToString("dd/MM/yyyy HH:mm"), book.CustomerName);

        //        Appoiments[book.Id] = new Appointment(dtStart, dtEnd, title);
        //    }
        //}

        //public void RemoveAppoiment(int bookId)
        //{
        //    if (Appoiments.ContainsKey(bookId))
        //    {
        //        Appoiments.Remove(bookId);
        //    }
        //}

        //public void Start()
        //{
        //    _SchedulerReminder.StartReminder();
        //}

        //public void Stop()
        //{
        //    _SchedulerReminder.StopReminder();
        //}


        //public void InitReminder()
        //{
        //    _SchedulerReminder = new RadSchedulerReminder();
        //    _RadScheduler = new RadScheduler();
        //    _CustomAlarmForm = new FrmAlarm();

        //    _SchedulerReminder.AssociatedScheduler = _RadScheduler;
        //    _SchedulerReminder.StartReminderInterval = DateTime.Now;
        //    _SchedulerReminder.EndReminderInterval = DateTime.Now.AddDays(1);

        //    _SchedulerReminder.AlarmFormShowing += schedulerReminder_AlarmFormShowing;
        //}

        //private void schedulerReminder_AlarmFormShowing(object sender, RadAlarmFormShowingEventArgs e)
        //{
        //    e.AlarmForm = _CustomAlarmForm;
        //}

        public HDReminder()
        {
            Appointments = new Dictionary<int, Book>();
            _IsAlarmFormShowed = false;

            _Timer = new System.Timers.Timer();
            _Timer.Interval = 60000;
            _Timer.Elapsed += _Timer_Elapsed;
        }



        #region properties
        public Dictionary<int, Book> Appointments { get; set; }

        private System.Timers.Timer _Timer { get; set; }

        private bool _IsAlarmFormShowed { get; set; }

        #endregion

        #region method
        public void AddAppointment(Book book)
        {
            if (book != null)
            {
                if (!Appointments.ContainsKey(book.Id))
                {
                    Appointments.Add(book.Id, book);
                }
            }
        }

        public void UpdateAppointment(Book book)
        {
            if (book != null)
            {
                if (Appointments.ContainsKey(book.Id))
                {
                    Appointments[book.Id] = book;
                }
            }
        }

        public void RemoveAppointment(int id)
        {
            if (Appointments.ContainsKey(id))
            {
                Appointments.Remove(id);
            }

        }

        public void Dismiss(int bookId)
        {
            if (Appointments.ContainsKey(bookId))
            {
                ErrorCode err = Program.Server.ChangeBookStatus(bookId, BookingStatus.Dimiss);
                if (err == ErrorCode.OK)
                {
                    Appointments.Remove(bookId);
                }
            }
        }

        public void DismissAll()
        {
            List<int> keys = Appointments.Keys.ToList();
            for (int j = keys.Count - 1; j >= 0; j--)
            {
                Dismiss(keys[j]);
            }
        }

        public void Snooze(int bookId)
        {
            if (Appointments.ContainsKey(bookId))
            {
                ErrorCode err = Program.Server.ChangeBookStatus(bookId, BookingStatus.Snoozed);
                if (err == ErrorCode.OK)
                {
                    // Appointments.Remove(bookId);
                }
            }
        }

        public void Start()
        {
            _Timer.Start();
        }

        public void Stop()
        {
            _Timer.Stop();
        }
        #endregion

        #region event
        private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_IsAlarmFormShowed == false)
            {
                List<Book> books = new List<Book>();
                DateTime now = DateTime.Now;
                foreach (Book book in Appointments.Values)
                {
                    int temp = (int)(book.BookingTime - now).TotalMinutes;
                    if (((temp >= 0) && (temp <= 2)) || temp < 0)
                    {
                        books.Add(book);
                    }
                }

                if (books.Count > 0)
                {
                    FrmAlarm f = new FrmAlarm();
                    foreach (Book book in Appointments.Values)
                    {
                        string content = string.Format("{0} : {1}", book.BookingTime.ToString("dd/MM/yyyy HH:mm"), book.CustomerName);
                        f.Init(book.Id, content);
                    }
                    _IsAlarmFormShowed = true;
                    f.TopMost = true;
                    f.ShowDialog();
                    _IsAlarmFormShowed = false;
                }
            }


        }
        #endregion

    }
}
