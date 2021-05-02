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
        List<Meyve> meyveler = new List<Meyve>();
        Label labelSkor = new Label();
        Label labelKronometre = new Label();
        Button buttonBaslat = new Button();
        private int skor = 0;
        private int kronometre = 60;

        public formVitaminDeposu()
        {
            InitializeComponent();

            Random random = new Random();

            NarenciyeSikacagi pictureBoxNarenciye = new NarenciyeSikacagi();

            pictureBoxNarenciye.Size = new Size(200, 120);
            pictureBoxNarenciye.Left = Width / 2 - 3 * pictureBoxNarenciye.Size.Width / 2;
            pictureBoxNarenciye.Top = Height / 2 - pictureBoxNarenciye.Size.Height;
            pictureBoxNarenciye.ImageLocation = "img/narenciye.png";
            pictureBoxNarenciye.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxNarenciye.AllowDrop = true;
            pictureBoxNarenciye.DragEnter += pictureBoxDragEnter;
            pictureBoxNarenciye.DragDrop += pictureBoxNarenciyeDragDrop;
            Controls.Add(pictureBoxNarenciye);

            KatiMeyveSikacagi pictureBoxKatiMeyve = new KatiMeyveSikacagi();

            pictureBoxKatiMeyve.Size = new Size(200, 120);
            pictureBoxKatiMeyve.Left = Width / 2 + pictureBoxKatiMeyve.Size.Width / 2;
            pictureBoxKatiMeyve.Top = Height / 2 - pictureBoxKatiMeyve.Size.Height;
            pictureBoxKatiMeyve.ImageLocation = "img/katimeyve.png";
            pictureBoxKatiMeyve.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxKatiMeyve.AllowDrop = true;
            pictureBoxKatiMeyve.DragEnter += pictureBoxDragEnter;
            pictureBoxKatiMeyve.DragDrop += pictureBoxKatiMeyveDragDrop;
            Controls.Add(pictureBoxKatiMeyve);

            for (int i = 0; i < MEYVE_SAYİSİ - 1; i++)
            {
                int meyve = random.Next(2);
                switch (meyve)
                {
                    case 0:
                        meyveler.Add(new Meyve());
                        meyveler[i].MeyveCesidi = Meyveler.Elma;
                        meyveler[i].MeyveTipi = Tip.KatiMeyve;
                        break;
                    case 1:
                        meyveler.Add(new Meyve());
                        meyveler[i].MeyveCesidi = Meyveler.Portakal;
                        meyveler[i].MeyveTipi = Tip.Narenciye;
                        break;
                }

                meyveler[i].Size = new Size(MEYVE_BOYUT, MEYVE_BOYUT);
                meyveler[i].Top = MEYVE_UST_BOSLUK;
                meyveler[i].Left = Width / 2 - 3 * pictureBoxNarenciye.Size.Width / 2 + i * MEYVELER_ARASİ_BOSLUK;
                meyveler[i].ImageLocation = "img/meyve" + meyve + ".png";
                meyveler[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Controls.Add(meyveler[i]);
            }

            int meyveCesidi = random.Next(2);
            switch (meyveCesidi)
            {
                case 0:
                    meyveler.Add(new Meyve());
                    meyveler[MEYVE_SAYİSİ - 1].MeyveCesidi = Meyveler.Elma;
                    meyveler[MEYVE_SAYİSİ - 1].MeyveTipi = Tip.KatiMeyve;
                    break;
                case 1:
                    meyveler.Add(new Meyve());
                    meyveler[MEYVE_SAYİSİ - 1].MeyveCesidi = Meyveler.Portakal;
                    meyveler[MEYVE_SAYİSİ - 1].MeyveTipi = Tip.Narenciye;
                    break;
            }

            meyveler[MEYVE_SAYİSİ - 1].Size = new Size(4 * MEYVE_BOYUT / 3, 4 * MEYVE_BOYUT / 3);
            meyveler[MEYVE_SAYİSİ - 1].Top = MEYVE_UST_BOSLUK;
            meyveler[MEYVE_SAYİSİ - 1].Left =
                Width / 2 - 3 * pictureBoxNarenciye.Size.Width / 2 + (MEYVE_SAYİSİ - 1) * MEYVELER_ARASİ_BOSLUK;
            meyveler[MEYVE_SAYİSİ - 1].ImageLocation = "img/meyve" + meyveCesidi + ".png";
            meyveler[MEYVE_SAYİSİ - 1].SizeMode = PictureBoxSizeMode.StretchImage;
            meyveler[MEYVE_SAYİSİ - 1].AllowDrop = true;
            meyveler[MEYVE_SAYİSİ - 1].MouseDown += pictureBoxMouseDown;
            Controls.Add(meyveler[MEYVE_SAYİSİ - 1]);

 
            labelSkor.Text = "Skor: " + skor;
            labelSkor.Left = Width / 2 - labelSkor.Width / 2;
            Controls.Add(labelSkor);

           labelKronometre.Text = "Kalan süre: " + kronometre;
           labelKronometre.Left = Width / 2 - labelKronometre.Width / 2;
           labelKronometre.Top = Height - 100;
           Controls.Add(labelKronometre);


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
            }
        }

        private void pictureBoxMouseDown(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            meyveler[MEYVE_SAYİSİ - 1].DoDragDrop(meyveler[MEYVE_SAYİSİ - 1].Image,DragDropEffects.All);
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
                skor++;
            }
            else
            {
                skor--;
            }

            labelSkor.Text = "Skor: " + skor;

            for (int i = MEYVE_SAYİSİ - 1; i > 0; i--)
            {
                meyveler[i].Image = meyveler[i - 1].Image;
                meyveler[i].MeyveCesidi = meyveler[i - 1].MeyveCesidi;
                meyveler[i].MeyveTipi = meyveler[i - 1].MeyveTipi;
            }

            Random random = new Random();

            int meyve = random.Next(2);
            switch (meyve)
            {
                case 0:
                    meyveler.Add(new Meyve());
                    meyveler[0].MeyveCesidi = Meyveler.Elma;
                    meyveler[0].MeyveTipi = Tip.KatiMeyve;
                    break;
                case 1:
                    meyveler.Add(new Meyve());
                    meyveler[0].MeyveCesidi = Meyveler.Portakal;
                    meyveler[0].MeyveTipi = Tip.Narenciye;
                    break;
            }

            meyveler[0].ImageLocation = "img/meyve" + meyve + ".png";

            
        }

        private void pictureBoxKatiMeyveDragDrop(object sender,
            System.Windows.Forms.DragEventArgs e)
        {
            if (meyveler[MEYVE_SAYİSİ - 1].MeyveTipi == Tip.KatiMeyve)
            {
                skor++;
            }
            else
            {
                skor--;
            }

            labelSkor.Text = "Skor: " + skor;

            for (int i = MEYVE_SAYİSİ - 1; i > 0; i--)
            {
                meyveler[i].Image = meyveler[i - 1].Image;
                meyveler[i].MeyveCesidi = meyveler[i - 1].MeyveCesidi;
                meyveler[i].MeyveTipi = meyveler[i - 1].MeyveTipi;
            }

            Random random = new Random();

            int meyve = random.Next(2);
            switch (meyve)
            {
                case 0:
                    meyveler.Add(new Meyve());
                    meyveler[0].MeyveCesidi = Meyveler.Elma;
                    meyveler[0].MeyveTipi = Tip.KatiMeyve;
                    break;
                case 1:
                    meyveler.Add(new Meyve());
                    meyveler[0].MeyveCesidi = Meyveler.Portakal;
                    meyveler[0].MeyveTipi = Tip.Narenciye;
                    break;
            }

            meyveler[0].ImageLocation = "img/meyve" + meyve + ".png";
        }

    }

    enum Meyveler
    {
        Elma,
        Armut,
        Cilek,
        Portakal,
        Mandalina,
        Greyfurt
    };

    enum Tip
    {
        Narenciye,
        KatiMeyve
    }

    class Meyve : PictureBox
    {
        protected Meyveler _meyve;
        protected Tip _meyveTipi;

        public Meyveler MeyveCesidi
        {
            get
            {
                return _meyve;
            }
            set
            {
                _meyve = value;
            }
        }

        public Tip MeyveTipi
        {
            get
            {
                return _meyveTipi;
            }
            set
            {
                _meyveTipi = value;
            }
        }
    }

    class Sikacak : PictureBox
    {

    }

    class KatiMeyveSikacagi : Sikacak
    {

    }

    class NarenciyeSikacagi : Sikacak
    {

    }
}