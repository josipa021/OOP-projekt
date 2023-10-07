using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    class Policajac_strogi : Policajac
    {
        public Policajac_strogi(int xcor, int ycor) : base ("sprites//policajac-strogi-desno.png", "sprites//policajac-strogi-lijevo.png", xcor, ycor)
        {

        }

        public override void Kazni(Player p)
        {
            p.Br_zivota = 0;
            p.Treperi();
        }
    }
}
