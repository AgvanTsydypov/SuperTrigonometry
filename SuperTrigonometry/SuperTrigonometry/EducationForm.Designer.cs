namespace SuperTrigonometry
{
    partial class EducationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EducationForm));
            this.TheoryBtn = new System.Windows.Forms.Button();
            this.EndGameRB = new System.Windows.Forms.RichTextBox();
            this.CBCount = new System.Windows.Forms.ComboBox();
            this.CountLbl = new System.Windows.Forms.Label();
            this.GenBtn = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.TimeLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TimerBtn = new System.Windows.Forms.Button();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.PausePB = new System.Windows.Forms.PictureBox();
            this.KeyGenTB = new System.Windows.Forms.TextBox();
            this.KGLbl = new System.Windows.Forms.Label();
            this.WebCheckBox = new System.Windows.Forms.CheckBox();
            this.AnswersCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PausePB)).BeginInit();
            this.SuspendLayout();
            // 
            // TheoryBtn
            // 
            this.TheoryBtn.ForeColor = System.Drawing.Color.Brown;
            this.TheoryBtn.Location = new System.Drawing.Point(667, 417);
            this.TheoryBtn.Name = "TheoryBtn";
            this.TheoryBtn.Size = new System.Drawing.Size(121, 23);
            this.TheoryBtn.TabIndex = 1;
            this.TheoryBtn.Text = "CheckTheory";
            this.TheoryBtn.UseVisualStyleBackColor = true;
            this.TheoryBtn.Click += new System.EventHandler(this.TheoryBtn_Click);
            // 
            // EndGameRB
            // 
            this.EndGameRB.Location = new System.Drawing.Point(12, 124);
            this.EndGameRB.Name = "EndGameRB";
            this.EndGameRB.Size = new System.Drawing.Size(776, 287);
            this.EndGameRB.TabIndex = 3;
            this.EndGameRB.Text = "";
            // 
            // CBCount
            // 
            this.CBCount.AllowDrop = true;
            this.CBCount.FormattingEnabled = true;
            this.CBCount.Location = new System.Drawing.Point(280, 94);
            this.CBCount.Name = "CBCount";
            this.CBCount.Size = new System.Drawing.Size(121, 21);
            this.CBCount.TabIndex = 6;
            this.CBCount.TextChanged += new System.EventHandler(this.CBCount_TextChanged);
            this.CBCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CBCount_KeyPress);
            // 
            // CountLbl
            // 
            this.CountLbl.AutoSize = true;
            this.CountLbl.ForeColor = System.Drawing.Color.Brown;
            this.CountLbl.Image = ((System.Drawing.Image)(resources.GetObject("CountLbl.Image")));
            this.CountLbl.Location = new System.Drawing.Point(277, 77);
            this.CountLbl.Name = "CountLbl";
            this.CountLbl.Size = new System.Drawing.Size(112, 13);
            this.CountLbl.TabIndex = 7;
            this.CountLbl.Text = "Count of Tasks (none)";
            // 
            // GenBtn
            // 
            this.GenBtn.ForeColor = System.Drawing.Color.Brown;
            this.GenBtn.Location = new System.Drawing.Point(326, 417);
            this.GenBtn.Name = "GenBtn";
            this.GenBtn.Size = new System.Drawing.Size(121, 23);
            this.GenBtn.TabIndex = 8;
            this.GenBtn.Text = "GenerateTasks";
            this.GenBtn.UseVisualStyleBackColor = true;
            this.GenBtn.Click += new System.EventHandler(this.GenBtn_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimeLbl
            // 
            this.TimeLbl.AutoSize = true;
            this.TimeLbl.ForeColor = System.Drawing.Color.Brown;
            this.TimeLbl.Image = ((System.Drawing.Image)(resources.GetObject("TimeLbl.Image")));
            this.TimeLbl.Location = new System.Drawing.Point(12, 77);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(82, 13);
            this.TimeLbl.TabIndex = 9;
            this.TimeLbl.Text = "Timer(0h:0m:0s)";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Location = new System.Drawing.Point(12, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "MainMenu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimerBtn
            // 
            this.TimerBtn.ForeColor = System.Drawing.Color.Brown;
            this.TimerBtn.Location = new System.Drawing.Point(12, 93);
            this.TimerBtn.Name = "TimerBtn";
            this.TimerBtn.Size = new System.Drawing.Size(121, 23);
            this.TimerBtn.TabIndex = 14;
            this.TimerBtn.Text = "Pause/Resume";
            this.TimerBtn.UseVisualStyleBackColor = true;
            this.TimerBtn.Click += new System.EventHandler(this.TimerBtn_Click);
            // 
            // PrintBtn
            // 
            this.PrintBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PrintBtn.BackgroundImage")));
            this.PrintBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PrintBtn.Location = new System.Drawing.Point(726, 14);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(62, 61);
            this.PrintBtn.TabIndex = 15;
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // PausePB
            // 
            this.PausePB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PausePB.BackgroundImage")));
            this.PausePB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PausePB.Location = new System.Drawing.Point(12, 124);
            this.PausePB.Name = "PausePB";
            this.PausePB.Size = new System.Drawing.Size(776, 287);
            this.PausePB.TabIndex = 16;
            this.PausePB.TabStop = false;
            // 
            // KeyGenTB
            // 
            this.KeyGenTB.Location = new System.Drawing.Point(153, 95);
            this.KeyGenTB.Name = "KeyGenTB";
            this.KeyGenTB.Size = new System.Drawing.Size(121, 20);
            this.KeyGenTB.TabIndex = 17;
            this.KeyGenTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyGenTB_KeyPress);
            // 
            // KGLbl
            // 
            this.KGLbl.AutoSize = true;
            this.KGLbl.ForeColor = System.Drawing.Color.Brown;
            this.KGLbl.Image = ((System.Drawing.Image)(resources.GetObject("KGLbl.Image")));
            this.KGLbl.Location = new System.Drawing.Point(150, 79);
            this.KGLbl.Name = "KGLbl";
            this.KGLbl.Size = new System.Drawing.Size(45, 13);
            this.KGLbl.TabIndex = 18;
            this.KGLbl.Text = "KeyGen";
            // 
            // WebCheckBox
            // 
            this.WebCheckBox.AutoSize = true;
            this.WebCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WebCheckBox.BackgroundImage")));
            this.WebCheckBox.ForeColor = System.Drawing.Color.Brown;
            this.WebCheckBox.Location = new System.Drawing.Point(453, 423);
            this.WebCheckBox.Name = "WebCheckBox";
            this.WebCheckBox.Size = new System.Drawing.Size(49, 17);
            this.WebCheckBox.TabIndex = 19;
            this.WebCheckBox.Text = "Web";
            this.WebCheckBox.UseVisualStyleBackColor = true;
            // 
            // AnswersCheckBox
            // 
            this.AnswersCheckBox.AutoSize = true;
            this.AnswersCheckBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AnswersCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AnswersCheckBox.BackgroundImage")));
            this.AnswersCheckBox.ForeColor = System.Drawing.Color.Brown;
            this.AnswersCheckBox.Location = new System.Drawing.Point(508, 423);
            this.AnswersCheckBox.Name = "AnswersCheckBox";
            this.AnswersCheckBox.Size = new System.Drawing.Size(66, 17);
            this.AnswersCheckBox.TabIndex = 20;
            this.AnswersCheckBox.Text = "Answers";
            this.AnswersCheckBox.UseVisualStyleBackColor = false;
            // 
            // EducationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AnswersCheckBox);
            this.Controls.Add(this.WebCheckBox);
            this.Controls.Add(this.KGLbl);
            this.Controls.Add(this.KeyGenTB);
            this.Controls.Add(this.PausePB);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.TimerBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimeLbl);
            this.Controls.Add(this.GenBtn);
            this.Controls.Add(this.CountLbl);
            this.Controls.Add(this.CBCount);
            this.Controls.Add(this.EndGameRB);
            this.Controls.Add(this.TheoryBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EducationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Generator";
            this.Load += new System.EventHandler(this.EducationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PausePB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button TheoryBtn;
        private System.Windows.Forms.RichTextBox EndGameRB;
        private System.Windows.Forms.ComboBox CBCount;
        private System.Windows.Forms.Label CountLbl;
        private System.Windows.Forms.Button GenBtn;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TimerBtn;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.PictureBox PausePB;
        private System.Windows.Forms.TextBox KeyGenTB;
        private System.Windows.Forms.Label KGLbl;
        private System.Windows.Forms.CheckBox WebCheckBox;
        private System.Windows.Forms.CheckBox AnswersCheckBox;
    }
}