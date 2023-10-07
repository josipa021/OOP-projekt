using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public class Policajac_blagi : Policajac
    {
        public Policajac_blagi(int xcor, int ycor) : base("sprites//policajac-desno.png", "sprites//policajac-lijevo.png", xcor, ycor)
        {
            Cijena_kazne = 5;
        }

        private int cijena_kazne;

        public int Cijena_kazne { get => cijena_kazne; set => cijena_kazne = value; }

        public override void Kazni(Player p)
        {
            if (p.Br_novcica >= Cijena_kazne)
            {
                p.Br_novcica = p.Br_novcica - Cijena_kazne;
                Game.WaitMS(1000); //nakon sto oduzme igracu novce, mora sacekati prije nego mu ih opet moze uzeti
            }
            else
            {
                p.Br_zivota = p.Br_zivota - 1;
                p.Treperi(); //dok igrac treperi nece se ponovno oduzimati zivot, ovo daje priliku igracu da pobjegne
            }
        }
    }
}

