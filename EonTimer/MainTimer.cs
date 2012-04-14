﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities;
using EonTimer.Utilities.Reference;
using EonTimer.Handlers;
using EonTimer.Timers;
using Settings = EonTimer.Properties.Settings;
using UserData = EonTimer.Properties.UserData;
using Resources = EonTimer.Properties.Resources;

namespace EonTimer
{
    public partial class MainTimer : Form, ITimeoutHandler
    {
        private ITimerMonitor monitor;
        private DisplayHandler displayHandler;
        private ActionHandler actionHandler;
        private Boolean eventLock;
        private EonTimerSettings settingsForm;
        

        #region Setup
        public MainTimer()
        {
            //migrates settings if necessary
            RegistryMigrationHelper.Migrate();

            //Build form
            InitializeComponent();
            InitializeCustom();
            PrepareTimeMonitor();
            ShowSettingsInControls();
            ApplyOpacity();
            HideGUIElements();

            CreateTimer();
            SetMini(Settings.Default.Setting_Form_Mini);
            SetPin(Settings.Default.Setting_Form_OnTop);

        }
        private void InitializeCustom()
        {
            //attach handlers
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseUp += new MouseEventHandler(Form_MouseUp);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);

            //set images
            pictureClose.Image = closeButton.Basic;
            pictureMinimize.Image = minimizeButton.Basic;
            pictureMini.Image = Settings.Default.Setting_Form_Mini ? miniButton.Active : miniButton.Basic;
            picturePin.Image = pinButton.Basic;
            pictureSettings.Image = settingsButton.Basic;

            //fill combo boxes
            combo_mode_5.Items.AddRange(GenerationModes.FIVE_STRINGS);
            combo_mode_4.Items.AddRange(GenerationModes.FOUR_STRINGS);
            combo_mode_3.Items.AddRange(GenerationModes.THREE_STRINGS);

            settingsForm = new EonTimerSettings();
            settingsForm.TransparencyHandler = new EventHandler(this.UpdateOpacity);
            settingsForm.FormClosing += new FormClosingEventHandler(this.OnSettingsFormClosing);
        }
        private void PrepareTimeMonitor()
        {
            monitor = new TimeMonitor(new NullTimer(), Settings.Default.Setting_Timer_SleepInterval);

            //create DisplayHandler
            displayHandler = new DisplayHandler();
            displayHandler.CurrentDisplays.Add(displayCurrent);
            displayHandler.NextStageDisplays.Add(displayNextStage);
            displayHandler.MinutesBeforeDisplays.Add(displayMinsBefore);

            //create ActionHandler
            actionHandler = new ActionHandler
            {
                ActionCount = Settings.Default.Setting_Action_Count,
                Interval = new TimeSpan(0, 0, 0, 0, Settings.Default.Setting_Action_Interval)
            };
            SetHandlers();
        }
        #endregion

        #region Update Methods
        private void SetHandlers()
        {
            CreateCountdownActions();
            monitor.ClearHandlers();
            monitor.AddHandler(displayHandler);
            monitor.AddHandler(actionHandler);
            monitor.AddHandler(this);
        }
        private void CreateCountdownActions()
        {
            actionHandler.Actions.Clear();

            switch ((Actions.ActionType)Settings.Default.Setting_Action_Mode)
            {
                case Actions.ActionType.Audio:
                    actionHandler.Actions.Add(GetSoundAction());
                    break;
                case Actions.ActionType.Visual:
                    actionHandler.Actions.Add(GetVisualAction());
                    break;
                case Actions.ActionType.Dual:
                    actionHandler.Actions.Add(GetSoundAction());
                    actionHandler.Actions.Add(GetVisualAction());
                    break;
            }
        }
        private SoundAction GetSoundAction()
        {
            switch ((Actions.SoundType)Settings.Default.Setting_Action_Sound)
            {
                case Actions.SoundType.Beep:
                    return new SoundAction(Resources.beep);
                case Actions.SoundType.Ding:
                    return new SoundAction(Resources.ding);
                case Actions.SoundType.Pop:
                    return new SoundAction(Resources.pop);
                case Actions.SoundType.Tick:
                    return new SoundAction(Resources.tick);
                default:
                    return new SoundAction();
            }
        }
        private VisualAction GetVisualAction()
        {
            return new VisualAction(displayCurrent, Settings.Default.Setting_Action_Color);
        }
        public void ShowSettingsInControls()
        {
            if (eventLock)
                return;

            eventLock = true;

            //gen 5 settings
            combo_mode_5.SelectedIndex = UserData.Default.Mode_5;
            text_calibration_5.Text = UserData.Default.Calibration_5_Basic.ToString();
            text_target_delay_5.Text = UserData.Default.Target_5_Delay.ToString();
            text_target_second_5.Text = UserData.Default.Target_5_Second.ToString();
            text_calibration_entralink_5.Text = UserData.Default.Calibration_5_Entralink.ToString();
            text_target_standard_5.Text = UserData.Default.Target_5_SecondaryEntralink.ToString();

            //gen 4 settings
            combo_mode_4.SelectedIndex = UserData.Default.Mode_4;
            text_calibration_delay_4.Text = UserData.Default.Calibration_4_Delay.ToString();
            text_calibration_second_4.Text = UserData.Default.Calibration_4_Second.ToString();
            text_target_delay_4.Text = UserData.Default.Target_4_Delay.ToString();
            text_target_second_4.Text = UserData.Default.Target_4_Second.ToString();

            //gen 3 settings
            combo_mode_3.SelectedIndex = UserData.Default.Mode_3;
            text_calibration_lag_3.Text = UserData.Default.Calibration_3_Lag.ToString();
            text_calibration_factor_3.Text = UserData.Default.Calibration_3_Factor.ToString();
            text_target_initial_3.Text = UserData.Default.Target_3_Initial.ToString();
            text_target_frame_3.Text = UserData.Default.Target_3_Frame.ToString();

            eventLock = false;
        }
        public void UpdateSettingsFromControls()
        {
            if (eventLock)
                return;

            eventLock = true;

            //gen 5 settings
            UserData.Default.Mode_5 = combo_mode_5.SelectedIndex;
            UserData.Default.Calibration_5_Basic = SetInt(text_calibration_5.Text, UserData.Default.Calibration_5_Basic);
            UserData.Default.Target_5_Delay = SetInt(text_target_delay_5.Text, UserData.Default.Target_5_Delay);
            UserData.Default.Target_5_Second = SetInt(text_target_second_5.Text, UserData.Default.Target_5_Second);
            UserData.Default.Calibration_5_Entralink = SetInt(text_calibration_entralink_5.Text, UserData.Default.Calibration_5_Entralink);
            UserData.Default.Target_5_SecondaryEntralink = SetInt(text_target_standard_5.Text, UserData.Default.Target_5_SecondaryEntralink);

            //gen 4 settings
            UserData.Default.Mode_4 = combo_mode_4.SelectedIndex;
            UserData.Default.Calibration_4_Delay = SetInt(text_calibration_delay_4.Text, UserData.Default.Calibration_4_Delay);
            UserData.Default.Calibration_4_Second = SetInt(text_calibration_second_4.Text, UserData.Default.Calibration_4_Second);
            UserData.Default.Target_4_Delay = SetInt(text_target_delay_4.Text, UserData.Default.Target_4_Delay);
            UserData.Default.Target_4_Second = SetInt(text_target_second_4.Text, UserData.Default.Target_4_Second);

            //gen 3 settings
            UserData.Default.Mode_3 = combo_mode_3.SelectedIndex;
            UserData.Default.Calibration_3_Lag = SetInt(text_calibration_lag_3.Text, UserData.Default.Calibration_3_Lag);
            UserData.Default.Calibration_3_Factor = SetDecimal(text_calibration_factor_3.Text, UserData.Default.Calibration_3_Factor);
            UserData.Default.Target_3_Initial = SetInt(text_target_initial_3.Text, UserData.Default.Target_3_Initial);
            UserData.Default.Target_3_Frame = SetInt(text_target_frame_3.Text, UserData.Default.Target_3_Frame);

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
        private Decimal SetDecimal(String toParse, Decimal defaultResult)
        {
            Decimal result = 0;
            if(Decimal.TryParse(toParse, out result))
                return result;
            else
                return defaultResult;
        }

        private void CreateTimer()
        {
            if (monitor.IsRunning())
                return;

            var type = (Consoles.ConsoleType)Settings.Default.Setting_Timer_Console;
            var min = Settings.Default.Setting_Timer_Minimum;

            // Gen 5
            if (tabMenu.SelectedTab.Equals(tabGen5))
            {
                var calibration = Settings.Default.Setting_Timer_PreciseCalibration ? UserData.Default.Calibration_5_Basic : CalibrationHelper.ConvertToMillis(UserData.Default.Calibration_5_Basic, type);
                var elCal = Settings.Default.Setting_Timer_PreciseCalibration ? UserData.Default.Calibration_5_Entralink : CalibrationHelper.ConvertToMillis(UserData.Default.Calibration_5_Entralink, type);

                switch ((GenerationModes.Five)UserData.Default.Mode_5)
                {
                    case GenerationModes.Five.Standard:
                        monitor.Timer = new SimpleTimer(calibration, UserData.Default.Target_5_Second, type, min);
                        break;
                    case GenerationModes.Five.CGear:
                        monitor.Timer = new DelayTimer(calibration, UserData.Default.Target_5_Delay, UserData.Default.Target_5_Second, type, min);
                        break;
                    case GenerationModes.Five.Entralink:
                        monitor.Timer = new EntralinkTimer(calibration, elCal, UserData.Default.Target_5_Delay, UserData.Default.Target_5_Second, type, min);
                        break;
                    case GenerationModes.Five.EntralinkPlus:
                        monitor.Timer = new EnhancedEntralinkTimer(calibration, elCal, UserData.Default.Target_5_SecondaryEntralink, UserData.Default.Target_5_Delay, UserData.Default.Target_5_Second, type, min);
                        break;
                    default:
                        monitor.Timer = new NullTimer();
                        break;
                }
            } // Gen 4
            else if (tabMenu.SelectedTab.Equals(tabGen4))
            {
                switch ((GenerationModes.Four)UserData.Default.Mode_4)
                {
                    case GenerationModes.Four.Standard:
                        monitor.Timer = new DelayTimer(CalibrationHelper.CreateCalibration(UserData.Default.Calibration_4_Delay, UserData.Default.Calibration_4_Second, type), UserData.Default.Target_4_Delay, UserData.Default.Target_4_Second, type, min);
                        break;    
                    default:
                        monitor.Timer = new NullTimer();
                        break;
                }
            } // Gen 3
            else if (tabMenu.SelectedTab.Equals(tabGen3))
            {
                switch ((GenerationModes.Three)UserData.Default.Mode_3)
                {
                    case GenerationModes.Three.Standard:
                        monitor.Timer = new FrameTimer(UserData.Default.Calibration_3_Lag, UserData.Default.Target_3_Initial, UserData.Default.Target_3_Frame, type);
                        break;
                    case GenerationModes.Three.VariableTarget:
                        monitor.Timer = new VariableTargetFrameTimer(type);
                        break;
                    default:
                        monitor.Timer = new NullTimer();
                        break;
                }
            }
        }

        private void ApplyOpacity()
        {
            this.Opacity = Settings.Default.Setting_Form_Opacity / 100.0;
            
        }
        private void Save()
        {
            UserData.Default.Save();
        }
        #endregion

        #region Form Change Events
        /// <summary>Makes sure keypresses are numeric</summary>
        private void NumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '-'))
                e.Handled = true;
        }
        /// <summary>Triggered when modes change</summary>
        private void UpdateTimer(object sender, EventArgs e)
        {
            UpdateSettingsFromControls();
            HideGUIElements();
            CreateTimer();
        }
        /// <summary>Sets opacity</summary>
        private void UpdateOpacity(object sender, EventArgs e)
        {
            ApplyOpacity();
        }
        /// <summary>Hides unused elements</summary>
        private void HideGUIElements()
        {
            labelDelayHit5.Text = "Delay Hit";

            switch ((GenerationModes.Five)UserData.Default.Mode_5)
            {
                case GenerationModes.Five.Standard:
                    Hide(new Control[] { label_target_delay_5, text_target_delay_5, label_calibration_entralink_5, text_calibration_entralink_5, label_target_entralink_second, text_target_standard_5 });
                    labelDelayHit5.Text = "Second Hit";
                    break;
                case GenerationModes.Five.CGear:
                    Hide(new Control[] { label_calibration_entralink_5, text_calibration_entralink_5, label_target_entralink_second, text_target_standard_5 });
                    Show(new Control[] { label_target_delay_5, text_target_delay_5 });
                    break;
                case GenerationModes.Five.Entralink:
                    Hide(new Control[] { label_target_entralink_second, text_target_standard_5 });
                    Show(new Control[] { label_target_delay_5, text_target_delay_5, label_calibration_entralink_5, text_calibration_entralink_5 });
                    break;
                case GenerationModes.Five.EntralinkPlus:
                    Show(new Control[] { label_target_delay_5, text_target_delay_5, label_calibration_entralink_5, text_calibration_entralink_5, label_target_entralink_second, text_target_standard_5 });
                    break;
            }
            switch ((GenerationModes.Three)UserData.Default.Mode_3)
            {
                case GenerationModes.Three.Standard:
                    Show(new Control[] { text_hit_3, labelHit3, label_calibration_lag_3, text_calibration_lag_3 });
                    break;
                case GenerationModes.Three.VariableTarget:
                    Hide(new Control[] { text_hit_3, labelHit3, label_calibration_lag_3, text_calibration_lag_3 });
                    break;
            }
        }
        private void Hide(Control[] ctrls)
        {
            foreach (var ctrl in ctrls)
                ctrl.Visible = false;
        }
        private void Show(Control[] ctrls)
        {
            foreach (var ctrl in ctrls)
                ctrl.Visible = true;
        }
        #endregion

        private void Start(object sender, EventArgs e)
        {
            if (!monitor.IsRunning())
            {
                buttonStart.Text = "Cancel";
                CreateTimer();
                monitor.Run();
            }
            else
            {
                monitor.Cancel();
                CreateTimer();
            }
        }

        #region Form Control Events
        /// <summary>Updates Calibration</summary>
        private void UpdateCalibration(object sender, EventArgs e)
        {
            Int32 temp = 0;

            if(tabMenu.SelectedTab.Equals(tabGen5))
            {
                switch((GenerationModes.Five)UserData.Default.Mode_5)
                {
                    case GenerationModes.Five.Standard:
                    case GenerationModes.Five.CGear:
                        temp = monitor.Timer.Calibrate(SetInt(text_hit_5.Text, UserData.Default.Calibration_5_Basic));
                        UserData.Default.Calibration_5_Basic = Settings.Default.Setting_Timer_PreciseCalibration ? temp : CalibrationHelper.ConvertToDelays(temp, (Consoles.ConsoleType)Settings.Default.Setting_Timer_Console);
                        break;
                    case GenerationModes.Five.Entralink:
                    case GenerationModes.Five.EntralinkPlus:
                        temp = monitor.Timer.Calibrate(SetInt(text_hit_5.Text, UserData.Default.Calibration_5_Entralink));
                        UserData.Default.Calibration_5_Entralink = Settings.Default.Setting_Timer_PreciseCalibration ? temp : CalibrationHelper.ConvertToDelays(temp, (Consoles.ConsoleType)Settings.Default.Setting_Timer_Console);
                        break;
                }

                text_hit_5.Text = "";
            }
            else if (tabMenu.SelectedTab.Equals(tabGen4))
            {
                switch ((GenerationModes.Four)UserData.Default.Mode_4)
                {
                    case GenerationModes.Four.Standard:
                        temp = monitor.Timer.Calibrate(SetInt(text_hit_4.Text, UserData.Default.Calibration_4_Delay)) + (UserData.Default.Calibration_4_Second * 1000);
                        UserData.Default.Calibration_4_Delay = Settings.Default.Setting_Timer_PreciseCalibration ? temp : CalibrationHelper.ConvertToDelays(temp, (Consoles.ConsoleType)Settings.Default.Setting_Timer_Console);
                        break;
                }

                text_hit_4.Text = "";
            }
            else if (tabMenu.SelectedTab.Equals(tabGen3))
            {
                switch ((GenerationModes.Three)UserData.Default.Mode_3)
                {
                    case GenerationModes.Three.Standard:
                        temp = monitor.Timer.Calibrate(SetInt(text_hit_3.Text, UserData.Default.Calibration_3_Lag));
                        UserData.Default.Calibration_3_Lag = temp;
                        break;
                    case GenerationModes.Three.VariableTarget:
                        temp = SetInt(text_target_frame_3.Text, 10000);
                        if (monitor.Timer is VariableTargetFrameTimer)
                            ((VariableTargetFrameTimer)monitor.Timer).TargetFrame = temp;
                        break;
                }

                text_hit_3.Text = "";
            }

            ShowSettingsInControls();
        }
        /// <summary>Saves Data</summary>
        private void Save(object sender, EventArgs e)
        {
            Save();
        }
        /// <summary>Closes the Program</summary>
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>Minimizes</summary>
        private void Minimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>Go To Help Forum</summary>
        private void Help(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.smogon.com/forums/showpost.php?p=3087342&postcount=1");
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, this doesn't work on your computer.");
            }
        }
        /// <summary>Controls Mini-Mode</summary>
        private void Mini(object sender, EventArgs e)
        {
            Settings.Default.Setting_Form_Mini = !Settings.Default.Setting_Form_Mini;
            SetMini(Settings.Default.Setting_Form_Mini);
        }
        private void SetMini(Boolean mini)
        {
            //hide interface
            tabMenu.Visible = !mini;
            buttonUpdate.Visible = !mini;
            buttonSave.Visible = !mini;

            //form changes
            if (mini)
            {
                this.BackgroundImage = EonTimer.Properties.Resources.glaceonmini;
                this.Height = 148;
                this.Width = 246;
                pictureMini.Image = miniButton.Active;
            }
            else
            {
                this.BackgroundImage = EonTimer.Properties.Resources.glaceonbg;
                this.Height = 293;
                this.Width = 392;
                pictureMini.Image = miniButton.Basic;
            }
        }
        /// <summary>Toggles pin to top</summary>
        private void Pin(object sender, EventArgs e)
        {
            Settings.Default.Setting_Form_OnTop = !Settings.Default.Setting_Form_OnTop;
            SetPin(Settings.Default.Setting_Form_OnTop);
        }
        private void SetPin(Boolean pinned)
        {
            this.TopMost = Settings.Default.Setting_Form_OnTop;
            picturePin.Image = pinButton.Active;
        }
        /// <summary>Opens settings</summary>
        private void OpenSettings(object sender, EventArgs e)
        {
            settingsForm.Show();
        }
        #endregion

        #region Other Form Events
        /// <summary>Closing handler</summary>
        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            monitor.Cancel();

            if (Settings.Default.Setting_Form_AutoSave)
                Save();
            else if (Settings.Default.Setting_Form_AskSave)
            {
                DialogResult result = MessageBox.Show("Store input?", "Save values?", MessageBoxButtons.YesNoCancel);

                if (result == System.Windows.Forms.DialogResult.Yes)
                    Save();
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        private void OnSettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            settingsForm.Hide();
            Settings.Default.Reload();
            ApplyOpacity();
            CreateCountdownActions();
            CreateTimer();
            e.Cancel = true;
        }
        #endregion

        #region Image Button Support
        /// <summary>Holds Images For Button States</summary>
        private class EonButton
        {
            public Image Basic { get; set; }
            public Image Hover { get; set; }
            public Image Active { get; set; }
        }
        EonButton minimizeButton = new EonButton
        {
            Basic = Resources.Minimize,
            Hover = Resources.Minimize_Hover
        };
        EonButton closeButton = new EonButton
        {
            Basic = Resources.Close,
            Hover = Resources.Close_Hover
        };
        EonButton settingsButton = new EonButton
        {
            Basic = Resources.Settings,
            Hover = Resources.Settings_Hover
        };
        EonButton miniButton = new EonButton
        {
            Basic = Resources.Mini,
            Hover = Resources.Mini_Hover,
            Active = Resources.Mini_Active
        };
        EonButton pinButton = new EonButton
        {
            Basic = Resources.Pin,
            Hover = Resources.Pin_Hover,
            Active = Resources.Pin_Active
        };

        //Close Button
        private void Close_MouseEnter(object sender, EventArgs e)
        {
            pictureClose.Image = closeButton.Hover;
        }
        private void Close_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.Image = closeButton.Basic;
        }

        //Minimize Button
        private void Minimize_MouseEnter(object sender, EventArgs e)
        {
            pictureMinimize.Image = minimizeButton.Hover;
        }
        private void Minimize_MouseLeave(object sender, EventArgs e)
        {
            pictureMinimize.Image = minimizeButton.Basic;
        }

        //Mini Button
        private void Mini_MouseEnter(object sender, EventArgs e)
        {
            pictureMini.Image = miniButton.Hover;
        }
        private void Mini_MouseLeave(object sender, EventArgs e)
        {
            pictureMini.Image = Settings.Default.Setting_Form_Mini ? miniButton.Active : miniButton.Basic;
        }

        //Pin Button
        private void Pin_MouseEnter(object sender, EventArgs e)
        {
            picturePin.Image = pinButton.Hover;
        }
        private void Pin_MouseLeave(object sender, EventArgs e)
        {
            picturePin.Image = Settings.Default.Setting_Form_OnTop ? pinButton.Active : pinButton.Basic;
        }

        //Settings Button
        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            pictureSettings.Image = settingsButton.Hover;
        }
        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            pictureSettings.Image = settingsButton.Basic;
        }
        #endregion

        #region Form Drag Support

        Boolean drag = false;
        Point start_point = new Point(0, 0);

        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.MouseDown += new MouseEventHandler(Form_MouseDown);
            e.Control.MouseUp += new MouseEventHandler(Form_MouseUp);
            e.Control.MouseMove += new MouseEventHandler(Form_MouseMove);
            base.OnControlAdded(e);
        }
        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            this.drag = true;
            this.start_point = new Point(e.X, e.Y);
        }
        void Form_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }
        void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.start_point.X,
                                     p2.Y - this.start_point.Y);
                this.Location = p3;
            }
        }

        #endregion

        //TODO:This is crap.
        public void NotifyTimeout()
        {
            GUIHelper.SetControlText(buttonStart, "Start");
            CreateTimer();
        }
    }
}
