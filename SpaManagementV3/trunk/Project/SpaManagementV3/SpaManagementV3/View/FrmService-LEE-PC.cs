using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace SpaManagementV3.View
{
    public partial class FrmService : Telerik.WinControls.UI.RadForm
    {
        public FrmService()
        {
            InitializeComponent();
        }

        private void Row_Formatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            e.RowElement.Font = new Font(this.Font.Name, (float)9);
        }
    }
}
