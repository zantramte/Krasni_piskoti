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

namespace Pojoči_piškotki
{
    public partial class Krasni_piškotki : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public Krasni_piškotki()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox cookie = sender as PictureBox;
            cookie.Image = Properties.Resources.kk;
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
            cookie.Image = Properties.Resources.image__7_;
            Cursor = Cursors.Default;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (cookie.Location.X + 54)))
                {
                    panel1.Controls[indeks].ForeColor = Color.White;
                }
            }
        }

        private void Krasni_piškotki_Load(object sender, EventArgs e)
        {
            Piskotki.Serija_glasov.Clear();

            Piskotki.Polni_glasove();

            Casovnik.Start();
        }

        private void Casovnik_Tick(object sender, EventArgs e)
        {
            for (int indeks = 0; indeks < Piskotki.Serija_glasov.Count; indeks++)
            {
                for (int indekss = 0; indekss < panel1.Controls.Count; indekss++)
                {
                    if (panel1.Controls[indekss] is Label)
                    {
                        if (Convert.ToInt32(panel1.Controls[indekss].Text) == Piskotki.Serija_glasov[indeks])
                        {
                            Casovnik.Enabled = true;

                            Casovnik.Start();

                            panel1.Controls[indekss].ForeColor = Color.Chocolate;

                            Casovnik.Stop();

                            panel1.Controls[indekss].ForeColor = Color.White;
                        }
                    }
                }
            }

            MessageBox.Show("KONEC! Zdaj pa še ti ponovi za nami!", "Piškotki sporočajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
