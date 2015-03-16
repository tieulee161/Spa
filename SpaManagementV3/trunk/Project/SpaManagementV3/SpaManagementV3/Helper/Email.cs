using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace SpaManagementV3.Helper
{
    public class Email
    {
        private static string _server = "smtp.gmail.com";   // SMTP Server
        private static string _user = "spamanagement.mail@gmail.com";          // user's name of this server
        private static string _password = "spamanagement.mail";           // password
        public static string Receiver = "spamanagement.mail@gmail.com";      // receiver's email
        private System.Net.Mail.Attachment _attachment;

        private MailMessage mail;// = new MailMessage();
        private SmtpClient SmtpServer;//= new SmtpClient(_server);

        public string Status = "";
        public Email(string Subject, string Body, string AttachFilePath)
        {
            // init the server
            SmtpInit();

            // add subject and body to the email
            mail.Subject = Subject;
            mail.Body = Body;

            // attach file
            try
            {
                _attachment = new System.Net.Mail.Attachment(AttachFilePath);
                mail.Attachments.Add(_attachment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // if the file's path is wrong
            }

            // send it
            new Thread(new ThreadStart(SendEmail)).Start();

        }
        public Email(string receiver, string AttachFilePath, int i)
        {
            // init the server
            Receiver = receiver;
            SmtpInit();

            // add subject and body to the email  
            mail.Subject = "DATA BACKUP " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            mail.Body = "";

            // attach file
            try
            {
                _attachment = new System.Net.Mail.Attachment(AttachFilePath);
                mail.Attachments.Add(_attachment);
            }
            catch (Exception ex)
            {
                //  if(ex.Message != "Illegal characters in path.")
                MessageBox.Show(ex.Message); // if the file's path is wrong
            }

            // send it
            Thread t = new Thread(new ThreadStart(SendEmail));
            t.Start();


        }
        public Email(string Subject, string Body)
        {
            // init the server
            SmtpInit();

            // add subject and body to the email
            mail.Subject = Subject;
            mail.Body = Body;

            // send it
            new Thread(new ThreadStart(SendEmail)).Start();
        }
        public Email(string Body)
        {
            // init the server
            SmtpInit();

            // add subject and body to the email
            mail.Subject = "SPA BILL   " + DateTime.Now.ToString();
            mail.Body = Body;

            // send it
            Thread t = new Thread(new ThreadStart(SendEmail));
            t.Start();

        }
        private void SmtpInit()
        {
            mail = new MailMessage();
            SmtpServer = new SmtpClient(_server);

            // init sender's mail and receiver's mail
            mail.From = new MailAddress(_user);
            mail.To.Add(Receiver);
            mail.IsBodyHtml = true;

            // init some informations to interact with SMTP Server
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_user, _password);
            SmtpServer.EnableSsl = true;
        }
        private void SendEmail()
        {
            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception)
            {
                Status = "Failure to sending email";
                // MessageBox.Show(ex.Message); // if something wrong occur, maybe errors form network
                //  SPA_Prototype.Program.f1.SendingEmailStatus(Status);
                return;
            }
            Status = "Sending email successful";
            //   SPA_Prototype.Program.f1.SendingEmailStatus(Status);
        }
    }

    public class BillTemplate
    {
        private List<InvoiceData> _DataList;
        public BillTemplate(List<InvoiceData> dt, string BillNo, string Cashier)
        {

            _DataList = dt;

            Template = "--------------------------------------------\r\n"
                        + "--------------------------------------------\r\n"
                        + "-----          GUEST BILL    -----\r\n"
                        + "--------------------------------------------\r\n"
                        + "--------------------------------------------\r\n"
                        + "  Customer's name : " + _DataList[3].Data + "\r\n"
                        + "  Date      : " + _DataList[0].Data + "\r\n"
                        + "  Bill No.  : " + BillNo + "\r\n"
                        + "  Cashier   : " + Cashier + "\r\n"
                        + "  Staff No. : " + _DataList[2].Data + "\r\n"
                        + "------------------------------------------------------------------\r\n";
            //   + "|No| Description | Code | Q'Ty | Unit Price | Amount |Discount | Room \r\n\r\n";

            Template += string.Format("{0,-20}", "No");
            Template += string.Format("{0,-20}", "Description");
            Template += string.Format("{0,-20}", "Code");
            Template += string.Format("{0,-20}", "Q'Ty");
            Template += string.Format("{0,-20}", "Unit Price");
            Template += string.Format("{0,-20}", "Amount");
            Template += string.Format("{0,-20}", "Discount");
            Template += string.Format("Room\r\n");


            for (int j = 4; j <= 75; )
                for (int i = 0; i < 9; i++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        string s = string.Format("{0,-20}", _DataList[j++].Data);
                        Template += s;
                    }
                    Template += "\r\n";
                }
            Template += "\r\n\r\n";
            Template += "  Raw Total         : " + _DataList[76].Data + "\r\n"
                       + "  Total Discount    : " + _DataList[78].Data + "\r\n"
                       + "  Voucher           : " + _DataList[81].Data + "\r\n"
                       + "  Service Charge    : " + _DataList[82].Data + "\r\n"
                       + "  Total             : " + _DataList[83].Data + "\r\n"
                       + _DataList[84].Data + "\r\n"
                       + "  Exchange Rate     : " + _DataList[80].Data + "\r\n";

        }
        public string Template;
    }
}

