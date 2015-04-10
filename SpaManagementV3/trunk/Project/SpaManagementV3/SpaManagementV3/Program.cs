using System;
using System.Linq;
using System.Windows.Forms;

using SpaManagementV3.View;
using SpaDatabase.Services;
using SpaCommon;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

using SpaManagementV3.View.Template;

namespace SpaManagementV3
{
    static class Program
    {
        #region properties
        public static HDReminder Reminder { get; set; }

        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Init();
            ConnectToServer();
         
            Application.Run(new FrmMain());
         //   Application.Run(new FrmBookingManager());
       //     Application.Run(new FrmRoomManagement2A());
      //      Application.Run(new FrmReport());
        }

        public static string ServerUrl = string.Format("tcp://{0}:{1}/SpaServer", Properties.Settings.Default.ServerIP, Properties.Settings.Default.Port);

        public static DBAccess Server 
        {
            get
            {
                return (DBAccess)Activator.GetObject(typeof(DBAccess), ServerUrl);
            }
        }

        private static void ConnectToServer()
        {
            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                RemotingConfiguration.RegisterWellKnownClientType(typeof(DBAccess), ServerUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến server !\r\n\r\nXem lại kết nối internet hoặc server hiện đang không hoạt động.\r\n" + ex.Message);
            }
        }

        private static void Init()
        {
            Reminder = new HDReminder();
        }
    }
}