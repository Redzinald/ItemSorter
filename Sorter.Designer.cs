namespace SortItemsToFolders
{
    partial class Sorter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sorter));
            button1 = new Button();
            label1 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            textBox1 = new TextBox();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            checkedListBox1 = new CheckedListBox();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            progressBar1 = new ProgressBar();
            textBox7 = new TextBox();
            checkedListBox2 = new CheckedListBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(303, 217);
            button1.Name = "button1";
            button1.Size = new Size(124, 51);
            button1.TabIndex = 0;
            button1.Text = "SORT!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(665, 156);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 1;
            label1.Text = "[Browse]";
            label1.Click += label1_Click;
            label1.MouseEnter += label1_MouseEnter;
            label1.MouseLeave += label1_MouseLeave;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Silver;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.ForeColor = Color.Black;
            textBox1.Location = new Point(70, 152);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(591, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "Select or drag folder";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.DragDrop += textBox1_DragDrop;
            textBox1.DragEnter += textBox1_DragEnter;
            textBox1.MouseDown += textBox1_MouseDown;
            textBox1.MouseEnter += textBox1_MouseEnter;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(303, 281);
            button2.Name = "button2";
            button2.Size = new Size(124, 46);
            button2.TabIndex = 3;
            button2.Text = "REVERSE SORT!";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(228, 116);
            label2.Name = "label2";
            label2.Size = new Size(251, 21);
            label2.TabIndex = 4;
            label2.Text = "Select a folder you want to sort:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label3.Location = new Point(288, 187);
            label3.Name = "label3";
            label3.Size = new Size(160, 15);
            label3.TabIndex = 5;
            label3.Text = "You have to choose directory";
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.Silver;
            checkedListBox1.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Font = new Font("Yu Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkedListBox1.ForeColor = Color.Black;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Images", "Documents", "Others", "Videos", "Audio", "Custom" });
            checkedListBox1.Location = new Point(23, 214);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(234, 164);
            checkedListBox1.TabIndex = 7;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.image_removebg_preview__5_;
            pictureBox1.Location = new Point(0, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 24);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.ForeColor = Color.Snow;
            checkBox1.Location = new Point(319, 349);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(108, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Rename folders";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(114, 217);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(134, 23);
            textBox2.TabIndex = 10;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(133, 242);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(115, 23);
            textBox3.TabIndex = 11;
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(101, 267);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(146, 23);
            textBox4.TabIndex = 12;
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(98, 294);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 23);
            textBox5.TabIndex = 13;
            textBox5.Visible = false;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(90, 322);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(158, 23);
            textBox6.TabIndex = 14;
            textBox6.Visible = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.DimGray;
            progressBar1.Location = new Point(70, 152);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(591, 23);
            progressBar1.TabIndex = 15;
            progressBar1.Visible = false;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(101, 349);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(146, 23);
            textBox7.TabIndex = 16;
            textBox7.Visible = false;
            // 
            // checkedListBox2
            // 
            checkedListBox2.BackColor = Color.Silver;
            checkedListBox2.BorderStyle = BorderStyle.None;
            checkedListBox2.CheckOnClick = true;
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { ".pdf", ".docx", ".txt", ".jpg", ".png", ".gif", ".mp4", ".mp3", ".exe", ".zip", ".cs", ".csv", ".html", ".7z", ".rar" });
            checkedListBox2.Location = new Point(512, 234);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(120, 144);
            checkedListBox2.TabIndex = 17;
            checkedListBox2.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Location = new Point(483, 214);
            label4.Name = "label4";
            label4.Size = new Size(178, 15);
            label4.TabIndex = 18;
            label4.Text = "File extensions for custom folder";
            label4.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.pexels_elina_araja_1743227_3377405;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(740, 428);
            Controls.Add(label4);
            Controls.Add(checkedListBox2);
            Controls.Add(textBox7);
            Controls.Add(progressBar1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(checkBox1);
            Controls.Add(pictureBox1);
            Controls.Add(checkedListBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "File sorter";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox textBox1;
        private Button button2;
        private Label label2;
        private Label label3;
        private CheckedListBox checkedListBox1;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private ErrorProvider errorProvider1;
        private ProgressBar progressBar1;
        private TextBox textBox7;
        private CheckedListBox checkedListBox2;
        private Label label4;
    }
}
