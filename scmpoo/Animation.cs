using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scmpoo
{
    public abstract class Animation
    {

        public FormPoo PooForm { get; private set; }

        public Animation(FormPoo poo)
        {
            PooForm = poo;
            Finished = false;
        }

        // should always call this in the override method otherwise the Finished property won't reset (alternatively just reset it yourself)
        public virtual void Start() {
            Finished = false;
        }
        public abstract int Update();
        public virtual void Stop() { }
        public bool Finished { get; set; }

    }
}
