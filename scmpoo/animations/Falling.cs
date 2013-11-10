using System;
using System.Drawing;
using System.Windows.Forms;

namespace scmpoo.animations
{
    public class Falling : Animation
    {
        static int acceleration = 2;
        int velocity;

        public Falling(FormPoo c)
            : base(c)
        {

        }

        public override void Start()
        {
            base.Start();
            velocity = 0;
        }

        public override int Tick()
        {
            Step = (Step + 1) % 2;
            Poo.SetSprite(4 + Step);
            if (Poo.IsMouseDown)
            {
                velocity = 0;
                return 100;
            }
            int newvelocity = velocity + acceleration;
            Screen currentScreen = Screen.FromControl(Poo);
            if (!currentScreen.WorkingArea.Contains(new Rectangle(Poo.Location.X, Poo.Location.Y + newvelocity, Poo.Width, Poo.Height)))
            {
                Impact(currentScreen.WorkingArea, newvelocity, false);
                return 100;
            }
            var rect = Utility.GetRectangleAtPoint(Poo.Location.X + Poo.Width / 2, Poo.Location.Y + Poo.Height + newvelocity);
            if (rect != Rectangle.Empty
                && Between(rect.Y, Poo.Location.Y + Poo.Height, Poo.Location.Y + Poo.Height + newvelocity)
                && rect.Contains(Poo.Location.X, Poo.Location.Y + Poo.Height + newvelocity)
                && rect.Contains(Poo.Location.X + Poo.Width, Poo.Location.Y + Poo.Height + newvelocity))
            {
                Impact(rect, newvelocity, true);
                return 100;
            }
            velocity = newvelocity;
            Poo.Top += velocity;
            return 100;
        }

        private void Impact(Rectangle rect, int newvelocity, bool top)
        {
            Poo.Location = new Point(Poo.Location.X, rect.Location.Y + (!top ? rect.Height : 0) - Poo.Height);
            if (velocity <= acceleration * 2)
            {
                velocity = 0;
                Finished = true;
            }
            else
            {
                velocity = newvelocity / -2;
            }
        }

        private bool Between(int num, int lower, int upper)
        {
            return lower <= num && num <= upper;
        }
    }
}
