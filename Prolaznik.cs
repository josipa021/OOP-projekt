using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public class Prolaznik : Sprite
    {
        public Prolaznik(int xcor, int ycor) : base("sprites//prolaznik.png", xcor, ycor)
        {
            AddCostumes("sprites//prolaznik-maska.png");
            Heigth = 100;
            Width = 40;
        }

        private bool maska;

        public bool Maska { get => maska; set => maska = value; }

        public void Mijenjaj_kostim()
        {
            if (CostumeIndex == 0)
            {
                CurrentCostume = Costumes[1];
                CostumeIndex = 1;
                Maska = true;
            }
            else
            {
                CurrentCostume = Costumes[0];
                CostumeIndex = 0;
                Maska = false;
            }
        }

        public void Zarazi(Player p)
        {
            p.Br_zivota = p.Br_zivota - 1;
            p.Treperi();
        }
    }
}
