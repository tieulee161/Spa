using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

using SpaDatabase.Services;

namespace SpaServer.View
{
    public partial class FrmMain : Telerik.WinControls.UI.RadForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public static string ServerUrl = string.Format("tcp://{0}:{1}/SpaServer", Properties.Settings.Default.ServerIP, Properties.Settings.Default.Port);

        public DBAccess Server;

        private TcpChannel _Channel = null;

        private void StartServer(string serverIP, int serverPort)
        {
            if (_Channel == null)
            {
                BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
                provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
                System.Collections.IDictionary props = new System.Collections.Hashtable();
                props["name"] = "SpaChannel";
                props["port"] = serverPort;
                _Channel = new TcpChannel(props, clientProvider, provider);
                _Channel.IsSecured = false;
             
                ChannelServices.RegisterChannel(_Channel, false);
                try
                {
                    RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                }
                catch (Exception)
                { }
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(DBAccess), "SpaServer", WellKnownObjectMode.Singleton);
            }
            Server = (DBAccess)Activator.GetObject(typeof(DBAccess), ServerUrl);
           
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            string serverIP = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.Port;
            StartServer(serverIP, port);
        }
    }
 

}
