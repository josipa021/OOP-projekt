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

namespace OTTER
{
    public class SpriteList<T> : List<T>
    {        
        public new void Add(T item)
        {
            base.Add(item);
            Change = true;
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            Change = true;
        }

        public SpriteList()
        {
            Change = false;
        }

        private bool change;

        public bool Change
        {
            get { return change; }
            set { change = value; }
        }
    }

    /// <summary>
    /// Klasa za općenite aktivnosti vezane uz igru.
    /// </summary>
    public static class Game
    {

        /// <summary>
        /// Pauzira izvršavanje trenutne metode
        /// </summary>
        /// <param name="ms"></param>
        public static void WaitMS(int ms)
        {
            Thread.Sleep(ms);
        }

        /// <summary>
        /// Instanciranje novog lika.
        /// </summary>
        /// <param name="file">Naziv i putanja datoteke koja sadrži sliku lika.</param>
        /// <param name="x">koordinata lika</param>
        /// <param name="y">koordinata lika</param>
        /// <returns>Vraća Sprite</returns>        
        public static void AddSprite(Sprite s)
        {            
            s.SpriteIndex = BGL.spriteCount;
            BGL.spriteCount++;
            BGL.allSprites.Add(s);
        }

        /// <summary>
        /// Metoda koja poziva izvršavanje metode <c>scriptName</c> te čeka završetak izvođenja.
        /// </summary>
        /// <remarks>Ponaša se isto kao i metoda <see cref="Game.StartScript"/> osim što čeka završetak izvođenja da bi se moglo prijeći na iduću naredbu.</remarks>
        /// <param name="scriptName"></param>
        public static void StartScriptAndWait(Func<int> scriptName)
        {
            Task t = Task.Factory.StartNew(scriptName);
            t.Wait();
        }

        /// <summary>
        /// Metoda koja poziva paralelno izvršavanje metode <c>scriptName</c>.
        /// </summary>
        /// <param name="scriptName"></param>
        /// <example>
        /// <para>Metoda (skripta ili procedura) koju pokreće <c>Game.StartScript</c> mora biti napisana na određen način inače se neće prihvatiti. 
        /// Metoda mora imati povratnu vrijednost tipa <c>int</c> koja se može koristiti za povratnu informaciju je li se dogodila pogreška (npr. 0 nije bilo pogreške). 
        /// Sve metode/skripte pozvane putem Game.StartScript() se izvršavaju istovremeno.
        /// </para>
        /// Primjer:
        /// <code>
        /// private int MetodaLika()
        /// {
        ///     //kod
        ///     return 0;
        /// }
        /// </code>
        /// <para>Obično se za aktivnosti lika koje traju dulje vrijeme (ili tijekom trajanja igre) koristi petlja while. 
        /// Pri tome se za uvjet petlje koristi vrijabla START (vidi: <see cref="BGL.START"/>).
        /// <code>
        /// while (START)
        /// {
        ///     //radi nešto
        /// }
        /// </code>
        /// </para>
        /// </example>
        public static void StartScript(Func<int> scriptName)
        {
            Task t;
            //t = Task.Factory.StartNew(scriptName, TaskCreationOptions.LongRunning);
            t = Task.Factory.StartNew(scriptName);
        }

        public static List<string> Lista_imena = new List<string>();
        public static List<string[]> Lista_igraca = new List<string[]>();  //string koji prima su podatci o igracu,
        public static bool Gameover, Goal, Rekord;                                 //prvo ime, pa max_br_novcica, pa je li otkljuca 2.level
        public static int Level;

        public static Sprite pozadina, cilj;
        public static SpriteList<Platforma> platforme;
        public static SpriteList<Policajac> policajci;
        public static SpriteList<Prolaznik> prolaznici;
        public static SpriteList<Novcic> novcici;
        public static SpriteList<Virus> virusi;
        public static SpriteList<Sprite> lista_objekata;

        public static void SetupLevel1()
        {
            pozadina = new Sprite("backgrounds//pozadina-1.jpg",0,0);
            Game.AddSprite(pozadina);

            cilj = new Sprite("sprites//cura.png",1820, 375);
            cilj.Width = 55;
            cilj.Heigth = 105;
            Game.AddSprite(cilj);

            platforme = new SpriteList<Platforma>
            {
                new Platforma(0,480, 1940),
                new Platforma(240, 330, 150, 40),
                new Platforma(420, 330, 240),
                new Platforma(660, 180, 340),
                new Platforma(1370, 330, 300),
                new Platforma(980, 330, 150),
                new Platforma(1160, 0, 350, 20)
            };

            foreach (Platforma x in platforme)
            {
                Game.AddSprite(x);
            }

            policajci = new SpriteList<Policajac>
            {
                new Policajac_blagi(420, 380),
                new Policajac_blagi(810, 80),
                new Policajac_blagi(1520, 230),
                new Policajac_strogi(520, 230)
            };

            foreach (Policajac x in policajci)
            {
                Game.AddSprite(x);
            }

            prolaznici = new SpriteList<Prolaznik>
            {
                new Prolaznik(200, 380),
                new Prolaznik(1470, 380),
                new Prolaznik(1050, 380)
            };

            foreach (Prolaznik x in prolaznici)
            {
                Game.AddSprite(x);
            }

            novcici = new SpriteList<Novcic>
            {
                new Novcic (460, 355),
                new Novcic (560, 355),
                new Novcic (1420, 355),
                new Novcic (900, 305),
                new Novcic (255, 205),
                new Novcic (470, 205),
                new Novcic (1560, 205),
                new Novcic (760, 305),
                new Novcic (740, 55),
                new Novcic (900, 55),
                new Novcic (1080, 205)
            };

            foreach (Novcic x in novcici)
            {
                Game.AddSprite(x);
            }
            virusi = new SpriteList<Virus>
            {
                new Virus (100, 305),
                new Virus (830, 305),
                new Virus (1260, 305)
            };

            foreach (Virus x in virusi)
            {
                Game.AddSprite(x);
            }

            Game.Napuni_listu_objekata();
        }

        public static void SetupLevel2()
        {
            pozadina = new Sprite("backgrounds//pozadina-2.jpg", 0, 0);
            Game.AddSprite(pozadina);

            cilj = new Sprite("sprites//cura.png", 1820, 375);
            cilj.Width = 55;
            cilj.Heigth = 105;
            Game.AddSprite(cilj);

            platforme = new SpriteList<Platforma>
            {
                new Platforma(0,480, 1940), //donja
                new Platforma(170, 330, 470), //prva
                new Platforma(550, 180, 130), //druga
                new Platforma(730, 180, 300, 40), //okomita
                new Platforma(770, 330, 290),
                new Platforma(1160, 180, 250), //kraj
                new Platforma(1590, 170, 180, 50) //druga okomita
            };

            foreach (Platforma x in platforme)
            {
                Game.AddSprite(x);
            }

            policajci = new SpriteList<Policajac>
            {
                new Policajac_blagi(300, 380),
                new Policajac_blagi(400, 230),
                new Policajac_blagi(1200, 380),
                new Policajac_strogi(930, 230)
            };

            foreach (Policajac x in policajci)
            {
                Game.AddSprite(x);
            }

            prolaznici = new SpriteList<Prolaznik>
            {
                new Prolaznik(600, 380),
                new Prolaznik(1200, 80)
            };

            foreach (Prolaznik x in prolaznici)
            {
                Game.AddSprite(x);
            }

            novcici = new SpriteList<Novcic>
            {
                new Novcic (550, 355),
                new Novcic (555, 55),
                new Novcic (655, 280),
                new Novcic (740, 55),
                new Novcic(920, 355),
                new Novcic (1320, 55),
                new Novcic(1600, 55)
            };

            foreach (Novcic x in novcici)
            {
                Game.AddSprite(x);
            }
            virusi = new SpriteList<Virus>
            {
                new Virus (150, 355),
                new Virus (695, 280),
                new Virus (600, 55),
                new Virus(950,355)
            };

            foreach (Virus x in virusi)
            {
                Game.AddSprite(x);
            }

            Game.Napuni_listu_objekata();
        }

        public static void Napuni_listu_objekata()
        {
            lista_objekata = new SpriteList<Sprite>();
            foreach (Platforma x in platforme)
                lista_objekata.Add(x);
            foreach (Policajac x in policajci)
                lista_objekata.Add(x);
            foreach (Prolaznik x in prolaznici)
                lista_objekata.Add(x);
            foreach (Novcic x in novcici)
                lista_objekata.Add(x);
            foreach (Virus x in virusi)
                lista_objekata.Add(x);
            lista_objekata.Add(cilj);
            lista_objekata.Add(pozadina);
        }

        public static void Zamijeni_igraca_u_listi(int i, Player p)
        {
            string podatci = p.CharacterName + ";" + p.Max_br_novcica.ToString() + ";" + p.Br_otkljucanih_levela.ToString();
            Lista_igraca[i] = podatci.Split(';');
        }

        public static void Dodaj_u_listu(string[] s)
        {
            Game.Lista_igraca.Add(s); 
        }
       
    } //game
}
