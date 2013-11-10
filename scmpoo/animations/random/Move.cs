using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scmpoo.animations.random
{
    public class Move : Animation
    {
        static int speed = 3;
        int totaldistance;
        int stepdistance;
        int movetype;

        public Move(FormPoo c)
            : base(c)
        {

        }

        public override void Start()
        {
            movetype = FormMain.RandomInst.Next(0, 3);
            // 0 = walking, 1 = running, 2 = rolling
            // todo: make sure the total distance isn't longer than the remaining width of the window under or screen
            totaldistance = Screen.FromControl(Poo).WorkingArea.Width / 4;
            // if we're walking have a slower stepdistance
            stepdistance = speed * (movetype == 0 ? 1 : 3);
        }

        public override int Tick()
        {
            if (movetype == 0)
            {
                Poo.SetSprite(2 + Step % 2);
            }
            else if (movetype == 1)
            {
                Poo.SetSprite(4 + Step % 2);
            }
            // todo: running into the edge of another poo or a background window causes the poo to bounce away
            // alternatively, step and run up the side of the window
            // if running and reach edge of a window with nothing below, jump off ?
            Poo.Left += stepdistance * (Poo.FacingRight ? 1 : -1);
            totaldistance -= stepdistance;
            if (totaldistance <= 0)
                Finished = true;
            return 200;
        }


    }
}
