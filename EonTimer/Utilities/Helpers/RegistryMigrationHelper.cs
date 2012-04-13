using System;
using System.Drawing;
using Microsoft.Win32;
using Settings = EonTimer.Properties.Settings;
using UserData = EonTimer.Properties.UserData;

namespace EonTimer.Utilities.Helpers
{
    /* The entire purpose of this class is to transfer values *
     * saved in the registry by an older version of EonTimer  *
     * to an app settings file. This is not intended to be    *
     * used for any other purpose.                            */

    public static class RegistryMigrationHelper
    {
        public static void Migrate()
        {
            //names the key has been assigned
            String[] names = { "ToastTimer", "ToastTimer1", "EonTimer" };

            foreach (var name in names)
            {
                var key = Registry.CurrentUser.OpenSubKey(name);

                if (key != null)
                {
                    //copy calibration
                    UserData.Default.Calibration_5_Basic = GetValue(key, "gen5cal", UserData.Default.Calibration_5_Basic);
                    UserData.Default.Calibration_5_Entralink = GetValue(key, "hlcal", UserData.Default.Calibration_5_Entralink);
                    UserData.Default.Calibration_4_Delay = GetValue(key, "gen4cd", UserData.Default.Calibration_4_Delay);
                    UserData.Default.Calibration_4_Second = GetValue(key, "gen4cs", UserData.Default.Calibration_4_Second);
                    UserData.Default.Calibration_3_Factor = GetValue(key, "gen3factor", UserData.Default.Calibration_3_Factor);
                    UserData.Default.Calibration_3_Lag = GetValue(key, "gen3lag", UserData.Default.Calibration_3_Lag);

                    //copy targets
                    UserData.Default.Target_3_Initial = GetValue(key, "gen3init", UserData.Default.Target_3_Initial);
                    UserData.Default.Target_3_Frame = GetValue(key, "gen3TFrame", UserData.Default.Target_3_Frame);
                    UserData.Default.Target_4_Delay = GetValue(key, "gen4TDelay", UserData.Default.Target_4_Delay);
                    UserData.Default.Target_4_Second = GetValue(key, "gen4TSec", UserData.Default.Target_4_Second);
                    UserData.Default.Target_5_Delay = GetValue(key, "gen5TDelay", UserData.Default.Target_5_Delay);
                    UserData.Default.Target_5_Second = GetValue(key, "gen5TSec", UserData.Default.Target_5_Second);

                    //copy action settings
                    Settings.Default.Setting_Action_Color = Color.FromArgb((Int32)GetValue(key, "color", 0xff00ffff));
                    Settings.Default.Setting_Action_Count = GetValue(key, "beepNo", Settings.Default.Setting_Action_Count);
                    Settings.Default.Setting_Action_Interval = GetValue(key, "beepFreq", Settings.Default.Setting_Action_Interval);
                    Settings.Default.Setting_Action_Sound = GetValue(key, "sound", Settings.Default.Setting_Action_Sound);
                    Settings.Default.Setting_Action_Mode = GetValue(key, "mode", Settings.Default.Setting_Action_Mode);

                    //copy form settings
                    Settings.Default.Setting_Form_AutoSave = GetValue(key, "saveQuit", Settings.Default.Setting_Form_AutoSave);
                    Settings.Default.Setting_Form_AskSave = GetValue(key, "askQuit", Settings.Default.Setting_Form_AskSave);
                    Settings.Default.Setting_Form_OnTop = GetValue(key, "onTop", Settings.Default.Setting_Form_OnTop);

                    //copy other settings
                    Settings.Default.Setting_Timer_Minimum = GetValue(key, "min", Settings.Default.Setting_Timer_Minimum);

                    //delete key
                    Registry.CurrentUser.DeleteSubKeyTree(name);
                }
            }
        }

        private static T GetValue<T>(RegistryKey key, String name, T defaultValue)
        {
            try
            {
                return (T)key.GetValue(name);
            }
            catch(Exception)
            {
                return defaultValue;
            }
        }
    }
}
