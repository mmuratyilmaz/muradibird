using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuradiBird
{
    public partial class Form2 : Form
    {
        //Tanımlamalar

        int i = 0;
        int a = 0;
        int b = 0;
        int c = 0;
        int skor = 0;

        bool artis = false;
        bool ters = false;
        bool baslangic = false;

        List<PictureBox> pb_bilgi = new List<PictureBox>();

        public Form2()
        {
            InitializeComponent();
        }

        private void bulut_olustur()
        {
            int h = 0;
            for(int k = 0; k <= 7; k++)
            {
                h += 140;
                PictureBox bulut = new PictureBox();
                bulut.Size = new Size(75, 75);
                bulut.Top = 50;
                bulut.Left = h;
                bulut.Image = Properties.Resources.bulut1;
                bulut.SizeMode = PictureBoxSizeMode.StretchImage;
                //bulut.Controls.SetChildIndex(sira, 1);
                //bulut.BringToFront();
                bulut.BackColor = Color.Transparent;
                this.Controls.Add(bulut);
                bulut.SendToBack();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(20, 120, 192);
            bulut_olustur();
            if (baslangic == false)
            {
                Random rastgele = new Random();
                int sayi = rastgele.Next(150, this.Size.Height - 250);
                dikdortgen_uret_alt(this.Size.Width, sayi);
                dikdortgen_uret(this.Size.Width, sayi);
                baslangic = true;
            }

            timer2.Enabled = true;
            karakter.Left = this.Size.Width / 2;
            karakter.Top = this.Size.Height / 2;
            karakter.Image = Properties.Resources.res;
            karakter.Width = 75;
            karakter.Height = 75;
            karakter.SizeMode = PictureBoxSizeMode.StretchImage;
            karakter.BackColor = Color.Transparent;
            this.Controls.Add(karakter);
            timer1.Enabled = true;
            timer3.Enabled = true;
        }

        private void dikdortgen_uret(int x, int y)
        {
            i++;
            PictureBox pb = new PictureBox();
            pb.Name = "pb" + i;
            pb.SetBounds(x, 0, 100, y);
            pb.SendToBack();
            pb.Image = Properties.Resources.toptube;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;
            this.Controls.Add(pb);
            pb.BringToFront(); 
            pb_bilgi.Add(pb);
        }

        private void dikdortgen_uret_alt(int x, int y)
        {
            i++;
            PictureBox pb = new PictureBox();
            pb.Name = "pb" + i;
            pb.SetBounds(x, y + 200, 100, this.Size.Height);
            pb.SendToBack();
            pb.Image = Properties.Resources.bottomtube;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;
            this.Controls.Add(pb);
            
            pb_bilgi.Add(pb);
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            b++;
            if(b <= 2)
            {
                karakter.Top -= 45;
            }
            else if (b > 2 && b < 5 )
            {
                karakter.Top -= 60;
            }
            else if(b >= 5)
            {
                karakter.Top -= 100;
            }
            a = 0;
        }

        private void game_over()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            label2.Left = (this.Size.Width - label2.Size.Width) / 2;
            label2.Top = this.Size.Height / 2;
            label2.Visible = true;
            label2.Text = "Kaybettin Ezik!";
            label3.Left = this.Size.Width / 2;
            label3.Top = this.Size.Height / 2 + label2.Height;
            label3.Visible = true;
            label3.Text = "Skor: " + skor;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var item in pb_bilgi)
            {
                item.Left -= 6;
            }
            if (ters == true)
            {
                if (ters == true)
                {
                    if (karakter.Left < pb_bilgi[c].Right && karakter.Right > pb_bilgi[c].Left)
                    {
                        if (karakter.Top < pb_bilgi[c].Bottom - 5)
                        {
                            game_over();
                        }
                        else if (karakter.Bottom > pb_bilgi[c + 1].Top  + 5)
                        {
                            game_over();
                        }
                        else if (karakter.Top > pb_bilgi[c].Bottom && karakter.Bottom < pb_bilgi[c + 1].Top)
                        {
                            artis = true;
                        }
                    }
                }
            }
            else
            {
                if (karakter.Right > pb_bilgi[c].Left && karakter.Left < pb_bilgi[c].Right)
                {
                    if (karakter.Bottom > pb_bilgi[c].Top + 5)
                    {
                        game_over();
                    }
                    else if (karakter.Top < pb_bilgi[c + 1].Bottom - 5)
                    {
                        game_over();
                    }
                    else if (karakter.Bottom < pb_bilgi[c].Top && karakter.Top > pb_bilgi[c + 1].Bottom)
                    {
                        artis = true;
                    }
                }

            }
            if (artis == true)
            {
                if (karakter.Left > pb_bilgi[c].Right)
                {
                    c++;
                    c++;
                    skor++;
                    artis = false;
                    ters = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(150,this.Size.Height-250);
            dikdortgen_uret(this.Size.Width, sayi);
            dikdortgen_uret_alt(this.Size.Width, sayi);
        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {
            a++;
            if(a<5)
            {
                karakter.Top += 0;
            }
            else if(a <= 15)
            {
                karakter.Top += 1;
            }
            else if( a > 15  && a < 20)
            {
                karakter.Top += 5;
            }
            else if(a >= 20)
            {
                karakter.Top += 10;
            }
            if(a > 20)
            {
                b = 0;
            }
            
            if(karakter.Bottom >= this.Size.Height +10)
            {
                game_over();
            }
            if(karakter.Top <= 0)
            {
                karakter.Top = 0;
            }
            
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                b++;
                if (b <= 2)
                {
                    karakter.Top -= 45;
                }
                else if (b > 2 && b < 5)
                {
                    karakter.Top -= 60;
                }
                else if (b >= 5)
                {
                    karakter.Top -= 100;
                }

                a = 0;
            }
            if(e.KeyCode == Keys.Escape)
            {
                Form1 frm1 = new Form1();
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                this.Close();
                frm1.Show();
            }
        }
    }
}
