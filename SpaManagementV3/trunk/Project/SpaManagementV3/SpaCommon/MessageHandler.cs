using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using System.Windows.Forms;
using System.Drawing;

namespace SpaCommon
{
    public enum ErrorCode
    {
        OK = 0,
        N_OK,
        EXISTED_NAME,
        EXISTED_CODE,
        EXISTED_SERVICE,
        EXISTED_ROOM,
        EXISTED_BED,
        EXISTED_KTVID,
        EXISTED_MEMBERCARDSERI,
        FULFIllDATA_IMPORTBY,
        FULFIllDATA_EXPORTBY,
        FULFIllDATA_NAME,
        FULFIllDATA_CODE,
        INVALID_NAME,
        INVALID_DATE,
        

    }

    public static class MessageHandler
    {
       // private static 
        public static void MessageManager(Form owner, ErrorCode error)
        {
            switch(error)
            {
                case ErrorCode.OK:
                    UpdateInfoSuccessfully(owner);
                    break;
                case ErrorCode.N_OK:
                    ErrorOnUpdate(owner);
                    break;
                case ErrorCode.EXISTED_NAME:
                    ErrorNameExisted();
                    break;
                case ErrorCode.EXISTED_CODE:
                    ErrorCodeExisted();
                    break;
                case ErrorCode.EXISTED_SERVICE:
                    ErrorServiceExisted();
                    break;
                case ErrorCode.EXISTED_ROOM:
                    ErrorRoomExisted();
                    break;
                case ErrorCode.EXISTED_BED:
                    ErrorBedExisted();
                    break;
                case ErrorCode.FULFIllDATA_IMPORTBY:
                    ErrorFulFillImportBy();
                    break;
                case ErrorCode.FULFIllDATA_EXPORTBY:
                    ErrorFulFillExportBy();
                    break;
                case ErrorCode.FULFIllDATA_NAME:
                    ErrorFulFillName();
                    break;
                case ErrorCode.FULFIllDATA_CODE:
                    ErrorFulFillCode();
                    break;
                case ErrorCode.INVALID_NAME:
                    ErrorInvalidName();
                    break;
                case ErrorCode.INVALID_DATE:
                    ErrorInvalidDate();
                    break;
                case ErrorCode.EXISTED_KTVID:
                    ErrorKTVIdExisted();
                    break;
                case ErrorCode.EXISTED_MEMBERCARDSERI:
                    ErrorMemberCardSeriExisted();
                    break;


            }
        }
        public static DialogResult Question(string message)
        {
            var m = RadMessageBox.Show(message, " Warning", System.Windows.Forms.MessageBoxButtons.YesNo, RadMessageIcon.Exclamation);
            return m;
        }

        public static void Inform(Form owner, string message)
        {
            try
            {
                RadMessageBox.Show(owner, message, " Info", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception)
            { }
        }

        public static void Inform(string message)
        {
            try
            {
                RadMessageBox.Show(message, " Info", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            catch (Exception)
            { }
        }

        public static void Error(string message)
        {
            try
            {
                
                var m = RadMessageBox.Show(message, " Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            catch (Exception)
            { }
        }

        #region error
        public static void ErrorOnAdd()
        {
            Error("Could not add new data to system !");
        }

        public static void ErrorOnUpdate(Form owner)
        {
            Error("Update data to system unsuceesfully !");
        }

        public static void ErrorOnDelete()
        {
            Error("Could not delete data from system");
        }

        public static void AsktoFulfillInput()
        {
            Error("Please fulfill all required data !");
        }

        public static void ErrorUserDataInput(Form owner)
        {
            MessageHandler.Inform(owner, "User name is invalid ! Does not allow white space in user name !");
        }

        public static void ErrorOnLogin()
        {
            Error("Login fail ! Wrong username or password !");
        }

        public static void ConfirmPasswordMismatch()
        {
            Error("Confirm password does not match with new password !");
        }

        public static void ErrorNameExisted()
        {
            Error("'Name' already exists! Try another name.");
        }

        public static void ErrorCodeExisted()
        {
            Error("'Code' already exists! Try another code.");
        }

        public static void ErrorServiceExisted()
        {
            Error("Service already exists! Try another service.");
        }

        public static void ErrorRoomExisted()
        {
            Error("Room already exists! Try another room name.");
        }

        public static void ErrorBedExisted()
        {
            Error("Bed already exists!");
        }

        public static void ErrorKTVIdExisted()
        {
            Error("KTV ID already exists!");
        }

        public static void ErrorMemberCardSeriExisted()
        {
            Error("Member card's seri already exists!");
        }

        public static void ErrorFulFillImportBy()
        {
            Error("Please type 'Import By' field!");
        }

        public static void ErrorFulFillExportBy()
        {
            Error("Please type 'Export By' field!");
        }

        public static void ErrorFulFillName()
        {
            Error("Please type 'Name' field!");
        }

        public static void ErrorFulFillCode()
        {
            Error("Please type 'Code' field!");
        }

        public static void ErrorInvalidName()
        {
            Error("'Name' is invalid ! 'Name' should not contain '(' or ')'");
        }

        public static void ErrorInvalidDate()
        {
            Error("'Date' is invalid !");
        }
        #endregion

        #region successful
        public static void UpdateInfoSuccessfully(Form owner)
        {
            Inform(owner, "Update data successfully !");
        }

        #endregion

        #region ask
        public static DialogResult AskForDeleting()
        {
            return Question("Are you really want to delete ?");
        }

        public static DialogResult AskForCancellingBooking()
        {
            return Question("Are you really want to cancel this booking?");
        }

        public static DialogResult AskForEndingBooking()
        {
            return Question("Are you want to end this booking?");
        }

        #endregion

    }

}
