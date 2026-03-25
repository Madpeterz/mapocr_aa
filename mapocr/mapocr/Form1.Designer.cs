namespace mapocr
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            textBox2 = new TextBox();
            pictureBox2 = new PictureBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            trackBar1 = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            trackBar2 = new TrackBar();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            trackBar3 = new TrackBar();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pictureBox4 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(56, 177);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(378, 47);
            textBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(14, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(205, 132);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(300, 374);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Select app";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(11, 375);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(283, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 7);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(378, 89);
            textBox2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Location = new Point(58, 226);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(173, 116);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 102);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(378, 89);
            textBox5.TabIndex = 11;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(665, 554);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(161, 49);
            textBox6.TabIndex = 12;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(18, 317);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(172, 45);
            trackBar1.TabIndex = 13;
            trackBar1.TickFrequency = 5;
            trackBar1.Value = 88;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 299);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 14;
            label1.Text = "Pattern match";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 207);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 16;
            label2.Text = "Color match";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(18, 225);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(172, 45);
            trackBar2.TabIndex = 15;
            trackBar2.TickFrequency = 5;
            trackBar2.Value = 59;
            trackBar2.ValueChanged += trackBar2_ValueChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Location = new Point(261, 226);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(173, 116);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(213, 240);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 19;
            label3.Text = "Resize";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(212, 258);
            trackBar3.Maximum = 800;
            trackBar3.Minimum = 10;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(172, 45);
            trackBar3.SmallChange = 50;
            trackBar3.TabIndex = 18;
            trackBar3.TickFrequency = 50;
            trackBar3.Value = 217;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(107, 299);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 20;
            label4.Text = "88";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(106, 207);
            label5.Name = "label5";
            label5.Size = new Size(19, 15);
            label5.TabIndex = 21;
            label5.Text = "59";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(300, 240);
            label6.Name = "label6";
            label6.Size = new Size(25, 15);
            label6.TabIndex = 22;
            label6.Text = "217";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(6, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(600, 600);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 23;
            pictureBox4.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(620, 643);
            tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox6);
            tabPage1.Controls.Add(pictureBox4);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(612, 615);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Map";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(trackBar3);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(trackBar2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(trackBar1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(612, 615);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Config";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(pictureBox1);
            tabPage3.Controls.Add(pictureBox3);
            tabPage3.Controls.Add(textBox1);
            tabPage3.Controls.Add(pictureBox2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(612, 615);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Helpers";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 657);
            Controls.Add(tabControl1);
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            HelpButtonClicked += Form1_HelpButtonClicked;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Button button1;
        private ComboBox comboBox1;
        private System.Windows.Forms.Timer timer1;
        private TextBox textBox2;
        private PictureBox pictureBox2;
        private TextBox textBox5;
        private TextBox textBox6;
        private TrackBar trackBar1;
        private Label label1;
        private Label label2;
        private TrackBar trackBar2;
        private PictureBox pictureBox3;
        private Label label3;
        private TrackBar trackBar3;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}