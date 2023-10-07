using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OTTER
{
    public partial class Izbornik : Form
    {
        public Izbornik()
        {
            InitializeComponent();
            Indeks = -1;
        }

        private void Uvod_Load(object sender, EventArgs e)
        {
            label1.Text = "Dobrodošli u našu igru!\n" +
                "Pomozite našem Romeu da posjeti djevojku za vrijeme trajanja karantene. Na putu vam\n" +
                "se mogu ispriječiti policajci, virusi i neoprezni prolaznici bez maske. Cilj vam je\n" +
                "sakupiti što više novčića i izbjeći sve opasnosti. Krećete se lijevo-desno pomoću tipki\n" +
                "<- i ->, a na platforme skačete pritiskom na tipku space.\n" +
                "Sretno :)";
            
            label2.Text = "";
            label3.Text = "";
            textBox1.Visible = false;
            pictureBox1.Image = zv1;
            
            if (!File.Exists("datoteka.txt"))
            { }
            else
            {
                using (StreamReader sr = File.OpenText("datoteka.txt"))
                {
                    string linija;
                    Game.Lista_igraca.Clear();
                    Game.Lista_imena.Clear();
                    while ((linija = sr.ReadLine()) != null)
                    {
                        Game.Dodaj_u_listu(linija.Split(';'));
                        Game.Lista_imena.Add(IzbaciRazmake(linija.Split(';')[0]));
                    }
                    //sr.Close();
                }
            }
        }
        private string ime;
        public int Indeks;
        string s;
        public bool mute;
        Bitmap zv1 = Properties.Resources.zvucnik; //instanciran ovo kako bi mogla usporedit objekte kad korisnik klikne picturebox
        Bitmap zv2 = Properties.Resources.zvucnik_mute;

        public string Ime
        {
            get { return ime; }
            set
            {
                if (value == "" || IzbaciRazmake(value) == String.Empty)
                    throw (new PrazanString());
                else if (Game.Lista_imena.Contains(IzbaciRazmake(value)))
                    throw (new PostojeceIme());
                else
                    ime = value;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible)
            {
                try
                {
                    Ime = ToTitleCase(textBox1.Text);         //ime igraca
                    textBox1.Text = "";          //resetiramo sve postavke za textboxove i labele
                    textBox1.Visible = false;    //prije nego zapocnemo igru
                    label2.Text = "";
                    label3.Text = "";
                    Game.Level = 1;
                    s = Ime + ";0;1";    //ovo su pocetni podatci za novog igraca koji nije jos skupio nista novcica i ima samo 1.level
                    Game.Dodaj_u_listu(s.Split(';'));  //dodajemo ga u listu kao sto smo dodali sve one iz datoteke
                    Game.Lista_imena.Add(IzbaciRazmake(Ime));
                    Indeks = Game.Lista_igraca.Count - 1;  //moramo postavit indeks preko kojeg cemo pozivat element liste koji oznacava
                                                           //podatke odabranog igraca, novi igrac je uvijek zadnji u listi
                    BGL igra = new BGL();
                    igra.pocetni = this;
                    igra.Show();
                }
                catch (PrazanString iznimka)
                {
                    label2.Text = iznimka.Message;
                }
                catch (PostojeceIme iznimka)
                {
                    label2.Text = iznimka.Message;
                }
            }
            else if (Indeks < 0)
            {
                label2.Text = "Niste izabrali igrača!";
            }
            else
            {
                label2.Text = "";
                BGL igra = new BGL();
                igra.pocetni = this;
                igra.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Unesi_novog_igraca_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label3.Text = "Unesite ime igrača:";
            label2.Text = "";
            Indeks = -1;
        }

        private void Odaberi_igraca_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label2.Text = "";
            Indeks = -1;
            textBox1.Text = "";
            label3.Text = "";
            Odabir_igraca forma = new Odabir_igraca();
            forma.pocetni = this;
            this.Hide();
            forma.ShowDialog();
            this.Show();
        }

        public string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public string IzbaciRazmake(string str) //kod provjere je li ime postoji ne računa razmake koje smo mogli dodat na pocetku
        {                                       //ili na kraju, a koji bi ubiti dali isto ime
            string bez_razmaka = "";

            bez_razmaka = str.Replace(" ", String.Empty);

            return bez_razmaka;
        }

        private void Odaberi_igraca_MouseHover(object sender, EventArgs e)
        {
            Odaberi_igraca.BackgroundImage = Properties.Resources.crvena;
        }

        private void Odaberi_igraca_MouseLeave(object sender, EventArgs e)
        {
            Odaberi_igraca.BackgroundImage = Properties.Resources.normalno;
        }

        private void Unesi_novog_igraca_MouseHover(object sender, EventArgs e)
        {
            Unesi_novog_igraca.BackgroundImage = Properties.Resources.crvena;
        }

        private void Unesi_novog_igraca_MouseLeave(object sender, EventArgs e)
        {
            Unesi_novog_igraca.BackgroundImage = Properties.Resources.normalno;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.crvena;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.normalno;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.crvena;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.normalno;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image==zv1)
            {
                pictureBox1.Image = zv2;
                mute = true;
            }
            else
            {
                pictureBox1.Image = zv1;
                mute = false;
            }
        }
    }
}

