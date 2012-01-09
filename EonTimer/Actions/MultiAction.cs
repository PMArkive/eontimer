using System;
using System.Collections.Generic;
using System.Text;

namespace EonTimer
{
    class MultiAction : CountdownAction
    {
        private CountdownAction[] actions;

        public MultiAction(CountdownAction[] actions)
        {
            this.actions = actions;
        }

        public void Action()
        {
            foreach (CountdownAction a in actions)
                a.Action();
        }
    }
}
