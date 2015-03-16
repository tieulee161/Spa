using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SpaDatabase.Model;
using SpaDatabase.Model.Entities;

namespace SpaManagementV3.Helper
{
    public enum GUEST_BILL
    {
        DATE, NUMBER, STAFF_NUMBER, CUSTOMER,   // ROOM 
        NO_1, NO_2, NO_3, NO_4, NO_5, NO_6, NO_7, NO_8, NO_9,
        DESC_1, DESC_2, DESC_3, DESC_4, DESC_5, DESC_6, DESC_7, DESC_8, DESC_9,
        CODE_1, CODE_2, CODE_3, CODE_4, CODE_5, CODE_6, CODE_7, CODE_8, CODE_9,
        STAFF_1, STAFF_2, STAFF_3, STAFF_4, STAFF_5, STAFF_6, STAFF_7, STAFF_8, STAFF_9,
        QTY_1, QTY_2, QTY_3, QTY_4, QTY_5, QTY_6, QTY_7, QTY_8, QTY_9,
        UNIT_PRICE_1, UNIT_PRICE_2, UNIT_PRICE_3, UNIT_PRICE_4, UNIT_PRICE_5, UNIT_PRICE_6, UNIT_PRICE_7, UNIT_PRICE_8, UNIT_PRICE_9,
        // USD_1, USD_2, USD_3, USD_4, USD_5, USD_6,
        VND_1, VND_2, VND_3, VND_4, VND_5, VND_6, VND_7, VND_8, VND_9,
        DISCOUNT_1, DISCOUNT_2, DISCOUNT_3, DISCOUNT_4, DISCOUNT_5, DISCOUNT_6, DISCOUNT_7, DISCOUNT_8, DISCOUNT_9,
        NOTE_1, NOTE_2, NOTE_3, NOTE_4, NOTE_5, NOTE_6, NOTE_7, NOTE_8, NOTE_9,
        TOTAL, TOTAL_EX,
        DISCOUNT_TOTAL, DISCOUNT_TOTAL_EX,
        EXCHANGE_RATE, VOUCHER,
        CHARGE,
        TOTAL_FINAL, //EQUIVALENT      
        TIPS,
        NOTE,
        FREE,
        VAT
    }

    public class InvoiceData
    {
        public int index;
        public GUEST_BILL ID;
        public int X;
        public int Y;
        public string Cell;
        public string Data;
    }
    public class PrintBill
    {
        public BillMain Bill { get; set; }
        List<InvoiceData> _PrintArray { get; set; }

        private void InitPrintArray()
        {
            _PrintArray = new List<InvoiceData>()
          {            
              new InvoiceData() {index= 0, ID = GUEST_BILL.DATE, X = 0, Y = 6, Data = null , Cell = "G1"},
              new InvoiceData() {index= 1, ID = GUEST_BILL.NUMBER, X = 1, Y = 6, Data = null, Cell = "G2"},
              new InvoiceData() {index= 2, ID = GUEST_BILL.STAFF_NUMBER, X = 2, Y = 6, Data = null, Cell = "G3"},                

              new InvoiceData() {index= 3, ID = GUEST_BILL.CUSTOMER, X = 5, Y = 0 , Data = null, Cell = "A6"}, // Customer's Name
              // 1
              new InvoiceData() {index= 4, ID = GUEST_BILL.NO_1, X = 7, Y = 0, Data = null, Cell = "A8"},
              new InvoiceData() {index= 5, ID = GUEST_BILL.DESC_1, X = 7, Y = 1, Data = null, Cell = "B8"},
              new InvoiceData() {index= 6, ID = GUEST_BILL.CODE_1, X = 7, Y = 2, Data = null, Cell = "C8"},
              new InvoiceData() {index= 7, ID = GUEST_BILL.STAFF_1, X = 7, Y = 3, Data = null, Cell = "D8"},
              new InvoiceData() {index= 8, ID = GUEST_BILL.QTY_1, X = 7, Y = 4, Data = null, Cell = "E8"},
              new InvoiceData() {index= 9, ID = GUEST_BILL.UNIT_PRICE_1, X = 7, Y = 5, Data = null, Cell = "F8"},                
              new InvoiceData() {index= 10, ID = GUEST_BILL.VND_1, X = 7, Y = 6, Data = null, Cell = "G8"},
              new InvoiceData() {index= 11, ID = GUEST_BILL.DISCOUNT_1, X = 7, Y = 7, Data = null, Cell = "H8"},
              new InvoiceData() {index= 12, ID = GUEST_BILL.NOTE_1, X = 7, Y = 8, Data = null, Cell = "I8"},
              // 2
              new InvoiceData() {index= 13, ID = GUEST_BILL.NO_2, X = 8, Y = 0, Data = null, Cell = "A9"},
              new InvoiceData() {index= 14, ID = GUEST_BILL.DESC_2, X = 8, Y = 1, Data = null, Cell = "B9"},
              new InvoiceData() {index= 15, ID = GUEST_BILL.CODE_2, X = 8, Y = 2, Data = null, Cell = "C9"},
              new InvoiceData() {index= 16, ID = GUEST_BILL.STAFF_2, X = 8, Y = 3, Data = null, Cell = "D9"},
              new InvoiceData() {index= 17, ID = GUEST_BILL.QTY_2, X = 8, Y = 4, Data = null, Cell = "E9"},
              new InvoiceData() {index= 18, ID = GUEST_BILL.UNIT_PRICE_2, X = 8, Y = 5, Data = null, Cell = "F9"},                
              new InvoiceData() {index= 19, ID = GUEST_BILL.VND_2, X = 8, Y = 6, Data = null, Cell = "G9"},
              new InvoiceData() {index= 20, ID = GUEST_BILL.DISCOUNT_2, X = 8, Y = 7, Data = null, Cell = "H9"},
              new InvoiceData() {index= 21, ID = GUEST_BILL.NOTE_2 , X = 8, Y = 8, Data = null, Cell = "I9"},
              // 3
              new InvoiceData() {index= 22, ID = GUEST_BILL.NO_3, X = 9, Y = 0, Data = null, Cell = "A10"},
              new InvoiceData() {index= 23, ID = GUEST_BILL.DESC_3, X = 9, Y = 1, Data = null, Cell = "B10"},
              new InvoiceData() {index= 24, ID = GUEST_BILL.CODE_3 , X = 9, Y = 2, Data = null, Cell = "C10"},
              new InvoiceData() {index= 25, ID = GUEST_BILL.STAFF_3, X = 9, Y = 3, Data = null, Cell = "D10"},
              new InvoiceData() {index= 26, ID = GUEST_BILL.QTY_3 , X = 9, Y = 4, Data = null, Cell = "E10"},
              new InvoiceData() {index= 27, ID = GUEST_BILL.UNIT_PRICE_3, X = 9, Y = 5, Data = null, Cell = "F10"},                
              new InvoiceData() {index= 28, ID = GUEST_BILL.VND_3, X = 9, Y = 6, Data = null, Cell = "G10"},
              new InvoiceData() {index= 29, ID = GUEST_BILL.DISCOUNT_3, X = 9, Y = 7, Data = null, Cell = "H10"},
              new InvoiceData() {index= 30, ID = GUEST_BILL.NOTE_3 , X = 9, Y = 8, Data = null, Cell = "I10"},
              // 4
              new InvoiceData() {index= 31, ID = GUEST_BILL.NO_4, X = 10, Y = 0, Data = null, Cell = "A11"},
              new InvoiceData() {index= 32, ID = GUEST_BILL.DESC_4, X = 10, Y = 1, Data = null, Cell = "B11"},
              new InvoiceData() {index= 33, ID = GUEST_BILL.CODE_4, X = 10, Y = 2, Data = null, Cell = "C11"},
              new InvoiceData() {index= 34, ID = GUEST_BILL.STAFF_4, X = 10, Y = 3, Data = null, Cell = "D11"},
              new InvoiceData() {index= 35, ID = GUEST_BILL.QTY_4, X = 10, Y = 4, Data = null, Cell = "E11"},
              new InvoiceData() {index= 36,ID = GUEST_BILL.UNIT_PRICE_4, X = 10, Y = 5, Data = null, Cell = "F11"},                
              new InvoiceData() {index= 37, ID = GUEST_BILL.VND_4, X = 10, Y = 6, Data = null, Cell = "G11"},
              new InvoiceData() {index= 38, ID = GUEST_BILL.DISCOUNT_4, X = 10, Y = 7, Data = null, Cell = "H11"},
              new InvoiceData() {index= 39, ID = GUEST_BILL.NOTE_4, X = 10, Y = 8, Data = null, Cell = "I11"},
              // 5
              new InvoiceData() {index= 40, ID = GUEST_BILL.NO_5, X = 11, Y = 0, Data = null, Cell = "A12"},
              new InvoiceData() {index= 41, ID = GUEST_BILL.DESC_5, X = 11, Y = 1, Data = null, Cell = "B12"},
              new InvoiceData() {index= 42, ID = GUEST_BILL.CODE_5, X = 11, Y = 2, Data = null, Cell = "C12"},
              new InvoiceData() {index= 43, ID = GUEST_BILL.STAFF_5, X = 11, Y = 3, Data = null, Cell = "D12"},
              new InvoiceData() {index= 44, ID = GUEST_BILL.QTY_5, X = 11, Y = 4, Data = null, Cell = "E12"},
              new InvoiceData() {index= 45, ID = GUEST_BILL.UNIT_PRICE_5, X = 11, Y = 5, Data = null, Cell = "F12"},                
              new InvoiceData() {index= 46, ID = GUEST_BILL.VND_5, X = 11, Y = 6, Data = null, Cell = "G12"},
              new InvoiceData() {index= 47, ID = GUEST_BILL.DISCOUNT_5, X = 11, Y = 7, Data = null, Cell = "H12"},
              new InvoiceData() {index= 48, ID = GUEST_BILL.NOTE_5, X = 11, Y = 8, Data = null, Cell = "I12"},
              // 6
              new InvoiceData() {index= 49, ID = GUEST_BILL.NO_6, X = 12, Y = 0, Data = null, Cell = "A13"},
              new InvoiceData() {index= 50, ID = GUEST_BILL.DESC_6, X = 12, Y = 1, Data = null, Cell = "B13"},
              new InvoiceData() {index= 51, ID = GUEST_BILL.CODE_6, X = 12, Y = 2, Data = null, Cell = "C13"},
              new InvoiceData() {index= 52, ID = GUEST_BILL.STAFF_6, X = 12, Y = 3, Data = null, Cell = "D13"},
              new InvoiceData() {index= 53, ID = GUEST_BILL.QTY_6, X = 12, Y = 4, Data = null, Cell = "E13"},
              new InvoiceData() {index= 54, ID = GUEST_BILL.UNIT_PRICE_6, X = 12, Y = 5, Data = null, Cell = "F13"},                
              new InvoiceData() {index= 55, ID = GUEST_BILL.VND_6, X = 12, Y = 6, Data = null, Cell = "G13"},
              new InvoiceData() {index= 56, ID = GUEST_BILL.DISCOUNT_6, X = 12, Y = 7, Data = null, Cell = "H13"},
              new InvoiceData() {index= 57, ID = GUEST_BILL.NOTE_6, X = 12, Y = 8, Data = null, Cell = "I13"},

              // 7 
              new InvoiceData() {index= 58, ID = GUEST_BILL.NO_7, X = 13, Y = 0, Data = null, Cell = "A14"},
              new InvoiceData() {index= 59, ID = GUEST_BILL.DESC_7, X = 13, Y = 1, Data = null, Cell = "B14"},
              new InvoiceData() {index= 60, ID = GUEST_BILL.CODE_7, X = 13, Y = 2, Data = null, Cell = "C14"},
              new InvoiceData() {index= 61, ID = GUEST_BILL.STAFF_7, X = 13, Y = 3, Data = null, Cell = "D14"},
              new InvoiceData() {index= 62, ID = GUEST_BILL.QTY_7, X = 13, Y = 4, Data = null, Cell = "E14"},
              new InvoiceData() {index= 63, ID = GUEST_BILL.UNIT_PRICE_7, X = 13, Y = 5, Data = null, Cell = "F14"},                
              new InvoiceData() {index= 64, ID = GUEST_BILL.VND_7, X = 13, Y = 6, Data = null, Cell = "G14"},
              new InvoiceData() {index= 65, ID = GUEST_BILL.DISCOUNT_7, X = 13, Y = 7, Data = null, Cell = "H14"},
              new InvoiceData() {index= 66, ID = GUEST_BILL.NOTE_7, X = 13, Y = 8, Data = null, Cell = "I14"},

              // 8
              new InvoiceData() {index= 67, ID = GUEST_BILL.NO_8, X = 14, Y = 0, Data = null, Cell = "A15"},
              new InvoiceData() {index= 68, ID = GUEST_BILL.DESC_8, X = 14, Y = 1, Data = null, Cell = "B15"},
              new InvoiceData() {index= 69, ID = GUEST_BILL.CODE_8, X = 14, Y = 2, Data = null, Cell = "C15"},
              new InvoiceData() {index= 70, ID = GUEST_BILL.STAFF_8, X = 14, Y = 3, Data = null, Cell = "D15"},
              new InvoiceData() {index= 71, ID = GUEST_BILL.QTY_8, X = 14, Y = 4, Data = null, Cell = "E15"},
              new InvoiceData() {index= 72, ID = GUEST_BILL.UNIT_PRICE_8, X = 14, Y = 5, Data = null, Cell = "F15"},                
              new InvoiceData() {index= 73, ID = GUEST_BILL.VND_8, X = 14, Y = 6, Data = null, Cell = "G15"},
              new InvoiceData() {index= 74, ID = GUEST_BILL.DISCOUNT_8, X = 14, Y = 7, Data = null, Cell = "H15"},
              new InvoiceData() {index= 75, ID = GUEST_BILL.NOTE_8, X = 14, Y = 8, Data = null, Cell = "I15"},
                
              // 9
              new InvoiceData() {index= 76, ID = GUEST_BILL.NO_9, X = 15, Y = 0, Data = null, Cell = "A16"},
              new InvoiceData() {index= 77, ID = GUEST_BILL.DESC_9, X = 15, Y = 1, Data = null, Cell = "B16"},
              new InvoiceData() {index= 78, ID = GUEST_BILL.CODE_9, X = 15, Y = 2, Data = null, Cell = "C16"},
              new InvoiceData() {index= 79, ID = GUEST_BILL.STAFF_9, X = 15, Y = 3, Data = null, Cell = "D16"},
              new InvoiceData() {index= 80, ID = GUEST_BILL.QTY_9, X = 15, Y = 4, Data = null, Cell = "E16"},
              new InvoiceData() {index= 81, ID = GUEST_BILL.UNIT_PRICE_9, X = 15, Y = 5, Data = null, Cell = "F16"},                
              new InvoiceData() {index= 82, ID = GUEST_BILL.VND_9, X = 15, Y = 6, Data = null, Cell = "G16"},
              new InvoiceData() {index= 83, ID = GUEST_BILL.DISCOUNT_9, X = 15, Y = 7, Data = null, Cell = "H16"},
              new InvoiceData() {index= 84, ID = GUEST_BILL.NOTE_9, X = 15, Y = 8, Data = null, Cell = "I16"},

              // 10
              new InvoiceData() {index= 85, ID = GUEST_BILL.TOTAL, X = 17, Y = 6, Data = null, Cell = "G18"},
              new InvoiceData() {index= 86, ID = GUEST_BILL.TOTAL_EX, X = 17, Y = 7, Data = null, Cell = "H18"},  // THIS CELL HAS NO FUNCTIONALITY IN THE INVOICE EXCEPT FOR EXTRA PURPOSES
              new InvoiceData() {index= 87, ID = GUEST_BILL.DISCOUNT_TOTAL, X = 18, Y = 6, Data = null, Cell = "G19"},
              new InvoiceData() {index= 88, ID = GUEST_BILL.DISCOUNT_TOTAL_EX, X = 18, Y = 7, Data = null, Cell = "H19"}, // THIS CELL HAS NO FUNCTIONALITY IN THE INVOICE EXCEPT FOR EXTRA PURPOSES
              new InvoiceData() {index= 89, ID = GUEST_BILL.EXCHANGE_RATE, X = 19, Y = 1, Data = null, Cell = "B20"},
              new InvoiceData() {index= 90, ID = GUEST_BILL.VOUCHER, X = 19, Y = 6, Data = null, Cell = "G20"},        
              new InvoiceData() {index= 91, ID = GUEST_BILL.CHARGE, X = 20, Y = 6, Data = null, Cell = "G21"},
              new InvoiceData() {index= 92, ID = GUEST_BILL.TOTAL_FINAL, X = 23, Y = 6, Data = null, Cell = "G24"},      
              new InvoiceData() {index= 93, ID = GUEST_BILL.TIPS, X = 23, Y = 6, Data = null, Cell = "G24"},   
             
              new InvoiceData() {index= 94, ID = GUEST_BILL.NOTE, X = 16, Y = 0, Data = null, Cell = "A17"},
              new InvoiceData() {index= 95, ID = GUEST_BILL.FREE, X = 21, Y = 6, Data = null, Cell = "G22"},
              new InvoiceData() {index= 96, ID = GUEST_BILL.VAT, X = 22, Y = 6, Data = null, Cell = "G23"},
          };
        }

        private void FillPrintHeadData()
        {
            _PrintArray[0].Data = Bill.Date.ToString("dd/MM/yyyy");
            _PrintArray[1].Data = Bill.BillNumber.ToString("000000");
            _PrintArray[2].Data = ""; //KTV           
            _PrintArray[3].Data = (Bill.Customer == null) ? Bill.CustomerName : (string)Bill.Customer.Name;

            List<string> ktvs = new List<string>();
            foreach (BillService billService in Bill.BillServices)
            {
                foreach (BillKTV billKTV in billService.BillKTVs)
                {
                    if (!ktvs.Contains(billKTV.Personnel.KTVId.ToString()))
                    {
                        ktvs.Add(billKTV.Personnel.KTVId.ToString());
                    }
                }
            }
            if (Bill.BillPackages != null)
            {
                foreach (BillPackage billPackage in Bill.BillPackages)
                {
                    if (billPackage.BillServices != null)
                    {
                        foreach (BillService billService in billPackage.BillServices)
                        {
                            if (billService.BillKTVs != null)
                            {
                                foreach (BillKTV billKTV in billService.BillKTVs)
                                {
                                    if (!ktvs.Contains(billKTV.Personnel.KTVId.ToString()))
                                    {
                                        ktvs.Add(billKTV.Personnel.KTVId.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }


            string temp = "";
            for (int j = 0; j < ktvs.Count; j++)
            {
                temp += ktvs[j] + ",";
            }
            if (temp.Length > 0)
            {
                _PrintArray[2].Data = temp.Substring(0, temp.Length - 1);
            }
        }

        private void FillPrintBodyData()
        {
            const int BOBY_ROWS_COUNT = 9;
            const int BOBY_COLS_COUNT = 9;
            const int BODY_ARRAY_INDEX_MIN = 4;
            const int BODY_ARRAY_INDEX_MAX = 84;
            string[][] BillBodyData = new string[BOBY_ROWS_COUNT][];
            int maxLength = 28;
            string description = "";
            int Count = 1; // Row No.

            for (int j = 0; j < BOBY_ROWS_COUNT; j++) BillBodyData[j] = new string[BOBY_COLS_COUNT];

            // fill Row No. 
            int usedRowsCount = Bill.BillDetails.Count;
            int step = 0;

            for (int i = 0; i < usedRowsCount; i++)
            {
                BillDetail billDetail = ((List<BillDetail>)Bill.BillDetails)[i];
                description = billDetail.Description; // Service Name

                BillBodyData[i][0] = (Count++).ToString();  // No.

                BillBodyData[i][2] = billDetail.Code; //Service Code
                BillBodyData[i][3] = billDetail.KTV; //Staff
                BillBodyData[i][4] = billDetail.Qty.ToString("#,#");// Quantity

                int UnitPriceTemp = billDetail.Price;
                if (UnitPriceTemp == 0) BillBodyData[i][5] = "0";
                else BillBodyData[i][5] = UnitPriceTemp.ToString("0,0");            // Unit Price


                int VNDTemp = billDetail.Total;
                if (VNDTemp == 0) BillBodyData[i][6] = "0";
                else BillBodyData[i][6] = VNDTemp.ToString("0,0"); // VND

                int DiscountTemp = billDetail.Discount;
                if (DiscountTemp == 0) BillBodyData[i][7] = "0";
                else BillBodyData[i][7] = DiscountTemp.ToString("0,0"); // Discount

                //if (dtgBillDetail.Rows[i + step].Cells[7].Value.ToString() != "")
                //{
                //    BillBodyData[i][8] = null;// dtgBillDetail.Rows[i + step].Cells[7].Value.ToString(); // Notes :Room
                //}
                //else
                //{
                //    //  BillBodyData[i][8] = dtgBillDetail.Rows[i].Cells[10].Value.ToString(); // Notes : gift seri
                //}

                if (description.Length <= maxLength) BillBodyData[i][1] = description;
                else
                {
                    // cut description into two strings, 1st string's length = maxLength
                    string s1;
                    string s2; ;
                    s1 = description.Substring(0, maxLength) + "-";
                    s2 = "-" + description.Substring(maxLength);

                    BillBodyData[i++][1] = s1;
                    BillBodyData[i][1] = s2;
                    usedRowsCount++;
                    step--;
                }
            }
            for (int i = BODY_ARRAY_INDEX_MIN; i <= BODY_ARRAY_INDEX_MAX; )
                for (int j = 0; j < BOBY_ROWS_COUNT; j++)
                    for (int k = 0; k < BOBY_COLS_COUNT; k++)
                        _PrintArray[i++].Data = BillBodyData[j][k];
        }

        private void FillPrintSummaryData()
        {
            const int DATA_INDEX_MIN = 85;
            int Charge = 0;
            int Tips = 0;

            _PrintArray[DATA_INDEX_MIN].Data = Bill.RawTotal.ToString("0,0"); //TOTAL
            _PrintArray[DATA_INDEX_MIN + 1].Data = null; //TOTAL_EX COLUMN

            int discountTotal = Bill.RawTotalDiscount;
            if (discountTotal == 0) _PrintArray[DATA_INDEX_MIN + 2].Data = "0";
            else _PrintArray[DATA_INDEX_MIN + 2].Data = discountTotal.ToString("0,0"); //DISCOUNT TOTAL

            _PrintArray[DATA_INDEX_MIN + 3].Data = null; //DISCOUNT TOTAL EX COLUMN
            _PrintArray[DATA_INDEX_MIN + 4].Data = Program.Server.GetExchangeRate().ToString("0,0");

            int voucherTemp = Bill.Voucher;
            if (voucherTemp == 0) _PrintArray[DATA_INDEX_MIN + 5].Data = "0";        // VOUCHER
            else _PrintArray[DATA_INDEX_MIN + 5].Data = voucherTemp.ToString("0,0"); // VOUCHER

            Charge = Bill.ServiceCharge;
            if (Charge == 0) _PrintArray[DATA_INDEX_MIN + 6].Data = "0"; // SERVICE CHARGE       
            else _PrintArray[DATA_INDEX_MIN + 6].Data = Charge.ToString("0,0"); // SERVICE CHARGE

            int billFinalTotal = Bill.FinalTotal - Bill.Voucher;
            if (billFinalTotal == 0) _PrintArray[DATA_INDEX_MIN + 7].Data = "0"; //FINAL TOTAL       
            else _PrintArray[DATA_INDEX_MIN + 7].Data = billFinalTotal.ToString("0,0");  //FINAL TOTAL              

            if (Tips == 0) _PrintArray[DATA_INDEX_MIN + 8].Data += null;      // TIPS
            else _PrintArray[DATA_INDEX_MIN + 8].Data += "(Tips : " + Tips.ToString("0,0") + ")";
        }

        private void FillAdditionalInfo()
        {
            _PrintArray[94].Data = Bill.Note;
            _PrintArray[95].Data = Bill.BillDiscount.ToString("0,0");
            _PrintArray[96].Data = Bill.VAT.ToString("#,#");
        }

        public string Print()
        {
            string text = "";
            InitPrintArray();
            FillPrintHeadData();
            FillPrintBodyData();
            FillPrintSummaryData();
            FillAdditionalInfo();
            ExportToExcel.ExportToExcel_PrintBill(_PrintArray, Bill.BillNumber.ToString(), false, false, out text);
            return text;
        }

        
    }
}
