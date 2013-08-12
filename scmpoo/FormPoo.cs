using System;
using System.Drawing;
using System.Windows.Forms;
using scmpoo.animations;
using System.Collections.Generic;

namespace scmpoo
{
    public partial class FormPoo : Form
    {

        System.Timers.Timer timer = new System.Timers.Timer();

        bool mouseDown = false;
        Point mouseDownPoint;

        Animation currentAnimation;

        public int Facing { get; set; }

        bool ticktock = false;

        List<Animation> AnimationList = new List<Animation>();

        public FormPoo()
        {
            InitializeComponent();
            // animation list
            AnimationList.Add(new Turn(this));
            AnimationList.Add(new Move(this));
            // init timer
            timer.SynchronizingObject = this;
            timer.Interval = 10;
            timer.Elapsed += timer_Elapsed;
            // set initial animation
            currentAnimation = new Falling(this);
            // dix
            this.DoubleBuffered = true;
        }

        private void FormPoo_Load(object sender, EventArgs e)
        {
            SetSprite(3);
            timer.Start();
        }

        private void FormPoo_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = e.Location;
            mouseDown = true;
        }

        private void FormPoo_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int xDiff = mouseDownPoint.X - e.Location.X;
                int yDiff = mouseDownPoint.Y - e.Location.Y;
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        private void FormPoo_MouseUp(object sender, MouseEventArgs e)
        {
            SetAnimation(new Falling(this));
            mouseDown = false;
        }

        DateTime nextrun = DateTime.Now;

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now > nextrun)
            {
                nextrun = DateTime.Now + TimeSpan.FromMilliseconds(tick());
            }
        }

        public void TickTock()
        {
            ticktock = !ticktock;
            SetSprite(ticktock ? 4 : 5);
        }

        public int tick()
        {
            if (mouseDown)
            {
                TickTock();
                return 100;
            }
            // todo: check if the window the poo is on has been moved and set animation to Falling ?
            if (currentAnimation == null || currentAnimation.Finished)
            {
                SetAnimation(AnimationList[Program.RandomInst.Next(AnimationList.Count)]);
            }
            return currentAnimation.Update();
        }

        delegate void SetSpriteCallback(int num);

        public void SetSprite(int num)
        {
            if (this.InvokeRequired)
            {
                SetSpriteCallback d = new SetSpriteCallback(SetSprite);
                this.Invoke(d, new object[] { num });
            }
            else
            {
                this.BackgroundImage = Program.SpriteList[num + (Facing == 0 ? 0 : Program.SpriteList.Count / 2)];
                this.Size = this.BackgroundImage.Size;
            }
        }

        public void SetAnimation(Animation newAnimation)
        {
            if (currentAnimation != null)
            {
                currentAnimation.Stop();
            }
            currentAnimation = newAnimation;
            currentAnimation.Start();
        }

    }
}
