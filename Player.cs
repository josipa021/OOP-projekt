using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace OTTER
{
    public class Player : Pomicni_lik
    {
        public Player(string ime, int max_novici, int otklj_leveli) : base("sprites//lik-desno.png", "sprites//lik-lijevo.png", 10, 200)
        {
            Skok = false;
            Br_zivota = 3;
            Br_novcica = 0;
            Speed = 5;
            Jump_speed = 2*Speed;
            Force = 15;
            CharacterName = ime;
            Max_br_novcica = max_novici;
            Br_otkljucanih_levela = otklj_leveli;
        }

        private bool skok, opet_skok, moze_skocit;
        private int jump_speed; //odredena brzinom kretanja, ali mijenja smjer, ovisno je li skace ili pada
        private int force;
        private int br_novcica, max_br_novcica;
        private int br_zivota;
        private string characterName;
        private int br_otkljucanih_levela;

        public bool Skok { get => skok; set => skok = value; }
        public bool Opet_skok { get => opet_skok; set => opet_skok = value; }
        public bool Moze_skocit { get => moze_skocit; set => moze_skocit = value; }
        public int Force { get => force; set => force = value; }
        public int Jump_speed { get => jump_speed; set => jump_speed = value; }
        public int Br_novcica { get => br_novcica; set => br_novcica = value; }
        public int Max_br_novcica { get => max_br_novcica; set => max_br_novcica = value; }
        public int Br_zivota { get => br_zivota; set => br_zivota = value; }
        public string CharacterName { get => characterName; set => characterName = value; }
        public int Br_otkljucanih_levela { get => br_otkljucanih_levela; set => br_otkljucanih_levela = value; }

        public override int X
        {
            get { return x; }
            set
            {
                if (value + 50 >= GameOptions.RightEdge)
                {
                    this.x = GameOptions.RightEdge - 50;
                }
                else if (value <= GameOptions.LeftEdge)
                {
                    this.x = GameOptions.LeftEdge;
                }
                else
                    this.x = value;
            }
        }

        public void Gravitacija()
        {
            this.Y = this.Y + this.Jump_speed;
        }

        public void Provjera_jump()
        {
            if (this.Skok == true && Force < 0)
            {
                this.Skok = false;
            }

            if (this.Skok == true)
            {
                Jump_speed = -2*Speed;
                Force = Force - 1;
            }
            else
            {
                Jump_speed = 2*Speed;
            }
        }

        public bool Udara_donjim_rubom(Platforma b) //igrac je svojim donjim rubom udario o gornji rub platforme
        {
            Sprite a = this;

            Rectangle A = new Rectangle(a.X, a.Y, a.Width, a.Heigth);
            Rectangle B = new Rectangle(b.X, b.Y, b.Width, b.Heigth);

            if (A.Bottom == B.Top && A.Right > B.Left && A.Left < B.Right)
                return true;
            else
                return false;
        }

        public bool Udara_gornjim_rubom(Platforma b)
        {
            Sprite a = this;

            Rectangle A = new Rectangle(a.X, a.Y, a.Width, a.Heigth);
            Rectangle B = new Rectangle(b.X, b.Y, b.Width, b.Heigth);

            if (A.Top == B.Bottom && A.Right > B.Left && A.Left < B.Right)
                return true;
            else
                return false;
        }

        public bool Udara_desnim_rubom(Platforma b)
        {
            Sprite a = this;

            Rectangle A = new Rectangle(a.X, a.Y, a.Width, a.Heigth);
            Rectangle B = new Rectangle(b.X, b.Y, b.Width, b.Heigth);

            if (a.TouchingSprite(b) && A.Left <= B.Left && A.Right >= B.Left
                || A.Right == B.Left && (A.Top <= B.Top && A.Bottom >= B.Bottom 
                || A.Top <= B.Top && A.Bottom >= B.Top && A.Bottom <= B.Bottom
                || A.Top >= B.Top && A.Top <= B.Bottom && A.Bottom >= B.Bottom 
                || A.Top >= B.Top && A.Bottom <= B.Bottom))
                return true;
            else
                return false;
        }

        public bool Udara_lijevim_rubom(Platforma b)
        {
            Sprite a = this;

            Rectangle A = new Rectangle(a.X, a.Y, a.Width, a.Heigth);
            Rectangle B = new Rectangle(b.X, b.Y, b.Width, b.Heigth);

            if (a.TouchingSprite(b) && A.Left <= B.Right && A.Right >= B.Right
                || A.Left == B.Right && (A.Top <= B.Top && A.Bottom >= B.Bottom 
                || A.Top <= B.Top && A.Bottom >= B.Top && A.Bottom <= B.Bottom
                || A.Top >= B.Top && A.Top <= B.Bottom && A.Bottom >= B.Bottom 
                || A.Top >= B.Top && A.Bottom <= B.Bottom))
                return true;
            else
                return false;
        }

        public void Treperi()
        {
            for (int i = 0; i < 5; Game.WaitMS(100), i++)
            {
                this.SetVisible(false);
                Game.WaitMS(100);
                this.SetVisible(true);
                Game.WaitMS(100);  
            } 
        }
    }
}

