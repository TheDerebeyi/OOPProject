using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace OOPProject
{
    public partial class formVitaminDeposu : Form
    {
        private const int MEYVE_SAYİSİ = 5, MEYVE_UST_BOSLUK = 45, MEYVELER_ARASİ_BOSLUK = 75, MEYVE_BOYUT = 50;
        List<IMeyve> meyveler = new List<IMeyve>();
        Label labelSkor = new Label();
        Label labelKronometre = new Label();
        Button buttonBaslat = new Button();
        private int skor = 0;
        private int kronometre = 60;
        private BilgiKutusu bilgiKutusu;
        private NarenciyeSikacagi narenciyeSikacagi;
        private KatiMeyveSikacagi katiMeyveSikacagi;

        public formVitaminDeposu()
        {
            InitializeComponent();

            bilgiKutusu = new BilgiKutusu(0, 0, Height - 200, 0);

            Controls.Add(bilgiKutusu._labelBaslik);
            Controls.Add(bilgiKutusu._labelVitaminA);
            Controls.Add(bilgiKutusu._labelVitaminC);
            Controls.Add(bilgiKutusu._labelAgirlik);

            Random random = new Random();

            narenciyeSikacagi =
                new NarenciyeSikacagi(200, 120, Width / 2 - 3 * 100, Height / 2 - 120);

            narenciyeSikacagi.PictureBox.DragEnter += pictureBoxDragEnter;
            narenciyeSikacagi.PictureBox.DragDrop += pictureBoxNarenciyeDragDrop;
            Controls.Add(narenciyeSikacagi.PictureBox);

           katiMeyveSikacagi =
                new KatiMeyveSikacagi(200, 120, Width / 2 + 100, Height / 2 - 120);

            katiMeyveSikacagi.PictureBox.DragEnter += pictureBoxDragEnter;
            katiMeyveSikacagi.PictureBox.DragDrop += pictureBoxKatiMeyveDragDrop;
            Controls.Add(katiMeyveSikacagi.PictureBox);

            for (int i = 0; i < MEYVE_SAYİSİ - 1; i++)
            {
                int meyve = random.Next(6);

                switch (meyve)
                {
                    case 0:
                        meyveler.Add(new Elma(MEYVE_BOYUT, MEYVE_BOYUT,
                            Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + i * MEYVELER_ARASİ_BOSLUK,
                            MEYVE_UST_BOSLUK));
                        break;
                    case 1:
                        meyveler.Add(new Portakal(MEYVE_BOYUT, MEYVE_BOYUT,
                            Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + i * MEYVELER_ARASİ_BOSLUK,
                            MEYVE_UST_BOSLUK));
                        break;
                    case 2:
                        meyveler.Add(new Armut(MEYVE_BOYUT, MEYVE_BOYUT,
                            Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + i * MEYVELER_ARASİ_BOSLUK,
                            MEYVE_UST_BOSLUK));
                        break;
                    case 3:
                        meyveler.Add(new Greyfurt(MEYVE_BOYUT, MEYVE_BOYUT,
                            Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + i * MEYVELER_ARASİ_BOSLUK,
                            MEYVE_UST_BOSLUK));
                        break;
                    case 4:
                        meyveler.Add(new Cilek(MEYVE_BOYUT, MEYVE_BOYUT,
                            Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + i * MEYVELER_ARASİ_BOSLUK,
                            MEYVE_UST_BOSLUK));
                        break;
                    case 5:
                        meyveler.Add(new Mandalina(MEYVE_BOYUT, MEYVE_BOYUT,
                            Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + i * MEYVELER_ARASİ_BOSLUK,
                            MEYVE_UST_BOSLUK));
                        break;
                }

                Controls.Add(meyveler[i].PictureBox);
            }

            int meyveCesidi = random.Next(6);
            switch (meyveCesidi)
            {
                case 0:
                    meyveler.Add(new Elma(4 * MEYVE_BOYUT / 3, 4 * MEYVE_BOYUT / 3,
                        Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + (MEYVE_SAYİSİ - 1) * MEYVELER_ARASİ_BOSLUK,
                        MEYVE_UST_BOSLUK, true));
                    break;
                case 1:
                    meyveler.Add(new Portakal(4 * MEYVE_BOYUT / 3, 4 * MEYVE_BOYUT / 3,
                        Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + (MEYVE_SAYİSİ - 1) * MEYVELER_ARASİ_BOSLUK,
                        MEYVE_UST_BOSLUK, true));
                    break;
                case 2:
                    meyveler.Add(new Armut(4 * MEYVE_BOYUT / 3, 4 * MEYVE_BOYUT / 3,
                        Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + (MEYVE_SAYİSİ - 1) * MEYVELER_ARASİ_BOSLUK,
                        MEYVE_UST_BOSLUK, true));
                    break;
                case 3:
                    meyveler.Add(new Greyfurt(4 * MEYVE_BOYUT / 3, 4 * MEYVE_BOYUT / 3,
                        Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + (MEYVE_SAYİSİ - 1) * MEYVELER_ARASİ_BOSLUK,
                        MEYVE_UST_BOSLUK, true));
                    break;
                case 4:
                    meyveler.Add(new Cilek(4 * MEYVE_BOYUT / 3, 4 * MEYVE_BOYUT / 3,
                        Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + (MEYVE_SAYİSİ - 1) * MEYVELER_ARASİ_BOSLUK,
                        MEYVE_UST_BOSLUK, true));
                    break;
                case 5:
                    meyveler.Add(new Mandalina(4 * MEYVE_BOYUT / 3, 4 * MEYVE_BOYUT / 3,
                        Width / 2 - 3 * narenciyeSikacagi.PictureBox.Size.Width / 2 + (MEYVE_SAYİSİ - 1) * MEYVELER_ARASİ_BOSLUK,
                        MEYVE_UST_BOSLUK, true));
                    break;
            }

            meyveler[MEYVE_SAYİSİ - 1].PictureBox.MouseDown += pictureBoxMouseDown;
            Controls.Add(meyveler[MEYVE_SAYİSİ - 1].PictureBox);


            labelSkor.Text = "Skor: " + skor;
            labelSkor.Left = Width / 2 - labelSkor.Width / 2;
            Controls.Add(labelSkor);

            labelKronometre.Text = "Kalan süre: " + kronometre;
            labelKronometre.Left = Width / 2 - labelKronometre.Width / 2;
            labelKronometre.Top = Height - 100;
            Controls.Add(labelKronometre);

            buttonBaslat.Size = new Size(120, 40);
            buttonBaslat.TextAlign = ContentAlignment.MiddleCenter;
            buttonBaslat.Left = Width / 2 - buttonBaslat.Width / 2;
            buttonBaslat.Top = 3 * Height / 4;
            buttonBaslat.Text = "BASLAT";
            buttonBaslat.Click += buttonBaslatClick;
            Controls.Add(buttonBaslat);
        }

        private void buttonBaslatClick(object sender, EventArgs e)
        {
            SetTimer();
            Controls.Remove(buttonBaslat);
            katiMeyveSikacagi.PictureBox.AllowDrop = true;
            narenciyeSikacagi.PictureBox.AllowDrop = true;
            bilgiKutusu.Sifirla();
        }

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private void SetTimer()
        {
            myTimer.Tick += timer1_Tick;
            myTimer.Interval = 1000;
            myTimer.Start();
            labelKronometre.Text = "Kalan süre: " + kronometre;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (kronometre > 0)
            {
                kronometre--;
                labelKronometre.Text = "Kalan süre: " + kronometre;
            }
            else
            {
                myTimer.Stop();
                myTimer.Dispose();
                katiMeyveSikacagi.PictureBox.AllowDrop = false;
                narenciyeSikacagi.PictureBox.AllowDrop = false;
                Controls.Add(buttonBaslat);
                kronometre = 60;
                buttonBaslat.Text = "Yeniden Başlat";
                myTimer.Tick -= timer1_Tick;
            }
        }

        private void pictureBoxMouseDown(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            meyveler[MEYVE_SAYİSİ - 1].PictureBox
                .DoDragDrop(meyveler[MEYVE_SAYİSİ - 1].PictureBox, DragDropEffects.All);
        }

        private void pictureBoxDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void pictureBoxNarenciyeDragDrop(object sender,
            System.Windows.Forms.DragEventArgs e)
        {
            if (meyveler[MEYVE_SAYİSİ - 1].MeyveTipi == Tip.Narenciye)
            {
                int vitaminA, vitaminC;
                Random random = new Random();
                vitaminA = meyveler[MEYVE_SAYİSİ - 1].VitaminA() * random.Next(30, 71) / 100;
                vitaminC = meyveler[MEYVE_SAYİSİ - 1].VitaminC() * random.Next(30, 71) / 100;
                
                bilgiKutusu.DegerEkle(vitaminA, vitaminC, meyveler[MEYVE_SAYİSİ - 1].Agirlik);

                foreach (var _meyve in meyveler)
                {
                    Controls.Remove(_meyve.PictureBox);
                }

                skor++;

                Portakal geciciPortakal = new Portakal(meyveler[meyveler.Count - 1]);


                switch (meyveler[meyveler.Count - 2].MeyveCesidi)
                {
                    case Meyveler.Elma:
                        meyveler[meyveler.Count - 1] = new Elma(geciciPortakal, true);
                        break;
                    case Meyveler.Portakal:
                        meyveler[meyveler.Count - 1] = new Portakal(geciciPortakal, true);
                        break;
                    case Meyveler.Armut:
                        meyveler[meyveler.Count - 1] = new Armut(geciciPortakal, true);
                        break;
                    case Meyveler.Greyfurt:
                        meyveler[meyveler.Count - 1] = new Greyfurt(geciciPortakal, true);
                        break;
                    case Meyveler.Cilek:
                        meyveler[meyveler.Count - 1] = new Cilek(geciciPortakal, true);
                        break;
                    case Meyveler.Mandalina:
                        meyveler[meyveler.Count - 1] = new Mandalina(geciciPortakal, true);
                        break;
                }

                meyveler[MEYVE_SAYİSİ - 1].PictureBox.MouseDown += pictureBoxMouseDown;

                for (int i = MEYVE_SAYİSİ - 2; i > 0; i--)
                {
                    Elma geciciElma = new Elma(meyveler[i]);

                    switch (meyveler[i - 1].MeyveCesidi)
                    {
                        case Meyveler.Elma:
                            meyveler[i] = new Elma(geciciElma);
                            break;
                        case Meyveler.Portakal:
                            meyveler[i] = new Portakal(geciciElma);
                            break;
                        case Meyveler.Armut:
                            meyveler[i] = new Armut(geciciElma);
                            break;
                        case Meyveler.Greyfurt:
                            meyveler[i] = new Greyfurt(geciciElma);
                            break;
                        case Meyveler.Cilek:
                            meyveler[i] = new Cilek(geciciElma);
                            break;
                        case Meyveler.Mandalina:
                            meyveler[i] = new Mandalina(geciciElma);
                            break;
                    }
                }

                int meyve = random.Next(6);

                Elma geciciMeyve = new Elma(meyveler[0]);

                switch (meyve)
                {
                    case 0:
                        meyveler[0] = new Elma(geciciMeyve);
                        break;
                    case 1:
                        meyveler[0] = new Portakal(geciciMeyve);
                        break;
                    case 2:
                        meyveler[0] = new Armut(geciciMeyve);
                        break;
                    case 3:
                        meyveler[0] = new Greyfurt(geciciMeyve);
                        break;
                    case 4:
                        meyveler[0] = new Cilek(geciciMeyve);
                        break;
                    case 5:
                        meyveler[0] = new Mandalina(geciciMeyve);
                        break;
                }

                foreach (var _meyve in meyveler)
                {
                    Controls.Add(_meyve.PictureBox);
                }
            }
            else
            {
                skor--;
            }

            labelSkor.Text = "Skor: " + skor;
        }

        private void pictureBoxKatiMeyveDragDrop(object sender,
            System.Windows.Forms.DragEventArgs e)
        {
            if (meyveler[MEYVE_SAYİSİ - 1].MeyveTipi == Tip.KatiMeyve)
            {
                int vitaminA, vitaminC;
                Random random = new Random();
                vitaminA = meyveler[MEYVE_SAYİSİ - 1].VitaminA() * random.Next(80, 96) / 100;
                vitaminC = meyveler[MEYVE_SAYİSİ - 1].VitaminC() * random.Next(80, 96) / 100;

                bilgiKutusu.DegerEkle(vitaminA, vitaminC,meyveler[MEYVE_SAYİSİ-1].Agirlik);

                foreach (var _meyve in meyveler)
                {
                    Controls.Remove(_meyve.PictureBox);
                }

                skor++;
                Portakal geciciPortakal = new Portakal(meyveler[meyveler.Count - 1]);


                switch (meyveler[meyveler.Count - 2].MeyveCesidi)
                {
                    case Meyveler.Elma:
                        meyveler[meyveler.Count - 1] = new Elma(geciciPortakal, true);
                        break;
                    case Meyveler.Portakal:
                        meyveler[meyveler.Count - 1] = new Portakal(geciciPortakal, true);
                        break;
                    case Meyveler.Armut:
                        meyveler[meyveler.Count - 1] = new Armut(geciciPortakal, true);
                        break;
                    case Meyveler.Greyfurt:
                        meyveler[meyveler.Count - 1] = new Greyfurt(geciciPortakal, true);
                        break;
                    case Meyveler.Cilek:
                        meyveler[meyveler.Count - 1] = new Cilek(geciciPortakal, true);
                        break;
                    case Meyveler.Mandalina:
                        meyveler[meyveler.Count - 1] = new Mandalina(geciciPortakal, true);
                        break;
                }

                meyveler[MEYVE_SAYİSİ - 1].PictureBox.MouseDown += pictureBoxMouseDown;

                for (int i = MEYVE_SAYİSİ - 2; i > 0; i--)
                {
                    Elma geciciElma = new Elma(meyveler[i]);

                    switch (meyveler[i - 1].MeyveCesidi)
                    {
                        case Meyveler.Elma:
                            meyveler[i] = new Elma(geciciElma);
                            break;
                        case Meyveler.Portakal:
                            meyveler[i] = new Portakal(geciciElma);
                            break;
                        case Meyveler.Armut:
                            meyveler[i] = new Armut(geciciElma);
                            break;
                        case Meyveler.Greyfurt:
                            meyveler[i] = new Greyfurt(geciciElma);
                            break;
                        case Meyveler.Cilek:
                            meyveler[i] = new Cilek(geciciElma);
                            break;
                        case Meyveler.Mandalina:
                            meyveler[i] = new Mandalina(geciciElma);
                            break;
                    }
                }

                int meyve = random.Next(6);

                Elma geciciMeyve = new Elma(meyveler[0]);

                switch (meyve)
                {
                    case 0:
                        meyveler[0] = new Elma(geciciMeyve);
                        break;
                    case 1:
                        meyveler[0] = new Portakal(geciciMeyve);
                        break;
                    case 2:
                        meyveler[0] = new Armut(geciciMeyve);
                        break;
                    case 3:
                        meyveler[0] = new Greyfurt(geciciMeyve);
                        break;
                    case 4:
                        meyveler[0] = new Cilek(geciciMeyve);
                        break;
                    case 5:
                        meyveler[0] = new Mandalina(geciciMeyve);
                        break;
                }

                foreach (var _meyve in meyveler)
                {
                    Controls.Add(_meyve.PictureBox);
                }
            }
            else
            {
                skor--;
            }

            labelSkor.Text = "Skor: " + skor;
        }
    }

    abstract class Meyve : IMeyve
    {
        public Meyveler MeyveCesidi { get; set; }
        public Tip MeyveTipi { get; set; }

        public PictureBox PictureBox { get; set; }
        public int Agirlik { get; set; }

        public abstract int VitaminA();
        public abstract int VitaminC();
    }

    class Elma : Meyve
    {
        public override int VitaminA()
        {
            return (int)(Agirlik/100.0 * (int)OOPProject.VitaminA.Elma);
        }

        public override int VitaminC()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminC.Elma);
        }

        public Elma(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Elma;
            MeyveTipi = Tip.KatiMeyve;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/elma.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }

        public Elma(IMeyve meyve, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Elma;
            MeyveTipi = Tip.KatiMeyve;
            PictureBox.Size = meyve.PictureBox.Size;
            PictureBox.Top = meyve.PictureBox.Top;
            PictureBox.Left = meyve.PictureBox.Left;
            PictureBox.ImageLocation = "img/elma.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }
    }

    class Portakal : Meyve
    {
        public override int VitaminA()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminA.Portakal);
        }

        public override int VitaminC()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminC.Portakal);
        }

        public Portakal(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Portakal;
            MeyveTipi = Tip.Narenciye;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/portakal.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }

        public Portakal(IMeyve meyve, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Portakal;
            MeyveTipi = Tip.Narenciye;
            PictureBox.Size = meyve.PictureBox.Size;
            PictureBox.Top = meyve.PictureBox.Top;
            PictureBox.Left = meyve.PictureBox.Left;
            PictureBox.ImageLocation = "img/portakal.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }
    }

    class Mandalina : Meyve
    {
        public override int VitaminA()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminA.Mandalina);
        }

        public override int VitaminC()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminC.Mandalina);
        }

        public Mandalina(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Mandalina;
            MeyveTipi = Tip.Narenciye;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/mandalina.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }

        public Mandalina(IMeyve meyve, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Mandalina;
            MeyveTipi = Tip.Narenciye;
            PictureBox.Size = meyve.PictureBox.Size;
            PictureBox.Top = meyve.PictureBox.Top;
            PictureBox.Left = meyve.PictureBox.Left;
            PictureBox.ImageLocation = "img/mandalina.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }
    }

    class Greyfurt : Meyve
    {
        public override int VitaminA()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminA.Greyfurt);
        }

        public override int VitaminC()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminC.Greyfurt);
        }

        public Greyfurt(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Greyfurt;
            MeyveTipi = Tip.Narenciye;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/greyfurt.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }

        public Greyfurt(IMeyve meyve, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Greyfurt;
            MeyveTipi = Tip.Narenciye;
            PictureBox.Size = meyve.PictureBox.Size;
            PictureBox.Top = meyve.PictureBox.Top;
            PictureBox.Left = meyve.PictureBox.Left;
            PictureBox.ImageLocation = "img/greyfurt.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }
    }

    class Armut : Meyve
    {
        public override int VitaminA()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminA.Armut);
        }

        public override int VitaminC()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminC.Armut);
        }

        public Armut(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Armut;
            MeyveTipi = Tip.KatiMeyve;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/armut.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }

        public Armut(IMeyve meyve, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Armut;
            MeyveTipi = Tip.KatiMeyve;
            PictureBox.Size = meyve.PictureBox.Size;
            PictureBox.Top = meyve.PictureBox.Top;
            PictureBox.Left = meyve.PictureBox.Left;
            PictureBox.ImageLocation = "img/armut.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }
    }

    class Cilek : Meyve
    {
        public override int VitaminA()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminA.Cilek);
        }

        public override int VitaminC()
        {
            return (int)(Agirlik / 100.0 * (int)OOPProject.VitaminC.Cilek);
        }

        public Cilek(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Cilek;
            MeyveTipi = Tip.KatiMeyve;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/cilek.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }

        public Cilek(IMeyve meyve, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            MeyveCesidi = Meyveler.Cilek;
            MeyveTipi = Tip.KatiMeyve;
            PictureBox.Size = meyve.PictureBox.Size;
            PictureBox.Top = meyve.PictureBox.Top;
            PictureBox.Left = meyve.PictureBox.Left;
            PictureBox.ImageLocation = "img/cilek.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            Agirlik = random.Next(70, 121);
        }
    }

    class Sikacak : ISikacak
    {
        public PictureBox PictureBox { get; set; }
    }

    class KatiMeyveSikacagi : Sikacak
    {
        public KatiMeyveSikacagi(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            PictureBox = new PictureBox();
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/katimeyve.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
        }
    }

    class NarenciyeSikacagi : Sikacak
    {
        public NarenciyeSikacagi(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/narenciye.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
        }
    }

    class BilgiKutusu : Form
    {
        public Label _labelVitaminA, _labelVitaminC, _labelBaslik, _labelAgirlik;
        private int _vitaminA, _vitaminC, _agirlik;

        public BilgiKutusu(int width, int height, int top, int left)
        {
            _labelBaslik = new Label();
            _labelVitaminA = new Label();
            _labelVitaminC = new Label();
            _labelBaslik.AutoSize = true;
            _labelVitaminA.AutoSize = true;
            _labelVitaminC.AutoSize = true;
            _labelBaslik.Text = "Vitamin değerleri:";
            _labelVitaminA.Text = "Vitamin A: 0";
            _labelVitaminC.Text = "Vitamin C: 0";
            _labelBaslik.Left = left;
            _labelBaslik.Top = top;
            _labelVitaminA.Top = top + 25;
            _labelVitaminC.Top = top + 50;
            _labelVitaminA.Left = left;
            _labelVitaminC.Left = left;

            _labelAgirlik = new Label();
            _labelAgirlik.Top = top + 75;
            _labelAgirlik.Left = left;
            _labelAgirlik.Text = "Toplam ağırlık: 0";
            _labelAgirlik.AutoSize = true;
        }

        public void DegerEkle(int vitaminA, int vitaminC, int agirlik)
        {
            _vitaminA += vitaminA;
            _vitaminC += vitaminC;
            _agirlik += agirlik;

            _labelVitaminA.Text = "Vitamin A: " + _vitaminA;
            _labelVitaminC.Text = "Vitamin C: " + _vitaminC;
            _labelAgirlik.Text = "Toplam ağırlık: " + _agirlik;
        }

        public void Sifirla()
        {
            _vitaminC = 0;
            _vitaminA = 0;
            _agirlik = 0;
            _labelVitaminA.Text = "Vitamin A: 0";
            _labelVitaminC.Text = "Vitamin C: 0";
            _labelAgirlik.Text = "Toplam ağırlık: 0";
        }
    }
}