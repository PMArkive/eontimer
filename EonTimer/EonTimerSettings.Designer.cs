namespace EonTimer
{
    partial class EonTimerSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabMenuSettings = new System.Windows.Forms.TabControl();
            this.tabActions = new System.Windows.Forms.TabPage();
            this.labelActionCount = new System.Windows.Forms.Label();
            this.text_setting_count = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_setting_frequency = new System.Windows.Forms.TextBox();
            this.labelSound = new System.Windows.Forms.Label();
            this.combo_setting_sound = new System.Windows.Forms.ComboBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.panel_setting_color = new System.Windows.Forms.Panel();
            this.labelActionMode = new System.Windows.Forms.Label();
            this.combo_setting_actionmode = new System.Windows.Forms.ComboBox();
            this.tabAppSettings = new System.Windows.Forms.TabPage();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.trackOpacity = new System.Windows.Forms.TrackBar();
            this.labelOnExit = new System.Windows.Forms.Label();
            this.combo_setting_onexit = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.text_setting_refresh = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.check_setting_precisionmode = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDefault = new System.Windows.Forms.Button();
            this.combo_setting_console = new System.Windows.Forms.ComboBox();
            this.labelConsole = new System.Windows.Forms.Label();
            this.tabMenuSettings.SuspendLayout();
            this.tabActions.SuspendLayout();
            this.tabAppSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.text_setting_refresh)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(148, 183);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(68, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.Save);
            // 
            // tabMenuSettings
            // 
            this.tabMenuSettings.Controls.Add(this.tabActions);
            this.tabMenuSettings.Controls.Add(this.tabAppSettings);
            this.tabMenuSettings.Controls.Add(this.tabPage1);
            this.tabMenuSettings.Location = new System.Drawing.Point(-5, 5);
            this.tabMenuSettings.Multiline = true;
            this.tabMenuSettings.Name = "tabMenuSettings";
            this.tabMenuSettings.SelectedIndex = 0;
            this.tabMenuSettings.Size = new System.Drawing.Size(231, 176);
            this.tabMenuSettings.TabIndex = 1;
            // 
            // tabActions
            // 
            this.tabActions.Controls.Add(this.labelActionCount);
            this.tabActions.Controls.Add(this.text_setting_count);
            this.tabActions.Controls.Add(this.label1);
            this.tabActions.Controls.Add(this.text_setting_frequency);
            this.tabActions.Controls.Add(this.labelSound);
            this.tabActions.Controls.Add(this.combo_setting_sound);
            this.tabActions.Controls.Add(this.labelColor);
            this.tabActions.Controls.Add(this.panel_setting_color);
            this.tabActions.Controls.Add(this.labelActionMode);
            this.tabActions.Controls.Add(this.combo_setting_actionmode);
            this.tabActions.Location = new System.Drawing.Point(4, 22);
            this.tabActions.Name = "tabActions";
            this.tabActions.Padding = new System.Windows.Forms.Padding(3);
            this.tabActions.Size = new System.Drawing.Size(223, 150);
            this.tabActions.TabIndex = 0;
            this.tabActions.Text = "Actions";
            this.tabActions.UseVisualStyleBackColor = true;
            // 
            // labelActionCount
            // 
            this.labelActionCount.AutoSize = true;
            this.labelActionCount.Location = new System.Drawing.Point(9, 120);
            this.labelActionCount.Name = "labelActionCount";
            this.labelActionCount.Size = new System.Drawing.Size(68, 13);
            this.labelActionCount.TabIndex = 9;
            this.labelActionCount.Text = "Action Count";
            this.toolTip1.SetToolTip(this.labelActionCount, "The number of alerts during a countdown");
            // 
            // text_setting_count
            // 
            this.text_setting_count.Location = new System.Drawing.Point(103, 117);
            this.text_setting_count.Name = "text_setting_count";
            this.text_setting_count.Size = new System.Drawing.Size(113, 20);
            this.text_setting_count.TabIndex = 8;
            this.text_setting_count.TextChanged += new System.EventHandler(this.Change);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Action Interval";
            this.toolTip1.SetToolTip(this.label1, "The frequency of the actions in milliseconds");
            // 
            // text_setting_frequency
            // 
            this.text_setting_frequency.Location = new System.Drawing.Point(103, 90);
            this.text_setting_frequency.Name = "text_setting_frequency";
            this.text_setting_frequency.Size = new System.Drawing.Size(113, 20);
            this.text_setting_frequency.TabIndex = 6;
            this.text_setting_frequency.TextChanged += new System.EventHandler(this.Change);
            this.text_setting_frequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // labelSound
            // 
            this.labelSound.AutoSize = true;
            this.labelSound.Location = new System.Drawing.Point(6, 65);
            this.labelSound.Name = "labelSound";
            this.labelSound.Size = new System.Drawing.Size(38, 13);
            this.labelSound.TabIndex = 5;
            this.labelSound.Text = "Sound";
            this.toolTip1.SetToolTip(this.labelSound, "Sets sound when using Audio or A/V modes");
            // 
            // combo_setting_sound
            // 
            this.combo_setting_sound.FormattingEnabled = true;
            this.combo_setting_sound.Location = new System.Drawing.Point(103, 62);
            this.combo_setting_sound.Name = "combo_setting_sound";
            this.combo_setting_sound.Size = new System.Drawing.Size(113, 21);
            this.combo_setting_sound.TabIndex = 4;
            this.combo_setting_sound.SelectedIndexChanged += new System.EventHandler(this.Change);
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(6, 40);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(64, 13);
            this.labelColor.TabIndex = 3;
            this.labelColor.Text = "Action Color";
            this.toolTip1.SetToolTip(this.labelColor, "Color to flash for visual or A/V modes");
            // 
            // panel_setting_color
            // 
            this.panel_setting_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_setting_color.Location = new System.Drawing.Point(103, 34);
            this.panel_setting_color.Name = "panel_setting_color";
            this.panel_setting_color.Size = new System.Drawing.Size(114, 21);
            this.panel_setting_color.TabIndex = 2;
            this.panel_setting_color.Click += new System.EventHandler(this.SelectColor);
            // 
            // labelActionMode
            // 
            this.labelActionMode.AutoSize = true;
            this.labelActionMode.Location = new System.Drawing.Point(6, 9);
            this.labelActionMode.Name = "labelActionMode";
            this.labelActionMode.Size = new System.Drawing.Size(91, 13);
            this.labelActionMode.TabIndex = 1;
            this.labelActionMode.Text = "Countdown Mode";
            this.toolTip1.SetToolTip(this.labelActionMode, "Method to use for countdown notifications");
            // 
            // combo_setting_actionmode
            // 
            this.combo_setting_actionmode.FormattingEnabled = true;
            this.combo_setting_actionmode.Location = new System.Drawing.Point(103, 6);
            this.combo_setting_actionmode.Name = "combo_setting_actionmode";
            this.combo_setting_actionmode.Size = new System.Drawing.Size(114, 21);
            this.combo_setting_actionmode.TabIndex = 0;
            this.combo_setting_actionmode.SelectedIndexChanged += new System.EventHandler(this.Change);
            // 
            // tabAppSettings
            // 
            this.tabAppSettings.Controls.Add(this.labelOpacity);
            this.tabAppSettings.Controls.Add(this.trackOpacity);
            this.tabAppSettings.Controls.Add(this.labelOnExit);
            this.tabAppSettings.Controls.Add(this.combo_setting_onexit);
            this.tabAppSettings.Location = new System.Drawing.Point(4, 22);
            this.tabAppSettings.Name = "tabAppSettings";
            this.tabAppSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppSettings.Size = new System.Drawing.Size(223, 150);
            this.tabAppSettings.TabIndex = 1;
            this.tabAppSettings.Text = "Application";
            this.tabAppSettings.UseVisualStyleBackColor = true;
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(6, 37);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(43, 13);
            this.labelOpacity.TabIndex = 3;
            this.labelOpacity.Text = "Opacity";
            // 
            // trackOpacity
            // 
            this.trackOpacity.Location = new System.Drawing.Point(96, 34);
            this.trackOpacity.Maximum = 100;
            this.trackOpacity.Minimum = 20;
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Size = new System.Drawing.Size(120, 45);
            this.trackOpacity.SmallChange = 2;
            this.trackOpacity.TabIndex = 2;
            this.trackOpacity.TickFrequency = 10;
            this.trackOpacity.Value = 20;
            // 
            // labelOnExit
            // 
            this.labelOnExit.AutoSize = true;
            this.labelOnExit.Location = new System.Drawing.Point(6, 9);
            this.labelOnExit.Name = "labelOnExit";
            this.labelOnExit.Size = new System.Drawing.Size(41, 13);
            this.labelOnExit.TabIndex = 1;
            this.labelOnExit.Text = "On Exit";
            // 
            // combo_setting_onexit
            // 
            this.combo_setting_onexit.FormattingEnabled = true;
            this.combo_setting_onexit.Items.AddRange(new object[] {
            "Ask To Save",
            "Auto-Save",
            "Do Nothing"});
            this.combo_setting_onexit.Location = new System.Drawing.Point(96, 6);
            this.combo_setting_onexit.Name = "combo_setting_onexit";
            this.combo_setting_onexit.Size = new System.Drawing.Size(121, 21);
            this.combo_setting_onexit.TabIndex = 0;
            this.combo_setting_onexit.SelectedIndexChanged += new System.EventHandler(this.Change);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelConsole);
            this.tabPage1.Controls.Add(this.combo_setting_console);
            this.tabPage1.Controls.Add(this.text_setting_refresh);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.check_setting_precisionmode);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(223, 150);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Timer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // text_setting_refresh
            // 
            this.text_setting_refresh.Location = new System.Drawing.Point(101, 124);
            this.text_setting_refresh.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.text_setting_refresh.Name = "text_setting_refresh";
            this.text_setting_refresh.Size = new System.Drawing.Size(116, 20);
            this.text_setting_refresh.TabIndex = 2;
            this.toolTip1.SetToolTip(this.text_setting_refresh, "This is an advanced setting that controls how");
            this.text_setting_refresh.ValueChanged += new System.EventHandler(this.Change);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Refresh Interval";
            this.toolTip1.SetToolTip(this.label2, "This is an advanced setting that controls how\r\noften the countdown is refreshed. " +
        "Higher values \r\nincrease performance at the cost of accuracy.");
            // 
            // check_setting_precisionmode
            // 
            this.check_setting_precisionmode.AutoSize = true;
            this.check_setting_precisionmode.Location = new System.Drawing.Point(13, 104);
            this.check_setting_precisionmode.Name = "check_setting_precisionmode";
            this.check_setting_precisionmode.Size = new System.Drawing.Size(151, 17);
            this.check_setting_precisionmode.TabIndex = 0;
            this.check_setting_precisionmode.Text = "Precision Calibration Mode";
            this.toolTip1.SetToolTip(this.check_setting_precisionmode, "This is an advanced setting that increases \r\nthe precision of timer calibration. " +
        "See the\r\nhelp thread for info.");
            this.check_setting_precisionmode.UseVisualStyleBackColor = true;
            this.check_setting_precisionmode.CheckedChanged += new System.EventHandler(this.Change);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(5, 183);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(68, 23);
            this.buttonDefault.TabIndex = 3;
            this.buttonDefault.Text = "Defaults";
            this.buttonDefault.UseVisualStyleBackColor = true;
            // 
            // combo_setting_console
            // 
            this.combo_setting_console.FormattingEnabled = true;
            this.combo_setting_console.Location = new System.Drawing.Point(101, 6);
            this.combo_setting_console.Name = "combo_setting_console";
            this.combo_setting_console.Size = new System.Drawing.Size(116, 21);
            this.combo_setting_console.TabIndex = 3;
            this.combo_setting_console.SelectedIndexChanged += new System.EventHandler(this.Change);
            // 
            // labelConsole
            // 
            this.labelConsole.AutoSize = true;
            this.labelConsole.Location = new System.Drawing.Point(6, 9);
            this.labelConsole.Name = "labelConsole";
            this.labelConsole.Size = new System.Drawing.Size(45, 13);
            this.labelConsole.TabIndex = 4;
            this.labelConsole.Text = "Console";
            // 
            // EonTimerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(221, 211);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.tabMenuSettings);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EonTimerSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.tabMenuSettings.ResumeLayout(false);
            this.tabActions.ResumeLayout(false);
            this.tabActions.PerformLayout();
            this.tabAppSettings.ResumeLayout(false);
            this.tabAppSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.text_setting_refresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TabControl tabMenuSettings;
        private System.Windows.Forms.TabPage tabActions;
        private System.Windows.Forms.TabPage tabAppSettings;
        private System.Windows.Forms.Label labelActionMode;
        private System.Windows.Forms.ComboBox combo_setting_actionmode;
        private System.Windows.Forms.Panel panel_setting_color;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox combo_setting_sound;
        private System.Windows.Forms.Label labelSound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_setting_frequency;
        private System.Windows.Forms.TextBox text_setting_count;
        private System.Windows.Forms.Label labelActionCount;
        private System.Windows.Forms.Label labelOnExit;
        private System.Windows.Forms.ComboBox combo_setting_onexit;
        private System.Windows.Forms.TrackBar trackOpacity;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox check_setting_precisionmode;
        private System.Windows.Forms.NumericUpDown text_setting_refresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_setting_console;
        private System.Windows.Forms.Label labelConsole;
    }
}