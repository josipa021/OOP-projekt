using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public abstract class Policajac : Pomicni_lik
    {
        public Policajac(string image_d, string image_l, int xcor, int ycor) : base(image_d, image_l, xcor, ycor)
        {
            Pocetna_pozicija = X;
            Raspon_kretanja = 200;
            Speed = 10;
        }

        private int pocetna_pozicija, raspon_kretanja;

        public int Pocetna_pozicija { get => pocetna_pozicija; set => pocetna_pozicija = value; }
        public int Raspon_kretanja { get => raspon_kretanja; set => raspon_kretanja = value; }

        public abstract void Kazni(Player p);
    }
}
