using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using Microsoft.Win32;
using System.IO;

namespace EonTimer
{
    public partial class MainTimer : Form
    {
        Color color = Color.Aqua;
        Boolean showWarning = true;
        Boolean isStartup;
        RNGTimer timer;
        TimerSettings settings;
        List<Double> customStages;

        Image[] helpImage = {EonTimer.Properties.Resources.helpbutton, EonTimer.Properties.Resources.helpbutton2};
        Image[] minimizeImage = { EonTimer.Properties.Resources._button, EonTimer.Properties.Resources._button2 };
        Image[] closeImage = { EonTimer.Properties.Resources.xbutton, EonTimer.Properties.Resources.xbutton2 };

        Boolean drag = false;
        Point start_point = new Point(0, 0);

        public MainTimer()
        {
            isStartup = true;

            InitializeComponent();

            //set event handlers
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseUp += new MouseEventHandler(Form_MouseUp);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);

            //set images
            pictureHelp.Image = helpImage[0];
            pictureClose.Image = closeImage[0];
            pictureMinimize.Image = minimizeImage[0];

            //default settings
            settings = new TimerSettings(new VisualAction(color, labelTime), 1000, 5, 15);
            comboMode.SelectedIndex = 0;
            comboSounds.SelectedIndex = 0;

            //load registry keys
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("EonTimer", true);

            try
            {
                textCal.Text = (String)registryKey.GetValue("gen5cal");
                textHLCal.Text = (String)registryKey.GetValue("hlcal");
                textCDelay.Text = (String)registryKey.GetValue("gen4cd");
                textCSec.Text = (String)registryKey.GetValue("gen4cs");
                textFactor.Text = (String)registryKey.GetValue("gen3factor");
                textLag.Text = (String)registryKey.GetValue("gen3lag");
                textInitial.Text = (String)registryKey.GetValue("gen3init");
                color = Color.FromArgb((Int32)registryKey.GetValue("color"));
                textMin.Text = (String)registryKey.GetValue("min");
                numBeeps.Value = Convert.ToInt32(registryKey.GetValue("beepNo"));
                numFreq.Value = Convert.ToDecimal(registryKey.GetValue("beepFreq"));
                comboSounds.SelectedIndex = (Int32)registryKey.GetValue("sound");
                comboMode.SelectedIndex = (Int32)registryKey.GetValue("mode");
                textTDelay4.Text = (String)registryKey.GetValue("gen4TDelay");
                textTDelay5.Text = (String)registryKey.GetValue("gen5TDelay");
                textTSec4.Text = (String)registryKey.GetValue("gen4TSec");
                textTSec5.Text = (String)registryKey.GetValue("gen5TSec");
                textFrame.Text = (String)registryKey.GetValue("gen3TFrame");
                saveOnQuitToolStripMenuItem.Checked = Convert.ToBoolean(registryKey.GetValue("saveQuit"));
                AskOnQuitToolStripMenuItem.Checked = Convert.ToBoolean(registryKey.GetValue("askQuit"));
                alwaysOnTopToolStripMenuItem.Checked = Convert.ToBoolean(registryKey.GetValue("onTop"));
            }
            catch (Exception)
            { }
            finally
            {
                if(registryKey != null)
                    registryKey.Close();
            }

            CreateTimer();
            UpdateDisplay();
            customStages = new List<Double>();

            isStartup = false;
        }

        //Checks for numeric input only
        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '-'))
                e.Handled = true;
        }

        //generic event to be called when display updating is required
        private void updateDisplayEvent(object sender, EventArgs e)
        {
            CreateTimer();
            UpdateDisplay();

            if (tabMenu.SelectedTab.Equals(tabSet))
            {
                buttonUpdate.Enabled = false;
                buttonStart.Enabled = false;
            }
            else if (tabMenu.SelectedTab.Equals(tabCustom))
            {
                buttonStart.Enabled = true;
                buttonUpdate.Enabled = false;
            }
            else
            {
                buttonUpdate.Enabled = true;
                buttonStart.Enabled = true;
            }

        }
        private void UpdateDisplay()
        {
            try
            {
                if(tabMenu.SelectedTab.Equals(tabGen5) || tabMenu.SelectedTab.Equals(tabGen4))
                    labelMinsBefore.Text = ((timer.GetLength(0) + timer.GetLength(1)) / 60000).ToString();

                labelTime.Text = String.Format("{0:0:00}", timer.GetLength(0) / 10);
                labelSecondTime.Text = String.Format("{0:0:00}", timer.GetLength(1) / 10);
            }
            catch (Exception)
            { }
        }
        private void CreateTimer()
        {
            try
            {
                if (timer != null && timer.IsRunning())
                    return;
                if (tabMenu.SelectedTab.Equals(tabGen5) && checkHL.Checked)
                    timer = new EntralinkTimer(Int32.Parse(textHLCal.Text), Int32.Parse(textCal.Text), Int32.Parse(textTDelay5.Text), Int32.Parse(textTSec5.Text), settings);
                else if (tabMenu.SelectedTab.Equals(tabGen5) && checkCGear.Checked)
                    timer = new DelayTimer(Int32.Parse(textCal.Text), Int32.Parse(textTDelay5.Text), Int32.Parse(textTSec5.Text), settings);
                else if (tabMenu.SelectedTab.Equals(tabGen5))
                    timer = new StandardSeedTimer(Int32.Parse(textCal.Text), Int32.Parse(textTSec5.Text), settings);
                else if (tabMenu.SelectedTab.Equals(tabGen4))
                    timer = new DelayTimer(Int32.Parse(textCDelay.Text), Int32.Parse(textCSec.Text), Int32.Parse(textTDelay4.Text), Int32.Parse(textTSec4.Text), settings);
                else if (tabMenu.SelectedTab.Equals(tabGen3))
                {
                    if (checkUnknownTarget.Checked)
                        timer = new GBAAltTimer(settings, checkGBA.Checked);
                    else
                        timer = new GBATimer(Int32.Parse(textInitial.Text), Int32.Parse(textLag.Text), Int32.Parse(textFrame.Text), settings, checkGBA.Checked);
                }
                else if (tabMenu.SelectedTab.Equals(tabCustom))
                {
                    timer = new CustomTimer(settings);
                    ((CustomTimer)timer).Stages = customStages;
                }

                timer.DisplayControl = labelTime;
                timer.StartStopControl = buttonStart;
            }
            catch (Exception)
            { }
        }

        //Gen 5 Events
        private void checkCGear_CheckedChanged(object sender, EventArgs e)
        {
            checkHL.Enabled = checkCGear.Checked;
            textTDelay5.Enabled = checkCGear.Checked;
            labelTDelay5.Enabled = checkCGear.Checked;
            if (!checkCGear.Checked)
                checkHL.Checked = false;

            CreateTimer();
            UpdateDisplay();
        }
        private void checkHL_CheckedChanged(object sender, EventArgs e)
        {
            textHLCal.Visible = checkHL.Checked;
            labelHL.Visible = checkHL.Checked;

            if (showWarning)
            {
                MessageBox.Show("Warning:\n\nThis mode assumes that you have already properly calibrated your cgear timer.\n\nThe update function will only update the Entralink calibration. This message will only appear once per startup.");
                showWarning = false;
            }

            CreateTimer();
            UpdateDisplay();
        }

        //Settings Events
        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.ShowDialog();
            color = dialog.Color;
        }
        private void textMin_TextChanged(object sender, EventArgs e)
        {
            UpdateMinimum();
        }
        private void numFreq_ValueChanged(object sender, EventArgs e)
        {
            UpdateAction();
        }
        private void sounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAction();
        }
        private void UpdateAction()
        {
            switch (comboMode.SelectedIndex)
            {
                case 0:
                    settings.Action = GetSoundAction();
                    break;
                case 1:
                    settings.Action = new VisualAction(color, labelTime);
                    break;
                case 2:
                    CountdownAction[] actions = { new VisualAction(color, labelTime), GetSoundAction() };
                    settings.Action = new MultiAction(actions);
                    break;
            }

            settings.Frequency = (Int32)(1000 / numFreq.Value);
            settings.ActionCount = (Int32)numBeeps.Value;
            UpdateMinimum();
        }
        private SoundAction GetSoundAction()
        {
            Stream sound = null;

            switch (comboSounds.SelectedIndex)
            {
                case 0:
                    sound = EonTimer.Properties.Resources.beep;
                    break;
                case 1:
                    sound = EonTimer.Properties.Resources.tick;
                    break;
                case 2:
                    sound = EonTimer.Properties.Resources.pop;
                    break;
                case 3:
                    sound = EonTimer.Properties.Resources.ding;
                    break;
            }

            return new SoundAction(sound, !isStartup);
        }
        private void UpdateMinimum()
        {
            try
            {
                settings.Minimum = Int32.Parse(textMin.Text);
            }
            catch (Exception)
            {
            }
        }

        //suggestion
        private void timingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabMenu.SelectedTab.Equals(tabGen5) && checkCGear.Checked)
                textTSec5.Text = ((DelayTimer)timer).SuggestSecond().ToString();

            if (tabMenu.SelectedTab.Equals(tabGen4))
                textTSec4.Text = ((DelayTimer)timer).SuggestSecond().ToString();
        }

        //start button
        private void start_Click(object sender, EventArgs e)
        {
            if (!timer.IsRunning())
            {
                timer.Run();
            }
            else
            {
                timer.CancelRun();
                UpdateDisplay();
            }
        }

        //Update Button Event
        private void update_Click(object sender, EventArgs e)
        {
            //try block in case any text boxes are empty
            try
            {
                Int32 update = 0;

                //pull update box
                if (tabMenu.SelectedTab.Equals(tabGen5))
                    update = Int32.Parse(textHit5.Text);
                else if (tabMenu.SelectedTab.Equals(tabGen4))
                    update = Int32.Parse(textHit4.Text);
                else if (tabMenu.SelectedTab.Equals(tabGen3))
                {
                    if (checkUnknownTarget.Checked)
                        update = Int32.Parse(textFrame.Text);
                    else
                        update = Int32.Parse(textHit3.Text);
                }

                //set update to the relative amount
                update = timer.UpdateCalibration(update);

                //update the calibration with the relative number
                if (tabMenu.SelectedTab.Equals(tabGen5))
                {
                    textCal.Text = (Int32.Parse(textCal.Text) + update).ToString();
                    textHit5.Text = "";
                }
                else if (tabMenu.SelectedTab.Equals(tabGen4))
                {
                    textCDelay.Text = (Int32.Parse(textCDelay.Text) + update).ToString();
                    textHit4.Text = "";
                }
                else if (tabMenu.SelectedTab.Equals(tabGen3))
                {
                    textLag.Text = (Int32.Parse(textLag.Text) + update).ToString();
                    textHit3.Text = "";
                }

            }
            catch (Exception)
            { }
        }

        //Save Button
        private void save_Click(object sender, EventArgs e)
        {
            save();
        }
        private void save()
        {
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("EonTimer");

            //Add Keys
            registryKey.SetValue("gen5cal", textCal.Text);
            registryKey.SetValue("hlcal", textHLCal.Text);
            registryKey.SetValue("gen4cd", textCDelay.Text);
            registryKey.SetValue("gen4cs", textCSec.Text);
            registryKey.SetValue("gen3factor", textFactor.Text);
            registryKey.SetValue("gen3lag", textLag.Text);
            registryKey.SetValue("gen3init", textInitial.Text);
            registryKey.SetValue("color", color.ToArgb());
            registryKey.SetValue("min", textMin.Text);
            registryKey.SetValue("beepNo", numBeeps.Value);
            registryKey.SetValue("beepFreq", numFreq.Value);
            registryKey.SetValue("sound", comboSounds.SelectedIndex);
            registryKey.SetValue("mode", comboMode.SelectedIndex);
            registryKey.SetValue("gen4TDelay", textTDelay4.Text);
            registryKey.SetValue("gen5TDelay", textTDelay5.Text);
            registryKey.SetValue("gen4TSec", textTSec4.Text);
            registryKey.SetValue("gen5TSec", textTSec5.Text);
            registryKey.SetValue("gen3TFrame", textFrame.Text);
            registryKey.SetValue("saveQuit", saveOnQuitToolStripMenuItem.Checked);
            registryKey.SetValue("askQuit", AskOnQuitToolStripMenuItem.Checked);
            registryKey.SetValue("onTop", alwaysOnTopToolStripMenuItem.Checked);

            registryKey.Close();

            MessageBox.Show("Saved.");
        }

        #region Standard buttons

        //Close Button
        private void pictureClose_MouseEnter(object sender, EventArgs e)
        {
            pictureClose.Image = closeImage[1];
        }
        private void pictureClose_MouseLeave(object sender, EventArgs e)
        {
            pictureClose.Image = closeImage[0];
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (timer != null)
                timer.CancelRun();
            this.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveOnQuitToolStripMenuItem.Checked)
                save();
            else if (AskOnQuitToolStripMenuItem.Checked)
            {
                DialogResult result = MessageBox.Show("Store input?", "Save values?", MessageBoxButtons.YesNoCancel);

                if (result == System.Windows.Forms.DialogResult.Yes)
                    save();
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        //Minimize Button
        private void pictureMinimize_MouseEnter(object sender, EventArgs e)
        {
            pictureMinimize.Image = minimizeImage[1];
        }
        private void pictureMinimize_MouseLeave(object sender, EventArgs e)
        {
            pictureMinimize.Image = minimizeImage[0];
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Help Button
        private void pictureHelp_MouseEnter(object sender, EventArgs e)
        {
            pictureHelp.Image = helpImage[1];
        }
        private void pictureHelp_MouseLeave(object sender, EventArgs e)
        {
            pictureHelp.Image = helpImage[0];
        }
        private void buttonSite_Click(object sender, EventArgs e)
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

        #endregion

        //Always on top
        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        //Unknown target check event
        private void checkUnknownTarget_CheckedChanged(object sender, EventArgs e)
        {
            textLag.Enabled = textInitial.Enabled = textHit3.Enabled = !checkUnknownTarget.Checked;
            CreateTimer();
            UpdateDisplay();
        }
        private void checkGBA_CheckedChanged(object sender, EventArgs e)
        {
            CreateTimer();
            UpdateDisplay();
        }

        //custom timer events
        private void buttonAddCustomStage_Click(object sender, EventArgs e)
        {
            Double stage;

            if (timer is CustomTimer && Double.TryParse(textCustom.Text, out stage))
            {
                customStages.Add(stage);
                ((CustomTimer)timer).Stages = customStages;
                listCustomStages.Items.Add(String.Format("Stage {0}: {1}" , (listCustomStages.Items.Count + 1).ToString("D2"), stage));
            }

            textCustom.Text = "";
            UpdateDisplay();
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (timer is CustomTimer)
            {
                customStages.Clear();
                ((CustomTimer)timer).Stages = customStages;
                listCustomStages.Items.Clear();
            }

            UpdateDisplay();
        }
        private void listCustomStages_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer is CustomTimer && e.KeyCode == Keys.Delete)
            {
                customStages.RemoveAt(listCustomStages.SelectedIndex);
                ((CustomTimer)timer).Stages = customStages;

                listCustomStages.Items.Clear();
                foreach (Double stage in customStages)
                    listCustomStages.Items.Add(String.Format("Stage {0}: {1}", (listCustomStages.Items.Count + 1).ToString("D2"), stage));
            }

            UpdateDisplay();
        }

        //gimmicks
        private void trackTransp_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackTransp.Value / 100.0;
        }
        private void miniToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            tabMenu.Visible = buttonUpdate.Visible = buttonSave.Visible = !miniToolStripMenuItem.Checked;

            if (miniToolStripMenuItem.Checked)
            {
                this.BackgroundImage = EonTimer.Properties.Resources.glaceonmini;
                this.Height = 148;
                this.Width = 246;
            }
            else
            {
                this.BackgroundImage = EonTimer.Properties.Resources.glaceonbg;
                this.Height = 293;
                this.Width = 392;
            }
        }

        #region movement handlers

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
