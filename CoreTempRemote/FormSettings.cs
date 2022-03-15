#region Using...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace CoreTempRemote
{
    public partial class FormSettings : Form
    {
        #region --- Konstruktor ---

        public FormSettings()
        {
            InitializeComponent();
            string[] IP_split = CConfig.IP_Address.Split('.');
            nud_IP1.Value = Convert.ToInt32(IP_split[0]);
            nud_IP2.Value = Convert.ToInt32(IP_split[1]);
            nud_IP3.Value = Convert.ToInt32(IP_split[2]);
            nud_IP4.Value = Convert.ToInt32(IP_split[3]);

            nud_Port.Value = CConfig.Port;

            cb_StartMinimized.Checked = CConfig.StartMinimized;
        }

        #endregion

        #region --- "Destruktor" ---

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            CConfig.IP_Address = $"{nud_IP1.Value}.{nud_IP2.Value}.{nud_IP3.Value}.{nud_IP4.Value}";
            CConfig.Port = Convert.ToInt32(nud_Port.Value);

            CConfig.StartMinimized = cb_StartMinimized.Checked;
        }

        #endregion

        #region --- OnFocus ---

        private void IP_OnFocus(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        #endregion
    }
}
