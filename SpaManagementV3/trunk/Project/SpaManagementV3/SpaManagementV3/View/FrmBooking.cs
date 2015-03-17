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
    public partial class FrmBooking : Telerik.WinControls.UI.RadForm
    {
        public FrmBooking()
        {
            InitializeComponent();
            InitializeGridview(dtgRoom);
            InitializeGridview(dtgService);
            InitializeGridview(dtgKTV);
            InitializeGridview(dtgPackage);
        }

        #region property

        public Book Book { get; set; }

        public ErrorCode IsSuccess { get; set; }

        #endregion

        #region event
        private void dtgVoucher_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }

        private void dtgVoucher_CreateCell(object sender, Telerik.WinControls.UI.GridViewCreateCellEventArgs e)
        {
            if (e.CellType == typeof(GridRowHeaderCellElement) && e.Row is GridDataRowElement)
            {
                e.CellType = typeof(SpreadsheetGridRowHeaderCellElement);
            }
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
            if (sender.Equals(btnSave))
            {
                string customerName = txtCustomerName.Text.Trim();
                DateTime bookingTime = dateBookingTime.Value;
                string note = txtNote.Text.Trim();

                if (customerName.Contains("(") || customerName.Contains("("))
                {
                    MessageHandler.MessageManager(this, ErrorCode.INVALID_NAME);
                }
                else if (bookingTime <= DateTime.Now)
                {
                    MessageHandler.MessageManager(this, ErrorCode.INVALID_DATE);
                }
                else
                {
                    List<string> rooms = new List<string>();
                    List<string> services = new List<string>();
                    List<string> personnels = new List<string>();
                    List<string> packages = new List<string>();

                    for (int j = 0; j < dtgRoom.Rows.Count; j++)
                    {
                        bool temp = (bool)dtgRoom.Rows[j].Cells[1].Value;
                        if (temp == true)
                        {
                            rooms.Add((string)dtgRoom.Rows[j].Cells[2].Value);
                        }
                    }
                    
                    for (int j = 0; j < dtgService.Rows.Count; j++)
                    {
                        bool temp = (bool)dtgService.Rows[j].Cells[1].Value;
                        if (temp == true)
                        {
                            services.Add((string)dtgService.Rows[j].Cells[2].Value);
                        }
                    }

                    for (int j = 0; j < dtgPackage.Rows.Count; j++)
                    {
                        bool temp = (bool)dtgPackage.Rows[j].Cells[1].Value;
                        if (temp == true)
                        {
                            packages.Add((string)dtgPackage.Rows[j].Cells[2].Value);
                        }
                    }
                    
                    for (int j = 0; j < dtgKTV.Rows.Count; j++)
                    {
                        bool temp = (bool)dtgKTV.Rows[j].Cells[1].Value;
                        if (temp == true)
                        {
                            personnels.Add((string)dtgKTV.Rows[j].Cells[2].Value);
                        }
                    }

                    if(Book == null)
                    {
                        Book book = null;
                        ErrorCode error = Program.Server.AddNewBook(customerName, bookingTime, note, personnels, rooms, services, packages, out book);
                        this.Book = book;
                        MessageHandler.MessageManager(this, error);
                        if (error == ErrorCode.OK)
                        {
                            IsSuccess = ErrorCode.OK;
                        }
                        else
                        {
                            IsSuccess = ErrorCode.N_OK;
                        }
                    }
                    else
                    {
                        ErrorCode error = Program.Server.UpdateBook(Book.Id, customerName, bookingTime, note, personnels, rooms, services, packages);
                        if (error == ErrorCode.OK)
                        {
                            IsSuccess = ErrorCode.OK;
                        }
                        else
                        {
                            IsSuccess = ErrorCode.N_OK;
                        }
                    }
                   
                }
            }
            else if (sender.Equals(btnCancel))
            {
                Close();
            }
        }

        #endregion

        #region method
        private void InitEvent()
        {
            btnSave.Click += Button_Click;
            btnCancel.Click += Button_Click;
        }



        private void LoadData()
        {
            if (Book != null)
            {
                txtCustomerName.Text = Book.CustomerName;
                txtNote.Text = Book.Note;
                dateBookingTime.Value = Book.BookingTime;
                spinId.Value = Book.Id;
            }


            List<Room> rooms = Program.Server.GetRooms();
            for (int j = 0; j < rooms.Count; j++)
            {
                if(Book != null)
                {
                      
                }
               
                dtgRoom.Rows.Add(new object[] { rooms[j].Id, false, rooms[j].Code });
            }

            List<Service> services = Program.Server.GetServices();
            for (int j = 0; j < services.Count; j++)
            {
                dtgService.Rows.Add(new object[] { services[j].Id, false, services[j].Code });
            }

            List<Personnel> ktvs = Program.Server.GetKTVs();
            for (int j = 0; j < ktvs.Count; j++)
            {
                dtgKTV.Rows.Add(new object[] { ktvs[j].Id, false, ktvs[j].Code });
            }

            List<Package> packages = Program.Server.GetPackages();
            for (int j = 0; j < packages.Count; j++)
            {
                dtgPackage.Rows.Add(new object[] { packages[j].Id, false, packages[j].Code });
            }

          
        }
        #endregion
    }
}
