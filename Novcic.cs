using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public class Novcic : Sprite
    {
        public Novcic (int xcor, int ycor) : base ("sprites//novcic.png", xcor, ycor)
        {
            AddCostumes("sprites//zvjezdice.png");
            Width = 15;
            Heigth = 15;
        }

        public void Prikupljanje(Player p)
        {
            p.Br_novcica = p.Br_novcica + 1;

            this.CurrentCostume = this.Costumes[1];
            this.Width = 40; this.Heigth = 40;
            this.Y = this.Y - 30;
            this.X = this.X - 10;
            Game.WaitMS(300);

            this.SetVisible(false);
        }
    }
}
