using System;
using System.Collections.Generic;
using System.Text;

namespace EonTimer.Utilities.Reference
{
    public static class Consoles
    {
        public static readonly String[] CONSOLE_STRINGS = { "GBA", "NDS", "DSI", "3DS" };
        public enum ConsoleType { GBA, NDS, DSI, _3DS }
    }

    public static class Actions
    {
        public static readonly String[] TYPE_STRINGS = { "Audio", "Visual", "A/V", "None" };
        public enum ActionType { Audio, Visual, Dual, None };

        public static readonly String[] SOUND_STRINGS = { "Beep", "Ding", "Pop", "Tick" };
        public enum SoundType { Beep, Ding, Pop, Tick };
    }
    
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
