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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rPen = new System.Windows.Forms.RadioButton();
            this.rLine = new System.Windows.Forms.RadioButton();
            this.rRect = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cRule = new System.Windows.Forms.ComboBox();
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
            this.buttonExit.Location = new System.Drawing.Point(1174, 0);
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
            this.bClear.Location = new System.Drawing.Point(316, -1);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(44, 20);
            this.bClear.TabIndex = 2;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // lStats
            // 
            this.lStats.AutoSize = true;
            this.lStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStats.ForeColor = System.Drawing.Color.Red;
            this.lStats.Location = new System.Drawing.Point(-1, 3);
            this.lStats.Name = "lStats";
            this.lStats.Size = new System.Drawing.Size(12, 15);
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
            this.hSpeed.Location = new System.Drawing.Point(315, 20);
            this.hSpeed.Minimum = 1;
            this.hSpeed.Name = "hSpeed";
            this.hSpeed.Size = new System.Drawing.Size(93, 17);
            this.hSpeed.TabIndex = 4;
            this.hSpeed.Value = 50;
            this.hSpeed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hSpeed_Scroll);
            // 
            // cRun
            // 
            this.cRun.AutoSize = true;
            this.cRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cRun.ForeColor = System.Drawing.Color.Red;
            this.cRun.Location = new System.Drawing.Point(237, 22);
            this.cRun.Name = "cRun";
            this.cRun.Size = new System.Drawing.Size(75, 17);
            this.cRun.TabIndex = 5;
            this.cRun.Text = "Run (F2)";
            this.cRun.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(237, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Step";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lFps
            // 
            this.lFps.AutoSize = true;
            this.lFps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFps.ForeColor = System.Drawing.Color.Red;
            this.lFps.Location = new System.Drawing.Point(-1, 23);
            this.lFps.Name = "lFps";
            this.lFps.Size = new System.Drawing.Size(12, 15);
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
            this.comboBox1.Location = new System.Drawing.Point(597, 16);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(743, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 19);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Location = new System.Drawing.Point(743, 0);
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
            this.delButton.Location = new System.Drawing.Point(823, 0);
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
            this.cFiles.Location = new System.Drawing.Point(925, 18);
            this.cFiles.Margin = new System.Windows.Forms.Padding(2);
            this.cFiles.Name = "cFiles";
            this.cFiles.Size = new System.Drawing.Size(191, 21);
            this.cFiles.TabIndex = 12;
            // 
            // bLoadPreset
            // 
            this.bLoadPreset.Location = new System.Drawing.Point(1118, 18);
            this.bLoadPreset.Name = "bLoadPreset";
            this.bLoadPreset.Size = new System.Drawing.Size(75, 20);
            this.bLoadPreset.TabIndex = 13;
            this.bLoadPreset.Text = "Load";
            this.bLoadPreset.UseVisualStyleBackColor = true;
            this.bLoadPreset.Click += new System.EventHandler(this.bLoadPreset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(594, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(922, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Local presets";
            // 
            // rPen
            // 
            this.rPen.Appearance = System.Windows.Forms.Appearance.Button;
            this.rPen.Checked = true;
            this.rPen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rPen.Location = new System.Drawing.Point(78, -1);
            this.rPen.Name = "rPen";
            this.rPen.Size = new System.Drawing.Size(47, 39);
            this.rPen.TabIndex = 16;
            this.rPen.TabStop = true;
            this.rPen.Text = "Pen";
            this.rPen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rPen.UseVisualStyleBackColor = true;
            // 
            // rLine
            // 
            this.rLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLine.Location = new System.Drawing.Point(122, -1);
            this.rLine.Name = "rLine";
            this.rLine.Size = new System.Drawing.Size(47, 39);
            this.rLine.TabIndex = 17;
            this.rLine.TabStop = true;
            this.rLine.Text = "Line";
            this.rLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rLine.UseVisualStyleBackColor = true;
            // 
            // rRect
            // 
            this.rRect.Appearance = System.Windows.Forms.Appearance.Button;
            this.rRect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rRect.Location = new System.Drawing.Point(166, -1);
            this.rRect.Name = "rRect";
            this.rRect.Size = new System.Drawing.Size(51, 39);
            this.rRect.TabIndex = 18;
            this.rRect.TabStop = true;
            this.rRect.Text = "Rect";
            this.rRect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rRect.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 20);
            this.button2.TabIndex = 19;
            this.button2.Text = "Center";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(423, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Rule";
            // 
            // cRule
            // 
            this.cRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cRule.FormattingEnabled = true;
            this.cRule.Location = new System.Drawing.Point(426, 16);
            this.cRule.Margin = new System.Windows.Forms.Padding(2);
            this.cRule.Name = "cRule";
            this.cRule.Size = new System.Drawing.Size(145, 21);
            this.cRule.TabIndex = 20;
            this.cRule.SelectedIndexChanged += new System.EventHandler(this.cRule_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1222, 594);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cRule);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rRect);
            this.Controls.Add(this.rLine);
            this.Controls.Add(this.rPen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.Text = "Game Of Life";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rPen;
        private System.Windows.Forms.RadioButton rLine;
        private System.Windows.Forms.RadioButton rRect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cRule;
    }
}

