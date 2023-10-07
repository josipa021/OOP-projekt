using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OTTER
{
    public partial class IzbornikNaKraju : Form
    {
        public IzbornikNaKraju()
        {
            InitializeComponent();
        }

        public Izbornik pocetni;
        private bool pokusaj;
        private int i;

        private void IzbornikNaKraju_Load(object sender, EventArgs e)
        {
            pokusaj = false;
            i = pocetni.Indeks;
            btn_novi_level.Visible = false;

            if (Game.Gameover)
            {
                this.BackgroundImage = Properties.Resources.kraj_neuspjeh;
                label1.Text = "Ups! Morate se vratiti kući. Više sreće drugi put, " + Game.Lista_igraca[i][0] + "!";
            }

            if (Game.Goal)
            {
                this.BackgroundImage = Properties.Resources.kraj_uspjeh;
                label1.Text = "Čestitamo, " + Game.Lista_igraca[i][0] + "! Uspjeli ste doći do djevojke živi i zdravi!\n";
                if (Game.Rekord)
                    label1.Text += "\nOborili ste i rekord u skupljanju novčića!";
                label1.Text += "\nVaš maksimalni broj novčića je: " + Game.Lista_igraca[i][1];
            }

            if (Game.Goal && Game.Level < 2 && int.Parse(Game.Lista_igraca[i][2]) > Game.Level) // < 2 jer je 2 ukupan br levela koje smo napravile
                btn_novi_level.Visible = true;
        }

        private void Pokusaj_ponovno_Click(object sender, EventArgs e)
        {
            pokusaj = true;
            pocetni.Indeks = i;
            pocetni.button1_Click(null, null);
            this.Close();
        }

        private void Povratak_na_menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IzbornikNaKraju_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!pokusaj)
            {
                pocetni.Show();
                pocetni.Indeks = -1;
            }
            this.Dispose(true);
            GC.Collect();
        }

        private void btn_novi_level_Click(object sender, EventArgs e)
        {
            pokusaj = true;
            pocetni.Indeks = i;
            Game.Level = Game.Level + 1;
            pocetni.button1_Click(null, null);
            this.Close();
        }

        private void Povratak_na_menu_MouseHover(object sender, EventArgs e)
        {
            Povratak_na_menu.BackgroundImage = Properties.Resources.crvena;
        }

        private void Povratak_na_menu_MouseLeave(object sender, EventArgs e)
        {
            Povratak_na_menu.BackgroundImage = Properties.Resources.normalno;
        }

        private void Pokusaj_ponovno_MouseHover(object sender, EventArgs e)
        {
            Pokusaj_ponovno.BackgroundImage = Properties.Resources.crvena;
        }

        private void Pokusaj_ponovno_MouseLeave(object sender, EventArgs e)
        {
            Pokusaj_ponovno.BackgroundImage = Properties.Resources.normalno;
        }

        private void btn_novi_level_MouseHover(object sender, EventArgs e)
        {
            btn_novi_level.BackgroundImage = Properties.Resources.crvena;
        }

        private void btn_novi_level_MouseLeave(object sender, EventArgs e)
        {
            btn_novi_level.BackgroundImage = Properties.Resources.normalno;
        }
    }
}
