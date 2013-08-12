using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scmpoo.animations
{
    public class Turn : Animation
    {

        int step, start;

        public Turn(FormPoo poo)
            : base(poo)
        {

        }

        public override void Start()
        {
            base.Start();
            step = -1;
            start = Program.RandomInst.Next(0, 2) == 1 ? 9 : 12;
        }

        public override int Update()
        {
            step++;
            if (step > 2)
            {
                PooForm.Facing = (PooForm.Facing + 1) % 2;
                PooForm.SetSprite(3);
                Finished = true;
            }
            else
                PooForm.SetSprite(start + step);
            return 200;
        }
    }
}
