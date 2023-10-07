using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OTTER
{
    /// <summary>
    /// -
    /// </summary>
    public partial class BGL : Form
    {
        public Izbornik pocetni;
        public IzbornikNaKraju zavrsni;
        /* ------------------- */
        #region Environment Variables

        List<Func<int>> GreenFlagScripts = new List<Func<int>>();

        /// <summary>
        /// Uvjet izvršavanja igre. Ako je <c>START == true</c> igra će se izvršavati.
        /// </summary>
        /// <example><c>START</c> se često koristi za beskonačnu petlju. Primjer metode/skripte:
        /// <code>
        /// private int MojaMetoda()
        /// {
        ///     while(START)
        ///     {
        ///       //ovdje ide kod
        ///     }
        ///     return 0;
        /// }</code>
        /// </example>
        public static bool START = true;

        //sprites
        /// <summary>
        /// Broj likova.
        /// </summary>
        public static int spriteCount = 0, soundCount = 0;

        /// <summary>
        /// Lista svih likova.
        /// </summary>
        //public static List<Sprite> allSprites = new List<Sprite>();
        public static SpriteList<Sprite> allSprites = new SpriteList<Sprite>();

        //sensing
        int mouseX, mouseY;
        Sensing sensing = new Sensing();

        //background
        List<string> backgroundImages = new List<string>();
        int backgroundImageIndex = 0;
        public string ISPIS = "";


        SoundPlayer[] sounds = new SoundPlayer[1000];
        
        TextReader[] readFiles = new StreamReader[1000];
        TextWriter[] writeFiles = new StreamWriter[1000];
        bool showSync = false;
        int loopcount;
        DateTime dt = new DateTime();
        String time;
        double lastTime, thisTime, diff;

        #endregion
        /* ------------------- */
        #region Events

        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            try
            {
                foreach (Sprite sprite in allSprites)
                {
                    if (sprite != null)
                        if (sprite.Show == true)
                        {
                            g.DrawImage(sprite.CurrentCostume, new Rectangle(sprite.X, sprite.Y, sprite.Width, sprite.Heigth));
                        }
                    if (allSprites.Change)
                        break;
                }
                if (allSprites.Change)
                    allSprites.Change = false;
            }
            catch
            {
                //ako se doda sprite dok crta onda se mijenja allSprites
                MessageBox.Show("Greška!");
            }
        }

        private void startTimer(object sender, EventArgs e)
        {
            pocetni.Hide();

            timer1.Start();
            timer2.Start();
            Init();
        }

        private void updateFrameRate(object sender, EventArgs e)
        {
            updateSyncRate();
        }

        /// <summary>
        /// Crta tekst po pozornici.
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        public void DrawTextOnScreen(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var brush = new SolidBrush(Color.Empty); //promijenila boju pozadine teksta iz bijele u prozirnu
            string text = ISPIS;

            SizeF stringSize = new SizeF();
            Font stringFont = new Font("Arial", 14);
            stringSize = e.Graphics.MeasureString(text, stringFont);

            using (Font font1 = stringFont)
            {
                RectangleF rectF1 = new RectangleF(GameOptions.RightEdge - stringSize.Width, 0, stringSize.Width, stringSize.Height); //postavila tekst u gornji desni kut, umjesto gornji lijevi
                e.Graphics.FillRectangle(brush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(text, font1, Brushes.DarkSalmon, rectF1);
            }
        }

        private void mouseClicked(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = true;
            sensing.MouseDown = true;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = true;
            sensing.MouseDown = true;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = false;
            sensing.MouseDown = false;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            //sensing.MouseX = e.X;
            //sensing.MouseY = e.Y;
            //Sensing.Mouse.x = e.X;
            //Sensing.Mouse.y = e.Y;
            sensing.Mouse.X = e.X;
            sensing.Mouse.Y = e.Y;

        }
        bool left, right;
        private void keyDown(object sender, KeyEventArgs e)
        {
            sensing.Key = e.KeyCode.ToString();
            sensing.KeyPressedTest = true;

            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }

            if (e.KeyCode == Keys.Space && !igrac.Skok && !igrac.Opet_skok && igrac.Moze_skocit)
            {
                igrac.Skok = true;
                igrac.Opet_skok = true;
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            sensing.Key = "";
            sensing.KeyPressedTest = false;

            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                igrac.Opet_skok = false;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (sensing.KeyPressed(Keys.Escape))
            {
                START = false;
            }

            if (START)
            {
                this.Refresh();
            }
        }

        #endregion
        /* ------------------- */
        #region Start of Game Methods

        //my
        #region my

        //private void StartScriptAndWait(Func<int> scriptName)
        //{
        //    Task t = Task.Factory.StartNew(scriptName);
        //    t.Wait();
        //}

        //private void StartScript(Func<int> scriptName)
        //{
        //    Task t;
        //    t = Task.Factory.StartNew(scriptName);
        //}

        private int AnimateBackground(int intervalMS)
        {
            while (START)
            {
                setBackgroundPicture(backgroundImages[backgroundImageIndex]);
                Game.WaitMS(intervalMS);
                backgroundImageIndex++;
                if (backgroundImageIndex == 3)
                    backgroundImageIndex = 0;
            }
            return 0;
        }

        private void KlikNaZastavicu()
        {
            foreach (Func<int> f in GreenFlagScripts)
            {
                Task.Factory.StartNew(f);
            }
        }

        #endregion

        /// <summary>
        /// BGL
        /// </summary>
        public BGL()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pričekaj (pauza) u sekundama.
        /// </summary>
        /// <example>Pričekaj pola sekunde: <code>Wait(0.5);</code></example>
        /// <param name="sekunde">Realan broj.</param>
        public void Wait(double sekunde)
        {
            int ms = (int)(sekunde * 1000);
            Thread.Sleep(ms);
        }

        //private int SlucajanBroj(int min, int max)
        //{
        //    Random r = new Random();
        //    int br = r.Next(min, max + 1);
        //    return br;
        //}

        /// <summary>
        /// -
        /// </summary>
        public void Init()
        {
            if (dt == null) time = dt.TimeOfDay.ToString();
            loopcount++;
            //Load resources and level here
            this.Paint += new PaintEventHandler(DrawTextOnScreen);
            SetupGame();
        }

        /// <summary>
        /// -
        /// </summary>
        /// <param name="val">-</param>
        public void showSyncRate(bool val)
        {
            showSync = val;
            if (val == true) syncRate.Show();
            if (val == false) syncRate.Hide();
        }

        /// <summary>
        /// -
        /// </summary>
        public void updateSyncRate()
        {
            if (showSync == true)
            {
                thisTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                diff = thisTime - lastTime;
                lastTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

                double fr = (1000 / diff) / 1000;

                int fr2 = Convert.ToInt32(fr);

                syncRate.Text = fr2.ToString();
            }

        }

        //stage
        #region Stage

        /// <summary>
        /// Postavi naslov pozornice.
        /// </summary>
        /// <param name="title">tekst koji će se ispisati na vrhu (naslovnoj traci).</param>
        public void SetStageTitle(string title)
        {
            this.Text = title;
        }

        /// <summary>
        /// Postavi boju pozadine.
        /// </summary>
        /// <param name="r">r</param>
        /// <param name="g">g</param>
        /// <param name="b">b</param>
        public void setBackgroundColor(int r, int g, int b)
        {
            this.BackColor = Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Postavi boju pozornice. <c>Color</c> je ugrađeni tip.
        /// </summary>
        /// <param name="color"></param>
        public void setBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        /// <summary>
        /// Postavi sliku pozornice.
        /// </summary>
        /// <param name="backgroundImage">Naziv (putanja) slike.</param>
        public void setBackgroundPicture(string backgroundImage)
        {
            this.BackgroundImage = new Bitmap(backgroundImage);
        }

        /// <summary>
        /// Izgled slike.
        /// </summary>
        /// <param name="layout">none, tile, stretch, center, zoom</param>
        public void setPictureLayout(string layout)
        {
            if (layout.ToLower() == "none") this.BackgroundImageLayout = ImageLayout.None;
            if (layout.ToLower() == "tile") this.BackgroundImageLayout = ImageLayout.Tile;
            if (layout.ToLower() == "stretch") this.BackgroundImageLayout = ImageLayout.Stretch;
            if (layout.ToLower() == "center") this.BackgroundImageLayout = ImageLayout.Center;
            if (layout.ToLower() == "zoom") this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        #endregion

        //sound
        #region sound methods

        /// <summary>
        /// Učitaj zvuk.
        /// </summary>
        /// <param name="soundNum">-</param>
        /// <param name="file">-</param>
        public void loadSound(int soundNum, string file)
        {
            soundCount++;
            sounds[soundNum] = new SoundPlayer(file);
        }

        /// <summary>
        /// Sviraj zvuk.
        /// </summary>
        /// <param name="soundNum">-</param>
        public void playSound(int soundNum)
        {
            sounds[soundNum].Play();
        }

        /// <summary>
        /// loopSound
        /// </summary>
        /// <param name="soundNum">-</param>
        public void loopSound(int soundNum)
        {
            sounds[soundNum].PlayLooping();
        }

        /// <summary>
        /// Zaustavi zvuk.
        /// </summary>
        /// <param name="soundNum">broj</param>
        public void stopSound(int soundNum)
        {
            sounds[soundNum].Stop();
        }

        #endregion

        //file
        #region file methods

        /// <summary>
        /// Otvori datoteku za čitanje.
        /// </summary>
        /// <param name="fileName">naziv datoteke</param>
        /// <param name="fileNum">broj</param>
        public void openFileToRead(string fileName, int fileNum)
        {
            readFiles[fileNum] = new StreamReader(fileName);
        }

        /// <summary>
        /// Zatvori datoteku.
        /// </summary>
        /// <param name="fileNum">broj</param>
        public void closeFileToRead(int fileNum)
        {
            readFiles[fileNum].Close();
        }

        /// <summary>
        /// Otvori datoteku za pisanje.
        /// </summary>
        /// <param name="fileName">naziv datoteke</param>
        /// <param name="fileNum">broj</param>
        public void openFileToWrite(string fileName, int fileNum)
        {
            writeFiles[fileNum] = new StreamWriter(fileName);
        }

        /// <summary>
        /// Zatvori datoteku.
        /// </summary>
        /// <param name="fileNum">broj</param>
        public void closeFileToWrite(int fileNum)
        {
            writeFiles[fileNum].Close();
        }

        /// <summary>
        /// Zapiši liniju u datoteku.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <param name="line">linija</param>
        public void writeLine(int fileNum, string line)
        {
            writeFiles[fileNum].WriteLine(line);
        }

        /// <summary>
        /// Pročitaj liniju iz datoteke.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <returns>vraća pročitanu liniju</returns>
        public string readLine(int fileNum)
        {
            return readFiles[fileNum].ReadLine();
        }

        /// <summary>
        /// Čita sadržaj datoteke.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <returns>vraća sadržaj</returns>
        public string readFile(int fileNum)
        {
            return readFiles[fileNum].ReadToEnd();
        }

        #endregion

        //mouse & keys
        #region mouse methods

        /// <summary>
        /// Sakrij strelicu miša.
        /// </summary>
        public void hideMouse()
        {
            Cursor.Hide();
        }

        /// <summary>
        /// Pokaži strelicu miša.
        /// </summary>
        public void showMouse()
        {
            Cursor.Show();
        }

        /// <summary>
        /// Provjerava je li miš pritisnut.
        /// </summary>
        /// <returns>true/false</returns>
        public bool isMousePressed()
        {
            //return sensing.MouseDown;
            return sensing.MouseDown;
        }

        /// <summary>
        /// Provjerava je li tipka pritisnuta.
        /// </summary>
        /// <param name="key">naziv tipke</param>
        /// <returns></returns>
        public bool isKeyPressed(string key)
        {
            if (sensing.Key == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Provjerava je li tipka pritisnuta.
        /// </summary>
        /// <param name="key">tipka</param>
        /// <returns>true/false</returns>
        public bool isKeyPressed(Keys key)
        {
            if (sensing.Key == key.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #endregion
        /* ------------------- */

        /* ------------ GAME CODE START ------------ */

        /* Game variables */


        /* Initialization */

        Player igrac;
       
        bool lijeva_granica, desna_granica, gornja_granica, donja_granica;

        private void BGL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Wait(0.5);
            stopSound(3);
            START = false;

            using (StreamWriter sw = new StreamWriter("datoteka.txt"))
            {
                for (int j = 0; j < Game.Lista_igraca.Count; j++)
                    sw.WriteLine(Game.Lista_igraca[j][0] + ";" + Game.Lista_igraca[j][1].ToString() + ";" + Game.Lista_igraca[j][2].ToString());
                sw.Close();
            }

            if (!Game.Goal && !Game.Gameover)
            {
                pocetni.Indeks = -1;
                pocetni.Show();
            }
            else
            {
                zavrsni = new IzbornikNaKraju();
                zavrsni.pocetni = this.pocetni;
                zavrsni.Show();
            }

            this.Dispose(true);
            //kupi smeće iz memorije, za svaki slučaj
            //Garbage collect
            GC.Collect();
        }

        public delegate void DelegatBGL();
        public delegate void Kraj_igreDel();
        public static event Kraj_igreDel Kraj_igre;

        private void Spremi_podatke_i_zatvori_formu()
        {
            if (igrac.Br_novcica > igrac.Max_br_novcica && Game.Goal)
            {
                igrac.Max_br_novcica = igrac.Br_novcica;
                Game.Rekord = true;
            }

            if (Game.Goal && Game.Level == igrac.Br_otkljucanih_levela && igrac.Br_otkljucanih_levela < 2) // < 2 jer imamo samo s levela, ali
                igrac.Br_otkljucanih_levela += 1;                                                          // koristilo bi ako zelimo dodat jos
             
            Game.Zamijeni_igraca_u_listi(pocetni.Indeks, igrac);

            if (this.InvokeRequired)
            { this.Invoke(new DelegatBGL(Spremi_podatke_i_zatvori_formu)); }
            else
            {
                this.Close();
            }
        }

        private void RemoveSprites()
        {
            BGL.spriteCount = 0;
            BGL.allSprites.Clear();
            GC.Collect();
        }
        

        private void SetupGame()
        {
            int brspr = BGL.allSprites.Count;
            RemoveSprites();
            START = true;

            //1. setup stage
            SetStageTitle("Igra");
            loadSound(1, "Ostalo//negativno2.wav");
            loadSound(2, "Ostalo//pozadinska.wav");
            loadSound(3, "Ostalo//pobjeda.wav");

            Game.Goal = false; Game.Gameover = false; Game.Rekord = false;

            //povezivanje dogadaja i metode koja njime upravlja
            Kraj_igre += Spremi_podatke_i_zatvori_formu;

            //2. add sprites
            if (Game.Level == 1)
                Game.SetupLevel1();

            if (Game.Level == 2)
                Game.SetupLevel2();

            if(pocetni.mute == false) //ako je mute = false svirat ce muzika
                loopSound(2); //loopa pozadinsku muziku

            string ime = Game.Lista_igraca[pocetni.Indeks][0];
            int max_novcici = int.Parse(Game.Lista_igraca[pocetni.Indeks][1]);
            int otkljucani_leveli = int.Parse(Game.Lista_igraca[pocetni.Indeks][2]);
            igrac = new Player(ime, max_novcici, otkljucani_leveli);
            Game.AddSprite(igrac);

            //3. scripts that start
            Game.StartScript(Kretanje_lika);
            Game.StartScript(Kretanje_policajca);
            Game.StartScript(Oduzimanje_zivota);
            Game.StartScript(Ponasanje_prolaznika);
            Game.StartScript(Skupljanje_novcica);
            Game.StartScript(Provjera_kraja);
        }

        /* Scripts */

        private int Kretanje_lika()
        {
            while (START) //ili neki drugi uvjet
            {
                if (!gornja_granica && igrac.Jump_speed < 0 || !donja_granica && igrac.Jump_speed > 0)
                    igrac.Gravitacija();

                if (right && !desna_granica)
                {
                    igrac.TurnRight();
                    igrac.MoveSimple(igrac.Speed);
                    Wait(0.03);

                    if (Game.cilj.X > GameOptions.RightEdge - Game.cilj.Width)
                    {
                        Parallel.ForEach(Game.lista_objekata, x =>
                        {
                            x.X = x.X - 10;
                        });

                        foreach (Policajac x in Game.policajci)
                        {
                            x.Pocetna_pozicija = x.Pocetna_pozicija - 10;
                        }
                    }
                }

                if (left && !lijeva_granica)
                {
                    igrac.TurnLeft();
                    igrac.MoveSimple(igrac.Speed);
                    Wait(0.03);

                    if (Game.pozadina.X < 0)
                    {
                        Parallel.ForEach(Game.lista_objekata, x =>
                        {
                            x.X = x.X + 10;
                        });

                        foreach (Policajac x in Game.policajci)
                        {
                            x.Pocetna_pozicija = x.Pocetna_pozicija + 10;
                        }
                    }
                }

                if (donja_granica)
                    igrac.Moze_skocit = true;
                else
                    igrac.Moze_skocit = false;

                igrac.Provjera_jump();

                lijeva_granica = false; desna_granica = false; gornja_granica = false; donja_granica = false;

                foreach (Platforma x in Game.platforme)
                {
                    if (igrac.Udara_donjim_rubom(x))
                    {
                        igrac.Force = 15;
                        donja_granica = true;
                    }

                    if (igrac.Udara_gornjim_rubom(x))
                    {
                        igrac.Skok = false;
                        gornja_granica = true;
                    }

                    if (igrac.Udara_lijevim_rubom(x))
                    {
                        lijeva_granica = true;
                        igrac.X = x.X + x.Width;
                    }

                    if (igrac.Udara_desnim_rubom(x))
                    {
                        desna_granica = true;
                        igrac.X = x.X - igrac.Width;
                    }
                }
                Wait(0.01);
                ISPIS = "Broj života: " + igrac.Br_zivota.ToString() + "\nBroj novčića: " + igrac.Br_novcica.ToString();
            }
            Wait(0.01);
            return 0;
        }

        private int Kretanje_policajca()
        {
            while (START)
            {
                foreach (Policajac x in Game.policajci)
               {
                   x.MoveSimple(x.Speed);
                   Wait(0.02);

                   if (x.X >= x.Pocetna_pozicija + x.Raspon_kretanja / 2)
                       x.TurnLeft();

                   if (x.X <= x.Pocetna_pozicija - x.Raspon_kretanja / 2)
                       x.TurnRight();
               }
            }
            Wait(0.01);
            return 0;
        }

        private int Oduzimanje_zivota()
        {
            while(START)
            {
                foreach (Policajac x in Game.policajci)
                { 
                    if (x.TouchingSprite(igrac))
                    {
                        x.Kazni(igrac);
                    }
                }

                foreach (Prolaznik x in Game.prolaznici)
                {
                    if (x.TouchingSprite(igrac) && !x.Maska)
                    {
                        x.Zarazi(igrac);
                    }
                }

                foreach (Virus x in Game.virusi)
                {
                    if (x.TouchingSprite(igrac) && x.Show)
                    {
                        x.SkupiVirus(igrac);
                    }
                }
            }
            Wait(0.01);
            return 0;
        }

        private int Ponasanje_prolaznika()
        {
            while(START)
            {
                Parallel.ForEach(Game.prolaznici, x =>
               {
                   x.Mijenjaj_kostim();
                   Wait(1.5);
               });
            }
            Wait(0.01);
            return 0;
        }

        private int Skupljanje_novcica()
        {
            while(START)
            {
                foreach (Novcic x in Game.novcici)
                {
                    if (x.TouchingSprite(igrac) && x.Show)
                    {
                        x.Prikupljanje(igrac);
                    }
                }
            }
            Wait(0.01);
            return 0;
        }

        private int Provjera_kraja()
        {
            while (START)
            {
                if (igrac.Br_zivota <= 0)
                {
                    Game.Gameover = true;
                    if(pocetni.mute==false)
                    {
                        stopSound(2);
                        playSound(1);
                        Wait(0.8);
                    }
                    Kraj_igre.Invoke();
                }

                if (igrac.TouchingSprite(Game.cilj))
                {
                    Game.Goal = true;
                    if(pocetni.mute==false)
                    {
                        stopSound(2);
                        playSound(3);
                        Wait(0.8); //da stigne odsvirat prije nego zatvori formu
                    } 
                    Kraj_igre.Invoke();
                }
            }
            Wait(0.01);
            return 0;
        }

        /* ------------ GAME CODE END ------------ */


    }
}
