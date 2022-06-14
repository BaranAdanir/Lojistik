using System;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Login : Form
    {
        public static string textPassedLogin;

        public Login()
        {
            InitializeComponent();
        }

        private void panel_bilgiler_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {

            textPassedLogin = textBox_kullanici_adi.Text;

            if (textBox_kullanici_adi.Text == "Tufan Özer" && textBox_password.Text == "admin")
            {
                new main_form().Show();
                this.Hide();
            }

            else
            {
                panel_yanlis.Visible = true;
                textBox_kullanici_adi.Clear();
                textBox_password.Clear();
            }
        }

        private void textBox_kullanici_adi_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            panel_yanlis.Visible = false;
            textBox_kullanici_adi.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox_kullanici_adi.Text = main_form.textPassedMainForm;
            textBox_kullanici_adi.Text = Dukkan.textPassedMainForm;
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Login_Activated(object sender, EventArgs e)
        {

        }

        private void Login_Shown(object sender, EventArgs e)
        {

        }

        private void panel_yanlis_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_show_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
        }

        private void button_show_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true; ;
        }

        private void textBox_kullanici_adi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBox_password.Focus();
            }
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBox_kullanici_adi.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                button_login.PerformClick();
            }
        }

        private void button_close_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
