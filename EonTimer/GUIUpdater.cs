using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ToastTimer
{
    static class GUIUpdater
    {
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName,System.Reflection.BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }
    }
}
