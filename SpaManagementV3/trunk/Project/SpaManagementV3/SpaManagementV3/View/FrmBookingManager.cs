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
using SpaManagementV3.View.Template;

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

        private DateTime CurrentSelectedDate
        {
            get
            {
                return calendar.SelectedDate;
            }
        }

        #endregion

        #region event
        private void dtgBooking_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void dtgBooking_CreateCell(object sender, Telerik.WinControls.UI.GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
        }

        private void InitializeGridview(RadGridView grid)
        {
            grid.TableElement.RowHeaderColumnWidth = 42;
            grid.RowFormatting += dtgBooking_RowFormatting;
            grid.CreateCell += dtgBooking_CreateCell;
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
                FrmBooking f = new FrmBooking();
                f.ShowDialog(this);
                if (f.IsSuccess == ErrorCode.OK)
                {
                    // add to reminder list
                   Program.Reminder.AddAppointment(f.Book);

                    // display to gridview
                    if (CurrentSelectedDate.Date == f.Book.BookingTime.Date)
                    {
                        AddNewBookingToBookingList(f.Book);
                    }

                    // hight light calendar
                }

            }
            else if (sender.Equals(btnEditBooking))
            {
                if (dtgBooking.SelectedRows.Count > 0)
                {
                    int bookId = (int)(decimal)dtgBooking.SelectedRows[0].Cells[0].Value;
                    Book book = Program.Server.GetBook(bookId);
                    if (book != null)
                    {
                        FrmBooking f = new FrmBooking();
                        f.Book = book;
                        f.ShowDialog(this);
                        if (f.IsSuccess == ErrorCode.OK)
                        {
                            // update to reminder list
                            Program.Reminder.UpdateAppointment(book);

                            // update to gridview
                            UpdateBooking(f.Book);
                        }
                    }
                }
            }
            else if (sender.Equals(btnDeleteBooking))
            {
                if (MessageHandler.AskForDeleting() == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dtgBooking.SelectedRows.Count > 0)
                    {
                        int bookId = (int)(decimal)dtgBooking.SelectedRows[0].Cells[0].Value;
                        ErrorCode err = Program.Server.DeleteBook(bookId);
                        if (err == ErrorCode.OK)
                        {
                            // remove to reminder list
                            Program.Reminder.RemoveAppointment(bookId);

                            // update to gridview
                            dtgBooking.SelectedRows[0].Delete();

                            // remove high light if dont have any booking on this day
                        }
                    }
                }

            }
            else if (sender.Equals(btnCancelBooking))
            {
                if (MessageHandler.AskForCancellingBooking() == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dtgBooking.SelectedRows.Count > 0)
                    {
                        int bookId = (int)(decimal)dtgBooking.SelectedRows[0].Cells[0].Value;
                        ErrorCode err = Program.Server.ChangeBookStatus(bookId, BookingStatus.Cancelled);
                        if (err == ErrorCode.OK)
                        {
                            // remove to reminder list
                            Program.Reminder.RemoveAppointment(bookId);

                            // update to gridview
                            dtgBooking.SelectedRows[0].Cells[1].Value = BookingStatus.Cancelled;
                        }
                    }
                }
            }
            else if (sender.Equals(btnEndBooking))
            {
                if (MessageHandler.AskForEndingBooking() == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dtgBooking.SelectedRows.Count > 0)
                    {
                        int bookId = (int)(decimal)dtgBooking.SelectedRows[0].Cells[0].Value;
                        ErrorCode err = Program.Server.ChangeBookStatus(bookId, BookingStatus.Done);
                        if (err == ErrorCode.OK)
                        {
                            // remove to reminder list
                            Program.Reminder.RemoveAppointment(bookId);

                            // update to gridview
                            dtgBooking.SelectedRows[0].Cells[1].Value = BookingStatus.Done;
                        }
                    }
                }
            }

        }

        private void calendar_SelectionChanged(object sender, EventArgs e)
        {
            UpdateBookingOnGridview();
        }

        #endregion

        #region method
        private void InitEvent()
        {
            btnNewBooking.Click += Button_Click;
            btnEditBooking.Click += Button_Click;
            btnDeleteBooking.Click += Button_Click;
            btnCancelBooking.Click += Button_Click;
            btnEndBooking.Click += Button_Click;

            calendar.SelectionChanged += calendar_SelectionChanged;
        }

        private void LoadData()
        {
            UpdateBookingOnCalendar();
            UpdateBookingOnGridview();
        }

        public void AddNewBookingToBookingList(Book book)
        {
            string ktvs;
            string rooms;
            string packges;
            string services;

            List<string> temp = new List<string>();
            foreach (Personnel ktv in book.Personnels)
            {
                temp.Add(ktv.Code);
            }
            ktvs = SpaCommon.StringParser.GetString(temp);

            temp.Clear();
            foreach (Room room in book.Rooms)
            {
                temp.Add(room.Code);
            }
            rooms = SpaCommon.StringParser.GetString(temp);

            temp.Clear();
            foreach (Service service in book.Services)
            {
                temp.Add(service.Code);
            }
            services = SpaCommon.StringParser.GetString(temp);

            temp.Clear();
            foreach (Package package in book.Packages)
            {
                temp.Add(package.Code);
            }
            packges = SpaCommon.StringParser.GetString(temp);

            dtgBooking.Rows.Add(new object[] { book.Id, book.Status, book.BookingTime, book.CustomerName, book.Location, ktvs, rooms, services, packges, book.Note });

        }

        public void UpdateBooking(Book book)
        {

            string ktvs;
            string rooms;
            string packges;
            string services;

            List<string> temp = new List<string>();
            foreach (Personnel ktv in book.Personnels)
            {
                temp.Add(ktv.Code);
            }
            ktvs = SpaCommon.StringParser.GetString(temp);

            temp.Clear();
            foreach (Room room in book.Rooms)
            {
                temp.Add(room.Code);
            }
            rooms = SpaCommon.StringParser.GetString(temp);

            temp.Clear();
            foreach (Service service in book.Services)
            {
                temp.Add(service.Code);
            }
            services = SpaCommon.StringParser.GetString(temp);

            temp.Clear();
            foreach (Package package in book.Packages)
            {
                temp.Add(package.Code);
            }
            packges = SpaCommon.StringParser.GetString(temp);

            dtgBooking.SelectedRows[0].Cells[1].Value = book.Status;
            dtgBooking.SelectedRows[0].Cells[2].Value = book.BookingTime;
            dtgBooking.SelectedRows[0].Cells[3].Value = book.CustomerName;
            dtgBooking.SelectedRows[0].Cells[4].Value = book.Location;
            dtgBooking.SelectedRows[0].Cells[5].Value = ktvs;
            dtgBooking.SelectedRows[0].Cells[6].Value = rooms;
            dtgBooking.SelectedRows[0].Cells[7].Value = services;
            dtgBooking.SelectedRows[0].Cells[8].Value = packges;
            dtgBooking.SelectedRows[0].Cells[9].Value = book.Note;

        }

        private void UpdateBookingOnGridview()
        {
            dtgBooking.Rows.Clear();

            List<Book> books = Program.Server.GetBooks(CurrentSelectedDate);
            foreach (Book book in books)
            {
                string ktvs;
                string rooms;
                string packges;
                string services;

                List<string> temp = new List<string>();
                foreach (Personnel ktv in book.Personnels)
                {
                    temp.Add(ktv.Code);
                }
                ktvs = SpaCommon.StringParser.GetString(temp);

                temp.Clear();
                foreach (Room room in book.Rooms)
                {
                    temp.Add(room.Code);
                }
                rooms = SpaCommon.StringParser.GetString(temp);

                temp.Clear();
                foreach (Service service in book.Services)
                {
                    temp.Add(service.Code);
                }
                services = SpaCommon.StringParser.GetString(temp);

                temp.Clear();
                foreach (Package package in book.Packages)
                {
                    temp.Add(package.Code);
                }
                packges = SpaCommon.StringParser.GetString(temp);

                dtgBooking.Rows.Add(new object[] { book.Id, book.Status, book.BookingTime, book.CustomerName, book.Location, ktvs, rooms, services, packges, book.Note });
            }
        }

        private void UpdateBookingOnCalendar()
        {
            List<Book> books = Program.Server.GetBooks();

        }

        private void UpdateBookingOnCalendar(DateTime date)
        {

        }
        #endregion
    }
}
