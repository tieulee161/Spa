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
                FrmBooking f = new FrmBooking();
                f.ShowDialog(this);
                if (f.IsSuccess == ErrorCode.OK)
                {
                    // add to reminder list

                    // display to gridview
                    AddNewBookingToBookingList(f.Book);
                }

            }
            else if (sender.Equals(btnEditBooking))
            {
                if (dtgBooking.SelectedRows.Count > 0)
                {
                    int bookId = (int)(decimal)dtgBooking.SelectedRows[0].Cells[0].Value;
                    Book book = Program.Server.GetBook(bookId);
                    if(book != null)
                    {
                        FrmBooking f = new FrmBooking();
                        f.Book = book;
                        f.ShowDialog(this);
                        if(f.IsSuccess == ErrorCode.OK)
                        {
                            // update to reminder list

                            // update to gridview
                        }
                    }
                }
            }
            else if (sender.Equals(btnDeleteBooking))
            {

            }
            else if (sender.Equals(btnCancelBooking))
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
            btnEditBooking.Click += Button_Click;
            btnDeleteBooking.Click += Button_Click;
            btnCancelBooking.Click += Button_Click;

            dtgBooking.RowFormatting += dtgBooking_RowFormatting;
            dtgBooking.CreateCell += dtgBooking_CreateCell;

            calendar.SelectionChanged += calendar_SelectionChanged;
        }

        private void LoadData()
        {

        }

        public void AddNewBookingToBookingList(Book book)
        {
            if (CurrentSelectedDate.Date == book.BookingTime.Date)
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

                dtgBooking.Rows.Add(new object[] { book.Id, book.Status, book.BookingTime, book.CustomerName, ktvs, rooms, services, packges, book.Note });
            }
        }

        public void UpdateBooking(Book book)
        {
            if (CurrentSelectedDate.Date == book.BookingTime.Date)
            {
                string ktvs;
                string rooms;
                string packges;
                string services;
                dtgBooking.Rows.Add(new object[] { book.Id, book.Status, book.BookingTime, book.CustomerName });
            }
        }
        #endregion
    }
}
