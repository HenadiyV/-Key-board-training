namespace Trenager
{
    partial class PriW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriW));
            this.Ok_ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Help_but = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btHello = new System.Windows.Forms.Button();
            this.IconADD = new System.Windows.Forms.Button();
            this.GoNext = new System.Windows.Forms.Button();
            this.f_admin = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_
            // 
            this.Ok_.Location = new System.Drawing.Point(6, 123);
            this.Ok_.Name = "Ok_";
            this.Ok_.Size = new System.Drawing.Size(158, 23);
            this.Ok_.TabIndex = 0;
            this.Ok_.Text = "Вхід";
            this.Ok_.UseVisualStyleBackColor = true;
            this.Ok_.Visible = false;
            this.Ok_.Click += new System.EventHandler(this.Ok__Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "А тебе як звати ?";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(371, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 49);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(202, 44);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(605, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 24);
            this.label3.TabIndex = 2;
            // 
            // Help_but
            // 
            this.Help_but.Location = new System.Drawing.Point(170, 97);
            this.Help_but.Name = "Help_but";
            this.Help_but.Size = new System.Drawing.Size(177, 23);
            this.Help_but.TabIndex = 3;
            this.Help_but.Text = "Ні";
            this.Help_but.UseVisualStyleBackColor = true;
            this.Help_but.Visible = false;
            this.Help_but.Click += new System.EventHandler(this.Help_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "памятаєш секретний ключ ?";
            this.label2.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PeachPuff;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.btHello);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.IconADD);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Help_but);
            this.panel2.Controls.Add(this.GoNext);
            this.panel2.Controls.Add(this.f_admin);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.Ok_);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(324, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 178);
            this.panel2.TabIndex = 2;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(168, 123);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(177, 23);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Вихід";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(265, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Введіть свій пароль";
            this.textBox2.Visible = false;
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // btHello
            // 
            this.btHello.Location = new System.Drawing.Point(272, 27);
            this.btHello.Name = "btHello";
            this.btHello.Size = new System.Drawing.Size(75, 23);
            this.btHello.TabIndex = 8;
            this.btHello.Text = "Привіт";
            this.btHello.UseVisualStyleBackColor = true;
            this.btHello.Click += new System.EventHandler(this.btHello_Click);
            // 
            // IconADD
            // 
            this.IconADD.Location = new System.Drawing.Point(6, 97);
            this.IconADD.Name = "IconADD";
            this.IconADD.Size = new System.Drawing.Size(156, 23);
            this.IconADD.TabIndex = 6;
            this.IconADD.Text = "Так";
            this.IconADD.UseVisualStyleBackColor = true;
            this.IconADD.Visible = false;
            this.IconADD.Click += new System.EventHandler(this.IconADD_Click);
            // 
            // GoNext
            // 
            this.GoNext.Location = new System.Drawing.Point(6, 149);
            this.GoNext.Name = "GoNext";
            this.GoNext.Size = new System.Drawing.Size(339, 23);
            this.GoNext.TabIndex = 7;
            this.GoNext.Text = "Розпочнемо";
            this.GoNext.UseVisualStyleBackColor = true;
            this.GoNext.Visible = false;
            this.GoNext.Click += new System.EventHandler(this.GoNext_Click);
            // 
            // f_admin
            // 
            this.f_admin.Location = new System.Drawing.Point(83, 149);
            this.f_admin.Name = "f_admin";
            this.f_admin.Size = new System.Drawing.Size(102, 23);
            this.f_admin.TabIndex = 5;
            this.f_admin.Text = "Admin";
            this.f_admin.UseVisualStyleBackColor = true;
            this.f_admin.Visible = false;
            this.f_admin.Click += new System.EventHandler(this.f_admin_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Введіть свій логін";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(155, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Продолжить";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(746, 382);
            this.panel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 379);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Справка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PriW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 397);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PriW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PriW";
            this.Load += new System.EventHandler(this.PriW_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Exit;
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Help_but;
        private System.Windows.Forms.Button f_admin;
        private System.Windows.Forms.Button GoNext;
        private System.Windows.Forms.Button IconADD;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Ok_;
        private System.Windows.Forms.Button btHello;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
    }
}