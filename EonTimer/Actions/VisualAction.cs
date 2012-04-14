using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using EonTimer.Utilities.Helpers;
using System;

namespace EonTimer
{
    public class VisualAction : ICountdownAction
    {
        public Color Color { get; set; }
        public Control Control { get; set; }

        public VisualAction(Control control)
        {
            Control = control;
            Color = Color.Black;
        }
        public VisualAction(Control control, Color color)
        {
            Control = control;
            Color = color;
        }

        public void Action()
        {
            Thread t = new Thread(new ThreadStart(ColorFlash));
            t.Start();
        }

        private void ColorFlash()
        {
            GUIHelper.SetControlBackColor(Control, Color);

            Thread.Sleep(50);

            GUIHelper.SetControlBackColor(Control, Color.Transparent);
        }
    }
}
