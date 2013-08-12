using System;
using System.Drawing;
using System.Windows.Forms;

namespace scmpoo.animations
{
    public class Falling : Animation
    {
        static int acceleration = 2;
        int velocity;

        public Falling(FormPoo poo)
            : base(poo)
        {

        }

        public override void Start()
        {
            velocity = 0;
        }

        public override int Update()
        {
            PooForm.TickTock();
            int newvelocity = velocity + acceleration;
            Screen currentScreen = Screen.FromControl(PooForm);
            if (!currentScreen.WorkingArea.Contains(new Rectangle(PooForm.Location.X, PooForm.Location.Y + newvelocity, PooForm.Width, PooForm.Height)))
            {
                Impact(currentScreen.WorkingArea, newvelocity, false);
                return 100;
            }
            var rect = Utility.GetRectangleAtPoint(PooForm.Location.X + PooForm.Width / 2, PooForm.Location.Y + PooForm.Height + newvelocity);
            if (rect != Rectangle.Empty
                && Between(rect.Y, PooForm.Location.Y + PooForm.Height, PooForm.Location.Y + PooForm.Height + newvelocity)
                && rect.Contains(PooForm.Location.X, PooForm.Location.Y + PooForm.Height + newvelocity)
                && rect.Contains(PooForm.Location.X + PooForm.Width, PooForm.Location.Y + PooForm.Height + newvelocity))
            {
                Impact(rect, newvelocity, true);
                return 100;
            }
            velocity = newvelocity;
            PooForm.Top += velocity;
            return 100;
        }

        private void Impact(Rectangle rect, int newvelocity, bool top)
        {
            PooForm.Location = new Point(PooForm.Location.X, rect.Location.Y + (!top ? rect.Height : 0) - PooForm.Height);
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
