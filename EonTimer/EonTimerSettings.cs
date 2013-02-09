using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Settings = EonTimer.Properties.UserSettings;
using EonTimer.Utilities.Reference;

namespace EonTimer
{
    public partial class EonTimerSettings : Form
    {
        public EventHandler TransparencyHandler { set{trackOpacity.Scroll += value;} }
        private Boolean eventLock;

        #region Setup
        public EonTimerSettings()
        {
            InitializeComponent();
            InitializeCustom();
            ShowSettingsInControls();
        }
        private void InitializeCustom()
        {
            foreach (var item in Actions.TYPE_STRINGS)
                combo_setting_actionmode.Items.Add(item);
            foreach (var item in Actions.SOUND_STRINGS)
                combo_setting_sound.Items.Add(item);
            foreach (var item in Consoles.CONSOLE_STRINGS)
                combo_setting_console.Items.Add(item);

            trackOpacity.Scroll += new EventHandler(this.Change);
        }
        #endregion

        #region Updates
        public void ShowSettingsInControls()
        {
            if (eventLock)
                return;

            eventLock = true;

            //Actions
            combo_setting_actionmode.SelectedIndex = Settings.Default.Setting_Action_Mode;
            combo_setting_sound.SelectedIndex = Settings.Default.Setting_Action_Sound;
            panel_setting_color.BackColor = Settings.Default.Setting_Action_Color;
            text_setting_frequency.Text = Settings.Default.Setting_Action_Interval.ToString();
            text_setting_count.Text = Settings.Default.Setting_Action_Count.ToString();

            //App
            if (Settings.Default.Setting_Form_AskSave)
                combo_setting_onexit.SelectedIndex = 0;
            else if (Settings.Default.Setting_Form_AutoSave)
                combo_setting_onexit.SelectedIndex = 1;
            else
                combo_setting_onexit.SelectedIndex = 2;
            trackOpacity.Value = Settings.Default.Setting_Form_Opacity;
            check_settings_updates.Checked = Settings.Default.Setting_Settings_Updates;

            //Timer
            combo_setting_console.SelectedIndex = Settings.Default.Setting_Timer_Console;
            check_setting_precisionmode.Checked = Settings.Default.Setting_Timer_PreciseCalibration;
            text_setting_refresh.Value = Settings.Default.Setting_Timer_SleepInterval;

            eventLock = false;
        }
        public void ApplySettingsFromControls()
        {
            if (eventLock)
                return;

            eventLock = true;

            //Actions
            Settings.Default.Setting_Action_Mode = combo_setting_actionmode.SelectedIndex;
            Settings.Default.Setting_Action_Sound = combo_setting_sound.SelectedIndex;
            Settings.Default.Setting_Action_Color = panel_setting_color.BackColor;
            Settings.Default.Setting_Action_Interval = SetInt(text_setting_frequency.Text, Settings.Default.Setting_Action_Interval);
            Settings.Default.Setting_Action_Count = SetInt(text_setting_count.Text, Settings.Default.Setting_Action_Count);

            //App
            Settings.Default.Setting_Form_AskSave = false;
            Settings.Default.Setting_Form_AutoSave = false;
            switch(combo_setting_onexit.SelectedIndex)
            {
                case 0:
                    Settings.Default.Setting_Form_AskSave = true;
                    break;
                case 1:
                    Settings.Default.Setting_Form_AutoSave = true;
                    break;
            }
            Settings.Default.Setting_Form_Opacity = trackOpacity.Value;
            Settings.Default.Setting_Settings_Updates = check_settings_updates.Checked;

            //Timer
            Settings.Default.Setting_Timer_Console = combo_setting_console.SelectedIndex;
            Settings.Default.Setting_Timer_PreciseCalibration = check_setting_precisionmode.Checked;
            Settings.Default.Setting_Timer_SleepInterval = (Int32)text_setting_refresh.Value;

            eventLock = false;
        }
        private Int32 SetInt(String toParse, Int32 defaultResult)
        {
            Int32 result = 0;
            if (Int32.TryParse(toParse, out result))
                return result;
            else
                return defaultResult;
        }

        private void Save(object sender, EventArgs e)
        {
            Settings.Default.Save();
            this.Close();
        }
        private void ResetToDefault(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            ShowSettingsInControls();
        }
        #endregion

        #region Events
        private void Change(object sender, EventArgs e)
        {
            ApplySettingsFromControls();
        }
        private void SelectColor(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
                Settings.Default.Setting_Action_Color = colorDialog.Color;

            panel_setting_color.BackColor = Settings.Default.Setting_Action_Color;
        }
        private void NumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '-'))
                e.Handled = true;
        }
        #endregion
    }
}
