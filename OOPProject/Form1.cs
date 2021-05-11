using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOPProject
{
    public partial class FormVitaminDeposu : Form
    {
        private const int SuyuCikarilabilenSayisi = 5, SuyuCikarilabilenUstBosluk = 45, SuyuCikarilabilenlerArasiBosluk = 75, SuyuCikarilabilenBoyut = 50;
        private readonly List<ISuyuCikarilabilen> _meyveler = new();
        private readonly Label _labelSkor = new();
        private readonly Label _labelKronometre = new();
        private readonly Button _buttonBaslat = new();
        private int _skor;
        private int _kronometre = 60;
        private readonly BilgiKutusu _bilgiKutusu;
        private readonly NarenciyeSikacagi _narenciyeSikacagi;
        private readonly KatiMeyveSikacagi _katiMeyveSikacagi;

        public FormVitaminDeposu()
        {
            InitializeComponent();

            _bilgiKutusu = new BilgiKutusu(Height - 200, 50);

            Controls.Add(_bilgiKutusu.LabelBaslik);
            Controls.Add(_bilgiKutusu.LabelAgirlik);
            Controls.Add(_bilgiKutusu.LabelVitaminA);
            Controls.Add(_bilgiKutusu.LabelVitaminC);

            Random random = new Random();

            _narenciyeSikacagi =
                new NarenciyeSikacagi(200, 120, Width / 2 - 3 * 100, Height / 2 - 120);

            _narenciyeSikacagi.PictureBox.DragEnter += PictureBoxDragEnter;
            _narenciyeSikacagi.PictureBox.DragDrop += PictureBoxNarenciyeDragDrop;
            Controls.Add(_narenciyeSikacagi.PictureBox);

            _katiMeyveSikacagi =
                 new KatiMeyveSikacagi(200, 120, Width / 2 + 100, Height / 2 - 120);

            _katiMeyveSikacagi.PictureBox.DragEnter += PictureBoxDragEnter;
            _katiMeyveSikacagi.PictureBox.DragDrop += PictureBoxKatiMeyveDragDrop;
            Controls.Add(_katiMeyveSikacagi.PictureBox);

            for (int i = 0; i < SuyuCikarilabilenSayisi - 1; i++)
            {
                int meyve = random.Next(6);

                switch (meyve)
                {
                    case 0:
                        _meyveler.Add(new Elma(SuyuCikarilabilenBoyut, SuyuCikarilabilenBoyut,
                            Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + i * SuyuCikarilabilenlerArasiBosluk,
                            SuyuCikarilabilenUstBosluk));
                        break;
                    case 1:
                        _meyveler.Add(new Portakal(SuyuCikarilabilenBoyut, SuyuCikarilabilenBoyut,
                            Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + i * SuyuCikarilabilenlerArasiBosluk,
                            SuyuCikarilabilenUstBosluk));
                        break;
                    case 2:
                        _meyveler.Add(new Armut(SuyuCikarilabilenBoyut, SuyuCikarilabilenBoyut,
                            Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + i * SuyuCikarilabilenlerArasiBosluk,
                            SuyuCikarilabilenUstBosluk));
                        break;
                    case 3:
                        _meyveler.Add(new Greyfurt(SuyuCikarilabilenBoyut, SuyuCikarilabilenBoyut,
                            Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + i * SuyuCikarilabilenlerArasiBosluk,
                            SuyuCikarilabilenUstBosluk));
                        break;
                    case 4:
                        _meyveler.Add(new Cilek(SuyuCikarilabilenBoyut, SuyuCikarilabilenBoyut,
                            Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + i * SuyuCikarilabilenlerArasiBosluk,
                            SuyuCikarilabilenUstBosluk));
                        break;
                    case 5:
                        _meyveler.Add(new Mandalina(SuyuCikarilabilenBoyut, SuyuCikarilabilenBoyut,
                            Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + i * SuyuCikarilabilenlerArasiBosluk,
                            SuyuCikarilabilenUstBosluk));
                        break;
                }

                Controls.Add(_meyveler[i].PictureBox);
            }

            int meyveCesidi = random.Next(6);
            switch (meyveCesidi)
            {
                case 0:
                    _meyveler.Add(new Elma(4 * SuyuCikarilabilenBoyut / 3, 4 * SuyuCikarilabilenBoyut / 3,
                        Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + (SuyuCikarilabilenSayisi - 1) * SuyuCikarilabilenlerArasiBosluk,
                        SuyuCikarilabilenUstBosluk, true));
                    break;
                case 1:
                    _meyveler.Add(new Portakal(4 * SuyuCikarilabilenBoyut / 3, 4 * SuyuCikarilabilenBoyut / 3,
                        Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + (SuyuCikarilabilenSayisi - 1) * SuyuCikarilabilenlerArasiBosluk,
                        SuyuCikarilabilenUstBosluk, true));
                    break;
                case 2:
                    _meyveler.Add(new Armut(4 * SuyuCikarilabilenBoyut / 3, 4 * SuyuCikarilabilenBoyut / 3,
                        Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + (SuyuCikarilabilenSayisi - 1) * SuyuCikarilabilenlerArasiBosluk,
                        SuyuCikarilabilenUstBosluk, true));
                    break;
                case 3:
                    _meyveler.Add(new Greyfurt(4 * SuyuCikarilabilenBoyut / 3, 4 * SuyuCikarilabilenBoyut / 3,
                        Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + (SuyuCikarilabilenSayisi - 1) * SuyuCikarilabilenlerArasiBosluk,
                        SuyuCikarilabilenUstBosluk, true));
                    break;
                case 4:
                    _meyveler.Add(new Cilek(4 * SuyuCikarilabilenBoyut / 3, 4 * SuyuCikarilabilenBoyut / 3,
                        Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + (SuyuCikarilabilenSayisi - 1) * SuyuCikarilabilenlerArasiBosluk,
                        SuyuCikarilabilenUstBosluk, true));
                    break;
                case 5:
                    _meyveler.Add(new Mandalina(4 * SuyuCikarilabilenBoyut / 3, 4 * SuyuCikarilabilenBoyut / 3,
                        Width / 2 - 3 * _narenciyeSikacagi.PictureBox.Size.Width / 2 + (SuyuCikarilabilenSayisi - 1) * SuyuCikarilabilenlerArasiBosluk,
                        SuyuCikarilabilenUstBosluk, true));
                    break;
            }

            _meyveler[SuyuCikarilabilenSayisi - 1].PictureBox.MouseDown += PictureBoxMouseDown;
            Controls.Add(_meyveler[SuyuCikarilabilenSayisi - 1].PictureBox);


            _labelSkor.Text = "Skor: " + _skor;
            _labelSkor.Left = Width / 2 - _labelSkor.Width / 2;
            Controls.Add(_labelSkor);

            _labelKronometre.Text = "Kalan süre: " + _kronometre;
            _labelKronometre.Left = Width / 2 - _labelKronometre.Width / 2;
            _labelKronometre.Top = Height - 100;
            Controls.Add(_labelKronometre);

            _buttonBaslat.Size = new Size(120, 40);
            _buttonBaslat.TextAlign = ContentAlignment.MiddleCenter;
            _buttonBaslat.Left = Width / 2 - _buttonBaslat.Width / 2;
            _buttonBaslat.Top = 3 * Height / 4;
            _buttonBaslat.Text = "BASLAT";
            _buttonBaslat.Click += ButtonBaslatClick;
            Controls.Add(_buttonBaslat);
        }

        private void SirayiIlerlet()
        {
            Random random = new Random();

            foreach (var meyve in _meyveler)
            {
                Controls.Remove(meyve.PictureBox);
            }

            Portakal geciciPortakal = new Portakal(_meyveler[^1]);


            switch (_meyveler[^2].Cesit)
            {
                case Cesit.Elma:
                    _meyveler[^1] = new Elma(geciciPortakal, true);
                    break;
                case Cesit.Portakal:
                    _meyveler[^1] = new Portakal(geciciPortakal, true);
                    break;
                case Cesit.Armut:
                    _meyveler[^1] = new Armut(geciciPortakal, true);
                    break;
                case Cesit.Greyfurt:
                    _meyveler[^1] = new Greyfurt(geciciPortakal, true);
                    break;
                case Cesit.Cilek:
                    _meyveler[^1] = new Cilek(geciciPortakal, true);
                    break;
                case Cesit.Mandalina:
                    _meyveler[^1] = new Mandalina(geciciPortakal, true);
                    break;
            }

            _meyveler[SuyuCikarilabilenSayisi - 1].PictureBox.MouseDown += PictureBoxMouseDown;

            for (int i = SuyuCikarilabilenSayisi - 2; i > 0; i--)
            {
                Elma geciciElma = new Elma(_meyveler[i]);

                switch (_meyveler[i - 1].Cesit)
                {
                    case Cesit.Elma:
                        _meyveler[i] = new Elma(geciciElma);
                        break;
                    case Cesit.Portakal:
                        _meyveler[i] = new Portakal(geciciElma);
                        break;
                    case Cesit.Armut:
                        _meyveler[i] = new Armut(geciciElma);
                        break;
                    case Cesit.Greyfurt:
                        _meyveler[i] = new Greyfurt(geciciElma);
                        break;
                    case Cesit.Cilek:
                        _meyveler[i] = new Cilek(geciciElma);
                        break;
                    case Cesit.Mandalina:
                        _meyveler[i] = new Mandalina(geciciElma);
                        break;
                }
            }

            int gecici = random.Next(6);

            Elma geciciMeyve = new Elma(_meyveler[0]);

            switch (gecici)
            {
                case 0:
                    _meyveler[0] = new Elma(geciciMeyve);
                    break;
                case 1:
                    _meyveler[0] = new Portakal(geciciMeyve);
                    break;
                case 2:
                    _meyveler[0] = new Armut(geciciMeyve);
                    break;
                case 3:
                    _meyveler[0] = new Greyfurt(geciciMeyve);
                    break;
                case 4:
                    _meyveler[0] = new Cilek(geciciMeyve);
                    break;
                case 5:
                    _meyveler[0] = new Mandalina(geciciMeyve);
                    break;
            }

            foreach (var meyve in _meyveler)
            {
                Controls.Add(meyve.PictureBox);
            }
        }

        private void ButtonBaslatClick(object sender, EventArgs e)
        {
            SetTimer();
            Controls.Remove(_buttonBaslat);
            _katiMeyveSikacagi.PictureBox.AllowDrop = true;
            _narenciyeSikacagi.PictureBox.AllowDrop = true;
            _bilgiKutusu.Sifirla();
        }

        private static readonly Timer MyTimer = new();

        private void SetTimer()
        {
            MyTimer.Tick += timer1_Tick;
            MyTimer.Interval = 1000;
            MyTimer.Start();
            _labelKronometre.Text = "Kalan süre: " + _kronometre;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_kronometre > 0)
            {
                _kronometre--;
                _labelKronometre.Text = "Kalan süre: " + _kronometre;
            }
            else
            {
                MyTimer.Stop();
                MyTimer.Dispose();
                _katiMeyveSikacagi.PictureBox.AllowDrop = false;
                _narenciyeSikacagi.PictureBox.AllowDrop = false;
                Controls.Add(_buttonBaslat);
                _kronometre = 60;
                _buttonBaslat.Text = "Yeniden Başlat";
                MyTimer.Tick -= timer1_Tick;
            }
        }

        private void PictureBoxMouseDown(object sender,
            MouseEventArgs e)
        {
            _meyveler[SuyuCikarilabilenSayisi - 1].PictureBox
                .DoDragDrop(_meyveler[SuyuCikarilabilenSayisi - 1].PictureBox, DragDropEffects.All);
        }

        private void PictureBoxDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void PictureBoxNarenciyeDragDrop(object sender,
            DragEventArgs e)
        {
            if (_meyveler[SuyuCikarilabilenSayisi - 1].Tip == Tip.Narenciye)
            {
                _narenciyeSikacagi.SuyunuCikar(_meyveler[SuyuCikarilabilenSayisi-1], _bilgiKutusu);

                _skor++;

               SirayiIlerlet();
            }
            else
            {
                _skor--;
            }

            _labelSkor.Text = "Skor: " + _skor;
        }

        private void PictureBoxKatiMeyveDragDrop(object sender,
            DragEventArgs e)
        {
            if (_meyveler[SuyuCikarilabilenSayisi - 1].Tip == Tip.KatiMeyve)
            {
                _katiMeyveSikacagi.SuyunuCikar(_meyveler[SuyuCikarilabilenSayisi - 1], _bilgiKutusu);

                _skor++;
                
                SirayiIlerlet();
            }
            else
            {
                _skor--;
            }

            _labelSkor.Text = "Skor: " + _skor;
        }
    }

    internal abstract class Meyve : ISuyuCikarilabilen
    {
        protected Tip _tip;
        protected Cesit _cesit;
        protected int _agirlik;

        public Cesit Cesit => _cesit;

        public Tip Tip => _tip;
        public PictureBox PictureBox { get; set; }
        public int Agirlik => _agirlik;

        public abstract int VitaminA { get; }
        public abstract int VitaminC { get; }
    }

    internal class Elma : Meyve
    {
        public override int VitaminA => (int)(Agirlik / 100.0 * (int)OOPProject.VitaminA.Elma);

        public override int VitaminC => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminC.Elma);

        public Elma(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Elma;
            _tip = Tip.KatiMeyve;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/elma.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Elma(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Elma;
            _tip = Tip.KatiMeyve;
            PictureBox.Size = suyuCikarilabilen.PictureBox.Size;
            PictureBox.Top = suyuCikarilabilen.PictureBox.Top;
            PictureBox.Left = suyuCikarilabilen.PictureBox.Left;
            PictureBox.ImageLocation = "img/elma.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    internal class Portakal : Meyve
    {
        public override int VitaminA => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminA.Portakal);

        public override int VitaminC => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminC.Portakal);

        public Portakal(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Portakal;
            _tip = Tip.Narenciye;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/portakal.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Portakal(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Portakal;
            _tip = Tip.Narenciye;
            PictureBox.Size = suyuCikarilabilen.PictureBox.Size;
            PictureBox.Top = suyuCikarilabilen.PictureBox.Top;
            PictureBox.Left = suyuCikarilabilen.PictureBox.Left;
            PictureBox.ImageLocation = "img/portakal.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    internal class Mandalina : Meyve
    {
        public override int VitaminA => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminA.Mandalina);

        public override int VitaminC => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminC.Mandalina);

        public Mandalina(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Mandalina;
            _tip = Tip.Narenciye;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/mandalina.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Mandalina(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Mandalina;
            _tip = Tip.Narenciye;
            PictureBox.Size = suyuCikarilabilen.PictureBox.Size;
            PictureBox.Top = suyuCikarilabilen.PictureBox.Top;
            PictureBox.Left = suyuCikarilabilen.PictureBox.Left;
            PictureBox.ImageLocation = "img/mandalina.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    internal class Greyfurt : Meyve
    {
        public override int VitaminA => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminA.Greyfurt);

        public override int VitaminC => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminC.Greyfurt);

        public Greyfurt(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Greyfurt;
            _tip = Tip.Narenciye;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/greyfurt.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Greyfurt(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Greyfurt;
            _tip = Tip.Narenciye;
            PictureBox.Size = suyuCikarilabilen.PictureBox.Size;
            PictureBox.Top = suyuCikarilabilen.PictureBox.Top;
            PictureBox.Left = suyuCikarilabilen.PictureBox.Left;
            PictureBox.ImageLocation = "img/greyfurt.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    internal class Armut : Meyve
    {
        public override int VitaminA => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminA.Armut);

        public override int VitaminC => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminC.Armut);

        public Armut(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Armut;
            _tip = Tip.KatiMeyve;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/armut.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Armut(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Armut;
            _tip = Tip.KatiMeyve;
            PictureBox.Size = suyuCikarilabilen.PictureBox.Size;
            PictureBox.Top = suyuCikarilabilen.PictureBox.Top;
            PictureBox.Left = suyuCikarilabilen.PictureBox.Left;
            PictureBox.ImageLocation = "img/armut.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    internal class Cilek : Meyve
    {
        public override int VitaminA => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminA.Cilek);

        public override int VitaminC => (int) (Agirlik / 100.0 * (int) OOPProject.VitaminC.Cilek);

        public Cilek(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Cilek;
            _tip = Tip.KatiMeyve;
            PictureBox.Size = new Size(width, height);
            PictureBox.Top = top;
            PictureBox.Left = left;
            PictureBox.ImageLocation = "img/cilek.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik= random.Next(70, 121);
        }

        public Cilek(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox();
            _cesit = Cesit.Cilek;
            _tip = Tip.KatiMeyve;
            PictureBox.Size = suyuCikarilabilen.PictureBox.Size;
            PictureBox.Top = suyuCikarilabilen.PictureBox.Top;
            PictureBox.Left = suyuCikarilabilen.PictureBox.Left;
            PictureBox.ImageLocation = "img/cilek.png";
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.AllowDrop = allowDrop;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    internal abstract class Sikacak : ISikacak
    {
        public PictureBox PictureBox { get; set; }
        public abstract void SuyunuCikar(ISuyuCikarilabilen suyuCikarilabilen, BilgiKutusu bilgiKutusu);
    }

    internal class KatiMeyveSikacagi : Sikacak
    {
        public KatiMeyveSikacagi(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/katimeyve.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
        }

        public override void SuyunuCikar(ISuyuCikarilabilen suyuCikarilabilen, BilgiKutusu bilgiKutusu)
        {
            Random random = new Random();
            var vitaminA = suyuCikarilabilen.VitaminA * random.Next(80, 96) / 100;
            var vitaminC = suyuCikarilabilen.VitaminC * random.Next(80, 96) / 100;

            bilgiKutusu.DegerEkle(vitaminA, vitaminC, suyuCikarilabilen.Agirlik);
        }
    }

    internal class NarenciyeSikacagi : Sikacak
    {
        public NarenciyeSikacagi(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/narenciye.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
        }

        public override void SuyunuCikar(ISuyuCikarilabilen suyuCikarilabilen, BilgiKutusu bilgiKutusu)
        {
            Random random = new Random();
            var vitaminA = suyuCikarilabilen.VitaminA * random.Next(30, 71) / 100;
            var vitaminC = suyuCikarilabilen.VitaminC * random.Next(30, 71) / 100;

            bilgiKutusu.DegerEkle(vitaminA, vitaminC, suyuCikarilabilen.Agirlik);
        }
    }

    internal class BilgiKutusu
    {
        private int _vitaminA, _vitaminC, _agirlik;

        public Label LabelAgirlik { get; }

        public Label LabelVitaminA { get; }

        public Label LabelVitaminC { get; }

        public Label LabelBaslik { get; }

        public BilgiKutusu(int top, int left)
        {
            LabelBaslik = new Label();
            LabelVitaminA = new Label();
            LabelVitaminC = new Label();
            LabelBaslik.AutoSize = true;
            LabelVitaminA.AutoSize = true;
            LabelVitaminC.AutoSize = true;
            LabelBaslik.Text = "Vitamin değerleri:";
            LabelVitaminA.Text = "Vitamin A: 0";
            LabelVitaminC.Text = "Vitamin C: 0";
            LabelBaslik.Left = left;
            LabelBaslik.Top = top;
            LabelVitaminA.Top = top + 25;
            LabelVitaminC.Top = top + 50;
            LabelVitaminA.Left = left;
            LabelVitaminC.Left = left;

            LabelAgirlik = new Label {Top = top + 75, Left = left, Text = "Toplam ağırlık: 0", AutoSize = true};
        }

        public void DegerEkle(int vitaminA, int vitaminC, int agirlik)
        {
            _vitaminA += vitaminA;
            _vitaminC += vitaminC;
            _agirlik += agirlik;

            LabelVitaminA.Text = "Vitamin A: " + _vitaminA;
            LabelVitaminC.Text = "Vitamin C: " + _vitaminC;
            LabelAgirlik.Text = "Toplam ağırlık: " + _agirlik;
        }

        public void Sifirla()
        {
            _vitaminC = 0;
            _vitaminA = 0;
            _agirlik = 0;
            LabelVitaminA.Text = "Vitamin A: 0";
            LabelVitaminC.Text = "Vitamin C: 0";
            LabelAgirlik.Text = "Toplam ağırlık: 0";
        }
    }
}