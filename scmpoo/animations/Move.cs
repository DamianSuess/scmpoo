using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scmpoo.animations
{
    public class Move : Animation
    {
        static int speed = 3;
        int totaldistance;
        int stepdistance;
        bool running;
        int step;

        public Move(FormPoo poo)
            : base(poo)
        {

        }

        public override void Start()
        {
            base.Start();
            step = -1;
            running = Program.RandomInst.Next(0, 2) == 0;
            // todo: make sure the total distance isn't longer than the remaining width of the window under or screen
            totaldistance = Screen.FromControl(PooForm).WorkingArea.Width / 4;
            stepdistance = speed * (running ? 3 : 1);
        }

        public override int Update()
        {
            step++;
            if (running)
            {
                step %= 3;
                PooForm.SetSprite(4 + step);
            }
            else
            {
                step %= 2;
                PooForm.SetSprite(2 + step);
            }
            PooForm.Left += stepdistance * (PooForm.Facing == 0 ? -1 : 1);
            totaldistance -= stepdistance;
            if (totaldistance <= 0)
                Finished = true;
            return 200;
        }


    }
}
