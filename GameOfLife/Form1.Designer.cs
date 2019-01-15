namespace GameOfLife
{
    partial class Form1
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
            this.pView = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.lStats = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hSpeed = new System.Windows.Forms.HScrollBar();
            this.cRun = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lFps = new System.Windows.Forms.Label();
            this.FPS = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.cFiles = new System.Windows.Forms.ComboBox();
            this.bLoadPreset = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cRule = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rRect = new System.Windows.Forms.RadioButton();
            this.rLine = new System.Windows.Forms.RadioButton();
            this.rPen = new System.Windows.Forms.RadioButton();
            this.frameBox = new System.Windows.Forms.ComboBox();
            this.saveBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cReplay = new System.Windows.Forms.CheckBox();
            this.Frame = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pView)).BeginInit();
            this.SuspendLayout();
            // 
            // pView
            // 
            this.pView.BackColor = System.Drawing.Color.Black;
            this.pView.Location = new System.Drawing.Point(0, 39);
            this.pView.Name = "pView";
            this.pView.Size = new System.Drawing.Size(950, 550);
            this.pView.TabIndex = 0;
            this.pView.TabStop = false;
            this.pView.Click += new System.EventHandler(this.pView_Click);
            this.pView.Paint += new System.Windows.Forms.PaintEventHandler(this.pView_Paint);
            this.pView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pView_MouseDown);
            this.pView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pView_MouseMove);
            this.pView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pView_MouseUp);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(1280, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(36, 31);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // bClear
            // 
            this.bClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClear.Location = new System.Drawing.Point(295, 1);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(53, 20);
            this.bClear.TabIndex = 2;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // lStats
            // 
            this.lStats.AutoSize = true;
            this.lStats.ForeColor = System.Drawing.Color.Red;
            this.lStats.Location = new System.Drawing.Point(-1, 3);
            this.lStats.Name = "lStats";
            this.lStats.Size = new System.Drawing.Size(10, 13);
            this.lStats.TabIndex = 3;
            this.lStats.Text = "-";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hSpeed
            // 
            this.hSpeed.Location = new System.Drawing.Point(312, 22);
            this.hSpeed.Minimum = 1;
            this.hSpeed.Name = "hSpeed";
            this.hSpeed.Size = new System.Drawing.Size(85, 17);
            this.hSpeed.TabIndex = 4;
            this.hSpeed.Value = 50;
            this.hSpeed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hSpeed_Scroll);
            // 
            // cRun
            // 
            this.cRun.AutoSize = true;
            this.cRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cRun.ForeColor = System.Drawing.Color.Red;
            this.cRun.Location = new System.Drawing.Point(237, 24);
            this.cRun.Name = "cRun";
            this.cRun.Size = new System.Drawing.Size(75, 17);
            this.cRun.TabIndex = 5;
            this.cRun.Text = "Run (F2)";
            this.cRun.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(237, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Step";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lFps
            // 
            this.lFps.AutoSize = true;
            this.lFps.ForeColor = System.Drawing.Color.Red;
            this.lFps.Location = new System.Drawing.Point(-1, 23);
            this.lFps.Name = "lFps";
            this.lFps.Size = new System.Drawing.Size(10, 13);
            this.lFps.TabIndex = 7;
            this.lFps.Text = "-";
            // 
            // FPS
            // 
            this.FPS.Enabled = true;
            this.FPS.Interval = 1000;
            this.FPS.Tick += new System.EventHandler(this.FPS_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(826, 16);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1119, -2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 20);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(826, -3);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(80, 20);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // delButton
            // 
            this.delButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delButton.Location = new System.Drawing.Point(903, -3);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(80, 20);
            this.delButton.TabIndex = 11;
            this.delButton.Text = "Delete";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // cFiles
            // 
            this.cFiles.FormattingEnabled = true;
            this.cFiles.Location = new System.Drawing.Point(565, 18);
            this.cFiles.Margin = new System.Windows.Forms.Padding(2);
            this.cFiles.Name = "cFiles";
            this.cFiles.Size = new System.Drawing.Size(209, 21);
            this.cFiles.TabIndex = 12;
            this.cFiles.SelectedIndexChanged += new System.EventHandler(this.cFiles_SelectedIndexChanged);
            // 
            // bLoadPreset
            // 
            this.bLoadPreset.Location = new System.Drawing.Point(775, 18);
            this.bLoadPreset.Name = "bLoadPreset";
            this.bLoadPreset.Size = new System.Drawing.Size(49, 20);
            this.bLoadPreset.TabIndex = 13;
            this.bLoadPreset.Text = "Load";
            this.bLoadPreset.UseVisualStyleBackColor = true;
            this.bLoadPreset.Click += new System.EventHandler(this.bLoadPreset_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(1196, -2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(80, 20);
            this.editButton.TabIndex = 14;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(1119, 17);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(157, 20);
            this.nameBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(406, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Rule";
            // 
            // cRule
            // 
            this.cRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cRule.FormattingEnabled = true;
            this.cRule.Location = new System.Drawing.Point(409, 18);
            this.cRule.Margin = new System.Windows.Forms.Padding(2);
            this.cRule.Name = "cRule";
            this.cRule.Size = new System.Drawing.Size(145, 21);
            this.cRule.TabIndex = 26;
            this.cRule.SelectedIndexChanged += new System.EventHandler(this.cRule_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 20);
            this.button2.TabIndex = 25;
            this.button2.Text = "Center";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rRect
            // 
            this.rRect.Appearance = System.Windows.Forms.Appearance.Button;
            this.rRect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rRect.Location = new System.Drawing.Point(178, 1);
            this.rRect.Name = "rRect";
            this.rRect.Size = new System.Drawing.Size(51, 39);
            this.rRect.TabIndex = 24;
            this.rRect.TabStop = true;
            this.rRect.Text = "Rect";
            this.rRect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rRect.UseVisualStyleBackColor = true;
            // 
            // rLine
            // 
            this.rLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLine.Location = new System.Drawing.Point(134, 1);
            this.rLine.Name = "rLine";
            this.rLine.Size = new System.Drawing.Size(47, 39);
            this.rLine.TabIndex = 23;
            this.rLine.TabStop = true;
            this.rLine.Text = "Line";
            this.rLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rLine.UseVisualStyleBackColor = true;
            // 
            // rPen
            // 
            this.rPen.Appearance = System.Windows.Forms.Appearance.Button;
            this.rPen.Checked = true;
            this.rPen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rPen.Location = new System.Drawing.Point(90, 1);
            this.rPen.Name = "rPen";
            this.rPen.Size = new System.Drawing.Size(47, 39);
            this.rPen.TabIndex = 22;
            this.rPen.TabStop = true;
            this.rPen.Text = "Pen";
            this.rPen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rPen.UseVisualStyleBackColor = true;
            // 
            // frameBox
            // 
            this.frameBox.FormattingEnabled = true;
            this.frameBox.Location = new System.Drawing.Point(985, 16);
            this.frameBox.Margin = new System.Windows.Forms.Padding(2);
            this.frameBox.Name = "frameBox";
            this.frameBox.Size = new System.Drawing.Size(46, 21);
            this.frameBox.TabIndex = 29;
            this.frameBox.SelectedIndexChanged += new System.EventHandler(this.frameBox_SelectedIndexChanged);
            // 
            // saveBox
            // 
            this.saveBox.AutoSize = true;
            this.saveBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBox.ForeColor = System.Drawing.Color.Red;
            this.saveBox.Location = new System.Drawing.Point(1040, 2);
            this.saveBox.Margin = new System.Windows.Forms.Padding(2);
            this.saveBox.Name = "saveBox";
            this.saveBox.Size = new System.Drawing.Size(67, 17);
            this.saveBox.TabIndex = 30;
            this.saveBox.Text = "Record";
            this.saveBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(562, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Local Presets";
            // 
            // cReplay
            // 
            this.cReplay.AutoSize = true;
            this.cReplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cReplay.ForeColor = System.Drawing.Color.Red;
            this.cReplay.Location = new System.Drawing.Point(1040, 20);
            this.cReplay.Margin = new System.Windows.Forms.Padding(2);
            this.cReplay.Name = "cReplay";
            this.cReplay.Size = new System.Drawing.Size(65, 17);
            this.cReplay.TabIndex = 33;
            this.cReplay.Text = "Replay";
            this.cReplay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cReplay.UseVisualStyleBackColor = true;
            // 
            // Frame
            // 
            this.Frame.AutoSize = true;
            this.Frame.Cursor = System.Windows.Forms.Cursors.Default;
            this.Frame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame.ForeColor = System.Drawing.Color.Red;
            this.Frame.Location = new System.Drawing.Point(986, 1);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(41, 13);
            this.Frame.TabIndex = 34;
            this.Frame.Text = "Frame";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1470, 594);
            this.ControlBox = false;
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.cReplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBox);
            this.Controls.Add(this.frameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cRule);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rRect);
            this.Controls.Add(this.rLine);
            this.Controls.Add(this.rPen);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.bLoadPreset);
            this.Controls.Add(this.cFiles);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lFps);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cRun);
            this.Controls.Add(this.hSpeed);
            this.Controls.Add(this.lStats);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pView;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label lStats;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HScrollBar hSpeed;
        private System.Windows.Forms.CheckBox cRun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lFps;
        private System.Windows.Forms.Timer FPS;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.ComboBox cFiles;
        private System.Windows.Forms.Button bLoadPreset;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cRule;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rRect;
        private System.Windows.Forms.RadioButton rLine;
        private System.Windows.Forms.RadioButton rPen;
        private System.Windows.Forms.ComboBox frameBox;
        private System.Windows.Forms.CheckBox saveBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cReplay;
        private System.Windows.Forms.Label Frame;
    }
}

