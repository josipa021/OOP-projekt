using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTTER
{
    public abstract class Pomicni_lik : Sprite
    {
        public Pomicni_lik(string image_d, string image_l, int xcor, int ycor) : base(image_d, xcor, ycor)
        {
            AddCostumes(image_l);
            Heigth = 100;
            Width = 40;
            SetDirection(90);
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value <= 0)
                    speed = GameOptions.Speed;  // default brzina, ukoliko netko unese krivu vrijednost
                else
                    speed = value;
            }
        }

        public void TurnLeft()
        {
            if (this.GetDirection() != 270)
            {
                this.SetDirection(270);
            }

            if (CostumeIndex != 1)
            {
                this.CurrentCostume = this.Costumes[1];
                this.CostumeIndex = 1;
            }
            //this.X = this.X - steps;
        }

        public void TurnRight()
        {
            if (this.GetDirection() != 90)
            {
                this.SetDirection(90);
            }

            if (CostumeIndex != 0)
            {
                this.CurrentCostume = this.Costumes[0];
                this.CostumeIndex = 0;
            }
            //this.X = this.X + steps;
        }
    }
}

