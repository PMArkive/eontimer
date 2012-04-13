namespace EonTimer
{
    partial class MainTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTimer));
            this.displayCurrent = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.displayNextStage = new System.Windows.Forms.Label();
            this.labelMinsLabel = new System.Windows.Forms.Label();
            this.displayMinsBefore = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.pictureClose = new System.Windows.Forms.PictureBox();
            this.pictureMinimize = new System.Windows.Forms.PictureBox();
            this.tabGen3 = new System.Windows.Forms.TabPage();
            this.labelMode3 = new System.Windows.Forms.Label();
            this.combo_mode_3 = new System.Windows.Forms.ComboBox();
            this.labelHit3 = new System.Windows.Forms.Label();
            this.text_hit_3 = new System.Windows.Forms.TextBox();
            this.text_calibration_lag_3 = new System.Windows.Forms.TextBox();
            this.text_calibration_factor_3 = new System.Windows.Forms.TextBox();
            this.text_target_frame_3 = new System.Windows.Forms.TextBox();
            this.text_target_initial_3 = new System.Windows.Forms.TextBox();
            this.labelFrame = new System.Windows.Forms.Label();
            this.labelInitial = new System.Windows.Forms.Label();
            this.labelLag = new System.Windows.Forms.Label();
            this.labelFactor = new System.Windows.Forms.Label();
            this.tabGen4 = new System.Windows.Forms.TabPage();
            this.labelMode4 = new System.Windows.Forms.Label();
            this.combo_mode_4 = new System.Windows.Forms.ComboBox();
            this.text_hit_4 = new System.Windows.Forms.TextBox();
            this.text_target_second_4 = new System.Windows.Forms.TextBox();
            this.text_target_delay_4 = new System.Windows.Forms.TextBox();
            this.text_calibration_second_4 = new System.Windows.Forms.TextBox();
            this.text_calibration_delay_4 = new System.Windows.Forms.TextBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.labelTSec = new System.Windows.Forms.Label();
            this.labelTDelay = new System.Windows.Forms.Label();
            this.labelCSec = new System.Windows.Forms.Label();
            this.labelCDelay = new System.Windows.Forms.Label();
            this.tabGen5 = new System.Windows.Forms.TabPage();
            this.labelELSec = new System.Windows.Forms.Label();
            this.text_target_standard_5 = new System.Windows.Forms.TextBox();
            this.labelMode5 = new System.Windows.Forms.Label();
            this.combo_mode_5 = new System.Windows.Forms.ComboBox();
            this.labelHL = new System.Windows.Forms.Label();
            this.text_calibration_entralink_5 = new System.Windows.Forms.TextBox();
            this.text_hit_5 = new System.Windows.Forms.TextBox();
            this.text_target_second_5 = new System.Windows.Forms.TextBox();
            this.text_target_delay_5 = new System.Windows.Forms.TextBox();
            this.text_calibration_5 = new System.Windows.Forms.TextBox();
            this.labelDelayHit5 = new System.Windows.Forms.Label();
            this.labelTSec5 = new System.Windows.Forms.Label();
            this.labelTDelay5 = new System.Windows.Forms.Label();
            this.labelCalibration = new System.Windows.Forms.Label();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabCustom = new System.Windows.Forms.TabPage();
            this.tabImages = new System.Windows.Forms.ImageList(this.components);
            this.pictureMini = new System.Windows.Forms.PictureBox();
            this.picturePin = new System.Windows.Forms.PictureBox();
            this.pictureSettings = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMinimize)).BeginInit();
            this.tabGen3.SuspendLayout();
            this.tabGen4.SuspendLayout();
            this.tabGen5.SuspendLayout();
            this.tabMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // displayCurrent
            // 
            this.displayCurrent.AutoSize = true;
            this.displayCurrent.BackColor = System.Drawing.Color.Transparent;
            this.displayCurrent.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayCurrent.Location = new System.Drawing.Point(2, 19);
            this.displayCurrent.MinimumSize = new System.Drawing.Size(193, 0);
            this.displayCurrent.Name = "displayCurrent";
            this.displayCurrent.Size = new System.Drawing.Size(193, 73);
            this.displayCurrent.TabIndex = 0;
            this.displayCurrent.Text = "00:00";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(326, 262);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(60, 24);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.Start);
            // 
            // displayNextStage
            // 
            this.displayNextStage.AutoSize = true;
            this.displayNextStage.BackColor = System.Drawing.Color.Transparent;
            this.displayNextStage.Location = new System.Drawing.Point(12, 107);
            this.displayNextStage.Name = "displayNextStage";
            this.displayNextStage.Size = new System.Drawing.Size(0, 13);
            this.displayNextStage.TabIndex = 3;
            // 
            // labelMinsLabel
            // 
            this.labelMinsLabel.AutoSize = true;
            this.labelMinsLabel.BackColor = System.Drawing.Color.Transparent;
            this.labelMinsLabel.Location = new System.Drawing.Point(12, 93);
            this.labelMinsLabel.Name = "labelMinsLabel";
            this.labelMinsLabel.Size = new System.Drawing.Size(115, 13);
            this.labelMinsLabel.TabIndex = 5;
            this.labelMinsLabel.Text = "Minutes Before Target:";
            // 
            // displayMinsBefore
            // 
            this.displayMinsBefore.AutoSize = true;
            this.displayMinsBefore.BackColor = System.Drawing.Color.Transparent;
            this.displayMinsBefore.ForeColor = System.Drawing.Color.Maroon;
            this.displayMinsBefore.Location = new System.Drawing.Point(127, 94);
            this.displayMinsBefore.Name = "displayMinsBefore";
            this.displayMinsBefore.Size = new System.Drawing.Size(0, 13);
            this.displayMinsBefore.TabIndex = 6;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Location = new System.Drawing.Point(196, 262);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(60, 24);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(262, 262);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(58, 24);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // pictureClose
            // 
            this.pictureClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureClose.BackColor = System.Drawing.Color.Transparent;
            this.pictureClose.Location = new System.Drawing.Point(372, 5);
            this.pictureClose.Name = "pictureClose";
            this.pictureClose.Size = new System.Drawing.Size(13, 13);
            this.pictureClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureClose.TabIndex = 12;
            this.pictureClose.TabStop = false;
            this.pictureClose.Click += new System.EventHandler(this.Close);
            this.pictureClose.MouseEnter += new System.EventHandler(this.Close_MouseEnter);
            this.pictureClose.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
            // 
            // pictureMinimize
            // 
            this.pictureMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureMinimize.BackColor = System.Drawing.Color.Transparent;
            this.pictureMinimize.Location = new System.Drawing.Point(353, 4);
            this.pictureMinimize.Name = "pictureMinimize";
            this.pictureMinimize.Size = new System.Drawing.Size(13, 13);
            this.pictureMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMinimize.TabIndex = 13;
            this.pictureMinimize.TabStop = false;
            this.pictureMinimize.Click += new System.EventHandler(this.Minimize);
            this.pictureMinimize.MouseEnter += new System.EventHandler(this.Minimize_MouseEnter);
            this.pictureMinimize.MouseLeave += new System.EventHandler(this.Minimize_MouseLeave);
            // 
            // tabGen3
            // 
            this.tabGen3.BackColor = System.Drawing.Color.GhostWhite;
            this.tabGen3.BackgroundImage = global::EonTimer.Properties.Resources.TabGlac;
            this.tabGen3.Controls.Add(this.labelMode3);
            this.tabGen3.Controls.Add(this.combo_mode_3);
            this.tabGen3.Controls.Add(this.labelHit3);
            this.tabGen3.Controls.Add(this.text_hit_3);
            this.tabGen3.Controls.Add(this.text_calibration_lag_3);
            this.tabGen3.Controls.Add(this.text_calibration_factor_3);
            this.tabGen3.Controls.Add(this.text_target_frame_3);
            this.tabGen3.Controls.Add(this.text_target_initial_3);
            this.tabGen3.Controls.Add(this.labelFrame);
            this.tabGen3.Controls.Add(this.labelInitial);
            this.tabGen3.Controls.Add(this.labelLag);
            this.tabGen3.Controls.Add(this.labelFactor);
            this.tabGen3.ImageKey = "3.png";
            this.tabGen3.Location = new System.Drawing.Point(4, 20);
            this.tabGen3.Name = "tabGen3";
            this.tabGen3.Padding = new System.Windows.Forms.Padding(3);
            this.tabGen3.Size = new System.Drawing.Size(177, 213);
            this.tabGen3.TabIndex = 2;
            // 
            // labelMode3
            // 
            this.labelMode3.AutoSize = true;
            this.labelMode3.BackColor = System.Drawing.Color.Transparent;
            this.labelMode3.Location = new System.Drawing.Point(6, 10);
            this.labelMode3.Name = "labelMode3";
            this.labelMode3.Size = new System.Drawing.Size(34, 13);
            this.labelMode3.TabIndex = 11;
            this.labelMode3.Text = "Mode";
            // 
            // combo_mode_3
            // 
            this.combo_mode_3.FormattingEnabled = true;
            this.combo_mode_3.Location = new System.Drawing.Point(46, 6);
            this.combo_mode_3.Name = "combo_mode_3";
            this.combo_mode_3.Size = new System.Drawing.Size(125, 21);
            this.combo_mode_3.TabIndex = 10;
            this.combo_mode_3.SelectedIndexChanged += new System.EventHandler(this.UpdateTimer);
            // 
            // labelHit3
            // 
            this.labelHit3.AutoSize = true;
            this.labelHit3.BackColor = System.Drawing.Color.Transparent;
            this.labelHit3.Location = new System.Drawing.Point(8, 188);
            this.labelHit3.Name = "labelHit3";
            this.labelHit3.Size = new System.Drawing.Size(52, 13);
            this.labelHit3.TabIndex = 9;
            this.labelHit3.Text = "Frame Hit";
            // 
            // text_hit_3
            // 
            this.text_hit_3.Location = new System.Drawing.Point(96, 185);
            this.text_hit_3.Name = "text_hit_3";
            this.text_hit_3.Size = new System.Drawing.Size(75, 20);
            this.text_hit_3.TabIndex = 8;
            this.text_hit_3.TextChanged += new System.EventHandler(this.UpdateTimer);
            // 
            // text_calibration_lag_3
            // 
            this.text_calibration_lag_3.Location = new System.Drawing.Point(130, 33);
            this.text_calibration_lag_3.Name = "text_calibration_lag_3";
            this.text_calibration_lag_3.Size = new System.Drawing.Size(41, 20);
            this.text_calibration_lag_3.TabIndex = 1;
            this.text_calibration_lag_3.TextChanged += new System.EventHandler(this.UpdateTimer);
            this.text_calibration_lag_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_calibration_factor_3
            // 
            this.text_calibration_factor_3.Enabled = false;
            this.text_calibration_factor_3.Location = new System.Drawing.Point(47, 33);
            this.text_calibration_factor_3.Name = "text_calibration_factor_3";
            this.text_calibration_factor_3.Size = new System.Drawing.Size(41, 20);
            this.text_calibration_factor_3.TabIndex = 0;
            this.text_calibration_factor_3.TextChanged += new System.EventHandler(this.UpdateTimer);
            // 
            // text_target_frame_3
            // 
            this.text_target_frame_3.Location = new System.Drawing.Point(96, 86);
            this.text_target_frame_3.Name = "text_target_frame_3";
            this.text_target_frame_3.Size = new System.Drawing.Size(75, 20);
            this.text_target_frame_3.TabIndex = 3;
            this.text_target_frame_3.TextChanged += new System.EventHandler(this.UpdateTimer);
            this.text_target_frame_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_target_initial_3
            // 
            this.text_target_initial_3.Location = new System.Drawing.Point(96, 60);
            this.text_target_initial_3.Name = "text_target_initial_3";
            this.text_target_initial_3.Size = new System.Drawing.Size(75, 20);
            this.text_target_initial_3.TabIndex = 2;
            this.text_target_initial_3.TextChanged += new System.EventHandler(this.UpdateTimer);
            this.text_target_initial_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // labelFrame
            // 
            this.labelFrame.AutoSize = true;
            this.labelFrame.BackColor = System.Drawing.Color.Transparent;
            this.labelFrame.Location = new System.Drawing.Point(6, 89);
            this.labelFrame.Name = "labelFrame";
            this.labelFrame.Size = new System.Drawing.Size(70, 13);
            this.labelFrame.TabIndex = 7;
            this.labelFrame.Text = "Target Frame";
            // 
            // labelInitial
            // 
            this.labelInitial.AutoSize = true;
            this.labelInitial.BackColor = System.Drawing.Color.Transparent;
            this.labelInitial.Location = new System.Drawing.Point(6, 63);
            this.labelInitial.Name = "labelInitial";
            this.labelInitial.Size = new System.Drawing.Size(52, 13);
            this.labelInitial.TabIndex = 6;
            this.labelInitial.Text = "Pre-Timer";
            // 
            // labelLag
            // 
            this.labelLag.AutoSize = true;
            this.labelLag.BackColor = System.Drawing.Color.Transparent;
            this.labelLag.Location = new System.Drawing.Point(99, 36);
            this.labelLag.Name = "labelLag";
            this.labelLag.Size = new System.Drawing.Size(25, 13);
            this.labelLag.TabIndex = 5;
            this.labelLag.Text = "Lag";
            // 
            // labelFactor
            // 
            this.labelFactor.AutoSize = true;
            this.labelFactor.BackColor = System.Drawing.Color.Transparent;
            this.labelFactor.Enabled = false;
            this.labelFactor.Location = new System.Drawing.Point(6, 36);
            this.labelFactor.Name = "labelFactor";
            this.labelFactor.Size = new System.Drawing.Size(37, 13);
            this.labelFactor.TabIndex = 3;
            this.labelFactor.Text = "Factor";
            // 
            // tabGen4
            // 
            this.tabGen4.BackColor = System.Drawing.Color.GhostWhite;
            this.tabGen4.BackgroundImage = global::EonTimer.Properties.Resources.TabGlac;
            this.tabGen4.Controls.Add(this.labelMode4);
            this.tabGen4.Controls.Add(this.combo_mode_4);
            this.tabGen4.Controls.Add(this.text_hit_4);
            this.tabGen4.Controls.Add(this.text_target_second_4);
            this.tabGen4.Controls.Add(this.text_target_delay_4);
            this.tabGen4.Controls.Add(this.text_calibration_second_4);
            this.tabGen4.Controls.Add(this.text_calibration_delay_4);
            this.tabGen4.Controls.Add(this.labelDelay);
            this.tabGen4.Controls.Add(this.labelTSec);
            this.tabGen4.Controls.Add(this.labelTDelay);
            this.tabGen4.Controls.Add(this.labelCSec);
            this.tabGen4.Controls.Add(this.labelCDelay);
            this.tabGen4.ImageKey = "4.png";
            this.tabGen4.Location = new System.Drawing.Point(4, 20);
            this.tabGen4.Name = "tabGen4";
            this.tabGen4.Padding = new System.Windows.Forms.Padding(3);
            this.tabGen4.Size = new System.Drawing.Size(177, 213);
            this.tabGen4.TabIndex = 0;
            // 
            // labelMode4
            // 
            this.labelMode4.AutoSize = true;
            this.labelMode4.BackColor = System.Drawing.Color.Transparent;
            this.labelMode4.Location = new System.Drawing.Point(6, 10);
            this.labelMode4.Name = "labelMode4";
            this.labelMode4.Size = new System.Drawing.Size(34, 13);
            this.labelMode4.TabIndex = 11;
            this.labelMode4.Text = "Mode";
            // 
            // combo_mode_4
            // 
            this.combo_mode_4.FormattingEnabled = true;
            this.combo_mode_4.Location = new System.Drawing.Point(46, 7);
            this.combo_mode_4.Name = "combo_mode_4";
            this.combo_mode_4.Size = new System.Drawing.Size(125, 21);
            this.combo_mode_4.TabIndex = 10;
            this.combo_mode_4.SelectedIndexChanged += new System.EventHandler(this.UpdateTimer);
            // 
            // text_hit_4
            // 
            this.text_hit_4.Location = new System.Drawing.Point(96, 185);
            this.text_hit_4.Name = "text_hit_4";
            this.text_hit_4.Size = new System.Drawing.Size(75, 20);
            this.text_hit_4.TabIndex = 9;
            this.text_hit_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_target_second_4
            // 
            this.text_target_second_4.Location = new System.Drawing.Point(96, 112);
            this.text_target_second_4.Name = "text_target_second_4";
            this.text_target_second_4.Size = new System.Drawing.Size(75, 20);
            this.text_target_second_4.TabIndex = 7;
            this.text_target_second_4.Text = "50";
            this.text_target_second_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_target_delay_4
            // 
            this.text_target_delay_4.Location = new System.Drawing.Point(96, 86);
            this.text_target_delay_4.Name = "text_target_delay_4";
            this.text_target_delay_4.Size = new System.Drawing.Size(75, 20);
            this.text_target_delay_4.TabIndex = 5;
            this.text_target_delay_4.Text = "600";
            this.text_target_delay_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_calibration_second_4
            // 
            this.text_calibration_second_4.Location = new System.Drawing.Point(96, 60);
            this.text_calibration_second_4.Name = "text_calibration_second_4";
            this.text_calibration_second_4.Size = new System.Drawing.Size(75, 20);
            this.text_calibration_second_4.TabIndex = 3;
            this.text_calibration_second_4.Text = "14";
            this.text_calibration_second_4.TextChanged += new System.EventHandler(this.UpdateTimer);
            this.text_calibration_second_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_calibration_delay_4
            // 
            this.text_calibration_delay_4.Location = new System.Drawing.Point(96, 34);
            this.text_calibration_delay_4.Name = "text_calibration_delay_4";
            this.text_calibration_delay_4.Size = new System.Drawing.Size(75, 20);
            this.text_calibration_delay_4.TabIndex = 1;
            this.text_calibration_delay_4.Text = "500";
            this.text_calibration_delay_4.TextChanged += new System.EventHandler(this.UpdateTimer);
            this.text_calibration_delay_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.BackColor = System.Drawing.Color.Transparent;
            this.labelDelay.Location = new System.Drawing.Point(8, 188);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(50, 13);
            this.labelDelay.TabIndex = 8;
            this.labelDelay.Text = "Delay Hit";
            // 
            // labelTSec
            // 
            this.labelTSec.AutoSize = true;
            this.labelTSec.BackColor = System.Drawing.Color.Transparent;
            this.labelTSec.Location = new System.Drawing.Point(6, 115);
            this.labelTSec.Name = "labelTSec";
            this.labelTSec.Size = new System.Drawing.Size(63, 13);
            this.labelTSec.TabIndex = 6;
            this.labelTSec.Text = "Target Sec.";
            // 
            // labelTDelay
            // 
            this.labelTDelay.AutoSize = true;
            this.labelTDelay.BackColor = System.Drawing.Color.Transparent;
            this.labelTDelay.Location = new System.Drawing.Point(6, 89);
            this.labelTDelay.Name = "labelTDelay";
            this.labelTDelay.Size = new System.Drawing.Size(68, 13);
            this.labelTDelay.TabIndex = 4;
            this.labelTDelay.Text = "Target Delay";
            // 
            // labelCSec
            // 
            this.labelCSec.AutoSize = true;
            this.labelCSec.BackColor = System.Drawing.Color.Transparent;
            this.labelCSec.Location = new System.Drawing.Point(6, 63);
            this.labelCSec.Name = "labelCSec";
            this.labelCSec.Size = new System.Drawing.Size(79, 13);
            this.labelCSec.TabIndex = 2;
            this.labelCSec.Text = "Calibrated Sec.";
            // 
            // labelCDelay
            // 
            this.labelCDelay.AutoSize = true;
            this.labelCDelay.BackColor = System.Drawing.Color.Transparent;
            this.labelCDelay.Location = new System.Drawing.Point(6, 37);
            this.labelCDelay.Name = "labelCDelay";
            this.labelCDelay.Size = new System.Drawing.Size(84, 13);
            this.labelCDelay.TabIndex = 0;
            this.labelCDelay.Text = "Calibrated Delay";
            // 
            // tabGen5
            // 
            this.tabGen5.BackColor = System.Drawing.Color.GhostWhite;
            this.tabGen5.BackgroundImage = global::EonTimer.Properties.Resources.TabGlac;
            this.tabGen5.Controls.Add(this.labelELSec);
            this.tabGen5.Controls.Add(this.text_target_standard_5);
            this.tabGen5.Controls.Add(this.labelMode5);
            this.tabGen5.Controls.Add(this.combo_mode_5);
            this.tabGen5.Controls.Add(this.labelHL);
            this.tabGen5.Controls.Add(this.text_calibration_entralink_5);
            this.tabGen5.Controls.Add(this.text_hit_5);
            this.tabGen5.Controls.Add(this.text_target_second_5);
            this.tabGen5.Controls.Add(this.text_target_delay_5);
            this.tabGen5.Controls.Add(this.text_calibration_5);
            this.tabGen5.Controls.Add(this.labelDelayHit5);
            this.tabGen5.Controls.Add(this.labelTSec5);
            this.tabGen5.Controls.Add(this.labelTDelay5);
            this.tabGen5.Controls.Add(this.labelCalibration);
            this.tabGen5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGen5.ImageKey = "5.png";
            this.tabGen5.Location = new System.Drawing.Point(4, 20);
            this.tabGen5.Name = "tabGen5";
            this.tabGen5.Padding = new System.Windows.Forms.Padding(3);
            this.tabGen5.Size = new System.Drawing.Size(177, 213);
            this.tabGen5.TabIndex = 1;
            // 
            // labelELSec
            // 
            this.labelELSec.AutoSize = true;
            this.labelELSec.BackColor = System.Drawing.Color.Transparent;
            this.labelELSec.Location = new System.Drawing.Point(6, 151);
            this.labelELSec.Name = "labelELSec";
            this.labelELSec.Size = new System.Drawing.Size(84, 13);
            this.labelELSec.TabIndex = 15;
            this.labelELSec.Text = "Standard Target";
            this.labelELSec.Visible = false;
            // 
            // text_target_standard_5
            // 
            this.text_target_standard_5.Location = new System.Drawing.Point(96, 148);
            this.text_target_standard_5.Name = "text_target_standard_5";
            this.text_target_standard_5.Size = new System.Drawing.Size(75, 20);
            this.text_target_standard_5.TabIndex = 14;
            this.text_target_standard_5.Visible = false;
            // 
            // labelMode5
            // 
            this.labelMode5.AutoSize = true;
            this.labelMode5.BackColor = System.Drawing.Color.Transparent;
            this.labelMode5.Location = new System.Drawing.Point(6, 10);
            this.labelMode5.Name = "labelMode5";
            this.labelMode5.Size = new System.Drawing.Size(34, 13);
            this.labelMode5.TabIndex = 13;
            this.labelMode5.Text = "Mode";
            // 
            // combo_mode_5
            // 
            this.combo_mode_5.FormattingEnabled = true;
            this.combo_mode_5.Location = new System.Drawing.Point(46, 7);
            this.combo_mode_5.Name = "combo_mode_5";
            this.combo_mode_5.Size = new System.Drawing.Size(125, 21);
            this.combo_mode_5.TabIndex = 12;
            // 
            // labelHL
            // 
            this.labelHL.AutoSize = true;
            this.labelHL.BackColor = System.Drawing.Color.Transparent;
            this.labelHL.Location = new System.Drawing.Point(6, 125);
            this.labelHL.Name = "labelHL";
            this.labelHL.Size = new System.Drawing.Size(72, 13);
            this.labelHL.TabIndex = 11;
            this.labelHL.Text = "EL Calibration";
            this.labelHL.Visible = false;
            // 
            // text_calibration_entralink_5
            // 
            this.text_calibration_entralink_5.Location = new System.Drawing.Point(96, 122);
            this.text_calibration_entralink_5.Name = "text_calibration_entralink_5";
            this.text_calibration_entralink_5.Size = new System.Drawing.Size(75, 20);
            this.text_calibration_entralink_5.TabIndex = 10;
            this.text_calibration_entralink_5.Visible = false;
            this.text_calibration_entralink_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_hit_5
            // 
            this.text_hit_5.Location = new System.Drawing.Point(96, 185);
            this.text_hit_5.Name = "text_hit_5";
            this.text_hit_5.Size = new System.Drawing.Size(75, 20);
            this.text_hit_5.TabIndex = 6;
            this.text_hit_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_target_second_5
            // 
            this.text_target_second_5.Location = new System.Drawing.Point(96, 86);
            this.text_target_second_5.Name = "text_target_second_5";
            this.text_target_second_5.Size = new System.Drawing.Size(75, 20);
            this.text_target_second_5.TabIndex = 4;
            this.text_target_second_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_target_delay_5
            // 
            this.text_target_delay_5.Location = new System.Drawing.Point(96, 60);
            this.text_target_delay_5.Name = "text_target_delay_5";
            this.text_target_delay_5.Size = new System.Drawing.Size(75, 20);
            this.text_target_delay_5.TabIndex = 2;
            this.text_target_delay_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // text_calibration_5
            // 
            this.text_calibration_5.Location = new System.Drawing.Point(96, 34);
            this.text_calibration_5.Name = "text_calibration_5";
            this.text_calibration_5.Size = new System.Drawing.Size(75, 20);
            this.text_calibration_5.TabIndex = 0;
            this.text_calibration_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericKeyPress);
            // 
            // labelDelayHit5
            // 
            this.labelDelayHit5.AutoSize = true;
            this.labelDelayHit5.BackColor = System.Drawing.Color.Transparent;
            this.labelDelayHit5.Location = new System.Drawing.Point(6, 188);
            this.labelDelayHit5.Name = "labelDelayHit5";
            this.labelDelayHit5.Size = new System.Drawing.Size(50, 13);
            this.labelDelayHit5.TabIndex = 7;
            this.labelDelayHit5.Text = "Delay Hit";
            // 
            // labelTSec5
            // 
            this.labelTSec5.AutoSize = true;
            this.labelTSec5.BackColor = System.Drawing.Color.Transparent;
            this.labelTSec5.Location = new System.Drawing.Point(6, 89);
            this.labelTSec5.Name = "labelTSec5";
            this.labelTSec5.Size = new System.Drawing.Size(83, 13);
            this.labelTSec5.TabIndex = 5;
            this.labelTSec5.Text = "Target Seconds";
            // 
            // labelTDelay5
            // 
            this.labelTDelay5.AutoSize = true;
            this.labelTDelay5.BackColor = System.Drawing.Color.Transparent;
            this.labelTDelay5.Location = new System.Drawing.Point(6, 63);
            this.labelTDelay5.Name = "labelTDelay5";
            this.labelTDelay5.Size = new System.Drawing.Size(68, 13);
            this.labelTDelay5.TabIndex = 3;
            this.labelTDelay5.Text = "Target Delay";
            // 
            // labelCalibration
            // 
            this.labelCalibration.AutoSize = true;
            this.labelCalibration.BackColor = System.Drawing.Color.Transparent;
            this.labelCalibration.Location = new System.Drawing.Point(6, 37);
            this.labelCalibration.Name = "labelCalibration";
            this.labelCalibration.Size = new System.Drawing.Size(56, 13);
            this.labelCalibration.TabIndex = 1;
            this.labelCalibration.Text = "Calibration";
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tabMenu.Controls.Add(this.tabGen5);
            this.tabMenu.Controls.Add(this.tabGen4);
            this.tabMenu.Controls.Add(this.tabGen3);
            this.tabMenu.Controls.Add(this.tabCustom);
            this.tabMenu.ImageList = this.tabImages;
            this.tabMenu.ItemSize = new System.Drawing.Size(36, 16);
            this.tabMenu.Location = new System.Drawing.Point(197, 20);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(185, 237);
            this.tabMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMenu.TabIndex = 2;
            this.tabMenu.SelectedIndexChanged += new System.EventHandler(this.UpdateTimer);
            // 
            // tabCustom
            // 
            this.tabCustom.BackgroundImage = global::EonTimer.Properties.Resources.TabGlac;
            this.tabCustom.ImageKey = "EonCustom.png";
            this.tabCustom.Location = new System.Drawing.Point(4, 20);
            this.tabCustom.Name = "tabCustom";
            this.tabCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustom.Size = new System.Drawing.Size(177, 213);
            this.tabCustom.TabIndex = 4;
            this.tabCustom.UseVisualStyleBackColor = true;
            // 
            // tabImages
            // 
            this.tabImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImages.ImageStream")));
            this.tabImages.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImages.Images.SetKeyName(0, "5.png");
            this.tabImages.Images.SetKeyName(1, "4.png");
            this.tabImages.Images.SetKeyName(2, "3.png");
            this.tabImages.Images.SetKeyName(3, "settings.png");
            this.tabImages.Images.SetKeyName(4, "EonCustom.png");
            // 
            // pictureMini
            // 
            this.pictureMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureMini.BackColor = System.Drawing.Color.Transparent;
            this.pictureMini.Location = new System.Drawing.Point(334, 4);
            this.pictureMini.Name = "pictureMini";
            this.pictureMini.Size = new System.Drawing.Size(13, 13);
            this.pictureMini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMini.TabIndex = 14;
            this.pictureMini.TabStop = false;
            this.pictureMini.Click += new System.EventHandler(this.Mini);
            this.pictureMini.MouseEnter += new System.EventHandler(this.Mini_MouseEnter);
            this.pictureMini.MouseLeave += new System.EventHandler(this.Mini_MouseLeave);
            // 
            // picturePin
            // 
            this.picturePin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePin.BackColor = System.Drawing.Color.Transparent;
            this.picturePin.Location = new System.Drawing.Point(315, 4);
            this.picturePin.Name = "picturePin";
            this.picturePin.Size = new System.Drawing.Size(13, 13);
            this.picturePin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePin.TabIndex = 15;
            this.picturePin.TabStop = false;
            this.picturePin.Click += new System.EventHandler(this.Pin);
            this.picturePin.MouseEnter += new System.EventHandler(this.Pin_MouseEnter);
            this.picturePin.MouseLeave += new System.EventHandler(this.Pin_MouseLeave);
            // 
            // pictureSettings
            // 
            this.pictureSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureSettings.BackColor = System.Drawing.Color.Transparent;
            this.pictureSettings.Location = new System.Drawing.Point(12, 262);
            this.pictureSettings.Name = "pictureSettings";
            this.pictureSettings.Size = new System.Drawing.Size(24, 24);
            this.pictureSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSettings.TabIndex = 16;
            this.pictureSettings.TabStop = false;
            this.pictureSettings.Click += new System.EventHandler(this.OpenSettings);
            this.pictureSettings.MouseEnter += new System.EventHandler(this.Settings_MouseEnter);
            this.pictureSettings.MouseLeave += new System.EventHandler(this.Settings_MouseLeave);
            // 
            // MainTimer
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EonTimer.Properties.Resources.glaceonbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(392, 293);
            this.Controls.Add(this.pictureSettings);
            this.Controls.Add(this.pictureMini);
            this.Controls.Add(this.picturePin);
            this.Controls.Add(this.pictureClose);
            this.Controls.Add(this.pictureMinimize);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.displayNextStage);
            this.Controls.Add(this.displayMinsBefore);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelMinsLabel);
            this.Controls.Add(this.displayCurrent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainTimer";
            this.Text = "EonTimer v1.6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMinimize)).EndInit();
            this.tabGen3.ResumeLayout(false);
            this.tabGen3.PerformLayout();
            this.tabGen4.ResumeLayout(false);
            this.tabGen4.PerformLayout();
            this.tabGen5.ResumeLayout(false);
            this.tabGen5.PerformLayout();
            this.tabMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayCurrent;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label displayNextStage;
        private System.Windows.Forms.Label labelMinsLabel;
        private System.Windows.Forms.Label displayMinsBefore;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox pictureClose;
        private System.Windows.Forms.PictureBox pictureMinimize;
        private System.Windows.Forms.TabPage tabGen3;
        private System.Windows.Forms.Label labelHit3;
        private System.Windows.Forms.TextBox text_hit_3;
        private System.Windows.Forms.TextBox text_calibration_lag_3;
        private System.Windows.Forms.TextBox text_calibration_factor_3;
        private System.Windows.Forms.TextBox text_target_frame_3;
        private System.Windows.Forms.TextBox text_target_initial_3;
        private System.Windows.Forms.Label labelFrame;
        private System.Windows.Forms.Label labelInitial;
        private System.Windows.Forms.Label labelLag;
        private System.Windows.Forms.Label labelFactor;
        private System.Windows.Forms.TabPage tabGen4;
        private System.Windows.Forms.TextBox text_hit_4;
        private System.Windows.Forms.TextBox text_target_second_4;
        private System.Windows.Forms.TextBox text_target_delay_4;
        private System.Windows.Forms.TextBox text_calibration_second_4;
        private System.Windows.Forms.TextBox text_calibration_delay_4;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.Label labelTSec;
        private System.Windows.Forms.Label labelTDelay;
        private System.Windows.Forms.Label labelCSec;
        private System.Windows.Forms.Label labelCDelay;
        private System.Windows.Forms.TabPage tabGen5;
        private System.Windows.Forms.Label labelHL;
        private System.Windows.Forms.TextBox text_calibration_entralink_5;
        private System.Windows.Forms.TextBox text_hit_5;
        private System.Windows.Forms.TextBox text_target_second_5;
        private System.Windows.Forms.TextBox text_target_delay_5;
        private System.Windows.Forms.TextBox text_calibration_5;
        private System.Windows.Forms.Label labelDelayHit5;
        private System.Windows.Forms.Label labelTSec5;
        private System.Windows.Forms.Label labelTDelay5;
        private System.Windows.Forms.Label labelCalibration;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabCustom;
        private System.Windows.Forms.ImageList tabImages;
        private System.Windows.Forms.PictureBox pictureMini;
        private System.Windows.Forms.PictureBox picturePin;
        private System.Windows.Forms.Label labelELSec;
        private System.Windows.Forms.TextBox text_target_standard_5;
        private System.Windows.Forms.Label labelMode5;
        private System.Windows.Forms.ComboBox combo_mode_5;
        private System.Windows.Forms.Label labelMode4;
        private System.Windows.Forms.ComboBox combo_mode_4;
        private System.Windows.Forms.Label labelMode3;
        private System.Windows.Forms.ComboBox combo_mode_3;
        private System.Windows.Forms.PictureBox pictureSettings;

    }
}

