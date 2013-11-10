using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scmpoo.animations.random
{
    public class Turn : Animation
    {

        int start;

        public Turn(FormPoo c)
            : base(c)
        {

        }

        public override void Start()
        {
            Finished = false;
            Step = -1;
            start = FormMain.RandomInst.Next(0, 2) == 1 ? 9 : 12;
        }

        public override int Tick()
        {
            Step++;
            if (Step > 2)
            {
                Poo.FacingRight = !Poo.FacingRight;
                Poo.SetSprite(3);
                Finished = true;
            }
            else
                Poo.SetSprite(start + Step);
            return 200;
        }
    }
}
