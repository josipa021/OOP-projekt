using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public class Virus : Sprite
    {
        public Virus (int xcor, int ycor) : base ("sprites//virus.png", xcor, ycor)
        {
            Heigth = 20;
            Width = 20;
        }

        public void SkupiVirus(Player p)
        {
            p.Br_zivota = p.Br_zivota - 1;
            this.SetVisible(false);
            p.Treperi();
        }
    }
}
