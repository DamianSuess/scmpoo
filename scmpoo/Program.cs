using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace scmpoo
{
    public static class Program
    {

        public static List<Bitmap> SpriteList = new List<Bitmap>();
        public static List<FormPoo> PooFormList = new List<FormPoo>();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // load tehm sprites
            LoadSprites();
            // start with 1 poo
            AddPoo();
            // run from settings
            Application.Run(new FormSettings());
        }

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
            int count = loadedfile.Width / 40;
            for (int n = 0; n < count; n++)
            {
                SpriteList.Add(loadedfile.Clone(new Rectangle(n * 40, 0, 40, 40), loadedfile.PixelFormat));
            }
            for (int n = 0; n < count; n++)
            {
                Bitmap b = (Bitmap) SpriteList[n].Clone();
                b.RotateFlip(RotateFlipType.RotateNoneFlipX);
                SpriteList.Add(b);
            }
        }

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

        public static FormPoo AddPoo(bool show = true)
        {
            var poo = new FormPoo();
            PooFormList.Add(poo);
            if (show)
                poo.Show();
            return poo;
        }

    }
}
