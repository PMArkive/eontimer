using System;
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
using Resources = EonTimer.Properties.Resources;

namespace EonTimer
{
    public partial class MainTimer : Form
    {
        private ITimerMonitor monitor;
        private DisplayHandler displayHandler;
        private ActionHandler actionHandler;

        

        #region Setup
        public MainTimer()
        {
            //migrates settings if necessary
            RegistryMigrationHelper.Migrate();

            //Build form
            InitializeComponent();
            InitializeCustom();
            PrepareTimeMonitor();
            AddSettings();

            CreateTimer();
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
            pictureSettings.Image = settingsButton.Basic;

            //fill combo boxes
            combo_mode_5.Items.AddRange(GenerationModes.FIVE_STRINGS);
            combo_mode_4.Items.AddRange(GenerationModes.FOUR_STRINGS);
            combo_mode_3.Items.AddRange(GenerationModes.THREE_STRINGS);
        }
        private void PrepareTimeMonitor()
        {
            monitor = new TimeMonitor(new NullTimer(), Settings.Default.Setting_Timer_SleepInterval);

            //create DisplayHandler
            displayHandler = new DisplayHandler();
            displayHandler.CurrentDisplays.Add(displayCurrent);
            displayHandler.NextStageDisplays.Add(displayNextStage);
            displayHandler.StatusDisplays.Add(buttonStart);
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
        }
        private void CreateCountdownActions()
        {
            actionHandler.Actions.Clear();

            switch ((ActionType)Settings.Default.Setting_Action_Mode)
            {
                case ActionType.Audio:
                    actionHandler.Actions.Add(GetSoundAction());
                    break;
                case ActionType.Visual:
                    actionHandler.Actions.Add(GetVisualAction());
                    break;
                case ActionType.Dual:
                    actionHandler.Actions.Add(GetSoundAction());
                    actionHandler.Actions.Add(GetVisualAction());
                    break;
            }
        }
        private SoundAction GetSoundAction()
        {
            switch ((SoundType)Settings.Default.Setting_Action_Sound)
            {
                case SoundType.Beep:
                    return new SoundAction(Resources.beep);
                case SoundType.Ding:
                    return new SoundAction(Resources.ding);
                case SoundType.Pop:
                    return new SoundAction(Resources.pop);
                case SoundType.Tick:
                    return new SoundAction(Resources.tick);
                default:
                    return new SoundAction();
            }
        }
        private VisualAction GetVisualAction()
        {
            return new VisualAction(displayCurrent, Settings.Default.Setting_Action_Color);
        }
        public void AddSettings()
        {
            //gen 5 settings
            combo_mode_5.SelectedIndex = Settings.Default.Mode_5;
            text_calibration_5.Text = Settings.Default.Calibration_5_Basic.ToString();
            text_target_delay_5.Text = Settings.Default.Target_5_Delay.ToString();
            text_target_second_5.Text = Settings.Default.Target_5_Second.ToString();
            text_calibration_entralink_5.Text = Settings.Default.Calibration_5_Entralink.ToString();
            text_target_standard_5.Text = Settings.Default.Target_5_SecondaryEntralink.ToString();

            //gen 4 settings
            combo_mode_4.SelectedIndex = Settings.Default.Mode_4;
            text_calibration_delay_4.Text = Settings.Default.Calibration_4_Delay.ToString();
            text_calibration_second_4.Text = Settings.Default.Calibration_4_Second.ToString();
            text_target_delay_4.Text = Settings.Default.Target_4_Delay.ToString();
            text_target_second_4.Text = Settings.Default.Target_4_Second.ToString();

            //gen 3 settings
            combo_mode_3.SelectedIndex = Settings.Default.Mode_3;
            text_calibration_lag_3.Text = Settings.Default.Calibration_3_Lag.ToString();
            text_calibration_factor_3.Text = Settings.Default.Calibration_3_Factor.ToString();
            text_target_initial_3.Text = Settings.Default.Target_3_Initial.ToString();
            text_target_frame_3.Text = Settings.Default.Target_3_Frame.ToString();
        }
        public void UpdateSettings()
        {
            //gen 5 settings
            Settings.Default.Mode_5 = combo_mode_5.SelectedIndex;
            Settings.Default.Calibration_5_Basic = SetInt(text_calibration_5.Text, Settings.Default.Calibration_5_Basic);
            Settings.Default.Target_5_Delay = SetInt(text_target_delay_5.Text, Settings.Default.Target_5_Delay);
            Settings.Default.Target_5_Second = SetInt(text_target_second_5.Text, Settings.Default.Target_5_Second);
            Settings.Default.Calibration_5_Entralink = SetInt(text_calibration_entralink_5.Text, Settings.Default.Calibration_5_Entralink);
            Settings.Default.Target_5_SecondaryEntralink = SetInt(text_target_standard_5.Text, Settings.Default.Target_5_SecondaryEntralink);

            //gen 4 settings
            Settings.Default.Mode_4 = combo_mode_4.SelectedIndex;
            Settings.Default.Calibration_4_Delay = SetInt(text_calibration_delay_4.Text, Settings.Default.Calibration_4_Delay);
            Settings.Default.Calibration_4_Second = SetInt(text_calibration_second_4.Text, Settings.Default.Calibration_4_Second);
            Settings.Default.Target_4_Delay = SetInt(text_target_delay_4.Text, Settings.Default.Target_4_Delay);
            Settings.Default.Target_4_Second = SetInt(text_target_second_4.Text, Settings.Default.Target_4_Second);

            //gen 3 settings
            Settings.Default.Mode_3 = combo_mode_3.SelectedIndex;
            Settings.Default.Calibration_3_Lag = SetInt(text_calibration_lag_3.Text, Settings.Default.Calibration_3_Lag);
            Settings.Default.Calibration_3_Factor = SetDecimal(text_calibration_factor_3.Text, Settings.Default.Calibration_3_Factor);
            Settings.Default.Target_3_Initial = SetInt(text_target_initial_3.Text, Settings.Default.Target_3_Initial);
            Settings.Default.Target_3_Frame = SetInt(text_target_frame_3.Text, Settings.Default.Target_3_Frame);
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

            var type = (ConsoleType)Settings.Default.Setting_Timer_Console;
            var min = Settings.Default.Setting_Timer_Minimum;

            if (tabMenu.SelectedTab.Equals(tabGen5))
            {
                var calibration = Settings.Default.Setting_Timer_PreciseCalibration ? Settings.Default.Calibration_5_Basic : CalibrationHelper.ConvertToMillis(Settings.Default.Calibration_5_Basic, type);
                var elCal = Settings.Default.Setting_Timer_PreciseCalibration ? Settings.Default.Calibration_5_Entralink : CalibrationHelper.ConvertToMillis(Settings.Default.Calibration_5_Entralink, type);

                switch (Settings.Default.Mode_5)
                {
                    case (Int32)GenerationModes.Five.Standard:
                        monitor.Timer = new SimpleTimer(calibration, Settings.Default.Target_5_Second, type, min);
                        break;
                    case (Int32)GenerationModes.Five.CGear:
                        monitor.Timer = new DelayTimer(calibration, Settings.Default.Target_5_Delay, Settings.Default.Target_5_Second, type, min);
                        break;
                    case (Int32)GenerationModes.Five.Entralink:
                        monitor.Timer = new EntralinkTimer(calibration, elCal, Settings.Default.Target_5_Delay, Settings.Default.Target_5_Second, type, min);
                        break;
                    case (Int32)GenerationModes.Five.EntralinkPlus:
                        monitor.Timer = new EnhancedEntralinkTimer(calibration, elCal, Settings.Default.Target_5_SecondaryEntralink, Settings.Default.Target_5_Delay, Settings.Default.Target_5_Second, type, min);
                        break;
                    default:
                        monitor.Timer = new NullTimer();
                        break;
                }
            }
            else if (tabMenu.SelectedTab.Equals(tabGen4))
            {
                switch (Settings.Default.Mode_4)
                {
                    case (Int32)GenerationModes.Four.Standard:
                        monitor.Timer = new DelayTimer(CalibrationHelper.CreateCalibration(Settings.Default.Calibration_4_Delay, Settings.Default.Calibration_4_Second, type), Settings.Default.Target_4_Delay, Settings.Default.Target_4_Second, type, min);
                        break;    
                    default:
                        monitor.Timer = new NullTimer();
                        break;
                }
            }
            else if (tabMenu.SelectedTab.Equals(tabGen3))
            {
                switch(Settings.Default.Mode_3)
                {
                    case (Int32)GenerationModes.Three.Standard:
                        monitor.Timer = new FrameTimer(Settings.Default.Calibration_3_Lag, Settings.Default.Target_3_Initial, Settings.Default.Target_3_Frame, type);
                        break;
                    case (Int32) GenerationModes.Three.VariableTarget:
                        monitor.Timer = new VariableTargetFrameTimer(type);
                        break;
                    default:
                        monitor.Timer = new NullTimer();
                        break;
                }
            }
        }
        #endregion

        private void Save()
        {
            Settings.Default.Save();
        }

        #region Form Change Events
        /// <summary>Makes sure keypresses are numeric</summary>
        private void NumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '-'))
                e.Handled = true;
        }
        /// <summary>Triggered when modes change</summary>
        private void ModeChanged(object sender, EventArgs e)
        {
            UpdateSettings();
            CreateTimer();
        }
        /// <summary>Triggered when </summary>
        private void InputTextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Form Control Events
        /// <summary>Saves Data</summary>
        private void Save(object sender, EventArgs e)
        {
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

            //hide interface
            tabMenu.Visible = !Settings.Default.Setting_Form_Mini;
            buttonUpdate.Visible = !Settings.Default.Setting_Form_Mini;
            buttonSave.Visible = !Settings.Default.Setting_Form_Mini;

            //form changes
            if (Settings.Default.Setting_Form_Mini)
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
        /// <summary>Opens settings</summary>
        private void OpenSettings(object sender, EventArgs e)
        {
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
            Basic = EonTimer.Properties.Resources.Minimize,
            Hover = EonTimer.Properties.Resources.Minimize_Hover
        };
        EonButton closeButton = new EonButton
        {
            Basic = EonTimer.Properties.Resources.Close,
            Hover = EonTimer.Properties.Resources.Close_Hover
        };
        EonButton settingsButton = new EonButton
        {
            Basic = EonTimer.Properties.Resources.Settings,
            Hover = EonTimer.Properties.Resources.Settings_Hover
        };
        EonButton miniButton = new EonButton
        {
            Basic = EonTimer.Properties.Resources.Mini,
            Hover = EonTimer.Properties.Resources.Mini_Hover,
            Active = EonTimer.Properties.Resources.Mini_Active
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

        private void Mini_MouseEnter(object sender, EventArgs e)
        {
            pictureMini.Image = miniButton.Hover;
        }
        private void Mini_MouseLeave(object sender, EventArgs e)
        {
            pictureMini.Image = Settings.Default.Setting_Form_Mini ? miniButton.Active : miniButton.Basic;
        }

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
    }
}
