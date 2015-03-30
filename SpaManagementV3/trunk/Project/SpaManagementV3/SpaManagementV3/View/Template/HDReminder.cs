using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.UI.Scheduler.Dialogs;
using SpaDatabase.Model.Entities;
using SpaDatabase.Model;

namespace SpaManagementV3.View.Template
{
    public static class HDReminder
    {
        public static Dictionary<int, Appointment> Appoiments = new Dictionary<int, Appointment>();

      //  private static List<object> openedAlerts = new List<object>();
        private static RadScheduler _RadScheduler { get; set; }

        private static RadSchedulerReminder _SchedulerReminder { get; set; }

        private static FrmAlarm _CustomAlarmForm { get; set; }

        public static void AddAppoiment(Book book)
        {
            if (!Appoiments.ContainsKey(book.Id))
            {
                DateTime dtStart = book.BookingTime;
                DateTime dtEnd = dtStart.AddHours(1);
                string title = string.Format("{0} : {1}", book.BookingTime.ToString("dd/MM/yyyy HH:mm"), book.CustomerName);

                Appointment appointment = new Appointment(dtStart, dtEnd, title);
                _RadScheduler.Appointments.Add(appointment);

                appointment.Reminder = new TimeSpan(0, 5, 0);

                Appoiments.Add(book.Id, appointment);
            }

        }

        public static void UpdateAppoiment(Book book)
        {
            if (Appoiments.ContainsKey(book.Id))
            {
                DateTime dtStart = book.BookingTime;
                DateTime dtEnd = dtStart.AddHours(1);
                string title = string.Format("{0} : {1}", book.BookingTime.ToString("dd/MM/yyyy HH:mm"), book.CustomerName);

                Appoiments[book.Id] = new Appointment(dtStart, dtEnd, title);
            }
        }

        public static void RemoveAppoiment(int bookId)
        {
            if (Appoiments.ContainsKey(bookId))
            {
                Appoiments.Remove(bookId);
            }
        }

        public static void Start()
        {
            _SchedulerReminder.StartReminder();
        }

        public static void Stop()
        {
            _SchedulerReminder.StopReminder();
        }


        public static void InitReminder()
        {
            _SchedulerReminder = new RadSchedulerReminder();
            _RadScheduler = new RadScheduler();

            _SchedulerReminder.AssociatedScheduler = _RadScheduler;
            _SchedulerReminder.StartReminderInterval = DateTime.Now;
            _SchedulerReminder.EndReminderInterval = DateTime.Now.AddDays(1);

            _SchedulerReminder.AlarmFormShowing += schedulerReminder_AlarmFormShowing;
        }

        private static void schedulerReminder_AlarmFormShowing(object sender, RadAlarmFormShowingEventArgs e)
        {
            e.AlarmForm = _CustomAlarmForm;
        }
    }
}
