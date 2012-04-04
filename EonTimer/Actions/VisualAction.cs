using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using EonTimer.Utilities;

namespace EonTimer
{
    public class VisualAction : ICountdownAction
    {
        public Color Color { get; set; }
        public Control Control { get; set; }

        public void Action()
        {
            Thread t = new Thread(new ThreadStart(ColorFlash));
            t.Start();
        }

        private void ColorFlash()
        {
            GUIUpdater.SetControlBackColor(Control, Color);

            Thread.Sleep(50);

            GUIUpdater.SetControlBackColor(Control, Color.Transparent);
        }
    }
}
