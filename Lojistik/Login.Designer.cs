
namespace Lojistik
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_yanlis = new System.Windows.Forms.Panel();
            this.button_close = new System.Windows.Forms.Button();
            this.textBox_yanlis = new System.Windows.Forms.TextBox();
            this.panel_bilgiler = new System.Windows.Forms.Panel();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_kullanici_adi = new System.Windows.Forms.TextBox();
            this.button_show = new System.Windows.Forms.Button();
            this.pictureBox_password = new System.Windows.Forms.PictureBox();
            this.pictureBox_username = new System.Windows.Forms.PictureBox();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel_main.SuspendLayout();
            this.panel_yanlis.SuspendLayout();
            this.panel_bilgiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Controls.Add(this.panel_bilgiler);
            this.panel_main.Controls.Add(this.pictureBox_logo);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(10, 10);
            this.panel_main.Name = "panel_main";
            this.panel_main.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.panel_main.Size = new System.Drawing.Size(328, 430);
            this.panel_main.TabIndex = 0;
            // 
            // panel_yanlis
            // 
            this.panel_yanlis.Controls.Add(this.button_close);
            this.panel_yanlis.Controls.Add(this.textBox_yanlis);
            this.panel_yanlis.Location = new System.Drawing.Point(0, 39);
            this.panel_yanlis.Name = "panel_yanlis";
            this.panel_yanlis.Padding = new System.Windows.Forms.Padding(10);
            this.panel_yanlis.Size = new System.Drawing.Size(308, 156);
            this.panel_yanlis.TabIndex = 2;
            this.panel_yanlis.Visible = false;
            this.panel_yanlis.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_yanlis_Paint);
            // 
            // button_close
            // 
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_close.ForeColor = System.Drawing.Color.White;
            this.button_close.Location = new System.Drawing.Point(84, 98);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(140, 40);
            this.button_close.TabIndex = 1;
            this.button_close.Text = "Tekrar Dene";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            this.button_close.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button_close_KeyDown);
            // 
            // textBox_yanlis
            // 
            this.textBox_yanlis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.textBox_yanlis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_yanlis.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_yanlis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_yanlis.ForeColor = System.Drawing.Color.White;
            this.textBox_yanlis.Location = new System.Drawing.Point(10, 10);
            this.textBox_yanlis.Multiline = true;
            this.textBox_yanlis.Name = "textBox_yanlis";
            this.textBox_yanlis.ReadOnly = true;
            this.textBox_yanlis.Size = new System.Drawing.Size(288, 92);
            this.textBox_yanlis.TabIndex = 0;
            this.textBox_yanlis.Text = "Kullanıcı adınızı veya şifrenizi yanlış girdiniz, lütfen tekrar deneyiniz.";
            this.textBox_yanlis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel_bilgiler
            // 
            this.panel_bilgiler.Controls.Add(this.panel_yanlis);
            this.panel_bilgiler.Controls.Add(this.button_show);
            this.panel_bilgiler.Controls.Add(this.button_login);
            this.panel_bilgiler.Controls.Add(this.pictureBox_password);
            this.panel_bilgiler.Controls.Add(this.pictureBox_username);
            this.panel_bilgiler.Controls.Add(this.textBox_password);
            this.panel_bilgiler.Controls.Add(this.textBox_kullanici_adi);
            this.panel_bilgiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bilgiler.Location = new System.Drawing.Point(10, 140);
            this.panel_bilgiler.Name = "panel_bilgiler";
            this.panel_bilgiler.Padding = new System.Windows.Forms.Padding(50, 50, 20, 0);
            this.panel_bilgiler.Size = new System.Drawing.Size(306, 278);
            this.panel_bilgiler.TabIndex = 1;
            this.panel_bilgiler.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_bilgiler_Paint);
            // 
            // button_login
            // 
            this.button_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(190, 136);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(115, 35);
            this.button_login.TabIndex = 6;
            this.button_login.Text = "Giriş Yap";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_password.ForeColor = System.Drawing.Color.White;
            this.textBox_password.Location = new System.Drawing.Point(50, 92);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(255, 29);
            this.textBox_password.TabIndex = 2;
            this.textBox_password.UseSystemPasswordChar = true;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox_password_TextChanged);
            this.textBox_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_password_KeyDown);
            // 
            // textBox_kullanici_adi
            // 
            this.textBox_kullanici_adi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox_kullanici_adi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_kullanici_adi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_kullanici_adi.ForeColor = System.Drawing.Color.White;
            this.textBox_kullanici_adi.Location = new System.Drawing.Point(50, 45);
            this.textBox_kullanici_adi.Name = "textBox_kullanici_adi";
            this.textBox_kullanici_adi.Size = new System.Drawing.Size(255, 29);
            this.textBox_kullanici_adi.TabIndex = 0;
            this.textBox_kullanici_adi.TextChanged += new System.EventHandler(this.textBox_kullanici_adi_TextChanged);
            this.textBox_kullanici_adi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_kullanici_adi_KeyDown);
            // 
            // button_show
            // 
            this.button_show.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_show.BackgroundImage")));
            this.button_show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_show.FlatAppearance.BorderSize = 0;
            this.button_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_show.Image = ((System.Drawing.Image)(resources.GetObject("button_show.Image")));
            this.button_show.Location = new System.Drawing.Point(280, 97);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(20, 20);
            this.button_show.TabIndex = 7;
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_show_MouseDown);
            this.button_show.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_show_MouseUp);
            // 
            // pictureBox_password
            // 
            this.pictureBox_password.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_password.Image")));
            this.pictureBox_password.Location = new System.Drawing.Point(4, 86);
            this.pictureBox_password.Name = "pictureBox_password";
            this.pictureBox_password.Size = new System.Drawing.Size(40, 40);
            this.pictureBox_password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_password.TabIndex = 5;
            this.pictureBox_password.TabStop = false;
            // 
            // pictureBox_username
            // 
            this.pictureBox_username.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_username.Image")));
            this.pictureBox_username.Location = new System.Drawing.Point(4, 39);
            this.pictureBox_username.Name = "pictureBox_username";
            this.pictureBox_username.Size = new System.Drawing.Size(40, 40);
            this.pictureBox_username.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_username.TabIndex = 4;
            this.pictureBox_username.TabStop = false;
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(10, 30);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(306, 110);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(348, 450);
            this.Controls.Add(this.panel_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(364, 489);
            this.MinimumSize = new System.Drawing.Size(364, 489);
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Yap";
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Login_Paint);
            this.panel_main.ResumeLayout(false);
            this.panel_yanlis.ResumeLayout(false);
            this.panel_yanlis.PerformLayout();
            this.panel_bilgiler.ResumeLayout(false);
            this.panel_bilgiler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Panel panel_bilgiler;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.PictureBox pictureBox_password;
        private System.Windows.Forms.PictureBox pictureBox_username;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Panel panel_yanlis;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.TextBox textBox_yanlis;
        public System.Windows.Forms.TextBox textBox_kullanici_adi;
        private System.Windows.Forms.Button button_show;
    }
}