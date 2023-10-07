using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public class Platforma : Sprite
    {
        public Platforma(int xcor, int ycor, int sirina) : base("sprites//platforma.png", xcor, ycor)
        {
            this.Heigth = 20;
            this.Width = sirina;
        }

        public Platforma(int xcor, int ycor, int visina, int sirina) : base("sprites//platforma.png", xcor, ycor)
        {
            this.Heigth = visina;
            this.Width = sirina;
        }
    }
}
