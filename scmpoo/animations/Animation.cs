
namespace scmpoo.animations
{
    public abstract class Animation
    {
        public Animation(FormPoo c)
        {
            Poo = c;
        }

        public FormPoo Poo { get; private set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }
        public int Step { get; set; }

        public virtual void Start() { }
        public abstract int Tick();
        public virtual void Stop() { }
    }
}
