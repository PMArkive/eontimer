using System;
using System.Collections.Generic;
using System.Text;

namespace EonTimer.Utilities.Reference
{
    public enum ConsoleType { GBA, NDS, DSI, _3DS }
    public enum ActionType { Audio, Visual, Dual, None }
    public enum SoundType { Beep, Ding, Pop, Tick }
    
    public static class GenerationModes
    {
        public static readonly String[] FIVE_STRINGS = { "Standard", "C-Gear", "Entralink", "Entralink+" };
        public enum Five { Standard, CGear, Entralink, EntralinkPlus };

        public static readonly String[] FOUR_STRINGS = { "Standard" };
        public enum Four { Standard };

        public static readonly String[] THREE_STRINGS = { "Standard", "Variable Target" };
        public enum Three { Standard, VariableTarget };
    }
}
