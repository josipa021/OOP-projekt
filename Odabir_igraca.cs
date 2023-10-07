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
    public partial class Odabir_igraca : Form
    {
        public Izbornik pocetni;

        public Odabir_igraca()
        {
            InitializeComponent();
        }

        private void Odabir_igraca_Load(object sender, EventArgs e)
        {
            rblevel1.Visible = false;
            rblevel2.Visible = false;
            lblnaslov.Text = "Odaberite igrača s popisa:";
            lblporuka.Text = "";
            lblodabir_levela.Text = "";
            lbl_prikaz_odabira.Text = "";

            listbox_lista_igraca.Items.Clear();
            foreach (string[] s in Game.Lista_igraca)
            {
                listbox_lista_igraca.Items.Add(s[0]);
            }
        }

        private void spremi_odabir_Click(object sender, EventArgs e)
        {
            if (listbox_lista_igraca.SelectedIndex > -1)
            {
                pocetni.Indeks = listbox_lista_igraca.SelectedIndex;

                if (rblevel1.Checked)
                {
                    Game.Level = 1;
                    this.Close();
                }
                else if (rblevel2.Checked)
                {
                    Game.Level = 2;
                    this.Close();
                }
                else
                    lblporuka.Text = "Morate odabrati level!";
            }
            else
            {
                lblporuka.Text = "Niste odabrali igrača!";
            }
        }

        private void Odabir_igraca_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void lista_igraca_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblevel1.Checked = false; rblevel2.Checked = false;
            lblodabir_levela.Text = "Odaberite level:";

            if (listbox_lista_igraca.SelectedIndex < 0)
            { }
            else
            {
                if (Game.Lista_igraca[listbox_lista_igraca.SelectedIndex][2] == 2.ToString())
                {
                    this.rblevel1.Visible = true;
                    this.rblevel2.Visible = true;
                }
                if (Game.Lista_igraca[listbox_lista_igraca.SelectedIndex][2] == 1.ToString())
                {
                    this.rblevel1.Visible = true;
                    this.rblevel2.Visible = false;
                }

                lbl_prikaz_odabira.Text = "Vaš odabir:\n\nIme: " + listbox_lista_igraca.SelectedItem.ToString()
                                            + "\nMaksimalni broj novčića: "
                                            + Game.Lista_igraca[listbox_lista_igraca.SelectedIndex][1].ToString();
            }
        }

        private void natrag_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void spremi_odabir_MouseHover(object sender, EventArgs e)
        {
            spremi_odabir.BackgroundImage = Properties.Resources.crvena;
        }

        private void spremi_odabir_MouseLeave(object sender, EventArgs e)
        {
            spremi_odabir.BackgroundImage = Properties.Resources.normalno;
        }

        private void natrag_MouseHover(object sender, EventArgs e)
        {
            natrag.BackgroundImage = Properties.Resources.crvena;
        }

        private void natrag_MouseLeave(object sender, EventArgs e)
        {
            natrag.BackgroundImage = Properties.Resources.normalno;
        }
    }
}
