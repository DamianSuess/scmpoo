using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace scmpoo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadSprites();
            AddPoo();
        }

        public static Random RandomInst = new Random();

        public static void PlaySound(string name)
        {
            try
            {
                if (File.Exists(name))
                {
                    new SoundPlayer(name).Play();
                }
                else
                {
                    var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("scmpoo.resources." + name);
                    new SoundPlayer(stream).Play();
                }
            }
            catch { }
        }

        public static ConcurrentBag<FormPoo> PooList = new ConcurrentBag<FormPoo>();
        public static List<Bitmap> SpriteList = new List<Bitmap>();

        public static void LoadSprites()
        {
            SpriteList.Clear();
            Stream stream;
            if (File.Exists("sprites.png"))
            {
                stream = File.OpenRead("sprites.png");
            }
            else
            {
                var assembly = Assembly.GetExecutingAssembly();
                stream = assembly.GetManifestResourceStream("scmpoo.resources.sprites.png");
            }
            Bitmap loadedfile = new Bitmap(Image.FromStream(stream));
            int count = loadedfile.Width / loadedfile.Height;
            for (int n = 0; n < count; n++)
            {
                SpriteList.Add(loadedfile.Clone(new Rectangle(n * loadedfile.Height, 0, loadedfile.Height, loadedfile.Height), loadedfile.PixelFormat));
            }
            for (int n = 0; n < count; n++)
            {
                Bitmap b = (Bitmap)SpriteList[n].Clone();
                b.RotateFlip(RotateFlipType.RotateNoneFlipX);
                SpriteList.Add(b);
            }
        }

        public static FormPoo AddPoo()
        {
            var poo = new FormPoo();
            poo.Show();
            PooList.Add(poo);
            return poo;
        }
    }
}
