#region Using...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace CoreTempRemote
{
    public class DoubleBufferedTreeView : TreeView
    {
        #region --- Variablen ---

        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;

        #endregion

        #region --- DllImports ---

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        #endregion

        #region --- OnHandleCreated ---

        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }

        #endregion
    }
}
