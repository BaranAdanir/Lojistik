using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Dukkan : Form
    {
        public static string textPassedMainForm;
        string tutar;
        string odenen;
        decimal kalan;
        bool tutar_dolu;
        bool odenen_dolu;
        decimal tutar_int;
        decimal odenen_int;
        readonly int panel_counter = 1;

        public string selectedDateGelirGider;
        public string selectedDateToptanci;
        int chosen_row_GelirGider;
        int chosen_column_GelirGider;

        int chosen_row_toptanci;
        int chosen_column_toptanci;

        bool has_been_inserted_sirket = false;
        string sirket_kalan_gun_string;
        bool sirket_kalan_gun_check;
        int sirket_kalan_gun;
        DateTime sirket_kalan_gun_date;

        string sirket_string;
        DateTime sirket_date;
        bool sirket_check;

        bool has_been_inserted_toptanci = false;
        string toptanci_kalan_gun_string;
        bool toptanci_kalan_gun_check;
        int toptanci_kalan_gun;
        DateTime toptanci_kalan_gun_date;

        string toptanci_string;
        DateTime toptanci_date;
        bool toptanci_check;

        FileOperations DataGridSil = new FileOperations();
        private decimal onceki_kalanlar;
        private string onceki_kalan_string;
        private bool onceki_kalan_check = false;
        private decimal onceki_kalan_decimal;
        private bool has_been_inserted = false;
        private string fatura_kalan_gun_string;
        private bool fatura_kalan_gun_check = false;
        private DateTime fatura_kalan_gun_date;
        private int fatura_kalan_gun;
        private string fatura_string;
        private bool fatura_check = false;
        private DateTime fatura_date;
        readonly string SaveLocation = "..\\Release\\Save";

        public Dukkan()
        {
            InitializeComponent();
        }

        private void button_tasimacilik_Click(object sender, EventArgs e)
        {
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Müşteriler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Müşteri Bilgiler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Toptancılar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Toptancı Bilgiler");

            CreateMusteri(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Dükkan Müşteriler");
            CreateMusteriBilgi(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Dükkan Müşteri Bilgiler");
            CreateToptanci(comboBox_ekle_2, SaveLocation + "\\" + "Dükkan Toptancılar");
            CreateToptanciBilgi(comboBox_ekle_2, SaveLocation + "\\" + "Dükkan Toptancı Bilgiler");

            new main_form().Show();
            this.Hide();
        }

        private void Dukkan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_panel != null)
            {
                current_panel.Visible = false;
            }
            else
            {
               
            }

            Panel current_panel_toptanci = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel_toptanci != null)
            {
                current_panel_toptanci.Visible = false;
            }
            else
            {
               
            }

            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Müşteriler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Müşteri Bilgiler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Toptancılar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Toptancı Bilgiler");
           
            CreateMusteri(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Dükkan Müşteriler");
            CreateMusteriBilgi(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Dükkan Müşteri Bilgiler");
            CreateToptanci(comboBox_ekle_2, SaveLocation + "\\" + "Dükkan Toptancılar");
            CreateToptanciBilgi(comboBox_ekle_2, SaveLocation + "\\" + "Dükkan Toptancı Bilgiler");

            Application.Exit();
        }

        private void button_cikis_Click(object sender, EventArgs e)
        {
            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_panel != null)
            {
                current_panel.Visible = false;
            }
            else
            {

            }

            Panel current_panel_toptanci = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel_toptanci != null)
            {
                current_panel_toptanci.Visible = false;
            }
            else
            {
               
            }

            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Müşteriler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Müşteri Bilgiler");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Toptancılar");
            DataGridSil.ClearFolder(SaveLocation + "\\" + "Dükkan Toptancı Bilgiler");

            CreateMusteri(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Dükkan Müşteriler");
            CreateMusteriBilgi(comboBox_mevcut_sirketler, SaveLocation + "\\" + "Dükkan Müşteri Bilgiler");
            CreateToptanci(comboBox_ekle_2, SaveLocation + "\\" + "Dükkan Toptancılar");
            CreateToptanciBilgi(comboBox_ekle_2, SaveLocation + "\\" + "Dükkan Toptancı Bilgiler");

            Application.Exit();
        }

        private void Dukkan_Load(object sender, EventArgs e)
        {
            textBox_username.Text = Login.textPassedLogin;
            timer_main.Start();

            button_dukkan.FlatAppearance.BorderColor = Color.FromArgb(151, 38, 32);
            button_dukkan.ForeColor = Color.FromArgb(151, 38, 32);
            button_dukkan.Font = new Font(button_tasimacilik.Font, FontStyle.Bold);
            button_dukkan.FlatAppearance.BorderSize = 2;

            ReadMusteri(SaveLocation + "\\" + "Dükkan Müşteriler");
            ReadMusteriBilgi(SaveLocation + "\\" + "Dükkan Müşteri Bilgiler");
            ReadToptanci(SaveLocation + "\\" + "Dükkan Toptancılar");
            ReadToptanciBilgi(SaveLocation + "\\" + "Dükkan Toptancı Bilgiler");
        }

        private void timer_main_Tick(object sender, EventArgs e)
        {
            textBox_date.Text = DateTime.Now.ToLongTimeString();
            textBox_time.Text = DateTime.Now.ToLongDateString();

            foreach (var selected_toptanci_index in comboBox_ekle_2.Items)
            {
                string selected_toptanci_index_string = selected_toptanci_index.ToString();
                DataGridView current_Fatura_Grid = this.Controls.Find("DataGridView_Toptanci_" + selected_toptanci_index_string, true).FirstOrDefault() as DataGridView;

                for (int current_toptanci_row = 0; current_toptanci_row < current_Fatura_Grid.RowCount; current_toptanci_row++)
                {
                    if (current_Fatura_Grid[1, current_toptanci_row].Value != null && current_Fatura_Grid[5, current_toptanci_row].Value != null)
                    {
                        has_been_inserted_toptanci = false;

                        toptanci_kalan_gun_string = current_Fatura_Grid[1, current_toptanci_row].Value.ToString();
                        toptanci_kalan_gun_check = DateTime.TryParse(toptanci_kalan_gun_string, out toptanci_kalan_gun_date);
                        if (toptanci_kalan_gun_check)
                        {
                            toptanci_kalan_gun = (toptanci_kalan_gun_date - DateTime.Today).Days;

                            for (int olay_row_index = 0; olay_row_index < dataGridView_olaylar.RowCount; olay_row_index++)
                            {
                                if (dataGridView_olaylar[0, olay_row_index].Value != null && dataGridView_olaylar[1, olay_row_index].Value != null && dataGridView_olaylar[2, olay_row_index].Value != null && dataGridView_olaylar[3, olay_row_index].Value != null)
                                {
                                    if (dataGridView_olaylar[0, olay_row_index].Value.ToString() == current_Fatura_Grid.Columns[2].HeaderText + " (Toptancı)" && dataGridView_olaylar[1, olay_row_index].Value.ToString() == current_Fatura_Grid[0, current_toptanci_row].Value.ToString() + " (Toptancı)" && dataGridView_olaylar[2, olay_row_index].Value.ToString() == current_Fatura_Grid[5, current_toptanci_row].Value.ToString() && dataGridView_olaylar[3, olay_row_index].Value.ToString() == toptanci_kalan_gun.ToString())
                                    {
                                        has_been_inserted_toptanci = true;
                                    }
                                }
                            }
                        }

                        toptanci_string = current_Fatura_Grid[1, current_toptanci_row].Value.ToString();
                        toptanci_check = DateTime.TryParse(toptanci_string, out toptanci_date);
                        if (toptanci_check)
                        {
                            if ((toptanci_date - DateTime.Today).Days <= 30 && !has_been_inserted_toptanci)
                            {
                                dataGridView_olaylar.Rows.Add(current_Fatura_Grid.Columns[2].HeaderText + " (Toptancı)", current_Fatura_Grid[0, current_toptanci_row].Value.ToString() + " (Toptancı)", current_Fatura_Grid[5, current_toptanci_row].Value.ToString(), (toptanci_date - DateTime.Today).Days.ToString());
                            }
                        }
                        toptanci_kalan_gun = (toptanci_date - DateTime.Today).Days;
                    }
                }
            }

            foreach (var selected_toptanci_index in comboBox_mevcut_sirketler.Items)
            {
                string selected_toptanci_index_string = selected_toptanci_index.ToString();

                DataGridView current_Fatura_Grid = this.Controls.Find("DataGridView_" + selected_toptanci_index_string, true).FirstOrDefault() as DataGridView;

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
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_ana_sayfa_Click(object sender, EventArgs e)
        {
            panel_ekle.Visible = false;
            panel_gelirgider.Visible = false;
            panel_ekle_2.Visible = false;
            panel_gelir_gider_2.Visible = false;
            panel_anasayfa.Visible = true;

            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_panel != null)
            {
                current_panel.Visible = false;
            }
            else
            {
                
            }

            Panel current_panel_toptanci = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel_toptanci != null)
            {
                current_panel_toptanci.Visible = false;
            }
            else
            {
                
            }

        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            panel_gelirgider.Visible = false;
            panel_anasayfa.Visible = false;
            panel_ekle_2.Visible = false;
            panel_gelir_gider_2.Visible = false;
            panel_ekle.Visible = true;

            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_panel != null)
            {
                current_panel.Visible = false;
            }
            else
            {
                
            }

            Panel current_panel_toptanci = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel_toptanci != null)
            {
                current_panel_toptanci.Visible = false;
            }
            else
            {
                
            }
        }

        private void button_hesap_Click(object sender, EventArgs e)
        {
            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (comboBox_mevcut_sirketler.Text != null)
            {
                if (current_panel != null)
                {
                    current_panel.Visible = true;
                }
                else
                {
                    
                }
            }

            Panel current_panel_toptanci = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel_toptanci != null)
            {
                current_panel_toptanci.Visible = false;
            }
            else
            {
                
            }


            panel_anasayfa.Visible = false;
            panel_ekle.Visible = false;
            panel_ekle_2.Visible = false;
            panel_gelir_gider_2.Visible = false;
            panel_gelirgider.Visible = true;
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

        private void panel_ekle_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_ekle.Visible == true)
            {
                button_ekle.BackColor = Color.FromArgb(19, 19, 19);
                button_ekle.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_ekle.BackColor = Color.FromArgb(45, 45, 45);
                button_ekle.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void panel_gelirgider_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_gelirgider.Visible == true)
            {
                button_hesap.BackColor = Color.FromArgb(19, 19, 19);
                button_hesap.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_hesap.BackColor = Color.FromArgb(45, 45, 45);
                button_hesap.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_ekle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_tebrikler_close_Click(object sender, EventArgs e)
        {
            button_tebrikler_close.Visible = false;
            textBox_tebrikler.Text = "Aşağıdaki açılır listeden müşteri seçiniz.";
            textBox_tebrikler.ForeColor = Color.White;
        }

        public void button_sirket_ekle_Click(object sender, EventArgs e)
        {
            if(textBox_sirket_ekle.Text.Length > 0)
            {
                comboBox_mevcut_sirketler.Items.Add(textBox_sirket_ekle.Text);
                Panel sirket_panel = new Panel
                {
                    Name = "Panel_" + textBox_sirket_ekle.Text,
                    AccessibleName = "Panel_" + textBox_sirket_ekle.Text,
                    BackColor = Color.FromArgb(45, 45, 45)
                };

                panel_gelirgider.Controls.Add(sirket_panel);
                panel_gelirgider.Controls.SetChildIndex(sirket_panel, panel_counter);
                sirket_panel.Dock = DockStyle.Fill;
                sirket_panel.BorderStyle = BorderStyle.FixedSingle;
                sirket_panel.Padding = new Padding(5);
                sirket_panel.Visible = false;
                
                DataGridView sirket_dataGrid = new DataGridView();
                sirket_dataGrid.Name = "DataGridView_" + textBox_sirket_ekle.Text;
                sirket_dataGrid.AccessibleName = "DataGridView_" + textBox_sirket_ekle.Text;
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

                sirket_dataGrid.Columns.Add("sirket_dataGrid_isim", "Şirket");
                sirket_dataGrid.Columns.Add("sirket_dataGrid_tarih", "Tarih");
                
                sirket_dataGrid.Columns["sirket_dataGrid_tarih"].ReadOnly = true;
                sirket_dataGrid.Columns.Add("sirket_dataGrid_fatura", "Fatura");
                sirket_dataGrid.Columns.Add("sirket_dataGrid_tutar", "Tutar");
                sirket_dataGrid.Columns[3].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns[3].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns.Add("sirket_dataGrid_odenen", "Ödenen");
                sirket_dataGrid.Columns[4].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns[4].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns.Add("sirket_dataGrid_kalan", "Kalan");
                sirket_dataGrid.Columns[5].ValueType = System.Type.GetType("System.Decimal");
                sirket_dataGrid.Columns[5].DefaultCellStyle.Format = "N2";
                sirket_dataGrid.Columns["sirket_dataGrid_kalan"].ReadOnly = true;
                sirket_dataGrid.Columns.Add("sirket_dataGrid_banka", "Banka");
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
                
                sirket_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(sirket_dataGrid_row_post_paint);
                sirket_dataGrid.CellClick += new DataGridViewCellEventHandler(sirket_dataGrid_Cell_Click);
                sirket_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(sirket_dataGrid_Cell_Editing);

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

        private void sirket_dataGrid_Cell_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (currentGrid.CurrentCell.ColumnIndex == 3 || currentGrid.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void sirket_dataGrid_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            currentGrid[0, e.RowIndex].Value = comboBox_mevcut_sirketler.Text;

            if (currentGrid[3, e.RowIndex].Value != null && currentGrid[4, e.RowIndex].Value != null)
            {

                onceki_kalanlar = 0;

                for (int Current_Row = 0; Current_Row < e.RowIndex; Current_Row++)
                {
                    if (currentGrid[5, Current_Row].Value != null)
                    {
                        onceki_kalan_string = currentGrid[5, Current_Row].Value.ToString();
                        onceki_kalan_check = decimal.TryParse(onceki_kalan_string, out onceki_kalan_decimal);
                        if (onceki_kalan_check)
                        {
                            onceki_kalanlar += onceki_kalan_decimal;
                        }
                    }
                }

                tutar = currentGrid[3, e.RowIndex].Value.ToString();
                odenen = currentGrid[4, e.RowIndex].Value.ToString();
                tutar_dolu = decimal.TryParse(tutar, out tutar_int);
                odenen_dolu = decimal.TryParse(odenen, out odenen_int);


                if (tutar_dolu && odenen_dolu)
                {
                    kalan = tutar_int - odenen_int;
                    currentGrid[5, e.RowIndex].Value = kalan + onceki_kalanlar;
                }
            }
            for (int i = 0; i < 4; i+=2)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            currentGrid[1, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
            currentGrid[1, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 61, 74);

            currentGrid[3, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
            currentGrid[3, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);

            currentGrid[4, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[4, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            currentGrid[5, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            currentGrid[5, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            currentGrid[6, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            currentGrid[6, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            currentGrid[7, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[7, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            currentGrid[8, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[8, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            //for(int current_sirket_row = 0; current_sirket_row < currentGrid.RowCount; current_sirket_row++)
            //{
            //    if(currentGrid[1, current_sirket_row].Value != null && currentGrid[5, current_sirket_row].Value != null)
            //    {
            //        has_been_inserted_sirket = false;

            //        sirket_kalan_gun_string = currentGrid[1, current_sirket_row].Value.ToString();
            //        sirket_kalan_gun_check = DateTime.TryParse(sirket_kalan_gun_string, out sirket_kalan_gun_date);
            //        if(sirket_kalan_gun_check)
            //        {
            //            sirket_kalan_gun = (sirket_kalan_gun_date - DateTime.Today).Days;

            //            for(int olay_row_index = 0; olay_row_index < dataGridView_olaylar.RowCount; olay_row_index++)
            //            {
            //                if (dataGridView_olaylar[0, olay_row_index].Value != null && dataGridView_olaylar[1, olay_row_index].Value != null && dataGridView_olaylar[2, olay_row_index].Value != null && dataGridView_olaylar[3, olay_row_index].Value != null)
            //                {
            //                    if (dataGridView_olaylar[0, olay_row_index].Value.ToString() == currentGrid.Columns[2].HeaderText && dataGridView_olaylar[1, olay_row_index].Value.ToString() == currentGrid[0, current_sirket_row].Value.ToString() && dataGridView_olaylar[2, olay_row_index].Value.ToString() == currentGrid[5, current_sirket_row].Value.ToString() && dataGridView_olaylar[3, olay_row_index].Value.ToString() == sirket_kalan_gun.ToString())
            //                    {
            //                        has_been_inserted_sirket = true;
            //                    }
            //                }
            //            }
            //        }

            //        sirket_string = currentGrid[1, current_sirket_row].Value.ToString();
            //        sirket_check = DateTime.TryParse(sirket_string, out sirket_date);
            //        if(sirket_check)
            //        {
            //            if((sirket_date - DateTime.Today).Days <= 30 && !has_been_inserted_sirket)
            //            {
            //                dataGridView_olaylar.Rows.Add(currentGrid.Columns[2].HeaderText, currentGrid[0, current_sirket_row].Value.ToString(), currentGrid[5, current_sirket_row].Value.ToString(), (sirket_date - DateTime.Today).Days.ToString());
            //            }
            //        }
            //        sirket_kalan_gun = (sirket_date - DateTime.Today).Days;
            //    }
            //}

        }

        private void textBox_sirket_ekle_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void comboBox_mevcut_sirketler_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox_mevcut_sirketler_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
        }

        private void comboBox_mevcut_sirketler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if(current_panel != null)
            {
                current_panel.Visible = true;
            }
            else
            {
                
            }

            button_hesap.PerformClick();
        }
        private void sirket_dataGrid_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 1 && currentGrid[5, e.RowIndex].Value != null)
            {
                
                panel_takvim.Visible = true;
            }
            else
            {
                
            }

            if(e.ColumnIndex == 1 && currentGrid[5, e.RowIndex].Value == null)
            {
                MessageBox.Show("Lütfen önce kalan tutarı belirleyin.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            chosen_row_GelirGider = e.RowIndex;
            chosen_column_GelirGider = e.ColumnIndex;

            bool blank = false;

            for (int i = 1; i < 7; i++)
            {
               
                if (currentGrid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 8 && blank && currentGrid.RowCount > 1)
            {
                currentGrid.Rows.Remove(currentGrid.Rows[e.RowIndex]);
            }

            if (e.ColumnIndex == 7)
            {
                Panel current_fatura_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;
                Panel current_fatura_bilgi_panel = this.Controls.Find("Panel_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;


                if (current_fatura_bilgi_panel == null)
                {
                    Panel sirket_bilgi_panel = new Panel
                    {
                        Name = "Panel_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text,
                        AccessibleName = "Panel_Fatura_Bilgi_" + comboBox_mevcut_sirketler.Text,
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_gelirgider.Controls.Add(sirket_bilgi_panel);
                    panel_gelirgider.Controls.SetChildIndex(sirket_bilgi_panel, panel_counter);
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

            Panel current_fatura_panel = this.Controls.Find("Panel_" + currentGrid[0, e.RowIndex].Value.ToString(), true).FirstOrDefault() as Panel;
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

        private void button_takvim_Click(object sender, EventArgs e)
        {
            DataGridView current_grid = this.Controls.Find("DataGridView_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as DataGridView;

            if (current_grid != null)
            {
                selectedDateGelirGider = monthCalendar1.SelectionRange.Start.ToShortDateString();
                current_grid.Rows[chosen_row_GelirGider].Cells[chosen_column_GelirGider].Value = selectedDateGelirGider;
               
            }
            else
            {
                
            }

            
            panel_takvim.Visible = false;
        }

        private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            

        }

        private void textBox_sirket_ekle_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_olaylar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == 4 && (dataGridView_olaylar[0, e.RowIndex].Value != null || dataGridView_olaylar[1, e.RowIndex].Value != null || dataGridView_olaylar[2, e.RowIndex].Value != null))
            {
                dataGridView_olaylar.Rows.Remove(this.dataGridView_olaylar.Rows[e.RowIndex]);
            }
        }

        private void monthCalendar1_VisibleChanged(object sender, EventArgs e)
        {
            if(monthCalendar1.Visible == false && monthCalendar1.SelectionRange.Start != null)
            {

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

        private void button_toptanci_sec_Click(object sender, EventArgs e)
        {
           

            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (current_panel != null)
            {
                current_panel.Visible = false;
            }
            else
            {
                
            }

            Panel current_panel_toptanci = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel_toptanci != null)
            {
                current_panel_toptanci.Visible = false;
            }
            else
            {
                
            }

            panel_gelirgider.Visible = false;
            panel_anasayfa.Visible = false;
            panel_ekle.Visible = false;
            panel_gelir_gider_2.Visible = false;
            panel_ekle_2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel current_panel = this.Controls.Find("Panel_" + comboBox_mevcut_sirketler.Text, true).FirstOrDefault() as Panel;

            if (comboBox_mevcut_sirketler.Text != null)
            {
                if (current_panel != null)
                {
                    current_panel.Visible = false;
                }
                else
                {
                   
                }
            }

            Panel current_panel_toptanci = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel_toptanci != null)
            {
                current_panel_toptanci.Visible = true;
            }
            else
            {
               
            }


            panel_anasayfa.Visible = false;
            panel_ekle.Visible = false;
            panel_ekle_2.Visible = false;
            panel_gelirgider.Visible = false;
            panel_gelir_gider_2.Visible = true;

        }

        private void panel_ekle_2_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_ekle_2.Visible == true)
            {
                button_toptanci_sec.BackColor = Color.FromArgb(19, 19, 19);
                button_toptanci_sec.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_toptanci_sec.BackColor = Color.FromArgb(45, 45, 45);
                button_toptanci_sec.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void panel_gelir_gider_2_VisibleChanged(object sender, EventArgs e)
        {
            if (panel_gelir_gider_2.Visible == true)
            {
                button_toptanci_gelir.BackColor = Color.FromArgb(19, 19, 19);
                button_toptanci_gelir.FlatAppearance.MouseOverBackColor = Color.FromArgb(19, 19, 19);
            }
            else
            {
                button_toptanci_gelir.BackColor = Color.FromArgb(45, 45, 45);
                button_toptanci_gelir.FlatAppearance.MouseOverBackColor = Color.FromArgb(55, 55, 55);
            }
        }

        private void textBox_ekle_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_ekle_2_Click(object sender, EventArgs e)
        {
            if (textBox_ekle_2.Text.Length > 0)
            {
                comboBox_ekle_2.Items.Add(textBox_ekle_2.Text);
                Panel toptanci_panel = new Panel
                {
                    Name = "Panel_Toptanci_" + textBox_ekle_2.Text,
                    AccessibleName = "Panel_Toptanci_" + textBox_ekle_2.Text,
                    BackColor = Color.FromArgb(45, 45, 45)
                };

                panel_gelir_gider_2.Controls.Add(toptanci_panel);
                panel_gelir_gider_2.Controls.SetChildIndex(toptanci_panel, panel_counter);
                toptanci_panel.Dock = DockStyle.Fill;
                toptanci_panel.BorderStyle = BorderStyle.FixedSingle;
                toptanci_panel.Padding = new Padding(5);
                toptanci_panel.Visible = false;
                                               
                DataGridView toptanci_dataGrid = new DataGridView();
                toptanci_dataGrid.Name = "DataGridView_Toptanci_" + textBox_ekle_2.Text;
                toptanci_dataGrid.AccessibleName = "DataGridView_Toptanci_" + textBox_ekle_2.Text;
                toptanci_panel.Controls.Add(toptanci_dataGrid);
                toptanci_panel.Controls.SetChildIndex(toptanci_dataGrid, 1);
                toptanci_dataGrid.Dock = DockStyle.Fill;

                DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                sil.Name = "toptanci_dataGrid_sil_" + textBox_sirket_ekle.Text;
                sil.HeaderText = "Satırı Sil";
                sil.DefaultCellStyle.NullValue = "Sil";
                sil.ReadOnly = true;
                sil.FlatStyle = FlatStyle.Flat;

                DataGridViewButtonColumn bilgi = new DataGridViewButtonColumn();
                bilgi.Name = "toptanci_dataGrid_bilgi_" + textBox_sirket_ekle.Text;
                bilgi.HeaderText = "Müşteri Bilgisi";
                bilgi.DefaultCellStyle.NullValue = "Seç";
                bilgi.ReadOnly = true;
                bilgi.FlatStyle = FlatStyle.Flat;

                toptanci_dataGrid.Columns.Add("toptanci_dataGrid_isim", "Şirket");
                toptanci_dataGrid.Columns.Add("toptanci_dataGrid_tarih", "Tarih");

                toptanci_dataGrid.Columns["toptanci_dataGrid_tarih"].ReadOnly = true;
                toptanci_dataGrid.Columns.Add("toptanci_dataGrid_fatura", "Fatura");
                toptanci_dataGrid.Columns.Add("toptanci_dataGrid_tutar", "Tutar");
                toptanci_dataGrid.Columns[3].ValueType = System.Type.GetType("System.Decimal");
                toptanci_dataGrid.Columns[3].DefaultCellStyle.Format = "N2";
                toptanci_dataGrid.Columns.Add("toptanci_dataGrid_odenen", "Ödenen");
                toptanci_dataGrid.Columns[4].ValueType = System.Type.GetType("System.Decimal");
                toptanci_dataGrid.Columns[4].DefaultCellStyle.Format = "N2";
                toptanci_dataGrid.Columns.Add("toptanci_dataGrid_kalan", "Kalan");
                toptanci_dataGrid.Columns[5].ValueType = System.Type.GetType("System.Decimal");
                toptanci_dataGrid.Columns[5].DefaultCellStyle.Format = "N2";
                toptanci_dataGrid.Columns["toptanci_dataGrid_kalan"].ReadOnly = true;
                toptanci_dataGrid.Columns.Add("toptanci_dataGrid_banka", "Banka");
                toptanci_dataGrid.Columns.Add(bilgi);
                toptanci_dataGrid.Columns.Add(sil);

                toptanci_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                toptanci_dataGrid.RowHeadersVisible = false;
                toptanci_dataGrid.ColumnHeadersVisible = true;
                toptanci_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                toptanci_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                toptanci_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                toptanci_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                toptanci_dataGrid.DefaultCellStyle.Font = new Font(toptanci_dataGrid.Font.FontFamily, 15);
                toptanci_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(toptanci_dataGrid.Font.FontFamily, 15);
                toptanci_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                toptanci_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                toptanci_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                toptanci_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                toptanci_dataGrid.EnableHeadersVisualStyles = false;
                toptanci_dataGrid.RowHeadersWidth = 41;
                toptanci_dataGrid.ColumnHeadersHeight = 28;
                toptanci_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                toptanci_dataGrid.BorderStyle = BorderStyle.None;


                toptanci_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(toptanci_dataGrid_row_post_paint);
                toptanci_dataGrid.CellClick += new DataGridViewCellEventHandler(toptanci_dataGrid_Cell_Click);
                toptanci_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(toptanci_dataGrid_Cell_Editing);


                foreach (DataGridViewColumn column in toptanci_dataGrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }



                textBox_ekle_2.Text = null;
                button_ekle_ok_2.Visible = true;
                textBox_ekle_2_seciniz.ForeColor = Color.PaleGreen;
                textBox_ekle_2_seciniz.Text = "Toptancı ismi başarıyla eklendi.";

            }

        }
        private void toptanci_dataGrid_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            currentGrid[0, e.RowIndex].Value = comboBox_ekle_2.Text;

            if (currentGrid[3, e.RowIndex].Value != null && currentGrid[4, e.RowIndex].Value != null)
            {

                onceki_kalanlar = 0;

                for (int Current_Row = 0; Current_Row < e.RowIndex; Current_Row++)
                {
                    if (currentGrid[5, Current_Row].Value != null)
                    {
                        onceki_kalan_string = currentGrid[5, Current_Row].Value.ToString();
                        onceki_kalan_check = decimal.TryParse(onceki_kalan_string, out onceki_kalan_decimal);
                        if (onceki_kalan_check)
                        {
                            onceki_kalanlar += onceki_kalan_decimal;
                        }
                    }
                }

                tutar = currentGrid[3, e.RowIndex].Value.ToString();
                odenen = currentGrid[4, e.RowIndex].Value.ToString();
                tutar_dolu = decimal.TryParse(tutar, out tutar_int);
                odenen_dolu = decimal.TryParse(odenen, out odenen_int);


                if (tutar_dolu && odenen_dolu)
                {
                    kalan = tutar_int - odenen_int;
                    currentGrid[5, e.RowIndex].Value = kalan;
                }
            }
            for (int i = 0; i < 4; i += 2)
            {
                currentGrid[i, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
                currentGrid[i, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);
            }

            currentGrid[1, e.RowIndex].Style.BackColor = Color.FromArgb(70, 107, 128);
            currentGrid[1, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(38, 61, 74);

            currentGrid[3, e.RowIndex].Style.BackColor = Color.FromArgb(67, 39, 92);
            currentGrid[3, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(45, 24, 64);

            currentGrid[4, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[4, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            currentGrid[5, e.RowIndex].Style.BackColor = Color.FromArgb(105, 43, 54);
            currentGrid[5, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(71, 23, 31);

            currentGrid[6, e.RowIndex].Style.BackColor = Color.FromArgb(153, 125, 49);
            currentGrid[6, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(105, 86, 35);

            currentGrid[7, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[7, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            currentGrid[8, e.RowIndex].Style.BackColor = Color.FromArgb(40, 112, 61);
            currentGrid[8, e.RowIndex].Style.SelectionBackColor = Color.FromArgb(25, 69, 38);

            //for (int current_toptanci_row = 0; current_toptanci_row < currentGrid.RowCount; current_toptanci_row++)
            //{
            //    if (currentGrid[1, current_toptanci_row].Value != null && currentGrid[5, current_toptanci_row].Value != null)
            //    {
            //        has_been_inserted_toptanci = false;

            //        toptanci_kalan_gun_string = currentGrid[1, current_toptanci_row].Value.ToString();
            //        toptanci_kalan_gun_check = DateTime.TryParse(toptanci_kalan_gun_string, out toptanci_kalan_gun_date);
            //        if (toptanci_kalan_gun_check)
            //        {
            //            toptanci_kalan_gun = (toptanci_kalan_gun_date - DateTime.Today).Days;

            //            for (int olay_row_index = 0; olay_row_index < dataGridView_olaylar.RowCount; olay_row_index++)
            //            {
            //                if (dataGridView_olaylar[0, olay_row_index].Value != null && dataGridView_olaylar[1, olay_row_index].Value != null && dataGridView_olaylar[2, olay_row_index].Value != null && dataGridView_olaylar[3, olay_row_index].Value != null)
            //                {
            //                    if (dataGridView_olaylar[0, olay_row_index].Value.ToString() == currentGrid.Columns[2].HeaderText && dataGridView_olaylar[1, olay_row_index].Value.ToString() == currentGrid[0, current_toptanci_row].Value.ToString() + " (Toptancı)" && dataGridView_olaylar[2, olay_row_index].Value.ToString() == currentGrid[5, current_toptanci_row].Value.ToString() && dataGridView_olaylar[3, olay_row_index].Value.ToString() == toptanci_kalan_gun.ToString())
            //                    {
            //                        has_been_inserted_toptanci = true;
            //                    }
            //                }
            //            }
            //        }

            //        toptanci_string = currentGrid[1, current_toptanci_row].Value.ToString();
            //        toptanci_check = DateTime.TryParse(toptanci_string, out toptanci_date);
            //        if (toptanci_check)
            //        {
            //            if ((toptanci_date - DateTime.Today).Days <= 30 && !has_been_inserted_toptanci)
            //            {
            //                dataGridView_olaylar.Rows.Add(currentGrid.Columns[2].HeaderText, currentGrid[0, current_toptanci_row].Value.ToString() + " (Toptancı)", currentGrid[5, current_toptanci_row].Value.ToString(), (toptanci_date - DateTime.Today).Days.ToString());
            //            }
            //        }
            //        toptanci_kalan_gun = (toptanci_date - DateTime.Today).Days;
            //    }
            //}
        }

        private void toptanci_dataGrid_Cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            if (e.RowIndex == -1) return;

            chosen_row_toptanci = e.RowIndex;
            chosen_column_toptanci = e.ColumnIndex;

            if (e.ColumnIndex == 1 && currentGrid[5, e.RowIndex].Value != null)
            {
               
                panel_toptanci_takvim.Visible = true;
            }
            else
            {
               
            }

            if (e.ColumnIndex == 1 && currentGrid[5, e.RowIndex].Value == null)
            {
                MessageBox.Show("Lütfen önce kalan tutarı belirleyin.", "Uyarı",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            bool blank = false;

            for (int i = 1; i < 7; i++)
            {

                if (currentGrid[i, e.RowIndex].Value != null)
                {
                    blank = true;
                    break;
                }
            }
            if (e.ColumnIndex == 8 && blank && currentGrid.RowCount > 1)
            {
                currentGrid.Rows.Remove(currentGrid.Rows[e.RowIndex]);
            }

            if (e.ColumnIndex == 7)
            {
                Panel current_toptanci_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;
                Panel current_toptanci_bilgi_panel = this.Controls.Find("Panel_Toptanci_Bilgi_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;


                if (current_toptanci_bilgi_panel == null)
                {
                    Panel toptanci_bilgi_panel = new Panel
                    {
                        Name = "Panel_Toptanci_Bilgi_" + comboBox_ekle_2.Text,
                        AccessibleName = "Panel_Toptanci_Bilgi_" + comboBox_ekle_2.Text,
                        BackColor = Color.FromArgb(45, 45, 45)
                    };

                    panel_gelir_gider_2.Controls.Add(toptanci_bilgi_panel);
                    panel_gelir_gider_2.Controls.SetChildIndex(toptanci_bilgi_panel, panel_counter);
                    toptanci_bilgi_panel.Dock = DockStyle.Fill;
                    toptanci_bilgi_panel.BorderStyle = BorderStyle.FixedSingle;
                    toptanci_bilgi_panel.Padding = new Padding(5);
                    toptanci_bilgi_panel.Visible = false;


                    DataGridView toptanci_bilgi_dataGrid = new DataGridView();
                    toptanci_bilgi_dataGrid.Name = "DataGridView_Toptanci_Bilgi_" + comboBox_ekle_2.Text;
                    toptanci_bilgi_dataGrid.AccessibleName = "DataGridView_Toptanci_Bilgi_" + comboBox_ekle_2.Text;
                    toptanci_bilgi_panel.Controls.Add(toptanci_bilgi_dataGrid);
                    toptanci_bilgi_panel.Controls.SetChildIndex(toptanci_bilgi_dataGrid, 1);
                    toptanci_bilgi_dataGrid.Dock = DockStyle.Fill;

                    DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                    sil.Name = "topanci_bilgi_sil_" + textBox_sirket_ekle.Text;
                    sil.HeaderText = "Satırı Sil";
                    sil.DefaultCellStyle.NullValue = "Sil";
                    sil.ReadOnly = true;
                    sil.FlatStyle = FlatStyle.Flat;

                    DataGridViewButtonColumn geri_don = new DataGridViewButtonColumn();
                    geri_don.Name = "toptanci_bilgi_geri_don_" + textBox_sirket_ekle.Text;
                    geri_don.HeaderText = "Geri Dön";
                    geri_don.DefaultCellStyle.NullValue = "Seç";
                    geri_don.ReadOnly = true;
                    geri_don.FlatStyle = FlatStyle.Flat;

                    toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_musteri", "Müşteri");
                    toptanci_bilgi_dataGrid.Columns[0].ReadOnly = true;
                    toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_telefon", "Telefon");

                    toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_adres", "Adres");

                    toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_banka", "Banka Bilgileri");
                    toptanci_bilgi_dataGrid.Columns.Add(geri_don);
                    toptanci_bilgi_dataGrid.Columns.Add(sil);


                    toptanci_bilgi_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                    toptanci_bilgi_dataGrid.RowHeadersVisible = false;
                    toptanci_bilgi_dataGrid.ColumnHeadersVisible = true;

                    toptanci_bilgi_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    toptanci_bilgi_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    toptanci_bilgi_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                    toptanci_bilgi_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                    toptanci_bilgi_dataGrid.DefaultCellStyle.Font = new Font(toptanci_bilgi_dataGrid.Font.FontFamily, 15);
                    toptanci_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(toptanci_bilgi_dataGrid.Font.FontFamily, 15);
                    toptanci_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    toptanci_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                    toptanci_bilgi_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    toptanci_bilgi_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    toptanci_bilgi_dataGrid.EnableHeadersVisualStyles = false;

                    toptanci_bilgi_dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    toptanci_bilgi_dataGrid.ColumnHeadersHeight = 28;
                    toptanci_bilgi_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    toptanci_bilgi_dataGrid.BorderStyle = BorderStyle.None;

                    toptanci_bilgi_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(toptanci_bilgi_dataGrid_row_post_paint);
                    toptanci_bilgi_dataGrid.CellClick += new DataGridViewCellEventHandler(toptanci_bilgi_dataGrid_Cell_Click);
                    toptanci_bilgi_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(toptanci_bilgi_dataGrid_Editing);


                    foreach (DataGridViewColumn column in toptanci_bilgi_dataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    current_toptanci_panel.Visible = false;
                    toptanci_bilgi_panel.Visible = true;
                }
                else
                {
                    current_toptanci_panel.Visible = false;
                    current_toptanci_bilgi_panel.Visible = true;
                }

            }
        }

        private void toptanci_bilgi_dataGrid_row_post_paint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView current_Fatura_Grid = (DataGridView)sender;

            current_Fatura_Grid[0, e.RowIndex].Value = comboBox_ekle_2.Text;

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

        private void toptanci_bilgi_dataGrid_Cell_Click(object sender, DataGridViewCellEventArgs e)
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

        private void toptanci_bilgi_dataGrid_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void toptanci_dataGrid_Cell_Editing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView currentGrid = (DataGridView)sender;

            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (currentGrid.CurrentCell.ColumnIndex == 3 || currentGrid.CurrentCell.ColumnIndex == 4)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void button_ekle_ok_2_Click(object sender, EventArgs e)
        {
            button_ekle_ok_2.Visible = false;
            textBox_ekle_2_seciniz.Text = "Aşağıdaki açılır listeden toptancı seçiniz.";
            textBox_ekle_2_seciniz.ForeColor = Color.White;
        }

        private void comboBox_ekle_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel current_panel = this.Controls.Find("Panel_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as Panel;

            if (current_panel != null)
            {
                current_panel.Visible = true;
            }
            else
            {
                
            }

            button_toptanci_gelir.PerformClick();
        }

        private void panel_gelir_gider_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridView current_grid = this.Controls.Find("DataGridView_Toptanci_" + comboBox_ekle_2.Text, true).FirstOrDefault() as DataGridView;

            if (current_grid != null)
            {
                selectedDateToptanci = monthCalendar_toptanci.SelectionRange.Start.ToShortDateString();
                current_grid.Rows[chosen_row_toptanci].Cells[chosen_column_toptanci].Value = selectedDateToptanci;
                
            }
            else
            {
               
            }


            panel_toptanci_takvim.Visible = false;
        }

        private void button_tasimacilik_Enter(object sender, EventArgs e)
        {

        }

        private void button_tasimacilik_MouseEnter(object sender, EventArgs e)
        {
            button_tasimacilik.FlatAppearance.BorderColor = Color.White;
            button_tasimacilik.ForeColor = Color.White;
        }
    

        private void button_tasimacilik_Leave(object sender, EventArgs e)
        {
        
        }

        private void button_dukkan_MouseEnter(object sender, EventArgs e)
        {
            button_dukkan.FlatAppearance.BorderColor = Color.White;
            button_dukkan.ForeColor = Color.White;
        }

        private void button_dukkan_MouseLeave(object sender, EventArgs e)
        {
            button_dukkan.FlatAppearance.BorderColor = Color.FromArgb(151, 38, 32);
            button_dukkan.ForeColor = Color.FromArgb(151, 38, 32);
        }

        private void button_tasimacilik_MouseLeave(object sender, EventArgs e)
        {
            button_tasimacilik.FlatAppearance.BorderColor = Color.FromArgb(113, 112, 110);
            button_tasimacilik.ForeColor = Color.FromArgb(113, 112, 110);
        }

        private void CreateMusteri(ComboBox musteriler, string Path)
        {
            for (int CurrentIndex = 0; CurrentIndex < musteriler.Items.Count; CurrentIndex++)
            {
                Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString());
                Panel current_panel = this.Controls.Find("Panel_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as Panel;
                if (current_panel != null)
                {
                    DataGridView current_grid = this.Controls.Find("DataGridView_" + musteriler.Items[CurrentIndex].ToString(), true).FirstOrDefault() as DataGridView;
                    if (current_grid != null)
                    {
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_" + musteriler.Items[CurrentIndex].ToString());
                        Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_" + musteriler.Items[CurrentIndex].ToString());
                        for (int CurrentGelirRow = 0; CurrentGelirRow < current_grid.Rows.Count - 1; CurrentGelirRow++)
                        {
                            Directory.CreateDirectory(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString());
                            using (FileStream fs = File.Create(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt"))
                            {

                            }
                            StreamWriter sw = new StreamWriter(Path + "\\" + musteriler.Items[CurrentIndex].ToString() + "\\" + "Panel_" + musteriler.Items[CurrentIndex].ToString() + "\\" + "DataGridView_" + musteriler.Items[CurrentIndex].ToString() + "\\" + CurrentGelirRow.ToString() + "\\" + "properties.txt");
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

                        panel_gelirgider.Controls.Add(sirket_panel);
                        panel_gelirgider.Controls.SetChildIndex(sirket_panel, panel_counter);
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

                            sirket_dataGrid.Columns.Add("sirket_dataGrid_isim", "Şirket");
                            sirket_dataGrid.Columns.Add("sirket_dataGrid_tarih", "Tarih");

                            sirket_dataGrid.Columns["sirket_dataGrid_tarih"].ReadOnly = true;
                            sirket_dataGrid.Columns.Add("sirket_dataGrid_fatura", "Fatura");
                            sirket_dataGrid.Columns.Add("sirket_dataGrid_tutar", "Tutar");
                            sirket_dataGrid.Columns[3].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns[3].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns.Add("sirket_dataGrid_odenen", "Ödenen");
                            sirket_dataGrid.Columns[4].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns[4].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns.Add("sirket_dataGrid_kalan", "Kalan");
                            sirket_dataGrid.Columns[5].ValueType = System.Type.GetType("System.Decimal");
                            sirket_dataGrid.Columns[5].DefaultCellStyle.Format = "N2";
                            sirket_dataGrid.Columns["sirket_dataGrid_kalan"].ReadOnly = true;
                            sirket_dataGrid.Columns.Add("sirket_dataGrid_banka", "Banka");
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

                            sirket_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(sirket_dataGrid_row_post_paint);
                            sirket_dataGrid.CellClick += new DataGridViewCellEventHandler(sirket_dataGrid_Cell_Click);
                            sirket_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(sirket_dataGrid_Cell_Editing);

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

        private void ReadToptanci(string Path)
        {
            string[] AllMusteriFiles = Directory.GetDirectories(Path, "*", SearchOption.TopDirectoryOnly);

            if (AllMusteriFiles.Length > 0)
            {
                foreach (string CurrentMusteriFile in AllMusteriFiles)
                {
                    string MusteriFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentMusteriFile)).Name;
                    comboBox_ekle_2.Items.Add(MusteriFolderName);

                    string[] AllPanelFiles = Directory.GetDirectories(CurrentMusteriFile, "*", SearchOption.TopDirectoryOnly);
                    foreach (string CurrentPanelFile in AllPanelFiles)
                    {
                        string PanelFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentPanelFile)).Name;
                        Panel toptanci_panel = new Panel
                        {
                            Name = PanelFolderName,
                            AccessibleName = PanelFolderName,
                            BackColor = Color.FromArgb(45, 45, 45)
                        };

                        panel_gelir_gider_2.Controls.Add(toptanci_panel);
                        panel_gelir_gider_2.Controls.SetChildIndex(toptanci_panel, panel_counter);
                        toptanci_panel.Dock = DockStyle.Fill;
                        toptanci_panel.BorderStyle = BorderStyle.FixedSingle;
                        toptanci_panel.Padding = new Padding(5);
                        toptanci_panel.Visible = false;


                        string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                        foreach (string CurrentGridFile in AllGridFiles)
                        {
                            string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;

                            DataGridView toptanci_dataGrid = new DataGridView();
                            toptanci_dataGrid.Name = GridFolderName;
                            toptanci_dataGrid.AccessibleName = GridFolderName;
                            toptanci_panel.Controls.Add(toptanci_dataGrid);
                            toptanci_panel.Controls.SetChildIndex(toptanci_dataGrid, 1);
                            toptanci_dataGrid.Dock = DockStyle.Fill;

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "toptanci_dataGrid_sil_" + GridFolderName;
                            sil.HeaderText = "Satırı Sil";
                            sil.DefaultCellStyle.NullValue = "Sil";
                            sil.ReadOnly = true;
                            sil.FlatStyle = FlatStyle.Flat;

                            DataGridViewButtonColumn bilgi = new DataGridViewButtonColumn();
                            bilgi.Name = "toptanci_dataGrid_bilgi_" + GridFolderName;
                            bilgi.HeaderText = "Müşteri Bilgisi";
                            bilgi.DefaultCellStyle.NullValue = "Seç";
                            bilgi.ReadOnly = true;
                            bilgi.FlatStyle = FlatStyle.Flat;

                            toptanci_dataGrid.Columns.Add("toptanci_dataGrid_isim", "Şirket");
                            toptanci_dataGrid.Columns.Add("toptanci_dataGrid_tarih", "Tarih");

                            toptanci_dataGrid.Columns["toptanci_dataGrid_tarih"].ReadOnly = true;
                            toptanci_dataGrid.Columns.Add("toptanci_dataGrid_fatura", "Fatura");
                            toptanci_dataGrid.Columns.Add("toptanci_dataGrid_tutar", "Tutar");
                            toptanci_dataGrid.Columns[3].ValueType = System.Type.GetType("System.Decimal");
                            toptanci_dataGrid.Columns[3].DefaultCellStyle.Format = "N2";
                            toptanci_dataGrid.Columns.Add("toptanci_dataGrid_odenen", "Ödenen");
                            toptanci_dataGrid.Columns[4].ValueType = System.Type.GetType("System.Decimal");
                            toptanci_dataGrid.Columns[4].DefaultCellStyle.Format = "N2";
                            toptanci_dataGrid.Columns.Add("toptanci_dataGrid_kalan", "Kalan");
                            toptanci_dataGrid.Columns[5].ValueType = System.Type.GetType("System.Decimal");
                            toptanci_dataGrid.Columns[5].DefaultCellStyle.Format = "N2";
                            toptanci_dataGrid.Columns["toptanci_dataGrid_kalan"].ReadOnly = true;
                            toptanci_dataGrid.Columns.Add("toptanci_dataGrid_banka", "Banka");
                            toptanci_dataGrid.Columns.Add(bilgi);
                            toptanci_dataGrid.Columns.Add(sil);

                            toptanci_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                            toptanci_dataGrid.RowHeadersVisible = false;
                            toptanci_dataGrid.ColumnHeadersVisible = true;
                            toptanci_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            toptanci_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            toptanci_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                            toptanci_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                            toptanci_dataGrid.DefaultCellStyle.Font = new Font(toptanci_dataGrid.Font.FontFamily, 15);
                            toptanci_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(toptanci_dataGrid.Font.FontFamily, 15);
                            toptanci_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            toptanci_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                            toptanci_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                            toptanci_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                            toptanci_dataGrid.EnableHeadersVisualStyles = false;
                            toptanci_dataGrid.RowHeadersWidth = 41;
                            toptanci_dataGrid.ColumnHeadersHeight = 28;
                            toptanci_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            toptanci_dataGrid.BorderStyle = BorderStyle.None;


                            toptanci_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(toptanci_dataGrid_row_post_paint);
                            toptanci_dataGrid.CellClick += new DataGridViewCellEventHandler(toptanci_dataGrid_Cell_Click);
                            toptanci_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(toptanci_dataGrid_Cell_Editing);


                            foreach (DataGridViewColumn column in toptanci_dataGrid.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }

                            string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                            if (AllColumnFiles.Length > 0)
                            {
                                int RowCounter = 0;
                                foreach (string CurrentColumnFile in AllColumnFiles)
                                {
                                    toptanci_dataGrid.Rows.Add();
                                    using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                    {
                                        string line;
                                        int ColumnCounter = 0;

                                        while ((line = sr.ReadLine()) != null)
                                        {

                                            toptanci_dataGrid[ColumnCounter, RowCounter].Value = line;

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

                        panel_gelirgider.Controls.Add(sirket_bilgi_panel);
                        panel_gelirgider.Controls.SetChildIndex(sirket_bilgi_panel, panel_counter);
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

        private void ReadToptanciBilgi(string Path)
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
                        Panel toptanci_bilgi_panel = new Panel
                        {
                            Name = PanelFolderName,
                            AccessibleName = PanelFolderName,
                            BackColor = Color.FromArgb(45, 45, 45)
                        };

                        panel_gelir_gider_2.Controls.Add(toptanci_bilgi_panel);
                        panel_gelir_gider_2.Controls.SetChildIndex(toptanci_bilgi_panel, panel_counter);
                        toptanci_bilgi_panel.Dock = DockStyle.Fill;
                        toptanci_bilgi_panel.BorderStyle = BorderStyle.FixedSingle;
                        toptanci_bilgi_panel.Padding = new Padding(5);
                        toptanci_bilgi_panel.Visible = false;


                        string[] AllGridFiles = Directory.GetDirectories(CurrentPanelFile, "*", SearchOption.TopDirectoryOnly);
                        foreach (string CurrentGridFile in AllGridFiles)
                        {
                            string GridFolderName = new DirectoryInfo(System.IO.Path.GetFileName(CurrentGridFile)).Name;

                            DataGridView toptanci_bilgi_dataGrid = new DataGridView();
                            toptanci_bilgi_dataGrid.Name = GridFolderName;
                            toptanci_bilgi_dataGrid.AccessibleName = GridFolderName;
                            toptanci_bilgi_panel.Controls.Add(toptanci_bilgi_dataGrid);
                            toptanci_bilgi_panel.Controls.SetChildIndex(toptanci_bilgi_dataGrid, 1);
                            toptanci_bilgi_dataGrid.Dock = DockStyle.Fill;

                            DataGridViewButtonColumn sil = new DataGridViewButtonColumn();
                            sil.Name = "topanci_bilgi_sil_" + GridFolderName;
                            sil.HeaderText = "Satırı Sil";
                            sil.DefaultCellStyle.NullValue = "Sil";
                            sil.ReadOnly = true;
                            sil.FlatStyle = FlatStyle.Flat;

                            DataGridViewButtonColumn geri_don = new DataGridViewButtonColumn();
                            geri_don.Name = "toptanci_bilgi_geri_don_" + GridFolderName;
                            geri_don.HeaderText = "Geri Dön";
                            geri_don.DefaultCellStyle.NullValue = "Seç";
                            geri_don.ReadOnly = true;
                            geri_don.FlatStyle = FlatStyle.Flat;

                            toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_musteri", "Müşteri");
                            toptanci_bilgi_dataGrid.Columns[0].ReadOnly = true;
                            toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_telefon", "Telefon");

                            toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_adres", "Adres");

                            toptanci_bilgi_dataGrid.Columns.Add("toptanci_bilgi_dataGrid_banka", "Banka Bilgileri");
                            toptanci_bilgi_dataGrid.Columns.Add(geri_don);
                            toptanci_bilgi_dataGrid.Columns.Add(sil);


                            toptanci_bilgi_dataGrid.BackgroundColor = Color.FromArgb(45, 45, 45);
                            toptanci_bilgi_dataGrid.RowHeadersVisible = false;
                            toptanci_bilgi_dataGrid.ColumnHeadersVisible = true;

                            toptanci_bilgi_dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            toptanci_bilgi_dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                            toptanci_bilgi_dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
                            toptanci_bilgi_dataGrid.DefaultCellStyle.ForeColor = Color.White;
                            toptanci_bilgi_dataGrid.DefaultCellStyle.Font = new Font(toptanci_bilgi_dataGrid.Font.FontFamily, 15);
                            toptanci_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(toptanci_bilgi_dataGrid.Font.FontFamily, 15);
                            toptanci_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            toptanci_bilgi_dataGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 5, 0, 0);
                            toptanci_bilgi_dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                            toptanci_bilgi_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                            toptanci_bilgi_dataGrid.EnableHeadersVisualStyles = false;

                            toptanci_bilgi_dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            toptanci_bilgi_dataGrid.ColumnHeadersHeight = 28;
                            toptanci_bilgi_dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            toptanci_bilgi_dataGrid.BorderStyle = BorderStyle.None;

                            toptanci_bilgi_dataGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(toptanci_bilgi_dataGrid_row_post_paint);
                            toptanci_bilgi_dataGrid.CellClick += new DataGridViewCellEventHandler(toptanci_bilgi_dataGrid_Cell_Click);
                            toptanci_bilgi_dataGrid.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(toptanci_bilgi_dataGrid_Editing);


                            foreach (DataGridViewColumn column in toptanci_bilgi_dataGrid.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }

                            string[] AllColumnFiles = Directory.GetDirectories(CurrentGridFile, "*", SearchOption.TopDirectoryOnly);
                            if (AllColumnFiles.Length > 0)
                            {
                                int RowCounter = 0;
                                foreach (string CurrentColumnFile in AllColumnFiles)
                                {
                                    toptanci_bilgi_dataGrid.Rows.Add();
                                    using (StreamReader sr = new StreamReader(CurrentColumnFile + "\\" + "properties.txt"))
                                    {
                                        string line;
                                        int ColumnCounter = 0;

                                        while ((line = sr.ReadLine()) != null)
                                        {

                                            toptanci_bilgi_dataGrid[ColumnCounter, RowCounter].Value = line;

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


    }
}
