using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using scmpoo.animations;
using System.Reflection;

namespace scmpoo
{
    public partial class FormPoo : Form
    {
        public FormPoo()
        {
            InitializeComponent();
        }

        public bool FacingRight { get; set; }

        public Animation CurrentAnimation { get; set; }

        public int CurrentSprite { get; set; }

        public void SetSprite(int idx)
        {
            CurrentSprite = idx;
            this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentAnimation == null)
            {
                CurrentAnimation = new Falling(this);
            }
            if (CurrentAnimation.Finished)
            {
                var animations = Assembly.GetExecutingAssembly().GetTypes().Where(t => string.Equals(t.Namespace, "scmpoo.animations.random"));
                var anim = animations.ElementAt(FormMain.RandomInst.Next(0, animations.Count()));
                CurrentAnimation = Activator.CreateInstance(anim, this) as Animation;
            }
            if (!CurrentAnimation.Started)
            {
                CurrentAnimation.Start();
                CurrentAnimation.Started = true;
            }
            int interval = CurrentAnimation.Tick();
            timer1.Interval = interval;
        }

        #region mouse move

        public bool IsMouseDown { get; set; }
        private Point mouseDownPoint;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseDownPoint = e.Location;
            IsMouseDown = true;
            if (CurrentAnimation == null || !(CurrentAnimation is Falling))
            {
                CurrentAnimation = new Falling(this);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                int xDiff = mouseDownPoint.X - e.Location.X;
                int yDiff = mouseDownPoint.Y - e.Location.Y;
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        #endregion

        private void FormPoo_Paint(object sender, PaintEventArgs e)
        {
            int sprite = CurrentSprite + (FacingRight ? FormMain.SpriteList.Count / 2 : 0);
            e.Graphics.DrawImage(FormMain.SpriteList[sprite], 0, 0);
        }

    }
}
