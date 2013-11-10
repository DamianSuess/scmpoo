using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scmpoo.animations.random
{
    public class Sneeze : Animation
    {

        int[] sprites = { 107, 108, 109, 110, 111, 130, 129, 128, 127 };

        public Sneeze(FormPoo c)
            : base(c)
        {

        }

        public override int Tick()
        {
            if (Step == 1)
                FormMain.PlaySound("sneeze.wav");
            if (Step >= sprites.Length)
                Finished = true;
            else
            {
                Poo.SetSprite(sprites[Step]);
                Step++;
            }
            return 200;
        }
    }
}
