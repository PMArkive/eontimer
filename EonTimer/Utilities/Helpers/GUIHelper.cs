using System;
using System.Drawing;
using System.Windows.Forms;

namespace EonTimer.Utilities.Helpers
{
    /// <summary>
    /// Helper to set control elements in a thread-safe way
    /// </summary>
    public static class GUIHelper
    {
        private delegate void SetControlStringDelegate(Control control, String value);
        private delegate void SetControlColorDelegate(Control control, Color value);

        /// <summary>
        /// Sets the text of a control
        /// </summary>
        /// <param name="control">Control to set</param>
        /// <param name="text">String to set as control text</param>
        public static void SetControlText(Control control, String text)
        { 
            if (control.InvokeRequired)
                control.Invoke(new SetControlStringDelegate(SetControlText), new Object[] { control, text });
            else
                control.Text = text;
        }
        /// <summary>
        /// Changes background color of a control
        /// </summary>
        /// <param name="control">Control to change</param>
        /// <param name="color">Color to set background</param>
        public static void SetControlBackColor(Control control, Color color)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlColorDelegate(SetControlBackColor), new Object[] { control, color });
            else
                control.BackColor = color;
        }
    }
}
