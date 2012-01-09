using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ToastTimer
{
    class VisualAction : CountdownAction
    {
        Color color;
        Control control;

        public VisualAction(Color color, Control control)
        {
            this.color = color;
            this.control = control;
        }

        public void Action()
        {
            Thread t = new Thread(new ThreadStart(ColorFlash));
            t.Start();
        }

        private void ColorFlash()
        {
            GUIUpdater.SetControlPropertyThreadSafe(control, "BackColor", color);

            Thread.Sleep(50);

            GUIUpdater.SetControlPropertyThreadSafe(control, "BackColor", Color.Transparent);
        }
    }
}
