using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class main_form : Form
    {

        public static string textPassedMainForm;
        int chosen_row_araclar;
        int chosen_column_araclar;

        public string selectedDate;
        public string selectedDateFaturalar;

        int panel_counter = 1;
        int arac_index;
        int chosen_row_GelirGider;
        int chosen_column_GelirGider;

        int panel_bakim_counter = 1;

        int chosen_row_bakim;
        int chosen_column_bakim;

        public string selectedDateGelirGider;

        public string selectedDatebakim;

        Panel opened_arac_gelir_panel;
        Panel opened_arac_bakim_panel;

        Panel opened_gelir_takvim_panel;
        Panel opened_bakim_takvim_panel;

        string tutar;
        string odenen;
        decimal kalan;
        bool tutar_dolu;
        bool odenen_dolu;
        decimal tutar_int;
        decimal odenen_int;
        int chosen_row_faturalar;
        int chosen_column_faturalar;
        Panel opened_fatura_takvim_panel;
        readonly int panel_musteri_counter = 1;

        public string selectedDateFatura;

        string masraf_1;
        string masraf_2;
        string masraf_3;
        string masraf_4;
        string masraf_5;
        string masraf_6;
        string masraf_7;

        bool masraf_1_check;
        bool masraf_2_check;
        bool masraf_3_check;
        bool masraf_4_check;
        bool masraf_5_check;
        bool masraf_6_check;
        bool masraf_7_check;

        decimal masraf_1_int;
        decimal masraf_2_int;
        decimal masraf_3_int;
        decimal masraf_4_int;
        decimal masraf_5_int;
        decimal masraf_6_int;
        decimal masraf_7_int;

        decimal toplam_masraf;

        string birim_fiyat;
        string net_tonaj;

        bool birim_fiyat_check;
        bool net_tonaj_check;

        decimal birim_fiyat_int;
        decimal net_tonaj_int;

        decimal kdv;
        decimal tevkifat;

        decimal toplam_tutar;

        string gelir;
        string gider;

        bool gelir_check;
        bool gider_check;

        decimal gelir_int;
        decimal gider_int;

        decimal net_kar;

        string alinan_yakit;
        string cikis_km;
        string gelis_km;
        string yakit_birim_fiyat;

        bool alinan_yakit_check;
        bool cikis_km_check;
        bool gelis_km_check;
        bool yakit_birim_fiyat_check;

        float alinan_yakit_int;
        float cikis_km_int;
        float gelis_km_int;
        float yakit_birim_fiyat_int;

        float gidilen_km;
        float tuketim;

        bool muayene_check;
        DateTime muayene_date;
        string muayene_string;

        bool kasko_check;
        DateTime kasko_date;
        string kasko_string;

        bool sigorta_check;
        DateTime sigorta_date;
        string sigorta_string;

        bool fatura_check;
        DateTime fatura_date;
        string fatura_string;

        int fatura_kalan_gun = 100;

        int muayene_kalan_gun = 100;
        int sigorta_kalan_gun = 100;
        int kasko_kalan_gun = 100;

        string muayene_kalan_gun_string;
        int muayene_kalan_gun_int;
        bool muayene_kalan_gun_check;

        string kasko_kalan_gun_string;
        int kasko_kalan_gun_int;
        bool kasko_kalan_gun_check;

        string sigorta_kalan_gun_string;
        int sigorta_kalan_gun_int;
        bool sigorta_kalan_gun_check;

        string fatura_kalan_gun_string;
        DateTime fatura_kalan_gun_date;
        bool fatura_kalan_gun_check;

        bool has_been_inserted = false;
        readonly string SaveLocation = "..\\Release\\Save";

        FileOperations DataGridSil = new FileOperations();
        private Panel opened_toptanci_takvim_panel;
        private int chosen_row_toptanci;
        private int chosen_column_toptanci;
        private string selectedDateToptanci;
        
        private string onceki_kalan_string;
        private bool onceki_kalan_check = false;
        private decimal onceki_kalan_decimal;
        private decimal onceki_kalanlar;
        private Panel opened_araclar_takvim_panel;

        public main_form()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_username.Text = Login.textPassedLogin;
            timer_main.Start();

            button_tasimacilik.FlatAppearance.BorderColor = Color.FromArgb(151, 38, 32);
            button_tasimacilik.ForeColor = Color.FromArgb(151, 38, 32);
            button_tasimacilik.Font = new Font(button_tasimacilik.Font, FontStyle.Bold);
            button_tasimacilik.FlatAppearance.BorderSize = 2;




            DataGridSil.ReadDataGrid(dataGridView_araclar, SaveLocation + "\\" + "Araçlar");
            ReadAracGelir(SaveLocation + "\\" + "Araç Gelirler");
            ReadAracBakim(SaveLocation + "\\" + "Araç Bakımlar");
            ReadMusteri(SaveLocation + "\\" + "Müşteriler");
            ReadMusteriBilgi(SaveLocation + "\\" + "Müşteri Bilgiler");
            ReadCalisan(SaveLocation + "\\" + "Toptancılar");
            ReadCalisanBilgi(SaveLocation + "\\" + "Toptancı Bilgiler");
        }

        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_bakimlar_Click(object sender, EventArgs e)
        {
            panel_arac_gelir.Visible = false;
            panel_araclar.Visible = false;
            panel_faturalar.Visible = false;
            panel_anasayfa.Visible = false;
            panel_ekle.Visible = false;
            panel_calisanlar.Visible = false;
            panel_calisan_ekle.Visible = false;
            panel_bakimlar.Visible = true;

            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }
            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }

            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }
            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_toptanci_panel.Visible = false;
            }
            else
            {

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }
            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }

            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }
            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }

            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araçlar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araç Gelirler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araç Bakımlar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Müşteriler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Müşteri Bilgiler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Toptancılar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Toptancı Bilgiler");

            string FilePath = SaveLocation + "\\" + "Araçlar";

            FileOperations WriteDataGridAraclar = new FileOperations();
            WriteDataGridAraclar.WriteDataGrid(dataGridView_araclar, FilePath);
            CreateAracGelir(dataGridView_araclar, SaveLocation + "\\" + "Araç Gelirler");
            CreateAracBakim(dataGridView_araclar, SaveLocation + "\\" + "Araç Bakımlar");
            CreateMusteri(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Müşteriler");
            CreateMusteriBilgi(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Müşteri Bilgiler");
            CreateToptanci(comboBox_calisanlar, SaveLocation + "\\" + "Toptancılar");
            CreateToptanciBilgi(comboBox_calisanlar, SaveLocation + "\\" + "Toptancı Bilgiler");

            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 8)
            {
                panel_takvim.Visible = true;
            }
        }

        private void button_faturalar_Click(object sender, EventArgs e)
        {
            panel_arac_gelir.Visible = false;
            panel_bakimlar.Visible = false;
            panel_araclar.Visible = false;
            panel_anasayfa.Visible = false;
            panel_faturalar.Visible = false;
            panel_calisanlar.Visible = false;
            panel_calisan_ekle.Visible = false;
            panel_ekle.Visible = true;

            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }
            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }
            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }

            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }
            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_toptanci_panel.Visible = false;
            }
            else
            {

            }

        }

        private void panel_faturalar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_araclar_Click(object sender, EventArgs e)
        {
            panel_arac_gelir.Visible = false;
            panel_bakimlar.Visible = false;
            panel_faturalar.Visible = false;
            panel_anasayfa.Visible = false;
            panel_ekle.Visible = false;
            panel_calisanlar.Visible = false;
            panel_calisan_ekle.Visible = false;
            panel_araclar.Visible = true;

            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }

            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }

            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }

            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }
            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_toptanci_panel.Visible = false;
            }
            else
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_bakimlar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_araclar_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            for (int i = 0; i < 3; i += 2)
            {
                dataGridView_araclar[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                dataGridView_araclar[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            for (int i = 1; i < 4; i += 2)
            {
                dataGridView_araclar[i, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
                dataGridView_araclar[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 61, 74);
            }

            for (int i = 4; i < 6; i++)
            {
                dataGridView_araclar[i, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
                dataGridView_araclar[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 71, 39);
            }

            for (int i = 6; i < 8; i++)
            {
                dataGridView_araclar[i, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
                dataGridView_araclar[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);
            }

            for (int i = 8; i < 10; i++)
            {
                dataGridView_araclar[i, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
                dataGridView_araclar[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);
            }

            for (int i = 10; i < 13; i++)
            {
                dataGridView_araclar[i, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
                dataGridView_araclar[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);
            }

            //for (int current_row = 0; current_row < dataGridView_araclar.RowCount; current_row++)
            //{
            //    if (dataGridView_araclar[4, current_row].Value != null)
            //    {
            //        if (dataGridView_araclar[5, current_row].Value != null)
            //        {
            //            muayene_kalan_gun_string = dataGridView_araclar[5, current_row].Value.ToString();
            //            muayene_kalan_gun_check = int.TryParse(muayene_kalan_gun_string, out muayene_kalan_gun_int);
            //            if (muayene_kalan_gun_check)
            //            {
            //                muayene_kalan_gun = muayene_kalan_gun_int;
            //            }
            //        }
            //        muayene_string = dataGridView_araclar[4, current_row].Value.ToString();
            //        muayene_check = DateTime.TryParse(muayene_string, out muayene_date);
            //        if (muayene_check)
            //        {
            //            dataGridView_araclar[5, current_row].Value = (muayene_date - DateTime.Today).Days;

            //            if ((muayene_date - DateTime.Today).Days <= 30 && muayene_kalan_gun != (muayene_date - DateTime.Today).Days)
            //            {
            //                dataGridView_olaylar.Rows.Add(dataGridView_araclar.Columns[4].HeaderText, dataGridView_araclar[2, current_row].Value.ToString(), "-", (muayene_date - DateTime.Today).Days.ToString());
            //            }
            //        }
            //        muayene_kalan_gun = (muayene_date - DateTime.Today).Days;
            //    }
            //    if (dataGridView_araclar[6, current_row].Value != null)
            //    {
            //        if (dataGridView_araclar[7, current_row].Value != null)
            //        {
            //            sigorta_kalan_gun_string = dataGridView_araclar[7, current_row].Value.ToString();
            //            sigorta_kalan_gun_check = int.TryParse(sigorta_kalan_gun_string, out sigorta_kalan_gun_int);
            //            if (sigorta_kalan_gun_check)
            //            {
            //                sigorta_kalan_gun = sigorta_kalan_gun_int;
            //            }
            //        }
            //        sigorta_string = dataGridView_araclar[6, current_row].Value.ToString();
            //        sigorta_check = DateTime.TryParse(sigorta_string, out sigorta_date);
            //        if (sigorta_check)
            //        {
            //            dataGridView_araclar[7, current_row].Value = (sigorta_date - DateTime.Today).Days;
            //            if ((sigorta_date - DateTime.Today).Days <= 30 && sigorta_kalan_gun != (sigorta_date - DateTime.Today).Days)
            //            {
            //                dataGridView_olaylar.Rows.Add(dataGridView_araclar.Columns[6].HeaderText, dataGridView_araclar[2, current_row].Value.ToString(), "-", (sigorta_date - DateTime.Today).Days.ToString());
            //            }
            //        }
            //        sigorta_kalan_gun = (sigorta_date - DateTime.Today).Days;
            //    }
            //    if (dataGridView_araclar[8, current_row].Value != null)
            //    {
            //        if (dataGridView_araclar[9, current_row].Value != null)
            //        {
            //            kasko_kalan_gun_string = dataGridView_araclar[9, current_row].Value.ToString();
            //            kasko_kalan_gun_check = int.TryParse(kasko_kalan_gun_string, out kasko_kalan_gun_int);
            //            if (kasko_kalan_gun_check)
            //            {
            //                kasko_kalan_gun = kasko_kalan_gun_int;
            //            }
            //        }
            //        kasko_string = dataGridView_araclar[8, current_row].Value.ToString();
            //        kasko_check = DateTime.TryParse(kasko_string, out kasko_date);
            //        if (kasko_check)
            //        {
            //            dataGridView_araclar[9, current_row].Value = (kasko_date - DateTime.Today).Days;
            //            if ((kasko_date - DateTime.Today).Days <= 30 && kasko_kalan_gun != (kasko_date - DateTime.Today).Days)
            //            {
            //                dataGridView_olaylar.Rows.Add(dataGridView_araclar.Columns[8].HeaderText, dataGridView_araclar[2, current_row].Value.ToString(), "-", (kasko_date - DateTime.Today).Days.ToString());
            //            }
            //        }
            //        kasko_kalan_gun = (kasko_date - DateTime.Today).Days;
            //    }
            //}






        }

        private void dataGridView_araclar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_araclar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView_araclar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void panel_araclar_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_araclar.Visible == true)
            {
                button_araclar.BackColor = Color.FromArgb(19, 19, 19);
                button_araclar.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_araclar.BackColor = Color.FromArgb(45, 45, 45);
                button_araclar.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void panel_bakimlar_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_bakimlar.Visible == true)
            {
                button_bakimlar.BackColor = Color.FromArgb(19, 19, 19);
                button_bakimlar.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_bakimlar.BackColor = Color.FromArgb(45, 45, 45);
                button_bakimlar.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }

        }

        private void panel_faturalar_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_faturalar.Visible == true)
            {
                button_alacaklar.BackColor = Color.FromArgb(19, 19, 19);
                button_alacaklar.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_alacaklar.BackColor = Color.FromArgb(45, 45, 45);
                button_alacaklar.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void dataGridView_bakim_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void dataGridView_araclar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            for (int i = 4; i < 9; i++)
            {
                dataGridView_araclar.Rows[e.RowIndex].Cells[i].ReadOnly = true;
            }

            dataGridView_araclar.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        private void dataGridView_araclar_SizeChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_bakim_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_bakim_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView_bakim_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_faturalar_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void dataGridView_faturalar_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dataGridView_faturalar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_faturalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                panel_faturalar_calendar.Visible = true;
            }
            chosen_row_faturalar = e.RowIndex;
            chosen_column_faturalar = e.ColumnIndex;
        }

        private void main_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }

            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }

            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }
            if(opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }

            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araçlar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araç Gelirler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araç Bakımlar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Müşteriler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Müşteri Bilgiler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Toptancılar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Toptancı Bilgiler");

            string FilePath = SaveLocation + "\\" + "Araçlar";

            FileOperations WriteDataGridAraclar = new FileOperations();
            WriteDataGridAraclar.WriteDataGrid(dataGridView_araclar, FilePath);
            CreateAracGelir(dataGridView_araclar, SaveLocation + "\\" + "Araç Gelirler");
            CreateAracBakim(dataGridView_araclar, SaveLocation + "\\" + "Araç Bakımlar");
            CreateMusteri(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Müşteriler");
            CreateMusteriBilgi(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Müşteri Bilgiler");
            CreateToptanci(comboBox_calisanlar, SaveLocation + "\\" + "Toptancılar");
            CreateToptanciBilgi(comboBox_calisanlar, SaveLocation + "\\" + "Toptancı Bilgiler");

            Application.Exit();
        }



        private void textBox_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer_main_Tick(object sender, EventArgs e)
        {
            textBox_date.Text = DateTime.Now.ToLongTimeString();
            textBox_time.Text = DateTime.Now.ToLongDateString();

            for (int current_row = 0; current_row < dataGridView_araclar.RowCount -1; current_row++)
            {
           
                if (dataGridView_araclar[4, current_row].Value != null)
                {
                    if (dataGridView_araclar[5, current_row].Value != null)
                    {
                        muayene_kalan_gun_string = dataGridView_araclar[5, current_row].Value.ToString();
                        muayene_kalan_gun_check = int.TryParse(muayene_kalan_gun_string, out muayene_kalan_gun_int);
                        if (muayene_kalan_gun_check)
                        {
                            muayene_kalan_gun = muayene_kalan_gun_int;
                        }
                    }
                    muayene_string = dataGridView_araclar[4, current_row].Value.ToString();
                    muayene_check = DateTime.TryParse(muayene_string, out muayene_date);
                    if (muayene_check)
                    {
                        dataGridView_araclar[5, current_row].Value = (muayene_date - DateTime.Today).Days;
                        
                        if ((muayene_date - DateTime.Today).Days <= 30 && muayene_kalan_gun != (muayene_date - DateTime.Today).Days)
                        {
                            
                            dataGridView_olaylar.Rows.Add(dataGridView_araclar.Columns[4].HeaderText, dataGridView_araclar[2, current_row].Value.ToString(), "-", (muayene_date - DateTime.Today).Days.ToString());
                        }
                    }
                    muayene_kalan_gun = (muayene_date - DateTime.Today).Days;
                }
                if (dataGridView_araclar[6, current_row].Value != null)
                {
                    if (dataGridView_araclar[7, current_row].Value != null)
                    {
                        sigorta_kalan_gun_string = dataGridView_araclar[7, current_row].Value.ToString();
                        sigorta_kalan_gun_check = int.TryParse(sigorta_kalan_gun_string, out sigorta_kalan_gun_int);
                        if (sigorta_kalan_gun_check)
                        {
                            sigorta_kalan_gun = sigorta_kalan_gun_int;
                        }
                    }
                    sigorta_string = dataGridView_araclar[6, current_row].Value.ToString();
                    sigorta_check = DateTime.TryParse(sigorta_string, out sigorta_date);
                    if (sigorta_check)
                    {
                        dataGridView_araclar[7, current_row].Value = (sigorta_date - DateTime.Today).Days;
                        if ((sigorta_date - DateTime.Today).Days <= 30 && sigorta_kalan_gun != (sigorta_date - DateTime.Today).Days)
                        {
                            dataGridView_olaylar.Rows.Add(dataGridView_araclar.Columns[6].HeaderText, dataGridView_araclar[2, current_row].Value.ToString(), "-", (sigorta_date - DateTime.Today).Days.ToString());
                        }
                    }
                    sigorta_kalan_gun = (sigorta_date - DateTime.Today).Days;
                }
                if (dataGridView_araclar[8, current_row].Value != null)
                {
                    if (dataGridView_araclar[9, current_row].Value != null)
                    {
                        kasko_kalan_gun_string = dataGridView_araclar[9, current_row].Value.ToString();
                        kasko_kalan_gun_check = int.TryParse(kasko_kalan_gun_string, out kasko_kalan_gun_int);
                        if (kasko_kalan_gun_check)
                        {
                            kasko_kalan_gun = kasko_kalan_gun_int;
                        }
                    }
                    kasko_string = dataGridView_araclar[8, current_row].Value.ToString();
                    kasko_check = DateTime.TryParse(kasko_string, out kasko_date);
                    if (kasko_check)
                    {
                        dataGridView_araclar[9, current_row].Value = (kasko_date - DateTime.Today).Days;
                        if ((kasko_date - DateTime.Today).Days <= 30 && kasko_kalan_gun != (kasko_date - DateTime.Today).Days)
                        {
                            dataGridView_olaylar.Rows.Add(dataGridView_araclar.Columns[8].HeaderText, dataGridView_araclar[2, current_row].Value.ToString(), "-", (kasko_date - DateTime.Today).Days.ToString());
                        }
                    }
                    kasko_kalan_gun = (kasko_date - DateTime.Today).Days;
                }
            }

            foreach(var selected_fatura_index in comboBox_mevcut_sirketler.Items)
            {
                string selected_fatura_index_string = selected_fatura_index.ToString();
                DataGridView current_Fatura_Grid = this.Controls.Find("DataGridView_Fatura_" + selected_fatura_index_string, true).FirstOrDefault() as DataGridView;

                for (int current_row = 0; current_row < current_Fatura_Grid.RowCount; current_row++)
                {

                    if (current_Fatura_Grid[1, current_row].Value != null && current_Fatura_Grid[5, current_row].Value != null)
                    {
                        has_been_inserted = false;

                        fatura_kalan_gun_string = current_Fatura_Grid[1, current_row].Value.ToString();
                        fatura_kalan_gun_check = DateTime.TryParse(fatura_kalan_gun_string, out fatura_kalan_gun_date);
                        if (fatura_kalan_gun_check)
                        {
                            fatura_kalan_gun = (fatura_kalan_gun_date - DateTime.Today).Days;

                            for (int olay_row_index = 0; olay_row_index < dataGridView_olaylar.RowCount; olay_row_index++)
                            {
                                if (dataGridView_olaylar[0, olay_row_index].Value != null && dataGridView_olaylar[1, olay_row_index].Value != null && dataGridView_olaylar[2, olay_row_index].Value != null && dataGridView_olaylar[3, olay_row_index].Value != null)
                                {
                                    if (dataGridView_olaylar[0, olay_row_index].Value.ToString() == current_Fatura_Grid.Columns[2].HeaderText + " (Müşteri)" && dataGridView_olaylar[1, olay_row_index].Value.ToString() == current_Fatura_Grid[0, current_row].Value.ToString() && dataGridView_olaylar[2, olay_row_index].Value.ToString() == current_Fatura_Grid[5, current_row].Value.ToString() && dataGridView_olaylar[3, olay_row_index].Value.ToString() == fatura_kalan_gun.ToString())
                                    {
                                        has_been_inserted = true;
                                    }
                                }

                            }
                        }

                        fatura_string = current_Fatura_Grid[1, current_row].Value.ToString();
                        fatura_check = DateTime.TryParse(fatura_string, out fatura_date);
                        if (fatura_check)
                        {
                            if ((fatura_date - DateTime.Today).Days <= 30 && !has_been_inserted)
                            {
                                dataGridView_olaylar.Rows.Add(current_Fatura_Grid.Columns[2].HeaderText + " (Müşteri)", current_Fatura_Grid[0, current_row].Value.ToString(), current_Fatura_Grid[5, current_row].Value.ToString(), (fatura_date - DateTime.Today).Days.ToString());

                            }
                        }
                        fatura_kalan_gun = (fatura_date - DateTime.Today).Days;

                    }
                }
            }

            foreach(var selected_toptanci_index in comboBox_calisanlar.Items)
            {
                string selected_toptanci_index_string = selected_toptanci_index.ToString();

                DataGridView current_Fatura_Grid = this.Controls.Find("DataGridView_Toptanci_" + selected_toptanci_index_string, true).FirstOrDefault() as DataGridView;

                for (int current_row = 0; current_row < current_Fatura_Grid.RowCount; current_row++)
                {

                    if (current_Fatura_Grid[1, current_row].Value != null && current_Fatura_Grid[5, current_row].Value != null)
                    {
                        has_been_inserted = false;

                        fatura_kalan_gun_string = current_Fatura_Grid[1, current_row].Value.ToString();
                        fatura_kalan_gun_check = DateTime.TryParse(fatura_kalan_gun_string, out fatura_kalan_gun_date);
                        if (fatura_kalan_gun_check)
                        {
                            fatura_kalan_gun = (fatura_kalan_gun_date - DateTime.Today).Days;

                            for (int olay_row_index = 0; olay_row_index < dataGridView_olaylar.RowCount; olay_row_index++)
                            {
                                if (dataGridView_olaylar[0, olay_row_index].Value != null && dataGridView_olaylar[1, olay_row_index].Value != null && dataGridView_olaylar[2, olay_row_index].Value != null && dataGridView_olaylar[3, olay_row_index].Value != null)
                                {
                                    if (dataGridView_olaylar[0, olay_row_index].Value.ToString() == current_Fatura_Grid.Columns[2].HeaderText + " (Çalışan)" && dataGridView_olaylar[1, olay_row_index].Value.ToString() == current_Fatura_Grid[0, current_row].Value.ToString() && dataGridView_olaylar[2, olay_row_index].Value.ToString() == current_Fatura_Grid[5, current_row].Value.ToString() && dataGridView_olaylar[3, olay_row_index].Value.ToString() == fatura_kalan_gun.ToString())
                                    {
                                        has_been_inserted = true;
                                    }
                                }

                            }
                        }

                        fatura_string = current_Fatura_Grid[1, current_row].Value.ToString();
                        fatura_check = DateTime.TryParse(fatura_string, out fatura_date);
                        if (fatura_check)
                        {
                            if ((fatura_date - DateTime.Today).Days <= 30 && !has_been_inserted)
                            {
                                dataGridView_olaylar.Rows.Add(current_Fatura_Grid.Columns[2].HeaderText + " (Çalışan)", current_Fatura_Grid[0, current_row].Value.ToString(), current_Fatura_Grid[5, current_row].Value.ToString(), (fatura_date - DateTime.Today).Days.ToString());

                            }
                        }
                        fatura_kalan_gun = (fatura_date - DateTime.Today).Days;

                    }
                }
            }
            
            
        }

        private void panel_date_time_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_ana_sayfa_Click(object sender, EventArgs e)
        {
            panel_arac_gelir.Visible = false;
            panel_bakimlar.Visible = false;
            panel_araclar.Visible = false;
            panel_faturalar.Visible = false;
            panel_ekle.Visible = false;
            panel_calisanlar.Visible = false;
            panel_calisan_ekle.Visible = false;
            panel_anasayfa.Visible = true;

            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }

            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }

            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }
            if(opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }
            if(opened_araclar_takvim_panel != null)
            {
                opened_araclar_takvim_panel.Visible = false;
            }

            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_toptanci_panel.Visible = false;
            }
            else
            {

            }

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }


        }

        private void panel_anasayfa_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_anasayfa.Visible == true)
            {
                button_ana_sayfa.BackColor = Color.FromArgb(19, 19, 19);
                button_ana_sayfa.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_ana_sayfa.BackColor = Color.FromArgb(45, 45, 45);
                button_ana_sayfa.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void button_tasimacilik_MouseHover(object sender, EventArgs e)
        {

        }

        private void button_tasimacilik_MouseLeave(object sender, EventArgs e)
        {
            button_tasimacilik.FlatAppearance.BorderColor = Color.FromArgb(151, 38, 32);
            button_tasimacilik.ForeColor = Color.FromArgb(151, 38, 32);
        }

        private void button_tasimacilik_MouseEnter(object sender, EventArgs e)
        {
            button_tasimacilik.FlatAppearance.BorderColor = Color.White;
            button_tasimacilik.ForeColor = Color.White;
        }

        private void button_dukkan_MouseEnter(object sender, EventArgs e)
        {
            button_dukkan.FlatAppearance.BorderColor = Color.White;
            button_dukkan.ForeColor = Color.White;
        }

        private void button_dukkan_MouseLeave(object sender, EventArgs e)
        {
            button_dukkan.FlatAppearance.BorderColor = Color.FromArgb(113, 112, 110);
            button_dukkan.ForeColor = Color.FromArgb(113, 112, 110);
        }

        private void button_tasimacilik_MouseDown(object sender, MouseEventArgs e)
        {

        }


        private void dataGridView_araclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 8)
            {
                if (dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    opened_araclar_takvim_panel = panel_takvim;
                    panel_takvim.Visible = true;
                }
                else
                {
                    MessageBox.Show("Lütfen önce aracın plakasını girin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            chosen_row_araclar = e.RowIndex;
            chosen_column_araclar = e.ColumnIndex;

            if (e.ColumnIndex == 10 && dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value != null)
            {

                Panel current_panel = this.Controls.Find("Panel_Gelir_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString(), true).FirstOrDefault() as Panel;



                if (current_panel == null)
                {
                    Panel arac_gelir_panel = new Panel
                    {
                        Name = "Panel_Gelir_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        AccessibleName = "Panel_Gelir_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_arac_gelir.Controls.Add(arac_gelir_panel);
                    panel_arac_gelir.Controls.SetChildIndex(arac_gelir_panel, panel_counter);
                    arac_gelir_panel.Dock = DockStyle.Fill;
                    arac_gelir_panel.BorderStyle = BorderStyle.FixedSingle;
                    arac_gelir_panel.Padding = new Padding(5);
                    arac_gelir_panel.Visible = false;



                    DataGridView arac_gelir_dataGrid = new DataGridView();
                    arac_gelir_dataGrid.Name = "DataGridView_Arac_Gelir_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    arac_gelir_dataGrid.AccessibleName = "DataGridView_Arac_Gelir_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    arac_gelir_panel.Controls.Add(arac_gelir_dataGrid);
                    arac_gelir_panel.Controls.SetChildIndex(arac_gelir_dataGrid, 1);
                    arac_gelir_dataGrid.Dock = DockStyle.Fill;

                    arac_index = e.RowIndex;

                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_arac", "Araç");
                    arac_gelir_dataGrid.Columns[0].ReadOnly = true;
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_tarih", "Tarih");

                    DataGridViewComboBoxColumn musteri_sec = new DataGridViewComboBoxColumn();
                    musteri_sec.Name = "arac_gelir_dataGrid_musteri_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    musteri_sec.HeaderText = "Müşteri";
                    musteri_sec.DefaultCellStyle.NullValue = "";
                    musteri_sec.DataSource = comboBox_mevcut_sirketler.Items;
                    musteri_sec.FlatStyle = FlatStyle.Flat;

                    DataGridViewButtonColumn ekle = new DataGridViewButtonColumn();
                    ekle.Name = "arac_gelir_dataGrid_ekle_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    ekle.HeaderText = "Faturalara Ekle";
                    ekle.DefaultCellStyle.NullValue = "Ekle";
                    ekle.ReadOnly = true;
                    ekle.FlatStyle = FlatStyle.Flat;


                    DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                    sil.Name = "arac_gelir_dataGrid_sil_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sil.HeaderText = "Satırı Sil";
                    sil.DefaultCellStyle.NullValue = "Sil";
                    sil.ReadOnly = true;
                    sil.FlatStyle = FlatStyle.Flat;

                    arac_gelir_dataGrid.Columns.Add(musteri_sec);






                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_guzergah", "Güzergah");
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_birim_fiyat", "Birim Fiyat");
                    arac_gelir_dataGrid.Columns[4].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[4].DefaultCellStyle.Format = "N3";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_net_tonaj", "Net Tonaj");
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_toplam_tutar", "Toplam Tutar");
                    arac_gelir_dataGrid.Columns[6].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[6].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[6].ReadOnly = true;
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_gemi", "Gemi Masrafı");
                    arac_gelir_dataGrid.Columns[7].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[7].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[7].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_otoban", "Otoban Masrafı");
                    arac_gelir_dataGrid.Columns[8].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[8].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[8].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_trafik", "Trafik Masrafı");
                    arac_gelir_dataGrid.Columns[9].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[9].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[9].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_komisyon", "Komisyon");
                    arac_gelir_dataGrid.Columns[10].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[10].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[10].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_diger", "Diğer Masraflar");
                    arac_gelir_dataGrid.Columns[11].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[11].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[11].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_birim_masraf_adblue", "AD Blue Masrafı");
                    arac_gelir_dataGrid.Columns[12].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[12].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[12].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_net_masraf_motorin", "Motorin Masrafı");
                    arac_gelir_dataGrid.Columns[13].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[13].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[13].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_toplam", "Masraflar Toplamı");
                    arac_gelir_dataGrid.Columns[14].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[14].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[14].DefaultCellStyle.NullValue = "0.00";
                    arac_gelir_dataGrid.Columns[14].ReadOnly = true;
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_yakit_birim", "Yakıt Birim Fiyat");
                    arac_gelir_dataGrid.Columns[15].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[15].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_alinan_yakit", "Alınan Yakıt");
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_cikis_km", "Çıkış km");
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_gelis_km", "Geliş km");
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_gidilen_yol", "Toplam Gidilen Yol (km)");
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_tuketim", "Toplam Tüketim (lt/km)");
                    arac_gelir_dataGrid.Columns[20].ReadOnly = true;
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_net_kar", "Net Kâr");
                    arac_gelir_dataGrid.Columns[21].ValueType = System.Type.GetType("System.Decimal");
                    arac_gelir_dataGrid.Columns[21].DefaultCellStyle.Format = "N2";
                    arac_gelir_dataGrid.Columns[21].ReadOnly = true;
                    arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_tahsilat", "Tahsilat Durumu");
                    arac_gelir_dataGrid.Columns.Add(ekle);
                    arac_gelir_dataGrid.Columns.Add(sil);


                    arac_gelir_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                    arac_gelir_dataGrid.RowHeadersVisible = false;
                    arac_gelir_dataGrid.ColumnHeadersVisible = true;
                    arac_gelir_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    arac_gelir_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    arac_gelir_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                    arac_gelir_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                    arac_gelir_dataGrid.DefaultCellStyle.Font = new Font(arac_gelir_dataGrid.Font.FontFamily, 15);
                    arac_gelir_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(arac_gelir_dataGrid.Font.FontFamily, 15);
                    arac_gelir_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    arac_gelir_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                    arac_gelir_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    arac_gelir_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    arac_gelir_dataGrid.EnableHeadersVisualStyles = false;
                    arac_gelir_dataGrid.RowHeadersWidth = 41;
                    arac_gelir_dataGrid.ColumnHeadersHeight = 28;
                    arac_gelir_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    arac_gelir_dataGrid.BorderStyle = BorderStyle.None;
                    panel_counter++;


                    arac_gelir_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(arac_gelir_dataGrid_row_post_paint);
                    arac_gelir_dataGrid.CellClick += new DataGridViewCellEventHandler(arac_gelir_dataGrid_Cell_Click);
                    arac_gelir_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(arac_gelir_dataGrid_Editing);


                    foreach (DataGridViewColumn column in arac_gelir_dataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    arac_gelir_panel.Visible = true;
                    opened_arac_gelir_panel = arac_gelir_panel;
                    button_arac_gelir.PerformClick();
                }
                else
                {
                    arac_index = e.RowIndex;
                    current_panel.Visible = true;
                    opened_arac_gelir_panel = current_panel;
                    button_arac_gelir.PerformClick();
                }

            }

            else if (e.ColumnIndex == 10)
            {
                MessageBox.Show("Lütfen önce araç bilgilerini girin.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (e.ColumnIndex == 11 && dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value != null)
            {
                Panel current_bakim_panel = this.Controls.Find("Panel_Bakim_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString(), true).FirstOrDefault() as Panel;

                if (current_bakim_panel == null)
                {
                    Panel arac_bakim_panel = new Panel
                    {
                        Name = "Panel_Bakim_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        AccessibleName = "Panel_Bakim_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_bakimlar.Controls.Add(arac_bakim_panel);
                    panel_bakimlar.Controls.SetChildIndex(arac_bakim_panel, panel_bakim_counter);
                    arac_bakim_panel.Dock = DockStyle.Fill;
                    arac_bakim_panel.BorderStyle = BorderStyle.FixedSingle;
                    arac_bakim_panel.Padding = new Padding(5);
                    arac_bakim_panel.Visible = false;

                    DataGridView arac_bakim_dataGrid = new DataGridView();
                    arac_bakim_dataGrid.Name = "DataGridView_Bakim_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    arac_bakim_dataGrid.AccessibleName = "DataGridView_Bakim_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    arac_bakim_panel.Controls.Add(arac_bakim_dataGrid);
                    arac_bakim_panel.Controls.SetChildIndex(arac_bakim_dataGrid, 1);
                    arac_bakim_dataGrid.Dock = DockStyle.Fill;



                    DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                    sil.Name = "arac_gelir_dataGrid_sil_" + dataGridView_araclar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    sil.HeaderText = "Satırı Sil";
                    sil.DefaultCellStyle.NullValue = "Sil";
                    sil.ReadOnly = true;
                    sil.FlatStyle = FlatStyle.Flat;

                    arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_arac", "Araç");
                    arac_bakim_dataGrid.Columns["arac_bakim_dataGrid_arac"].ReadOnly = true;
                    arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_tarih", "Tarih");
                    arac_bakim_dataGrid.Columns["arac_bakim_dataGrid_tarih"].ReadOnly = true;
                    arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_km", "KM");
                    arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_usta", "Usta");
                    arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_yapilan_is", "Yapılan İş");
                    arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_tutar", "Tutar");
                    arac_bakim_dataGrid.Columns[5].ValueType = System.Type.GetType("System.Decimal");
                    arac_bakim_dataGrid.Columns[5].DefaultCellStyle.Format = "N2";
                    arac_bakim_dataGrid.Columns.Add(sil);
                    arac_bakim_dataGrid.Columns[6].ReadOnly = true;



                    arac_bakim_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                    arac_bakim_dataGrid.RowHeadersVisible = false;
                    arac_bakim_dataGrid.ColumnHeadersVisible = true;
                    arac_bakim_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    arac_bakim_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    arac_bakim_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                    arac_bakim_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                    arac_bakim_dataGrid.DefaultCellStyle.Font = new Font(arac_bakim_dataGrid.Font.FontFamily, 15);
                    arac_bakim_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(arac_bakim_dataGrid.Font.FontFamily, 15);
                    arac_bakim_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    arac_bakim_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                    arac_bakim_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    arac_bakim_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    arac_bakim_dataGrid.EnableHeadersVisualStyles = false;
                    arac_bakim_dataGrid.RowHeadersWidth = 41;
                    arac_bakim_dataGrid.ColumnHeadersHeight = 28;
                    arac_bakim_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    arac_bakim_dataGrid.BorderStyle = BorderStyle.None;
                    panel_bakim_counter++;

                    arac_bakim_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(arac_bakim_dataGrid_row_post_paint);
                    arac_bakim_dataGrid.CellClick += new DataGridViewCellEventHandler(arac_bakim_dataGrid_Cell_Click);
                    arac_bakim_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(arac_bakim__dataGrid_Editing);

                    foreach (DataGridViewColumn column in arac_bakim_dataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    arac_bakim_panel.Visible = true;
                    opened_arac_bakim_panel = arac_bakim_panel;
                    button_bakimlar.PerformClick();
                }
                else
                {

                    current_bakim_panel.Visible = true;
                    opened_arac_bakim_panel = current_bakim_panel;
                    button_bakimlar.PerformClick();
                }

            }
            else if (e.ColumnIndex == 11)
            {
                MessageBox.Show("Lütfen önce araç bilgilerini girin.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool blank = false;

            for (int i = 1; i < 10; i++)
            {

                if (dataGridView_araclar[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 12 && blank)
            {
                dataGridView_araclar.Rows.Remove(dataGridView_araclar.Rows[e.RowIndex]);
            }


        }



        private void arac_gelir_dataGrid_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            bool numerical_bool = false;

            for (int i = 4; i < 20; i++)
            {
                if (currentGrid.CurrentCell.ColumnIndex == i)
                {
                    numerical_bool = true;
                }
            }

            if (numerical_bool)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
            && e.KeyChar != ',')
            {
                e.Handled = true;
            }


            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void arac_bakim__dataGrid_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (currentGrid.CurrentCell.ColumnIndex == 2 || currentGrid.CurrentCell.ColumnIndex == 5)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void arac_bakim_dataGrid_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            currentGrid[0, e.RowIndex].Value = dataGridView_araclar.Rows[arac_index].Cells[2].Value.ToString();

            for (int i = 0; i < 5; i += 2)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            for (int i = 1; i < 5; i += 2)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 61, 74);
            }

            currentGrid[5, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            currentGrid[5, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            currentGrid[6, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[6, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

        }

        private void arac_bakim_dataGrid_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {

                opened_bakim_takvim_panel = panel_takvim_bakim;
                panel_takvim_bakim.Visible = true;
            }
            else
            {

            }

            chosen_row_bakim = e.RowIndex;
            chosen_column_bakim = e.ColumnIndex;

            bool blank = false;

            for (int i = 1; i < 6; i++)
            {

                if (currentGrid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 6 && blank && currentGrid.RowCount > 1)
            {
                currentGrid.Rows.Remove(currentGrid.Rows[e.RowIndex]);
            }
        }

        private void arac_gelir_dataGrid_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1)
            {

                opened_gelir_takvim_panel = panel_takvim_arac_gelir;
                panel_takvim_arac_gelir.Visible = true;
            }
            else
            {

            }

            chosen_row_GelirGider = e.RowIndex;
            chosen_column_GelirGider = e.ColumnIndex;

            if (e.ColumnIndex == 23 && currentGrid[1, e.RowIndex].Value != null && currentGrid[2, e.RowIndex].Value != null && currentGrid[6, e.RowIndex].Value != null)
            {
                DataGridView fatura_grid = this.Controls.Find("DataGridView_Fatura_" + currentGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), true).FirstOrDefault() as DataGridView;
                int fatura_counter = 0;

                if (fatura_grid != null)
                {
                    fatura_grid.Rows.Add();
                    while (fatura_grid[1, fatura_counter].Value != null || fatura_grid[2, fatura_counter].Value != null || fatura_grid[3, fatura_counter].Value != null || fatura_grid[4, fatura_counter].Value != null || fatura_grid[5, fatura_counter].Value != null || fatura_grid[6, fatura_counter].Value != null)
                    {
                        fatura_counter++;
                    }

                    fatura_grid[1, fatura_counter].Value = currentGrid[1, e.RowIndex].Value.ToString();
                    fatura_grid[3, fatura_counter].Value = currentGrid[6, e.RowIndex].Value.ToString();
                    MessageBox.Show("Bilgiler başarıyla fatura paneline aktarıldı.", "Bilgilendirme",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (e.ColumnIndex == 23)
            {
                MessageBox.Show("Lütfen önce gerekli bilgiliri giriniz.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bool blank = false;

            for (int i = 1; i < 23; i++)
            {
                if (i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14)
                {
                    continue;
                }
                if (currentGrid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 24 && blank && currentGrid.RowCount > 1)
            {
                currentGrid.Rows.Remove(currentGrid.Rows[e.RowIndex]);
            }
        }




        private void arac_gelir_dataGrid_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            currentGrid[0, e.RowIndex].Value = dataGridView_araclar.Rows[arac_index].Cells[2].Value.ToString();

            for (int i = 0; i < 4; i++)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            for (int i = 4; i < 6; i++)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 61, 74);
            }

            currentGrid[6, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            currentGrid[6, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            for (int i = 7; i < 14; i++)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);
            }

            currentGrid[14, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            currentGrid[14, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);




            for (int i = 15; i < 20; i++)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            currentGrid[20, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            currentGrid[20, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            currentGrid[21, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[21, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            currentGrid[22, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
            currentGrid[22, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 51, 74);

            currentGrid[23, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[23, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            currentGrid[24, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[24, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);





            if (currentGrid[7, e.RowIndex].Value != null || currentGrid[8, e.RowIndex].Value != null || currentGrid[9, e.RowIndex].Value != null || currentGrid[10, e.RowIndex].Value != null || currentGrid[11, e.RowIndex].Value != null || currentGrid[12, e.RowIndex].Value != null || currentGrid[13, e.RowIndex].Value != null)
            {

                if (currentGrid[7, e.RowIndex].Value != null)
                {
                    masraf_1 = currentGrid[7, e.RowIndex].Value.ToString();
                }
                else
                {
                    masraf_1 = "0";
                }
                if (currentGrid[8, e.RowIndex].Value != null)
                {
                    masraf_2 = currentGrid[8, e.RowIndex].Value.ToString();
                }
                else
                {
                    masraf_2 = "0";
                }
                if (currentGrid[9, e.RowIndex].Value != null)
                {
                    masraf_3 = currentGrid[9, e.RowIndex].Value.ToString();
                }
                else
                {
                    masraf_3 = "0";
                }
                if (currentGrid[10, e.RowIndex].Value != null)
                {
                    masraf_4 = currentGrid[10, e.RowIndex].Value.ToString();
                }
                else
                {
                    masraf_4 = "0";
                }
                if (currentGrid[11, e.RowIndex].Value != null)
                {
                    masraf_5 = currentGrid[11, e.RowIndex].Value.ToString();
                }
                else
                {
                    masraf_5 = "0";
                }
                if (currentGrid[12, e.RowIndex].Value != null)
                {
                    masraf_6 = currentGrid[12, e.RowIndex].Value.ToString();
                }
                else
                {
                    masraf_6 = "0";
                }
                if (currentGrid[13, e.RowIndex].Value != null)
                {
                    masraf_7 = currentGrid[13, e.RowIndex].Value.ToString();
                }
                else
                {
                    masraf_7 = "0";
                }


                masraf_1_check = decimal.TryParse(masraf_1, out masraf_1_int);
                masraf_2_check = decimal.TryParse(masraf_2, out masraf_2_int);
                masraf_3_check = decimal.TryParse(masraf_3, out masraf_3_int);
                masraf_4_check = decimal.TryParse(masraf_4, out masraf_4_int);
                masraf_5_check = decimal.TryParse(masraf_5, out masraf_5_int);
                masraf_6_check = decimal.TryParse(masraf_6, out masraf_6_int);
                masraf_7_check = decimal.TryParse(masraf_7, out masraf_7_int);

                if (masraf_1_check || masraf_2_check || masraf_3_check || masraf_4_check || masraf_5_check || masraf_6_check || masraf_7_check)
                {
                    toplam_masraf = masraf_1_int + masraf_2_int + masraf_3_int + masraf_4_int + masraf_5_int + masraf_6_int + masraf_7_int;
                    currentGrid[14, e.RowIndex].Value = toplam_masraf;
                }

            }

            if (currentGrid[4, e.RowIndex].Value != null && currentGrid[5, e.RowIndex].Value != null)
            {
                birim_fiyat = currentGrid[4, e.RowIndex].Value.ToString();
                net_tonaj = currentGrid[5, e.RowIndex].Value.ToString();

                birim_fiyat_check = decimal.TryParse(birim_fiyat, out birim_fiyat_int);
                net_tonaj_check = decimal.TryParse(net_tonaj, out net_tonaj_int);


                if (birim_fiyat_check && net_tonaj_check)
                {
                    kdv = (birim_fiyat_int * net_tonaj_int) * (18M / 100M);
                    tevkifat = kdv * (20M / 100M);

                    toplam_tutar = (birim_fiyat_int * net_tonaj_int) + kdv - tevkifat;
                    currentGrid[6, e.RowIndex].Value = toplam_tutar;
                }
            }

            if (currentGrid[6, e.RowIndex].Value != null || currentGrid[14, e.RowIndex].Value != null)
            {
                if (currentGrid[6, e.RowIndex].Value != null)
                {
                    gelir = currentGrid[6, e.RowIndex].Value.ToString();
                }

                if (currentGrid[14, e.RowIndex].Value != null)
                {
                    gider = currentGrid[14, e.RowIndex].Value.ToString();
                }


                gelir_check = decimal.TryParse(gelir, out gelir_int);
                gider_check = decimal.TryParse(gider, out gider_int);


                if (gelir_check && gider_check)
                {
                    net_kar = gelir_int - gider_int;
                    currentGrid[21, e.RowIndex].Value = net_kar;
                }
                else if (gelir_check)
                {
                    currentGrid[21, e.RowIndex].Value = gelir_int;
                }
                else if (gider_check)
                {
                    currentGrid[21, e.RowIndex].Value = -gider_int;
                }
            }

            if (currentGrid[17, e.RowIndex].Value != null && currentGrid[18, e.RowIndex].Value != null)
            {
                cikis_km = currentGrid[17, e.RowIndex].Value.ToString();
                gelis_km = currentGrid[18, e.RowIndex].Value.ToString();

                cikis_km_check = float.TryParse(cikis_km, out cikis_km_int);
                gelis_km_check = float.TryParse(gelis_km, out gelis_km_int);

                if (cikis_km_check && gelis_km_check)
                {
                    gidilen_km = gelis_km_int - cikis_km_int;

                    currentGrid[19, e.RowIndex].Value = gidilen_km.ToString();
                }

            }

            if (currentGrid[16, e.RowIndex].Value != null && currentGrid[17, e.RowIndex].Value != null && currentGrid[18, e.RowIndex].Value != null)
            {

                alinan_yakit = currentGrid[16, e.RowIndex].Value.ToString();
                cikis_km = currentGrid[17, e.RowIndex].Value.ToString();
                gelis_km = currentGrid[18, e.RowIndex].Value.ToString();


                alinan_yakit_check = float.TryParse(alinan_yakit, out alinan_yakit_int);
                cikis_km_check = float.TryParse(cikis_km, out cikis_km_int);
                gelis_km_check = float.TryParse(gelis_km, out gelis_km_int);


                if (alinan_yakit_check && cikis_km_check && gelis_km_check)
                {
                    gidilen_km = gelis_km_int - cikis_km_int;

                    tuketim = (alinan_yakit_int / gidilen_km) * 100;

                    currentGrid[20, e.RowIndex].Value = "% " + tuketim.ToString();
                }


            }
            if (currentGrid[15, e.RowIndex].Value != null && currentGrid[16, e.RowIndex].Value != null)
            {

                alinan_yakit = currentGrid[16, e.RowIndex].Value.ToString();
                yakit_birim_fiyat = currentGrid[15, e.RowIndex].Value.ToString();



                alinan_yakit_check = float.TryParse(alinan_yakit, out alinan_yakit_int);
                yakit_birim_fiyat_check = float.TryParse(yakit_birim_fiyat, out yakit_birim_fiyat_int);



                if (alinan_yakit_check && yakit_birim_fiyat_check)
                {
                    tuketim = alinan_yakit_int * yakit_birim_fiyat_int;
                    currentGrid[13, e.RowIndex].Value = tuketim.ToString();
                }




            }
        }


        private void button_takvim_Click(object sender, EventArgs e)
        {
            selectedDate = monthCalendar1.SelectionRange.Start.ToShortDateString();
            dataGridView_araclar.Rows[chosen_row_araclar].Cells[chosen_column_araclar].Value = selectedDate;

            panel_takvim.Visible = false;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

        }

        private void dataGridView_olaylar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_araclar_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dataGridView_olaylar_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView_olaylar[0, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            dataGridView_olaylar[0, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            dataGridView_olaylar[1, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
            dataGridView_olaylar[1, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);

            dataGridView_olaylar[2, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            dataGridView_olaylar[2, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            dataGridView_olaylar[3, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            dataGridView_olaylar[3, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            dataGridView_olaylar[4, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            dataGridView_olaylar[4, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);
            dataGridView_olaylar[4, e.RowIndex].Style.NullValue = "Sil";

        }

        private void button_tasimacilik_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {



        }

        private void dataGridView_faturalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataGridView current_fatura_grid = this.Controls.Find("DataGridView_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as DataGridView;

            if (current_fatura_grid != null)
            {
                selectedDateFatura = monthCalendar2.SelectionRange.Start.ToShortDateString();
                current_fatura_grid.Rows[chosen_row_faturalar].Cells[chosen_column_faturalar].Value = selectedDateFatura;


            }
            else
            {

            }

            panel_faturalar_calendar.Visible = false;
        }

        private void dataGridView_faturalar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_faturalar_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {


        }

        private void dataGridView_faturalar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_dukkan_Click(object sender, EventArgs e)
        {
            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }

            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }

            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }

            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }
            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }


            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araçlar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araç Gelirler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Araç Bakımlar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Müşteriler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Müşteri Bilgiler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Toptancılar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Toptancı Bilgiler");

            string FilePath = SaveLocation + "\\" + "Araçlar";

            FileOperations WriteDataGridAraclar = new FileOperations();
            WriteDataGridAraclar.WriteDataGrid(dataGridView_araclar, FilePath);
            CreateAracGelir(dataGridView_araclar, SaveLocation + "\\" + "Araç Gelirler");
            CreateAracBakim(dataGridView_araclar, SaveLocation + "\\" + "Araç Bakımlar");
            CreateMusteri(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Müşteriler");
            CreateMusteriBilgi(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Müşteri Bilgiler");
            CreateToptanci(comboBox_calisanlar, SaveLocation + "\\" + "Toptancılar");
            CreateToptanciBilgi(comboBox_calisanlar, SaveLocation + "\\" + "Toptancı Bilgiler");

            new Dukkan().Show();
            this.Hide();
        }

        private void dataGridView_olaylar_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_bakim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
        }

        private void button_arac_gelir_Click(object sender, EventArgs e)
        {

            panel_bakimlar.Visible = false;
            panel_faturalar.Visible = false;
            panel_anasayfa.Visible = false;
            panel_araclar.Visible = false;
            panel_ekle.Visible = false;
            panel_calisanlar.Visible = false;
            panel_calisan_ekle.Visible = false;
            panel_arac_gelir.Visible = true;

            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }



            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }

            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = false;
            }
            else
            {

            }

            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }
            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_toptanci_panel.Visible = false;
            }
            else
            {

            }

        }

        private void panel_arac_gelir_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_arac_gelir.Visible == true)
            {
                button_arac_gelir.BackColor = Color.FromArgb(19, 19, 19);
                button_arac_gelir.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_arac_gelir.BackColor = Color.FromArgb(45, 45, 45);
                button_arac_gelir.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_takvim_arac_gelir.Visible = false;
        }

        private void monthCalendar_arac_gelir_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar_arac_gelir_DateSelected(object sender, DateRangeEventArgs e)
        {
            DataGridView current_grid = this.Controls.Find("DataGridView_Arac_Gelir_" + dataGridView_araclar.Rows[arac_index].Cells[2].Value.ToString(), true).FirstOrDefault() as DataGridView;

            if (current_grid != null)
            {
                selectedDateGelirGider = monthCalendar_arac_gelir.SelectionRange.Start.ToShortDateString();
                current_grid.Rows[chosen_row_GelirGider].Cells[chosen_column_GelirGider].Value = selectedDateGelirGider;



            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_takvim_bakim.Visible = false;
        }

        private void monthCalendar_bakim_DateSelected(object sender, DateRangeEventArgs e)
        {
            DataGridView current_bakim_grid = this.Controls.Find("DataGridView_Bakim_" + dataGridView_araclar.Rows[arac_index].Cells[2].Value.ToString(), true).FirstOrDefault() as DataGridView;

            if (current_bakim_grid != null)
            {
                selectedDatebakim = monthCalendar_bakim.SelectionRange.Start.ToShortDateString();
                current_bakim_grid.Rows[chosen_row_bakim].Cells[chosen_column_bakim].Value = selectedDatebakim;



            }
            else
            {

            }
        }

        private void button_alacaklar_Click(object sender, EventArgs e)
        {
            panel_arac_gelir.Visible = false;
            panel_bakimlar.Visible = false;
            panel_araclar.Visible = false;
            panel_faturalar.Visible = false;
            panel_anasayfa.Visible = false;
            panel_ekle.Visible = false;
            panel_calisanlar.Visible = false;
            panel_calisan_ekle.Visible = false;
            panel_faturalar.Visible = true;

            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }

            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }

            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }
            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_toptanci_panel.Visible = false;
            }
            else
            {

            }
        }

        private void panel_ekle_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_ekle.Visible == true)
            {
                button_musteri_ekle.BackColor = Color.FromArgb(19, 19, 19);
                button_musteri_ekle.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_musteri_ekle.BackColor = Color.FromArgb(45, 45, 45);
                button_musteri_ekle.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void button_sirket_ekle_Click(object sender, EventArgs e)
        {
            if (textBox_sirket_ekle.Text.Length > 0)
            {
                comboBox_mevcut_sirketler.Items.Add(textBox_sirket_ekle.Text);


                Panel sirket_panel = new Panel
                {
                    Name = "Panel_Fatura_" + textBox_sirket_ekle.Text,
                    AccessibleName = "Panel_Fatura_" + textBox_sirket_ekle.Text,
                    BackColor = Color.FromArgb(45, 45, 45)
                };

                panel_faturalar.Controls.Add(sirket_panel);
                panel_faturalar.Controls.SetChildIndex(sirket_panel, panel_musteri_counter);
                sirket_panel.Dock = DockStyle.Fill;
                sirket_panel.BorderStyle = BorderStyle.FixedSingle;
                sirket_panel.Padding = new Padding(5);
                sirket_panel.Visible = false;

                DataGridView sirket_dataGrid = new DataGridView();
                sirket_dataGrid.Name = "DataGridView_Fatura_" + textBox_sirket_ekle.Text;
                sirket_dataGrid.AccessibleName = "DataGridView_Fatura_" + textBox_sirket_ekle.Text;
                sirket_panel.Controls.Add(sirket_dataGrid);
                sirket_panel.Controls.SetChildIndex(sirket_dataGrid, 1);
                sirket_dataGrid.Dock = DockStyle.Fill;

                DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                sil.Name = "arac_gelir_dataGrid_sil_" + textBox_sirket_ekle.Text;
                sil.HeaderText = "Satırı Sil";
                sil.DefaultCellStyle.NullValue = "Sil";
                sil.ReadOnly = true;
                sil.FlatStyle = FlatStyle.Flat;

                DataGridViewButtonColumn bilgi = new DataGridViewButtonColumn();
                bilgi.Name = "arac_gelir_dataGrid_bilgi_" + textBox_sirket_ekle.Text;
                bilgi.HeaderText = "Müşteri Bilgisi";
                bilgi.DefaultCellStyle.NullValue = "Seç";
                bilgi.ReadOnly = true;
                bilgi.FlatStyle = FlatStyle.Flat;

                sirket_dataGrid.Columns.Add("DataGridView_Fatura_musteri", "Müşteri");
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_tarih", "Tarih");
                sirket_dataGrid.Columns["DataGridView_Fatura_tarih"].ReadOnly = true;
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_fatura", "Fatura");
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_tutar", "Tutar");
                sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_odenen", "Ödenen");
                sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_kalan", "Kalan");
                sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ReadOnly = true;
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_banka", "Banka");
                sirket_dataGrid.Columns.Add(bilgi);
                sirket_dataGrid.Columns.Add(sil);
                sirket_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                sirket_dataGrid.RowHeadersVisible = false;
                sirket_dataGrid.ColumnHeadersVisible = true;
                sirket_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                sirket_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                sirket_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                sirket_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                sirket_dataGrid.DefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                sirket_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                sirket_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                sirket_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                sirket_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                sirket_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                sirket_dataGrid.EnableHeadersVisualStyles = false;
                sirket_dataGrid.RowHeadersWidth = 41;
                sirket_dataGrid.ColumnHeadersHeight = 28;
                sirket_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                sirket_dataGrid.BorderStyle = BorderStyle.None;


                sirket_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Fatura_row_post_paint);
                sirket_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Fatura_Cell_Click);
                sirket_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(sirket_dataGrid_Editing);


                foreach (DataGridViewColumn column in sirket_dataGrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }



                textBox_sirket_ekle.Text = null;
                button_tebrikler_close.Visible = true;
                textBox_tebrikler.ForeColor = Color.PaleGreen;
                textBox_tebrikler.Text = "Müşteri ismi başarıyla eklendi.";



            }
        }

        private void sirket_dataGrid_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            bool numerical_bool = false;

            for (int i = 3; i < 5; i++)
            {
                if (currentGrid.CurrentCell.ColumnIndex == i)
                {
                    numerical_bool = true;
                }
            }

            if (numerical_bool)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void DataGridView_Fatura_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView current_Fatura_Grid = (DataGridView)sender;

            current_Fatura_Grid[0, e.RowIndex].Value = comboBox_mevcut_sirketler.Text;


            if (current_Fatura_Grid[3, e.RowIndex].Value != null && current_Fatura_Grid[4, e.RowIndex].Value != null)
            {
                onceki_kalanlar = 0;

                for(int Current_Row = 0; Current_Row < e.RowIndex; Current_Row++)
                {
                    if(current_Fatura_Grid[5, Current_Row].Value != null)
                    {
                        onceki_kalan_string = current_Fatura_Grid[5, Current_Row].Value.ToString();
                        onceki_kalan_check = decimal.TryParse(onceki_kalan_string, out onceki_kalan_decimal);
                        if(onceki_kalan_check)
                        {
                            onceki_kalanlar += onceki_kalan_decimal;
                        }
                    }
                }
                tutar = current_Fatura_Grid[3, e.RowIndex].Value.ToString();
                odenen = current_Fatura_Grid[4, e.RowIndex].Value.ToString();
                tutar_dolu = decimal.TryParse(tutar, out tutar_int);
                odenen_dolu = decimal.TryParse(odenen, out odenen_int);


                if (tutar_dolu && odenen_dolu)
                {
                    kalan = tutar_int - odenen_int;
                    
                    current_Fatura_Grid[5, e.RowIndex].Value = kalan + onceki_kalanlar;
                }
            }
            for (int i = 0; i < 4; i += 2)
            {
                current_Fatura_Grid[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                current_Fatura_Grid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            current_Fatura_Grid[1, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
            current_Fatura_Grid[1, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 61, 74);

            current_Fatura_Grid[3, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
            current_Fatura_Grid[3, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);

            current_Fatura_Grid[4, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[4, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[5, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            current_Fatura_Grid[5, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            current_Fatura_Grid[6, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            current_Fatura_Grid[6, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            current_Fatura_Grid[7, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[7, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[8, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[8, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            //for (int current_row = 0; current_row < current_Fatura_Grid.RowCount; current_row++)
            //{

            //    if (current_Fatura_Grid[1, current_row].Value != null && current_Fatura_Grid[5, current_row].Value != null)
            //    {
            //        has_been_inserted = false;

            //        fatura_kalan_gun_string = current_Fatura_Grid[1, current_row].Value.ToString();
            //        fatura_kalan_gun_check = DateTime.TryParse(fatura_kalan_gun_string, out fatura_kalan_gun_date);
            //        if (fatura_kalan_gun_check)
            //        {
            //            fatura_kalan_gun = (fatura_kalan_gun_date - DateTime.Today).Days;

            //            for (int olay_row_index = 0; olay_row_index < dataGridView_olaylar.RowCount; olay_row_index++)
            //            {
            //                if (dataGridView_olaylar[0, olay_row_index].Value != null && dataGridView_olaylar[1, olay_row_index].Value != null && dataGridView_olaylar[2, olay_row_index].Value != null && dataGridView_olaylar[3, olay_row_index].Value != null)
            //                {
            //                    if (dataGridView_olaylar[0, olay_row_index].Value.ToString() == current_Fatura_Grid.Columns[2].HeaderText && dataGridView_olaylar[1, olay_row_index].Value.ToString() == current_Fatura_Grid[0, current_row].Value.ToString() && dataGridView_olaylar[2, olay_row_index].Value.ToString() == current_Fatura_Grid[5, current_row].Value.ToString() && dataGridView_olaylar[3, olay_row_index].Value.ToString() == fatura_kalan_gun.ToString())
            //                    {
            //                        has_been_inserted = true;
            //                    }
            //                }

            //            }
            //        }

            //        fatura_string = current_Fatura_Grid[1, current_row].Value.ToString();
            //        fatura_check = DateTime.TryParse(fatura_string, out fatura_date);
            //        if (fatura_check)
            //        {
            //            if ((fatura_date - DateTime.Today).Days <= 30 && !has_been_inserted)
            //            {
            //                dataGridView_olaylar.Rows.Add(current_Fatura_Grid.Columns[2].HeaderText, current_Fatura_Grid[0, current_row].Value.ToString(), current_Fatura_Grid[5, current_row].Value.ToString(), (fatura_date - DateTime.Today).Days.ToString());

            //            }
            //        }
            //        fatura_kalan_gun = (fatura_date - DateTime.Today).Days;

            //    }
            //}
        }

        private void DataGridView_Fatura_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView current_Fatura_Grid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1 && current_Fatura_Grid[5, e.RowIndex].Value != null)
            {

                opened_fatura_takvim_panel = panel_faturalar_calendar;
                panel_faturalar_calendar.Visible = true;
            }
            else
            {

            }

            if (e.ColumnIndex == 1 && current_Fatura_Grid[5, e.RowIndex].Value == null)
            {
                MessageBox.Show("Lütfen önce kalan tutarı belirleyin.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            chosen_row_faturalar = e.RowIndex;
            chosen_column_faturalar = e.ColumnIndex;

            bool blank = false;

            for (int i = 1; i < 7; i++)
            {

                if (current_Fatura_Grid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 8 && blank && current_Fatura_Grid.RowCount > 1)
            {
                current_Fatura_Grid.Rows.Remove(current_Fatura_Grid.Rows[e.RowIndex]);
            }

            if (e.ColumnIndex == 7)
            {
                Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;
                Panel current_fatura_bilgi_panel = this.Controls.Find("Panel_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;


                if (current_fatura_bilgi_panel == null)
                {
                    Panel sirket_bilgi_panel = new Panel
                    {
                        Name = "Panel_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text,
                        AccessibleName = "Panel_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text,
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_faturalar.Controls.Add(sirket_bilgi_panel);
                    panel_faturalar.Controls.SetChildIndex(sirket_bilgi_panel, panel_musteri_counter);
                    sirket_bilgi_panel.Dock = DockStyle.Fill;
                    sirket_bilgi_panel.BorderStyle = BorderStyle.FixedSingle;
                    sirket_bilgi_panel.Padding = new Padding(5);
                    sirket_bilgi_panel.Visible = false;


                    DataGridView sirket_bilgi_dataGrid = new DataGridView();
                    sirket_bilgi_dataGrid.Name = "DataGridView_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text;
                    sirket_bilgi_dataGrid.AccessibleName = "DataGridView_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text;
                    sirket_bilgi_panel.Controls.Add(sirket_bilgi_dataGrid);
                    sirket_bilgi_panel.Controls.SetChildIndex(sirket_bilgi_dataGrid, 1);
                    sirket_bilgi_dataGrid.Dock = DockStyle.Fill;

                    DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                    sil.Name = "arac_gelir_dataGrid_sil_" + textBox_sirket_ekle.Text;
                    sil.HeaderText = "Satırı Sil";
                    sil.DefaultCellStyle.NullValue = "Sil";
                    sil.ReadOnly = true;
                    sil.FlatStyle = FlatStyle.Flat;

                    DataGridViewButtonColumn geri_don = new DataGridViewButtonColumn();
                    geri_don.Name = "arac_gelir_dataGrid_geri_don_" + textBox_sirket_ekle.Text;
                    geri_don.HeaderText = "Geri Dön";
                    geri_don.DefaultCellStyle.NullValue = "Seç";
                    geri_don.ReadOnly = true;
                    geri_don.FlatStyle = FlatStyle.Flat;

                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_musteri", "Müşteri");
                    sirket_bilgi_dataGrid.Columns[0].ReadOnly = true;
                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_telefon", "Telefon");

                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_adres", "Adres");

                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_banka", "Banka Bilgileri");
                    sirket_bilgi_dataGrid.Columns.Add(geri_don);
                    sirket_bilgi_dataGrid.Columns.Add(sil);


                    sirket_bilgi_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                    sirket_bilgi_dataGrid.RowHeadersVisible = false;
                    sirket_bilgi_dataGrid.ColumnHeadersVisible = true;

                    sirket_bilgi_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    sirket_bilgi_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    sirket_bilgi_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                    sirket_bilgi_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                    sirket_bilgi_dataGrid.DefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                    sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                    sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                    sirket_bilgi_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    sirket_bilgi_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    sirket_bilgi_dataGrid.EnableHeadersVisualStyles = false;

                    sirket_bilgi_dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    sirket_bilgi_dataGrid.ColumnHeadersHeight = 28;
                    sirket_bilgi_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    sirket_bilgi_dataGrid.BorderStyle = BorderStyle.None;




                    sirket_bilgi_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Fatura_Bilgi_row_post_paint);
                    sirket_bilgi_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Fatura_Bilgi_Cell_Click);
                    sirket_bilgi_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(sirket_bilgi_dataGrid_Editing);


                    foreach (DataGridViewColumn column in sirket_bilgi_dataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    current_fatura_panel.Visible = false;
                    sirket_bilgi_panel.Visible = true;
                }
                else
                {
                    current_fatura_panel.Visible = false;
                    current_fatura_bilgi_panel.Visible = true;
                }

            }

        }

        private void DataGridView_Fatura_Bilgi_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView current_Fatura_Grid = (DataGridView)sender;

            current_Fatura_Grid[0, e.RowIndex].Value = comboBox_mevcut_sirketler.Text;

            current_Fatura_Grid[0, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
            current_Fatura_Grid[0, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);

            current_Fatura_Grid[1, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[1, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[2, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            current_Fatura_Grid[2, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            current_Fatura_Grid[3, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            current_Fatura_Grid[3, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            current_Fatura_Grid[4, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[4, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[5, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[5, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);
        }

        private void DataGridView_Fatura_Bilgi_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + currentGrid[0, e.RowIndex].Value.ToString(), true).FirstOrDefault() as Panel;
            Panel current_fatura_bilgi_panel = this.Controls.Find("Panel_Fatura_Bilgi_" + currentGrid[0, e.RowIndex].Value.ToString(), true).FirstOrDefault() as Panel;

            

            bool blank = false;

            for (int i = 1; i < 4; i++)
            {

                if (currentGrid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 5 && blank && currentGrid.RowCount > 1)
            {
                currentGrid.Rows.Remove(currentGrid.Rows[e.RowIndex]);
            }
            if (e.ColumnIndex == 4 && current_fatura_panel != null)
            {
                current_fatura_bilgi_panel.Visible = false;
                current_fatura_panel.Visible = true;
            }
        }

        private void sirket_bilgi_dataGrid_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void button_tebrikler_close_Click(object sender, EventArgs e)
        {
            button_tebrikler_close.Visible = false;
            textBox_tebrikler.Text = "Aşağıdaki açılır listeden müşteri seçiniz.";
            textBox_tebrikler.ForeColor = Color.White;
        }

        private void comboBox_mevcut_sirketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel current_fatura_panel = this.Controls.Find("Panel_Fatura_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = true;
            }
            else
            {

            }

            button_alacaklar.PerformClick();
        }

        private void dataGridView_olaylar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 4 && (dataGridView_olaylar[0, e.RowIndex].Value != null || dataGridView_olaylar[1, e.RowIndex].Value != null || dataGridView_olaylar[2, e.RowIndex].Value != null))
            {
                dataGridView_olaylar.Rows.Remove(this.dataGridView_olaylar.Rows[e.RowIndex]);
            }
        }

        private void textBox_ekle_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateAracGelir(DataGridView Grid, string Path)
        {
            for (int CurrentRow = 0; CurrentRow < Grid.Rows.Count - 1; CurrentRow++)
            {
                for (int CurrentColumn = 0; CurrentColumn < Grid.Columns.Count; CurrentColumn++)
                {
                    if (CurrentColumn == 2 && Grid[CurrentColumn, CurrentRow].Value != null)
                    {
                        Panel current_panel = this.Controls.Find("Panel_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString(), true).FirstOrDefault() as Panel;
                        if (current_panel != null)
                        {
                            DataGridView current_grid = this.Controls.Find("DataGridView_Arac_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString(), true).FirstOrDefault() as DataGridView;
                            if (current_grid != null)
                            {
                                Directory.CreateDirectory(Path + "\\" + "Panel_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString());
                                Directory.CreateDirectory(Path + "\\" + "Panel_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Arac_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString());
                                for (int CurrentGelirRow = 0; CurrentGelirRow < current_grid.Rows.Count - 1; CurrentGelirRow++)
                                {
                                    Directory.CreateDirectory(Path + "\\" + "Panel_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Arac_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + CurrentGelirRow.ToString());
                                    using (FileStream fs = File.Create(Path + "\\" + "Panel_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Arac_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt"))
                                    {

                                    }
                                    StreamWriter sw = new StreamWriter(Path + "\\" + "Panel_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Arac_Gelir_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt");
                                    for (int CurrentGelirColumn = 0; CurrentGelirColumn < current_grid.Columns.Count; CurrentGelirColumn++)
                                    {
                                        if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && (CurrentGelirColumn == 7 || CurrentGelirColumn == 8 || CurrentGelirColumn == 9 || CurrentGelirColumn == 10 || CurrentGelirColumn == 11 || CurrentGelirColumn == 12 || CurrentGelirColumn == 13 || CurrentGelirColumn == 14))
                                        {
                                            sw.WriteLine("0.00");
                                        }

                                        else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 23)
                                        {
                                            sw.WriteLine("Ekle");
                                        }
                                        else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 24)
                                        {
                                            sw.WriteLine("Sil");
                                        }

                                        else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null)
                                        {
                                            sw.WriteLine("");
                                        }



                                        else
                                        {

                                            sw.WriteLine(current_grid[CurrentGelirColumn, CurrentGelirRow].Value.ToString());
                                        }
                                    }
                                    sw.Close();
                                }

                            }


                        }
                    }
                }
            }
        }

        private void CreateAracBakim(DataGridView Grid, string Path)
        {
            for (int CurrentRow = 0; CurrentRow < Grid.Rows.Count - 1; CurrentRow++)
            {
                for (int CurrentColumn = 0; CurrentColumn < Grid.Columns.Count; CurrentColumn++)
                {
                    if (CurrentColumn == 2 && Grid[CurrentColumn, CurrentRow].Value != null)
                    {
                        Panel current_panel = this.Controls.Find("Panel_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString(), true).FirstOrDefault() as Panel;
                        if (current_panel != null)
                        {
                            Console.WriteLine("Bakım Paneli Null Değil.");
                            DataGridView current_grid = this.Controls.Find("DataGridView_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString(), true).FirstOrDefault() as DataGridView;
                            if (current_grid != null)
                            {
                                Console.WriteLine("Bakım Gridi Null Değil");
                                Directory.CreateDirectory(Path + "\\" + "Panel_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString());
                                Directory.CreateDirectory(Path + "\\" + "Panel_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString());
                                for (int CurrentGelirRow = 0; CurrentGelirRow < current_grid.Rows.Count - 1; CurrentGelirRow++)
                                {
                                    Directory.CreateDirectory(Path + "\\" + "Panel_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + CurrentGelirRow.ToString());
                                    using (FileStream fs = File.Create(Path + "\\" + "Panel_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt"))
                                    {

                                    }
                                    StreamWriter sw = new StreamWriter(Path + "\\" + "Panel_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + "DataGridView_Bakim_" + Grid[CurrentColumn, CurrentRow].Value.ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt");
                                    for (int CurrentGelirColumn = 0; CurrentGelirColumn < current_grid.Columns.Count; CurrentGelirColumn++)
                                    {
                                        if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 6)
                                        {
                                            sw.WriteLine("Sil");
                                        }

                                        else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value != null)
                                        {
                                            sw.WriteLine(current_grid[CurrentGelirColumn, CurrentGelirRow].Value.ToString());
                                        }
                                        else
                                        {
                                            sw.WriteLine("");
                                        }



                                    }
                                    sw.Close();
                                }

                            }


                        }
                    }
                }
            }
        }

        private void ReadAracBakim(string Path)
        {

            string[] AllPanelFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);


            if (AllPanelFiles.Length > 0)
            {
                foreach (string CurrentPanelFile in AllPanelFiles)
                {
                    string PanelFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentPanelFile)).Name;
                    Console.WriteLine(PanelFolderName);
                    Panel arac_bakim_panel = new Panel
                    {
                        Name = PanelFolderName,
                        AccessibleName = PanelFolderName,
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_bakimlar.Controls.Add(arac_bakim_panel);
                    panel_bakimlar.Controls.SetChildIndex(arac_bakim_panel, panel_bakim_counter);
                    arac_bakim_panel.Dock = DockStyle.Fill;
                    arac_bakim_panel.BorderStyle = BorderStyle.FixedSingle;
                    arac_bakim_panel.Padding = new Padding(5);
                    arac_bakim_panel.Visible = false;


                    string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                    foreach (string CurrentGridFile in AllGridFiles)
                    {
                        string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;
                        Console.WriteLine(GridFolderName);
                        DataGridView arac_bakim_dataGrid = new DataGridView();
                        arac_bakim_dataGrid.Name = GridFolderName;
                        arac_bakim_dataGrid.AccessibleName = GridFolderName;
                        arac_bakim_panel.Controls.Add(arac_bakim_dataGrid);
                        arac_bakim_panel.Controls.SetChildIndex(arac_bakim_dataGrid, 1);
                        arac_bakim_dataGrid.Dock = DockStyle.Fill;



                        DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                        sil.Name = "arac_gelir_dataGrid_sil_" + GridFolderName;
                        sil.HeaderText = "Satırı Sil";
                        sil.DefaultCellStyle.NullValue = "Sil";
                        sil.ReadOnly = true;
                        sil.FlatStyle = FlatStyle.Flat;

                        arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_arac", "Araç");
                        arac_bakim_dataGrid.Columns["arac_bakim_dataGrid_arac"].ReadOnly = true;
                        arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_tarih", "Tarih");
                        arac_bakim_dataGrid.Columns["arac_bakim_dataGrid_tarih"].ReadOnly = true;
                        arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_km", "KM");
                        arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_usta", "Usta");
                        arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_yapilan_is", "Yapılan İş");
                        arac_bakim_dataGrid.Columns.Add("arac_bakim_dataGrid_tutar", "Tutar");
                        arac_bakim_dataGrid.Columns[5].ValueType = System.Type.GetType("System.Decimal");
                        arac_bakim_dataGrid.Columns[5].DefaultCellStyle.Format = "N2";
                        arac_bakim_dataGrid.Columns.Add(sil);
                        arac_bakim_dataGrid.Columns[6].ReadOnly = true;



                        arac_bakim_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                        arac_bakim_dataGrid.RowHeadersVisible = false;
                        arac_bakim_dataGrid.ColumnHeadersVisible = true;
                        arac_bakim_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        arac_bakim_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        arac_bakim_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                        arac_bakim_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                        arac_bakim_dataGrid.DefaultCellStyle.Font = new Font(arac_bakim_dataGrid.Font.FontFamily, 15);
                        arac_bakim_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(arac_bakim_dataGrid.Font.FontFamily, 15);
                        arac_bakim_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        arac_bakim_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                        arac_bakim_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        arac_bakim_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        arac_bakim_dataGrid.EnableHeadersVisualStyles = false;
                        arac_bakim_dataGrid.RowHeadersWidth = 41;
                        arac_bakim_dataGrid.ColumnHeadersHeight = 28;
                        arac_bakim_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        arac_bakim_dataGrid.BorderStyle = BorderStyle.None;
                        panel_bakim_counter++;

                        arac_bakim_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(arac_bakim_dataGrid_row_post_paint);
                        arac_bakim_dataGrid.CellClick += new DataGridViewCellEventHandler(arac_bakim_dataGrid_Cell_Click);
                        arac_bakim_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(arac_bakim__dataGrid_Editing);

                        foreach (DataGridViewColumn column in arac_bakim_dataGrid.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }

                        string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                        if (AllColumnFiles.Length > 0)
                        {
                            int RowCounter = 0;
                            foreach (string CurrentColumnFile in AllColumnFiles)
                            {
                                arac_bakim_dataGrid.Rows.Add();
                                using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                {
                                    string line;
                                    int ColumnCounter = 0;

                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        arac_bakim_dataGrid[ColumnCounter, RowCounter].Value = line;
                                        Console.WriteLine(line);
                                        ColumnCounter++;
                                    }
                                }
                                RowCounter++;
                            }
                        }
                    }

                }
            }
        }

        private void CreateMusteri(ComboBox musteriler, string Path)
        {
            for (int CurrentIndex = 0; CurrentIndex < musteriler.Items.Count; CurrentIndex++)
            {
                Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString());
                Panel current_panel = this.Controls.Find("Panel_Fatura_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as Panel;
                if (current_panel != null)
                {
                    DataGridView current_grid = this.Controls.Find("DataGridView_Fatura_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as DataGridView;
                    if (current_grid != null)
                    {
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_" + musteriler.Items[CurrentIndex].ToString());
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_" + musteriler.Items[CurrentIndex].ToString());
                        for (int CurrentGelirRow = 0; CurrentGelirRow < current_grid.Rows.Count - 1; CurrentGelirRow++)
                        {
                            Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString());
                            using (FileStream fs = File.Create(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt"))
                            {

                            }
                            StreamWriter sw = new StreamWriter(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt");
                            for (int CurrentGelirColumn = 0; CurrentGelirColumn < current_grid.Columns.Count; CurrentGelirColumn++)
                            {
                                if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 7)
                                {
                                    sw.WriteLine("Seç");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 8)
                                {
                                    sw.WriteLine("Sil");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null)
                                {
                                    sw.WriteLine("");
                                }
                                else
                                {
                                    sw.WriteLine(current_grid[CurrentGelirColumn, CurrentGelirRow].Value.ToString());
                                }


                            }
                            sw.Close();
                        }
                    }

                }



            }
        }

        private void CreateMusteriBilgi(ComboBox musteriler, string Path)
        {
            for (int CurrentIndex = 0; CurrentIndex < musteriler.Items.Count; CurrentIndex++)
            {
                Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString());
                Panel current_panel = this.Controls.Find("Panel_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as Panel;
                if (current_panel != null)
                {

                    DataGridView current_grid = this.Controls.Find("DataGridView_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as DataGridView;
                    if (current_grid != null)
                    {

                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString());
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString());
                        for (int CurrentGelirRow = 0; CurrentGelirRow < current_grid.Rows.Count - 1; CurrentGelirRow++)
                        {
                            Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString());
                            using (FileStream fs = File.Create(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt"))
                            {

                            }
                            StreamWriter sw = new StreamWriter(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Fatura_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt");
                            for (int CurrentGelirColumn = 0; CurrentGelirColumn < current_grid.Columns.Count; CurrentGelirColumn++)
                            {
                                if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 4)
                                {
                                    sw.WriteLine("Seç");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 5)
                                {
                                    sw.WriteLine("Sil");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null)
                                {
                                    sw.WriteLine("");
                                }
                                else
                                {
                                    sw.WriteLine(current_grid[CurrentGelirColumn, CurrentGelirRow].Value.ToString());
                                }


                            }
                            sw.Close();
                        }
                    }

                }



            }
        }

        private void ReadMusteriBilgi(string Path)
        {
            string[] AllMusteriFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);

            if (AllMusteriFiles.Length > 0)
            {
                foreach (string CurrentMusteriFile in AllMusteriFiles)
                {
                    string MusteriFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentMusteriFile)).Name;


                    string[] AllPanelFiles = Directory.GetDirectories(CurrentMusteriFile, "*", SearchOption.TopDirectoryOnly);
                    foreach (string CurrentPanelFile in AllPanelFiles)
                    {
                        string PanelFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentPanelFile)).Name;
                        Panel sirket_bilgi_panel = new Panel
                        {
                            Name = PanelFolderName,
                            AccessibleName = PanelFolderName,
                            BackColor = Color.FromArgb(45, 45, 45)
                        };

                        panel_faturalar.Controls.Add(sirket_bilgi_panel);
                        panel_faturalar.Controls.SetChildIndex(sirket_bilgi_panel, panel_musteri_counter);
                        sirket_bilgi_panel.Dock = DockStyle.Fill;
                        sirket_bilgi_panel.BorderStyle = BorderStyle.FixedSingle;
                        sirket_bilgi_panel.Padding = new Padding(5);
                        sirket_bilgi_panel.Visible = false;

                        string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                        foreach (string CurrentGridFile in AllGridFiles)
                        {
                            string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;

                            DataGridView sirket_bilgi_dataGrid = new DataGridView();
                            sirket_bilgi_dataGrid.Name = GridFolderName;
                            sirket_bilgi_dataGrid.AccessibleName = GridFolderName;
                            sirket_bilgi_panel.Controls.Add(sirket_bilgi_dataGrid);
                            sirket_bilgi_panel.Controls.SetChildIndex(sirket_bilgi_dataGrid, 1);
                            sirket_bilgi_dataGrid.Dock = DockStyle.Fill;

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "arac_gelir_dataGrid_sil_" + GridFolderName;
                            sil.HeaderText = "Satırı Sil";
                            sil.DefaultCellStyle.NullValue = "Sil";
                            sil.ReadOnly = true;
                            sil.FlatStyle = FlatStyle.Flat;

                            DataGridViewButtonColumn geri_don = new DataGridViewButtonColumn();
                            geri_don.Name = "arac_gelir_dataGrid_geri_don_" + GridFolderName;
                            geri_don.HeaderText = "Geri Dön";
                            geri_don.DefaultCellStyle.NullValue = "Seç";
                            geri_don.ReadOnly = true;
                            geri_don.FlatStyle = FlatStyle.Flat;

                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_musteri", "Müşteri");
                            sirket_bilgi_dataGrid.Columns[0].ReadOnly = true;
                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_telefon", "Telefon");

                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_adres", "Adres");

                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_banka", "Banka Bilgileri");
                            sirket_bilgi_dataGrid.Columns.Add(geri_don);
                            sirket_bilgi_dataGrid.Columns.Add(sil);


                            sirket_bilgi_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                            sirket_bilgi_dataGrid.RowHeadersVisible = false;
                            sirket_bilgi_dataGrid.ColumnHeadersVisible = true;

                            sirket_bilgi_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            sirket_bilgi_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            sirket_bilgi_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                            sirket_bilgi_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                            sirket_bilgi_dataGrid.DefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                            sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                            sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                            sirket_bilgi_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                            sirket_bilgi_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                            sirket_bilgi_dataGrid.EnableHeadersVisualStyles = false;

                            sirket_bilgi_dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            sirket_bilgi_dataGrid.ColumnHeadersHeight = 28;
                            sirket_bilgi_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_bilgi_dataGrid.BorderStyle = BorderStyle.None;




                            sirket_bilgi_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Fatura_Bilgi_row_post_paint);
                            sirket_bilgi_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Fatura_Bilgi_Cell_Click);
                            sirket_bilgi_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(sirket_bilgi_dataGrid_Editing);


                            foreach (DataGridViewColumn column in sirket_bilgi_dataGrid.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }


                            string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                            if (AllColumnFiles.Length > 0)
                            {
                                int RowCounter = 0;
                                foreach (string CurrentColumnFile in AllColumnFiles)
                                {
                                    sirket_bilgi_dataGrid.Rows.Add();
                                    using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                    {
                                        string line;
                                        int ColumnCounter = 0;

                                        while ((line = sr.ReadLine()) != null)
                                        {

                                            sirket_bilgi_dataGrid[ColumnCounter, RowCounter].Value = line;

                                            ColumnCounter++;
                                        }
                                    }
                                    RowCounter++;
                                }
                            }
                        }



                    }
                }
            }
        }

        private void ReadMusteri(string Path)
        {
            string[] AllMusteriFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);

            if (AllMusteriFiles.Length > 0)
            {
                foreach (string CurrentMusteriFile in AllMusteriFiles)
                {
                    string MusteriFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentMusteriFile)).Name;
                    comboBox_mevcut_sirketler.Items.Add(MusteriFolderName);

                    string[] AllPanelFiles = Directory.GetDirectories(CurrentMusteriFile, "*", SearchOption.TopDirectoryOnly);
                    foreach (string CurrentPanelFile in AllPanelFiles)
                    {
                        string PanelFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentPanelFile)).Name;
                        Panel sirket_panel = new Panel
                        {
                            Name = PanelFolderName,
                            AccessibleName = PanelFolderName,
                            BackColor = Color.FromArgb(45, 45, 45)
                        };

                        panel_faturalar.Controls.Add(sirket_panel);
                        panel_faturalar.Controls.SetChildIndex(sirket_panel, panel_musteri_counter);
                        sirket_panel.Dock = DockStyle.Fill;
                        sirket_panel.BorderStyle = BorderStyle.FixedSingle;
                        sirket_panel.Padding = new Padding(5);
                        sirket_panel.Visible = false;

                        string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                        foreach (string CurrentGridFile in AllGridFiles)
                        {
                            string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;

                            DataGridView sirket_dataGrid = new DataGridView();
                            sirket_dataGrid.Name = GridFolderName;
                            sirket_dataGrid.AccessibleName = GridFolderName;
                            sirket_panel.Controls.Add(sirket_dataGrid);
                            sirket_panel.Controls.SetChildIndex(sirket_dataGrid, 1);
                            sirket_dataGrid.Dock = DockStyle.Fill;

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "arac_gelir_dataGrid_sil_" + GridFolderName;
                            sil.HeaderText = "Satırı Sil";
                            sil.DefaultCellStyle.NullValue = "Sil";
                            sil.ReadOnly = true;
                            sil.FlatStyle = FlatStyle.Flat;

                            DataGridViewButtonColumn bilgi = new DataGridViewButtonColumn();
                            bilgi.Name = "arac_gelir_dataGrid_bilgi_" + GridFolderName;
                            bilgi.HeaderText = "Müşteri Bilgisi";
                            bilgi.DefaultCellStyle.NullValue = "Seç";
                            bilgi.ReadOnly = true;
                            bilgi.FlatStyle = FlatStyle.Flat;

                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_musteri", "Müşteri");
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_tarih", "Tarih");
                            sirket_dataGrid.Columns["DataGridView_Fatura_tarih"].ReadOnly = true;
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_fatura", "Fatura");
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_tutar", "Tutar");
                            sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_odenen", "Ödenen");
                            sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_kalan", "Kalan");
                            sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ReadOnly = true;
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_banka", "Banka");
                            sirket_dataGrid.Columns.Add(bilgi);
                            sirket_dataGrid.Columns.Add(sil);
                            sirket_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                            sirket_dataGrid.RowHeadersVisible = false;
                            sirket_dataGrid.ColumnHeadersVisible = true;
                            sirket_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            sirket_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            sirket_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                            sirket_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                            sirket_dataGrid.DefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                            sirket_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                            sirket_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                            sirket_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                            sirket_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                            sirket_dataGrid.EnableHeadersVisualStyles = false;
                            sirket_dataGrid.RowHeadersWidth = 41;
                            sirket_dataGrid.ColumnHeadersHeight = 28;
                            sirket_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_dataGrid.BorderStyle = BorderStyle.None;


                            sirket_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Fatura_row_post_paint);
                            sirket_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Fatura_Cell_Click);
                            sirket_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(sirket_dataGrid_Editing);


                            foreach (DataGridViewColumn column in sirket_dataGrid.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }

                            string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                            if (AllColumnFiles.Length > 0)
                            {
                                int RowCounter = 0;
                                foreach (string CurrentColumnFile in AllColumnFiles)
                                {
                                    sirket_dataGrid.Rows.Add();
                                    using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                    {
                                        string line;
                                        int ColumnCounter = 0;

                                        while ((line = sr.ReadLine()) != null)
                                        {

                                            sirket_dataGrid[ColumnCounter, RowCounter].Value = line;

                                            ColumnCounter++;
                                        }
                                    }
                                    RowCounter++;
                                }
                            }
                        }



                    }
                }
            }
        }
        private void ReadAracGelir(string Path)
        {

            string[] AllPanelFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);


            if (AllPanelFiles.Length > 0)
            {
                foreach (string CurrentPanelFile in AllPanelFiles)
                {
                    string PanelFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentPanelFile)).Name;

                    Panel arac_gelir_panel = new Panel
                    {
                        Name = PanelFolderName,
                        AccessibleName = PanelFolderName,
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_arac_gelir.Controls.Add(arac_gelir_panel);
                    panel_arac_gelir.Controls.SetChildIndex(arac_gelir_panel, panel_counter);
                    arac_gelir_panel.Dock = DockStyle.Fill;
                    arac_gelir_panel.BorderStyle = BorderStyle.FixedSingle;
                    arac_gelir_panel.Padding = new Padding(5);
                    arac_gelir_panel.Visible = false;


                    string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                    foreach (string CurrentGridFile in AllGridFiles)
                    {
                        string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;

                        DataGridView arac_gelir_dataGrid = new DataGridView();
                        arac_gelir_dataGrid.Name = GridFolderName;
                        arac_gelir_dataGrid.AccessibleName = GridFolderName;
                        arac_gelir_panel.Controls.Add(arac_gelir_dataGrid);
                        arac_gelir_panel.Controls.SetChildIndex(arac_gelir_dataGrid, 1);
                        arac_gelir_dataGrid.Dock = DockStyle.Fill;



                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_arac", "Araç");
                        arac_gelir_dataGrid.Columns[0].ReadOnly = true;
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_tarih", "Tarih");

                        DataGridViewComboBoxColumn musteri_sec = new DataGridViewComboBoxColumn();
                        musteri_sec.Name = "arac_gelir_dataGrid_musteri_" + GridFolderName;
                        musteri_sec.HeaderText = "Müşteri";
                        musteri_sec.DefaultCellStyle.NullValue = "";
                        musteri_sec.DataSource = comboBox_mevcut_sirketler.Items;
                        musteri_sec.FlatStyle = FlatStyle.Flat;

                        DataGridViewButtonColumn ekle = new DataGridViewButtonColumn();
                        ekle.Name = "arac_gelir_dataGrid_ekle_" + GridFolderName;
                        ekle.HeaderText = "Faturalara Ekle";
                        ekle.DefaultCellStyle.NullValue = "Ekle";
                        ekle.ReadOnly = true;
                        ekle.FlatStyle = FlatStyle.Flat;


                        DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                        sil.Name = "arac_gelir_dataGrid_sil_" + GridFolderName;
                        sil.HeaderText = "Satırı Sil";
                        sil.DefaultCellStyle.NullValue = "Sil";
                        sil.ReadOnly = true;
                        sil.FlatStyle = FlatStyle.Flat;

                        arac_gelir_dataGrid.Columns.Add(musteri_sec);






                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_guzergah", "Güzergah");
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_birim_fiyat", "Birim Fiyat");
                        arac_gelir_dataGrid.Columns[4].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[4].DefaultCellStyle.Format = "N3";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_net_tonaj", "Net Tonaj");
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_toplam_tutar", "Toplam Tutar");
                        arac_gelir_dataGrid.Columns[6].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[6].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[6].ReadOnly = true;
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_gemi", "Gemi Masrafı");
                        arac_gelir_dataGrid.Columns[7].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[7].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[7].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_otoban", "Otoban Masrafı");
                        arac_gelir_dataGrid.Columns[8].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[8].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[8].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_trafik", "Trafik Masrafı");
                        arac_gelir_dataGrid.Columns[9].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[9].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[9].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_komisyon", "Komisyon");
                        arac_gelir_dataGrid.Columns[10].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[10].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[10].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_diger", "Diğer Masraflar");
                        arac_gelir_dataGrid.Columns[11].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[11].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[11].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_birim_masraf_adblue", "AD Blue Masrafı");
                        arac_gelir_dataGrid.Columns[12].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[12].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[12].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_net_masraf_motorin", "Motorin Masrafı");
                        arac_gelir_dataGrid.Columns[13].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[13].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[13].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_masraf_toplam", "Masraflar Toplamı");
                        arac_gelir_dataGrid.Columns[14].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[14].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[14].DefaultCellStyle.NullValue = "0.00";
                        arac_gelir_dataGrid.Columns[14].ReadOnly = true;
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_yakit_birim", "Yakıt Birim Fiyat");
                        arac_gelir_dataGrid.Columns[15].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[15].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_alinan_yakit", "Alınan Yakıt");
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_cikis_km", "Çıkış km");
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_gelis_km", "Geliş km");
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_gidilen_yol", "Toplam Gidilen Yol (km)");
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_tuketim", "Toplam Tüketim (lt/km)");
                        arac_gelir_dataGrid.Columns[20].ReadOnly = true;
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_net_kar", "Net Kâr");
                        arac_gelir_dataGrid.Columns[21].ValueType = System.Type.GetType("System.Decimal");
                        arac_gelir_dataGrid.Columns[21].DefaultCellStyle.Format = "N2";
                        arac_gelir_dataGrid.Columns[21].ReadOnly = true;
                        arac_gelir_dataGrid.Columns.Add("arac_gelir_dataGrid_tahsilat", "Tahsilat Durumu");
                        arac_gelir_dataGrid.Columns.Add(ekle);
                        arac_gelir_dataGrid.Columns.Add(sil);


                        arac_gelir_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                        arac_gelir_dataGrid.RowHeadersVisible = false;
                        arac_gelir_dataGrid.ColumnHeadersVisible = true;
                        arac_gelir_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        arac_gelir_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        arac_gelir_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                        arac_gelir_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                        arac_gelir_dataGrid.DefaultCellStyle.Font = new Font(arac_gelir_dataGrid.Font.FontFamily, 15);
                        arac_gelir_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(arac_gelir_dataGrid.Font.FontFamily, 15);
                        arac_gelir_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        arac_gelir_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                        arac_gelir_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                        arac_gelir_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        arac_gelir_dataGrid.EnableHeadersVisualStyles = false;
                        arac_gelir_dataGrid.RowHeadersWidth = 41;
                        arac_gelir_dataGrid.ColumnHeadersHeight = 28;
                        arac_gelir_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        arac_gelir_dataGrid.BorderStyle = BorderStyle.None;
                        panel_counter++;


                        arac_gelir_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(arac_gelir_dataGrid_row_post_paint);
                        arac_gelir_dataGrid.CellClick += new DataGridViewCellEventHandler(arac_gelir_dataGrid_Cell_Click);
                        arac_gelir_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(arac_gelir_dataGrid_Editing);


                        foreach (DataGridViewColumn column in arac_gelir_dataGrid.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }

                        string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                        if (AllColumnFiles.Length > 0)
                        {
                            int RowCounter = 0;
                            foreach (string CurrentColumnFile in AllColumnFiles)
                            {
                                arac_gelir_dataGrid.Rows.Add();
                                using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                {
                                    string line;
                                    int ColumnCounter = 0;

                                    while ((line = sr.ReadLine()) != null)
                                    {

                                        arac_gelir_dataGrid[ColumnCounter, RowCounter].Value = line;

                                        ColumnCounter++;
                                    }
                                }
                                RowCounter++;
                            }
                        }
                    }

                }
            }


        }

        private void button_calisan_ekle_Click(object sender, EventArgs e)
        {
            panel_arac_gelir.Visible = false;
            panel_bakimlar.Visible = false;
            panel_araclar.Visible = false;
            panel_anasayfa.Visible = false;
            panel_faturalar.Visible = false;
            panel_ekle.Visible = false;
            panel_calisanlar.Visible = false;
            
            panel_calisan_ekle.Visible = true;

            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }
            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }
            if (opened_fatura_takvim_panel != null)
            {
                opened_fatura_takvim_panel.Visible = false;
            }

            if (opened_toptanci_takvim_panel != null)
            {
                opened_toptanci_takvim_panel.Visible = false;
            }
            Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_toptanci_panel != null)
            {
                current_toptanci_panel.Visible = false;
            }
            else
            {

            }
        }

        private void button_calican_cari_Click(object sender, EventArgs e)
        {
            panel_arac_gelir.Visible = false;
            panel_bakimlar.Visible = false;
            panel_araclar.Visible = false;
            panel_faturalar.Visible = false;
            panel_anasayfa.Visible = false;
            panel_ekle.Visible = false;
            panel_faturalar.Visible = false;
            
            panel_calisan_ekle.Visible = false;
            panel_calisanlar.Visible = true;

            if (opened_arac_gelir_panel != null)
            {
                opened_arac_gelir_panel.Visible = false;
            }

            if (opened_arac_bakim_panel != null)
            {
                opened_arac_bakim_panel.Visible = false;
            }

            if (opened_gelir_takvim_panel != null)
            {
                opened_gelir_takvim_panel.Visible = false;
            }

            if (opened_bakim_takvim_panel != null)
            {
                opened_bakim_takvim_panel.Visible = false;
            }
        }

        private void panel_calisan_ekle_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_calisan_ekle.Visible == true)
            {
                button_calisan_ekle.BackColor = Color.FromArgb(19, 19, 19);
                button_calisan_ekle.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_calisan_ekle.BackColor = Color.FromArgb(45, 45, 45);
                button_calisan_ekle.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void panel_calisanlar_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_calisanlar.Visible == true)
            {
                button_calican_cari.BackColor = Color.FromArgb(19, 19, 19);
                button_calican_cari.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_calican_cari.BackColor = Color.FromArgb(45, 45, 45);
                button_calican_cari.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void textBox_eklenecek_calisan_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_calisan_add_Click(object sender, EventArgs e)
        {
            if (textBox_eklenecek_calisan.Text.Length > 0)
            {
                comboBox_calisanlar.Items.Add(textBox_eklenecek_calisan.Text);


                Panel sirket_panel = new Panel
                {
                    Name = "Panel_Toptanci_" + textBox_eklenecek_calisan.Text,
                    AccessibleName = "Panel_Toptanci_" + textBox_eklenecek_calisan.Text,
                    BackColor = Color.FromArgb(45, 45, 45)
                };

                panel_calisanlar.Controls.Add(sirket_panel);
                panel_calisanlar.Controls.SetChildIndex(sirket_panel, panel_musteri_counter);
                sirket_panel.Dock = DockStyle.Fill;
                sirket_panel.BorderStyle = BorderStyle.FixedSingle;
                sirket_panel.Padding = new Padding(5);
                sirket_panel.Visible = false;

                DataGridView sirket_dataGrid = new DataGridView();
                sirket_dataGrid.Name = "DataGridView_Toptanci_" + textBox_eklenecek_calisan.Text;
                sirket_dataGrid.AccessibleName = "DataGridView_Toptanci_" + textBox_eklenecek_calisan.Text;
                sirket_panel.Controls.Add(sirket_dataGrid);
                sirket_panel.Controls.SetChildIndex(sirket_dataGrid, 1);
                sirket_dataGrid.Dock = DockStyle.Fill;

                DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                sil.Name = "arac_gelir_dataGrid_sil_" + textBox_eklenecek_calisan.Text;
                sil.HeaderText = "Satırı Sil";
                sil.DefaultCellStyle.NullValue = "Sil";
                sil.ReadOnly = true;
                sil.FlatStyle = FlatStyle.Flat;

                DataGridViewButtonColumn bilgi = new DataGridViewButtonColumn();
                bilgi.Name = "arac_gelir_dataGrid_bilgi_" + textBox_eklenecek_calisan.Text;
                bilgi.HeaderText = "Müşteri Bilgisi";
                bilgi.DefaultCellStyle.NullValue = "Seç";
                bilgi.ReadOnly = true;
                bilgi.FlatStyle = FlatStyle.Flat;

                sirket_dataGrid.Columns.Add("DataGridView_Fatura_musteri", "Çalışan");
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_tarih", "Tarih");
                sirket_dataGrid.Columns["DataGridView_Fatura_tarih"].ReadOnly = true;
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_fatura", "Fatura");
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_tutar", "Tutar");
                sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_odenen", "Ödenen");
                sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_kalan", "Kalan");
                sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ReadOnly = true;
                sirket_dataGrid.Columns.Add("DataGridView_Fatura_banka", "Banka");
                sirket_dataGrid.Columns.Add(bilgi);
                sirket_dataGrid.Columns.Add(sil);
                sirket_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                sirket_dataGrid.RowHeadersVisible = false;
                sirket_dataGrid.ColumnHeadersVisible = true;
                sirket_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                sirket_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                sirket_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                sirket_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                sirket_dataGrid.DefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                sirket_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                sirket_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                sirket_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                sirket_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                sirket_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                sirket_dataGrid.EnableHeadersVisualStyles = false;
                sirket_dataGrid.RowHeadersWidth = 41;
                sirket_dataGrid.ColumnHeadersHeight = 28;
                sirket_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                sirket_dataGrid.BorderStyle = BorderStyle.None;


                sirket_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Toptanci_row_post_paint);
                sirket_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Toptanci_Cell_Click);
                sirket_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Toptanci_dataGrid_Editing);


                foreach (DataGridViewColumn column in sirket_dataGrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }



                textBox_eklenecek_calisan.Text = null;
                button_calisan_ok.Visible = true;
                textBox5.ForeColor = Color.PaleGreen;
                textBox5.Text = "Çalışan ismi başarıyla eklendi.";



            }
        }

        private void button_calisan_ok_Click(object sender, EventArgs e)
        {
            button_calisan_ok.Visible = false;
            textBox5.Text = "Aşağıdaki açılır listeden çalışan seçiniz.";
            textBox5.ForeColor = Color.White;
        }

        private void comboBox_calisanlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel current_fatura_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;

            if (current_fatura_panel != null)
            {
                current_fatura_panel.Visible = true;
            }
            else
            {

            }

            button_calican_cari.PerformClick();
        }

        private void textBox_sirket_ekle_TextChanged(object sender, EventArgs e)
        {

        }

        private void Toptanci_dataGrid_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            bool numerical_bool = false;

            for (int i = 3; i < 5; i++)
            {
                if (currentGrid.CurrentCell.ColumnIndex == i)
                {
                    numerical_bool = true;
                }
            }

            if (numerical_bool)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void DataGridView_Toptanci_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView current_Fatura_Grid = (DataGridView)sender;

            current_Fatura_Grid[0, e.RowIndex].Value = comboBox_calisanlar.Text;



            if (current_Fatura_Grid[3, e.RowIndex].Value != null && current_Fatura_Grid[4, e.RowIndex].Value != null)
            {
                onceki_kalanlar = 0;

                for (int Current_Row = 0; Current_Row < e.RowIndex; Current_Row++)
                {
                    if (current_Fatura_Grid[5, Current_Row].Value != null)
                    {
                        onceki_kalan_string = current_Fatura_Grid[5, Current_Row].Value.ToString();
                        onceki_kalan_check = decimal.TryParse(onceki_kalan_string, out onceki_kalan_decimal);
                        if (onceki_kalan_check)
                        {
                            onceki_kalanlar += onceki_kalan_decimal;
                        }
                    }
                }


                tutar = current_Fatura_Grid[3, e.RowIndex].Value.ToString();
                odenen = current_Fatura_Grid[4, e.RowIndex].Value.ToString();
                tutar_dolu = decimal.TryParse(tutar, out tutar_int);
                odenen_dolu = decimal.TryParse(odenen, out odenen_int);


                if (tutar_dolu && odenen_dolu)
                {
                    kalan = tutar_int - odenen_int;
                    current_Fatura_Grid[5, e.RowIndex].Value = kalan + onceki_kalanlar;
                }
            }
            for (int i = 0; i < 4; i += 2)
            {
                current_Fatura_Grid[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                current_Fatura_Grid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            current_Fatura_Grid[1, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
            current_Fatura_Grid[1, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 61, 74);

            current_Fatura_Grid[3, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
            current_Fatura_Grid[3, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);

            current_Fatura_Grid[4, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[4, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[5, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            current_Fatura_Grid[5, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            current_Fatura_Grid[6, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            current_Fatura_Grid[6, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            current_Fatura_Grid[7, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[7, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[8, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[8, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            //for (int current_row = 0; current_row < current_Fatura_Grid.RowCount; current_row++)
            //{

            //    if (current_Fatura_Grid[1, current_row].Value != null && current_Fatura_Grid[5, current_row].Value != null)
            //    {
            //        has_been_inserted = false;

            //        fatura_kalan_gun_string = current_Fatura_Grid[1, current_row].Value.ToString();
            //        fatura_kalan_gun_check = DateTime.TryParse(fatura_kalan_gun_string, out fatura_kalan_gun_date);
            //        if (fatura_kalan_gun_check)
            //        {
            //            fatura_kalan_gun = (fatura_kalan_gun_date - DateTime.Today).Days;

            //            for (int olay_row_index = 0; olay_row_index < dataGridView_olaylar.RowCount; olay_row_index++)
            //            {
            //                if (dataGridView_olaylar[0, olay_row_index].Value != null && dataGridView_olaylar[1, olay_row_index].Value != null && dataGridView_olaylar[2, olay_row_index].Value != null && dataGridView_olaylar[3, olay_row_index].Value != null)
            //                {
            //                    if (dataGridView_olaylar[0, olay_row_index].Value.ToString() == current_Fatura_Grid.Columns[2].HeaderText && dataGridView_olaylar[1, olay_row_index].Value.ToString() == current_Fatura_Grid[0, current_row].Value.ToString() && dataGridView_olaylar[2, olay_row_index].Value.ToString() == current_Fatura_Grid[5, current_row].Value.ToString() && dataGridView_olaylar[3, olay_row_index].Value.ToString() == fatura_kalan_gun.ToString())
            //                    {
            //                        has_been_inserted = true;
            //                    }
            //                }

            //            }
            //        }

            //        fatura_string = current_Fatura_Grid[1, current_row].Value.ToString();
            //        fatura_check = DateTime.TryParse(fatura_string, out fatura_date);
            //        if (fatura_check)
            //        {
            //            if ((fatura_date - DateTime.Today).Days <= 30 && !has_been_inserted)
            //            {
            //                dataGridView_olaylar.Rows.Add(current_Fatura_Grid.Columns[2].HeaderText, current_Fatura_Grid[0, current_row].Value.ToString(), current_Fatura_Grid[5, current_row].Value.ToString(), (fatura_date - DateTime.Today).Days.ToString());

            //            }
            //        }
            //        fatura_kalan_gun = (fatura_date - DateTime.Today).Days;

            //    }
            //}
        }

        private void DataGridView_Toptanci_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView current_Fatura_Grid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1 && current_Fatura_Grid[5, e.RowIndex].Value != null)
            {

                opened_toptanci_takvim_panel = panel_calisanlar_takvim;
                panel_calisanlar_takvim.Visible = true;
            }
            else
            {

            }

            if (e.ColumnIndex == 1 && current_Fatura_Grid[5, e.RowIndex].Value == null)
            {
                MessageBox.Show("Lütfen önce kalan tutarı belirleyin.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            chosen_row_toptanci = e.RowIndex;
            chosen_column_toptanci = e.ColumnIndex;

            bool blank = false;

            for (int i = 1; i < 7; i++)
            {

                if (current_Fatura_Grid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 8 && blank && current_Fatura_Grid.RowCount > 1)
            {
                current_Fatura_Grid.Rows.Remove(current_Fatura_Grid.Rows[e.RowIndex]);
            }

            if (e.ColumnIndex == 7)
            {
                Panel current_fatura_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;
                Panel current_fatura_bilgi_panel = this.Controls.Find("Panel_Toptanci_Bilgi_" + comboBox_calisanlar.Text, true).FirstOrDefault() as Panel;


                if (current_fatura_bilgi_panel == null)
                {
                    Panel sirket_bilgi_panel = new Panel
                    {
                        Name = "Panel_Toptanci_Bilgi_" + comboBox_calisanlar.Text,
                        AccessibleName = "Panel_Toptanci_Bilgi" + comboBox_calisanlar.Text,
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_calisanlar.Controls.Add(sirket_bilgi_panel);
                    panel_calisanlar.Controls.SetChildIndex(sirket_bilgi_panel, panel_musteri_counter);
                    sirket_bilgi_panel.Dock = DockStyle.Fill;
                    sirket_bilgi_panel.BorderStyle = BorderStyle.FixedSingle;
                    sirket_bilgi_panel.Padding = new Padding(5);
                    sirket_bilgi_panel.Visible = false;


                    DataGridView sirket_bilgi_dataGrid = new DataGridView();
                    sirket_bilgi_dataGrid.Name = "DataGridView_Toptanci_Bilgi_" + comboBox_calisanlar.Text;
                    sirket_bilgi_dataGrid.AccessibleName = "DataGridView_Toptanci_Bilgi_" + comboBox_calisanlar.Text;
                    sirket_bilgi_panel.Controls.Add(sirket_bilgi_dataGrid);
                    sirket_bilgi_panel.Controls.SetChildIndex(sirket_bilgi_dataGrid, 1);
                    sirket_bilgi_dataGrid.Dock = DockStyle.Fill;

                    DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                    sil.Name = "arac_gelir_dataGrid_sil_" + comboBox_calisanlar.Text;
                    sil.HeaderText = "Satırı Sil";
                    sil.DefaultCellStyle.NullValue = "Sil";
                    sil.ReadOnly = true;
                    sil.FlatStyle = FlatStyle.Flat;

                    DataGridViewButtonColumn geri_don = new DataGridViewButtonColumn();
                    geri_don.Name = "arac_gelir_dataGrid_geri_don_" + comboBox_calisanlar.Text;
                    geri_don.HeaderText = "Geri Dön";
                    geri_don.DefaultCellStyle.NullValue = "Seç";
                    geri_don.ReadOnly = true;
                    geri_don.FlatStyle = FlatStyle.Flat;

                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_musteri", "Çalışan");
                    sirket_bilgi_dataGrid.Columns[0].ReadOnly = true;
                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_telefon", "Telefon");

                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_adres", "Adres");

                    sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_banka", "Banka Bilgileri");
                    sirket_bilgi_dataGrid.Columns.Add(geri_don);
                    sirket_bilgi_dataGrid.Columns.Add(sil);


                    sirket_bilgi_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                    sirket_bilgi_dataGrid.RowHeadersVisible = false;
                    sirket_bilgi_dataGrid.ColumnHeadersVisible = true;

                    sirket_bilgi_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    sirket_bilgi_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    sirket_bilgi_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                    sirket_bilgi_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                    sirket_bilgi_dataGrid.DefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                    sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                    sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                    sirket_bilgi_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    sirket_bilgi_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    sirket_bilgi_dataGrid.EnableHeadersVisualStyles = false;

                    sirket_bilgi_dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    sirket_bilgi_dataGrid.ColumnHeadersHeight = 28;
                    sirket_bilgi_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    sirket_bilgi_dataGrid.BorderStyle = BorderStyle.None;




                    sirket_bilgi_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Toptanci_Bilgi_row_post_paint);
                    sirket_bilgi_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Toptanci_Bilgi_Cell_Click);
                    sirket_bilgi_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Toptanci_bilgi_dataGrid_Editing);


                    foreach (DataGridViewColumn column in sirket_bilgi_dataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    current_fatura_panel.Visible = false;
                    sirket_bilgi_panel.Visible = true;
                }
                else
                {
                    current_fatura_panel.Visible = false;
                    current_fatura_bilgi_panel.Visible = true;
                }

            }

        }

        private void DataGridView_Toptanci_Bilgi_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView current_Fatura_Grid = (DataGridView)sender;

            current_Fatura_Grid[0, e.RowIndex].Value = comboBox_calisanlar.Text;

            current_Fatura_Grid[0, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
            current_Fatura_Grid[0, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);

            current_Fatura_Grid[1, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[1, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[2, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            current_Fatura_Grid[2, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            current_Fatura_Grid[3, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            current_Fatura_Grid[3, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            current_Fatura_Grid[4, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[4, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            current_Fatura_Grid[5, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            current_Fatura_Grid[5, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);
        }

        private void DataGridView_Toptanci_Bilgi_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            Panel current_fatura_panel = this.Controls.Find("Panel_Toptanci_" + currentGrid[0, e.RowIndex].Value.ToString(), true).FirstOrDefault() as Panel;
            Panel current_fatura_bilgi_panel = this.Controls.Find("Panel_Toptanci_Bilgi_" + currentGrid[0, e.RowIndex].Value.ToString(), true).FirstOrDefault() as Panel;

            

            bool blank = false;

            for (int i = 1; i < 4; i++)
            {

                if (currentGrid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 5 && blank && currentGrid.RowCount > 1)
            {
                currentGrid.Rows.Remove(currentGrid.Rows[e.RowIndex]);
            }
            if (e.ColumnIndex == 4 && current_fatura_panel != null)
            {
                current_fatura_bilgi_panel.Visible = false;
                current_fatura_panel.Visible = true;
            }
        }

        private void Toptanci_bilgi_dataGrid_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridView current_grid = this.Controls.Find("DataGridView_Toptanci_" + comboBox_calisanlar.Text, true).FirstOrDefault() as DataGridView;

            if (current_grid != null)
            {
                selectedDateToptanci = monthCalendar_calisan_takvim.SelectionRange.Start.ToShortDateString();
                current_grid.Rows[chosen_row_toptanci].Cells[chosen_column_toptanci].Value = selectedDateToptanci;

            }
            else
            {

            }


            panel_calisanlar_takvim.Visible = false;
        }

        private void ReadCalisan(string Path)
        {
            string[] AllMusteriFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);

            if (AllMusteriFiles.Length > 0)
            {
                foreach (string CurrentMusteriFile in AllMusteriFiles)
                {
                    string MusteriFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentMusteriFile)).Name;
                    comboBox_calisanlar.Items.Add(MusteriFolderName);

                    string[] AllPanelFiles = Directory.GetDirectories(CurrentMusteriFile, "*", SearchOption.TopDirectoryOnly);
                    foreach (string CurrentPanelFile in AllPanelFiles)
                    {
                        string PanelFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentPanelFile)).Name;
                        Panel sirket_panel = new Panel
                        {
                            Name = PanelFolderName,
                            AccessibleName = PanelFolderName,
                            BackColor = Color.FromArgb(45, 45, 45)
                        };

                        panel_calisanlar.Controls.Add(sirket_panel);
                        panel_calisanlar.Controls.SetChildIndex(sirket_panel, panel_musteri_counter);
                        sirket_panel.Dock = DockStyle.Fill;
                        sirket_panel.BorderStyle = BorderStyle.FixedSingle;
                        sirket_panel.Padding = new Padding(5);
                        sirket_panel.Visible = false;

                        string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                        foreach (string CurrentGridFile in AllGridFiles)
                        {
                            string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;

                            DataGridView sirket_dataGrid = new DataGridView();
                            sirket_dataGrid.Name = GridFolderName;
                            sirket_dataGrid.AccessibleName = GridFolderName;
                            sirket_panel.Controls.Add(sirket_dataGrid);
                            sirket_panel.Controls.SetChildIndex(sirket_dataGrid, 1);
                            sirket_dataGrid.Dock = DockStyle.Fill;

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "arac_gelir_dataGrid_sil_" + GridFolderName;
                            sil.HeaderText = "Satırı Sil";
                            sil.DefaultCellStyle.NullValue = "Sil";
                            sil.ReadOnly = true;
                            sil.FlatStyle = FlatStyle.Flat;

                            DataGridViewButtonColumn bilgi = new DataGridViewButtonColumn();
                            bilgi.Name = "arac_gelir_dataGrid_bilgi_" + GridFolderName;
                            bilgi.HeaderText = "Müşteri Bilgisi";
                            bilgi.DefaultCellStyle.NullValue = "Seç";
                            bilgi.ReadOnly = true;
                            bilgi.FlatStyle = FlatStyle.Flat;

                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_musteri", "Çalışan");
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_tarih", "Tarih");
                            sirket_dataGrid.Columns["DataGridView_Fatura_tarih"].ReadOnly = true;
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_fatura", "Fatura");
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_tutar", "Tutar");
                            sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns["DataGridView_Fatura_tutar"].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_odenen", "Ödenen");
                            sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns["DataGridView_Fatura_odenen"].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_kalan", "Kalan");
                            sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns["DataGridView_Fatura_kalan"].ReadOnly = true;
                            sirket_dataGrid.Columns.Add("DataGridView_Fatura_banka", "Banka");
                            sirket_dataGrid.Columns.Add(bilgi);
                            sirket_dataGrid.Columns.Add(sil);
                            sirket_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                            sirket_dataGrid.RowHeadersVisible = false;
                            sirket_dataGrid.ColumnHeadersVisible = true;
                            sirket_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            sirket_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            sirket_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                            sirket_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                            sirket_dataGrid.DefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                            sirket_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_dataGrid.Font.FontFamily, 15);
                            sirket_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                            sirket_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                            sirket_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                            sirket_dataGrid.EnableHeadersVisualStyles = false;
                            sirket_dataGrid.RowHeadersWidth = 41;
                            sirket_dataGrid.ColumnHeadersHeight = 28;
                            sirket_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_dataGrid.BorderStyle = BorderStyle.None;


                            sirket_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Toptanci_row_post_paint);
                            sirket_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Toptanci_Cell_Click);
                            sirket_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Toptanci_dataGrid_Editing);


                            foreach (DataGridViewColumn column in sirket_dataGrid.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }

                            string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                            if (AllColumnFiles.Length > 0)
                            {
                                int RowCounter = 0;
                                foreach (string CurrentColumnFile in AllColumnFiles)
                                {
                                    sirket_dataGrid.Rows.Add();
                                    using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                    {
                                        string line;
                                        int ColumnCounter = 0;

                                        while ((line = sr.ReadLine()) != null)
                                        {

                                            sirket_dataGrid[ColumnCounter, RowCounter].Value = line;

                                            ColumnCounter++;
                                        }
                                    }
                                    RowCounter++;
                                }
                            }
                        }



                    }
                }
            }
        }

        private void ReadCalisanBilgi(string Path)
        {
            string[] AllMusteriFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);

            if (AllMusteriFiles.Length > 0)
            {
                foreach (string CurrentMusteriFile in AllMusteriFiles)
                {
                    string MusteriFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentMusteriFile)).Name;


                    string[] AllPanelFiles = Directory.GetDirectories(CurrentMusteriFile, "*", SearchOption.TopDirectoryOnly);
                    foreach (string CurrentPanelFile in AllPanelFiles)
                    {
                        string PanelFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentPanelFile)).Name;
                        Panel sirket_bilgi_panel = new Panel
                        {
                            Name = PanelFolderName,
                            AccessibleName = PanelFolderName,
                            BackColor = Color.FromArgb(45, 45, 45)
                        };

                        panel_calisanlar.Controls.Add(sirket_bilgi_panel);
                        panel_calisanlar.Controls.SetChildIndex(sirket_bilgi_panel, panel_musteri_counter);
                        sirket_bilgi_panel.Dock = DockStyle.Fill;
                        sirket_bilgi_panel.BorderStyle = BorderStyle.FixedSingle;
                        sirket_bilgi_panel.Padding = new Padding(5);
                        sirket_bilgi_panel.Visible = false;

                        string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                        foreach (string CurrentGridFile in AllGridFiles)
                        {
                            string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;

                            DataGridView sirket_bilgi_dataGrid = new DataGridView();
                            sirket_bilgi_dataGrid.Name = GridFolderName;
                            sirket_bilgi_dataGrid.AccessibleName = GridFolderName;
                            sirket_bilgi_panel.Controls.Add(sirket_bilgi_dataGrid);
                            sirket_bilgi_panel.Controls.SetChildIndex(sirket_bilgi_dataGrid, 1);
                            sirket_bilgi_dataGrid.Dock = DockStyle.Fill;

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "arac_gelir_dataGrid_sil_" + GridFolderName;
                            sil.HeaderText = "Satırı Sil";
                            sil.DefaultCellStyle.NullValue = "Sil";
                            sil.ReadOnly = true;
                            sil.FlatStyle = FlatStyle.Flat;

                            DataGridViewButtonColumn geri_don = new DataGridViewButtonColumn();
                            geri_don.Name = "arac_gelir_dataGrid_geri_don_" + GridFolderName;
                            geri_don.HeaderText = "Geri Dön";
                            geri_don.DefaultCellStyle.NullValue = "Seç";
                            geri_don.ReadOnly = true;
                            geri_don.FlatStyle = FlatStyle.Flat;

                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_musteri", "Çalışan");
                            sirket_bilgi_dataGrid.Columns[0].ReadOnly = true;
                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_telefon", "Telefon");

                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_adres", "Adres");

                            sirket_bilgi_dataGrid.Columns.Add("sirket_bilgi_dataGrid_banka", "Banka Bilgileri");
                            sirket_bilgi_dataGrid.Columns.Add(geri_don);
                            sirket_bilgi_dataGrid.Columns.Add(sil);


                            sirket_bilgi_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                            sirket_bilgi_dataGrid.RowHeadersVisible = false;
                            sirket_bilgi_dataGrid.ColumnHeadersVisible = true;

                            sirket_bilgi_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            sirket_bilgi_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            sirket_bilgi_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                            sirket_bilgi_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                            sirket_bilgi_dataGrid.DefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                            sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(sirket_bilgi_dataGrid.Font.FontFamily, 15);
                            sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                            sirket_bilgi_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                            sirket_bilgi_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                            sirket_bilgi_dataGrid.EnableHeadersVisualStyles = false;

                            sirket_bilgi_dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            sirket_bilgi_dataGrid.ColumnHeadersHeight = 28;
                            sirket_bilgi_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            sirket_bilgi_dataGrid.BorderStyle = BorderStyle.None;




                            sirket_bilgi_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridView_Toptanci_Bilgi_row_post_paint);
                            sirket_bilgi_dataGrid.CellClick += new DataGridViewCellEventHandler(DataGridView_Toptanci_Bilgi_Cell_Click);
                            sirket_bilgi_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(Toptanci_bilgi_dataGrid_Editing);


                            foreach (DataGridViewColumn column in sirket_bilgi_dataGrid.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }


                            string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                            if (AllColumnFiles.Length > 0)
                            {
                                int RowCounter = 0;
                                foreach (string CurrentColumnFile in AllColumnFiles)
                                {
                                    sirket_bilgi_dataGrid.Rows.Add();
                                    using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                    {
                                        string line;
                                        int ColumnCounter = 0;

                                        while ((line = sr.ReadLine()) != null)
                                        {

                                            sirket_bilgi_dataGrid[ColumnCounter, RowCounter].Value = line;

                                            ColumnCounter++;
                                        }
                                    }
                                    RowCounter++;
                                }
                            }
                        }



                    }
                }
            }
        }

        private void CreateToptanci(ComboBox musteriler, string Path)
        {
            for (int CurrentIndex = 0; CurrentIndex < musteriler.Items.Count; CurrentIndex++)
            {
                Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString());
                Panel current_panel = this.Controls.Find("Panel_Toptanci_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as Panel;
                if (current_panel != null)
                {
                    DataGridView current_grid = this.Controls.Find("DataGridView_Toptanci_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as DataGridView;
                    if (current_grid != null)
                    {
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_" + musteriler.Items[CurrentIndex].ToString());
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_" + musteriler.Items[CurrentIndex].ToString());
                        for (int CurrentGelirRow = 0; CurrentGelirRow < current_grid.Rows.Count - 1; CurrentGelirRow++)
                        {
                            Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString());
                            using (FileStream fs = File.Create(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt"))
                            {

                            }
                            StreamWriter sw = new StreamWriter(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt");
                            for (int CurrentGelirColumn = 0; CurrentGelirColumn < current_grid.Columns.Count; CurrentGelirColumn++)
                            {
                                if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 7)
                                {
                                    sw.WriteLine("Seç");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 8)
                                {
                                    sw.WriteLine("Sil");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null)
                                {
                                    sw.WriteLine("");
                                }
                                else
                                {
                                    sw.WriteLine(current_grid[CurrentGelirColumn, CurrentGelirRow].Value.ToString());
                                }


                            }
                            sw.Close();
                        }
                    }

                }



            }
        }

        private void CreateToptanciBilgi(ComboBox musteriler, string Path)
        {
            for (int CurrentIndex = 0; CurrentIndex < musteriler.Items.Count; CurrentIndex++)
            {
                Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString());
                Panel current_panel = this.Controls.Find("Panel_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as Panel;
                if (current_panel != null)
                {

                    DataGridView current_grid = this.Controls.Find("DataGridView_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as DataGridView;
                    if (current_grid != null)
                    {

                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString());
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString());
                        for (int CurrentGelirRow = 0; CurrentGelirRow < current_grid.Rows.Count - 1; CurrentGelirRow++)
                        {
                            Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString());
                            using (FileStream fs = File.Create(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt"))
                            {

                            }
                            StreamWriter sw = new StreamWriter(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_Toptanci_Bilgi_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt");
                            for (int CurrentGelirColumn = 0; CurrentGelirColumn < current_grid.Columns.Count; CurrentGelirColumn++)
                            {
                                if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 4)
                                {
                                    sw.WriteLine("Seç");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null && CurrentGelirColumn == 5)
                                {
                                    sw.WriteLine("Sil");
                                }
                                else if (current_grid[CurrentGelirColumn, CurrentGelirRow].Value == null)
                                {
                                    sw.WriteLine("");
                                }
                                else
                                {
                                    sw.WriteLine(current_grid[CurrentGelirColumn, CurrentGelirRow].Value.ToString());
                                }


                            }
                            sw.Close();
                        }
                    }

                }



            }
        }

        private void dataGridView_araclar_Click(object sender, EventArgs e)
        {

        }
    }



}


