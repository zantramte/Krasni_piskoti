using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Threading;

namespace Pojoči_piškotki
{
    public partial class Krasni_piškotki : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public void Ne()
        {
            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if (panel1.Controls[indeks] is PictureBox)
                {
                    panel1.Controls[indeks].Enabled = false;
                }
            }
        }

        public void Ja()
        {
            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if (panel1.Controls[indeks] is PictureBox)
                {
                    panel1.Controls[indeks].Enabled = true;
                }
            }
        }

        public async void Uredi_vse()
        {
            Ne();

            if (Piskotki.stopnja < Piskotki.stevec)
            {
                Piskotki.stopnja++;
                
                Piskotki.Trenutni_glasek = Piskotki.Vrni_Trenutno_Stevilko_Glas();

                for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
                {
                    if ((panel1.Controls[indeks] is Label) && (Convert.ToInt32(panel1.Controls[indeks].Text) == Piskotki.Sedajsnji_glas))
                    {
                        for (int indekss = 0; indekss < panel1.Controls.Count; indekss++)
                        {
                            if ((panel1.Controls[indekss] is PictureBox) && (panel1.Controls[indekss].Location.X == (panel1.Controls[indeks].Location.X - 54)))
                            {
                                panel1.Controls[indeks].ForeColor = Color.Chocolate;

                                panel1.Controls[indekss].BackgroundImage = Properties.Resources.kk;

                                player.URL = "smeh.wav";

                                await Task.Delay(900);

                                panel1.Controls[indeks].ForeColor = Color.White;

                                panel1.Controls[indekss].BackgroundImage = Properties.Resources.image__7_;
                            }
                        }
                    }
                }
            }
        }

        public Krasni_piškotki()
        {
            InitializeComponent();

            Piskotki.Serija_glasov.Clear();

            Piskotki.Polni_glasove();

            Piskotki.Vrni_Trenutno_Stevilko_Glas();

            Uredi_vse();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox cookie = sender as PictureBox;
            cookie.BackgroundImage = Properties.Resources.kk;
            Cursor = Cursors.Hand;
            player.URL = "smeh.wav";

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (cookie.Location.X + 54)))
                {
                    panel1.Controls[indeks].ForeColor = Color.Chocolate;
                }
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox cookie = sender as PictureBox;
            cookie.BackgroundImage = Properties.Resources.image__7_;
            Cursor = Cursors.Default;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (cookie.Location.X + 54)))
                {
                    panel1.Controls[indeks].ForeColor = Color.White;
                }
            }
        }
    }
}
