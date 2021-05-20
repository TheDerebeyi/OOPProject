using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OOPProject.Classlar.Enum;
using OOPProject.Classlar.Meyve;
using OOPProject.Classlar.Sikacak;
using OOPProject.Interfaceler;

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

            //Arkaplan rengi
            BackColor = Color.White;


            //Oyunun nasıl oynandığıyla alakalı ipucu metni
            Label labelInfo = new Label()
            {
                MaximumSize = new Size(250,250), Text = "Başla butonuna bastıktan sonra meyveleri uygun sıkacağın üzerine sürükleyip bırak.",Top = Height-175,Left = Width-300,AutoSize = true
            };

            Controls.Add(labelInfo);

            //Bilgi kutusu tüm değerleri gösterdiğimiz bir kutucuk, 
            _bilgiKutusu = new BilgiKutusu(Height - 200, 50);

            Controls.Add(_bilgiKutusu.LabelBaslik);
            Controls.Add(_bilgiKutusu.LabelAgirlik);
            Controls.Add(_bilgiKutusu.LabelVitaminA);
            Controls.Add(_bilgiKutusu.LabelVitaminC);

            Random random = new Random();


            //Sıkacaklar forma ekleniyor
            _narenciyeSikacagi =
                new NarenciyeSikacagi(200, 120, Width / 2 - 3 * 100, Height / 2 - 120);

            //Tasarımda meyvelerin sürüklenip sıkacakların üzerine bırakılması üzerine bir sistem kuruldu. Bunun için gerekli eventler ekleniyor.
            _narenciyeSikacagi.PictureBox.DragEnter += PictureBoxDragEnter;
            _narenciyeSikacagi.PictureBox.DragDrop += PictureBoxNarenciyeDragDrop;
            Controls.Add(_narenciyeSikacagi.PictureBox);

            _katiMeyveSikacagi =
                 new KatiMeyveSikacagi(200, 120, Width / 2 + 100, Height / 2 - 120);

            _katiMeyveSikacagi.PictureBox.DragEnter += PictureBoxDragEnter;
            _katiMeyveSikacagi.PictureBox.DragDrop += PictureBoxKatiMeyveDragDrop;
            Controls.Add(_katiMeyveSikacagi.PictureBox);

            //Tasarımda sadece şu anki değil birkaç sıra sonrasında da hangi meyvelerin geleceğini gösteren bir tasarıma gidildi. Bunun için meyveleri tuttuğumuz bir List'imiz var.
            //_meyveler listesine random meyveler ekleniyor.
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

            //Son meyve diğer meyvelere göre boyut olarak biraz daha büyük olduğu için ayrı bir şekilde ekleniyor.
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

            //Meyvenin sürüklenmesi gerektiğinden sürükleme işleminin başlayacağı mouse butonunun basılma durumuyla ilgili event ekleniyor. Bundan önceki meyvelerde bu yok çünkü onlar inaktif durumda.
            _meyveler[SuyuCikarilabilenSayisi - 1].PictureBox.MouseDown += PictureBoxMouseDown;
            Controls.Add(_meyveler[SuyuCikarilabilenSayisi - 1].PictureBox);

            //Başlat butonu, skor göstergesi ve kalan süre göstergesi eklenip konum ayarlamaları yapılıyor.
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

        private void SirayiIlerlet()                                        //Sırada birden fazla meyve olduğu için işlem sonrasında ilk başta belirlediğimiz sıradaki meyvenin başa gelmesi lazım. Ayrıca son sıraya rastgele bir meyve eklenecek.  
        {
            Random random = new Random();

            //Meyvelerin PictureBox'ları formdan kaldırılıyor.
            foreach (var meyve in _meyveler)
            {
                Controls.Remove(meyve.PictureBox);
            }

            //İşlem yapılıp sırası geçmiş meyvenin özelliklerini tutacak bir geçici meyve oluşturuluyor.
            Portakal geciciPortakal = new Portakal(_meyveler[^1]);

            //Sıranın başına gelecek yeni meyvenin çeşidine göre aynı çeşitten yeni bir meyve oluşturulacak ve bu meyveye sırası geçmiş meyvenin konum ve boyut gibi özellikleri aktarılacak.
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

            //Sürükle bırak mekaniğinin çalışabilmesi için yeni oluşturulan meyveye gerekli event ekleniyor.
            _meyveler[SuyuCikarilabilenSayisi - 1].PictureBox.MouseDown += PictureBoxMouseDown;

            //Sıranın sonundan sıranın baştan ikincisine kadar özellikler aynı olduğundan bir döngü ile bu meyvelerin sıradaki yeri bir ilerletilecek.
            for (int i = SuyuCikarilabilenSayisi - 2; i > 0; i--)
            {
                //Meyveyi yerleştireceğimiz sıradaki elemanın konum ve boyut gibi özelliklerinin tutulacağı gecici meyve oluşturuluyor.
                Elma geciciElma = new Elma(_meyveler[i]);

                //Meyvenin çeşidine göre yeni sırada tekrar bir meyve oluşturuluyor ve gecici meyvede tuttuğumuz özellikler aktarılıyor.
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

            //Son sıra bu şartlarda boş kalıyor, buraya rastgele yeni bir meyve üretilecek.
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

            //Tüm meyveler forma geri ekleniyor.
            foreach (var meyve in _meyveler)
            {
                Controls.Add(meyve.PictureBox);
            }
        }

        private void ButtonBaslatClick(object sender, EventArgs e)
        {
            //Kronometre ayarlanıyor
            SetTimer();
            //Başlatma butonu formdan kaldırılıyor
            Controls.Remove(_buttonBaslat);

            //Sıkacaklar aktif ediliyor
            _katiMeyveSikacagi.PictureBox.AllowDrop = true;
            _narenciyeSikacagi.PictureBox.AllowDrop = true;

            //Bilgi kutusunun değerleri temizleniyor
            _bilgiKutusu.Sifirla();
        }

        private static readonly Timer MyTimer = new();

        private void SetTimer()
        {
            //Her aralık sonunda gerçekleşecek event ekleniyor.
            MyTimer.Tick += timer1_Tick;
            //Aralık bir saniye olarak belirleniyor.
            MyTimer.Interval = 1000;
            //Kronometre başlatılıyor.
            MyTimer.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Kronometrenin değeri kontrol ediliyor. Eğer 0'dan büyükse değeri bir azaltılıp güncellenecek.
            if (_kronometre > 0)
            {
                _kronometre--;
                _labelKronometre.Text = "Kalan süre: " + _kronometre;
            }
            else        //Eğer kronometre değeri 0 ise aşağıdaki blok çalışacak.
            {
                MyTimer.Stop(); 
                MyTimer.Dispose();
                _katiMeyveSikacagi.PictureBox.AllowDrop = false;            //Sıkacaklar kullanıma kapatılıyor.
                _narenciyeSikacagi.PictureBox.AllowDrop = false;
                Controls.Add(_buttonBaslat);                                //Oyunu başlatan buton tekrardan ekleniyor.
                _kronometre = 60;                                           //Kronometrenin sayacı tekrardan 60'a ayarlanıyor
                _buttonBaslat.Text = "Yeniden Başlat";
                MyTimer.Tick -= timer1_Tick;                                //Tekrar başlatıldığında üst üste event binmesi olmaması için event kaldırılıyor. Eğer oyun tekrar başlarsa kronometre başlatılırken bu metod geri eklenecek.
            }
        }

        private void PictureBoxMouseDown(object sender,
            MouseEventArgs e)                                           //Sürükle bırak sisteminin başladığı nokta.
        {
            _meyveler[SuyuCikarilabilenSayisi - 1].PictureBox
                .DoDragDrop(_meyveler[SuyuCikarilabilenSayisi - 1].PictureBox, DragDropEffects.All);
        }

        private void PictureBoxDragEnter(object sender, DragEventArgs e)   //Sürükleme sırasında sıkacakların üstüne gelindiğinde imlecin değişmesini sağlayan event.
        {
            e.Effect = e.AllowedEffect;
        }

        private void PictureBoxNarenciyeDragDrop(object sender,
            DragEventArgs e)                                                //Meyve narenciye sıkacağına sürüklendiğinde çalıştırılacak event.
        {
            if (_meyveler[SuyuCikarilabilenSayisi - 1].Tip == Tip.Narenciye)        //Sürüklenen meyvenin tipi doğru mu kontrol ediliyor. Yanlışsa skor bir düşürülüp işlem yapılmayacak.
            {
                _narenciyeSikacagi.SuyunuCikar(_meyveler[SuyuCikarilabilenSayisi-1], _bilgiKutusu);     //Sıkacağın SuyunuCikar() fonksiyonu çağırılarak meyvenin değerleri hesaplanıyor. Bu değerler bilgi kutusuna gönderiliyor.

                _skor++;

               SirayiIlerlet();                                         //Sıkılan meyve çıkarılarak sıradaki meyveler ilerletiyor ve sıranın sonuna bir tane rastgele meyve ekleniyor.
            }
            else
            {
                _skor--;
            }

            _labelSkor.Text = "Skor: " + _skor;
        }

        private void PictureBoxKatiMeyveDragDrop(object sender,
            DragEventArgs e)                                                //Meyve katı meyve sıkacağına sürüklendiğinde çalıştırılacak event.
        {
            if (_meyveler[SuyuCikarilabilenSayisi - 1].Tip == Tip.KatiMeyve)        //Sürüklenen meyvenin tipi doğru mu kontrol ediliyor. Yanlışsa skor bir düşürülüp işlem yapılmayacak.
            {
                _katiMeyveSikacagi.SuyunuCikar(_meyveler[SuyuCikarilabilenSayisi - 1], _bilgiKutusu);     //Sıkacağın SuyunuCikar() fonksiyonu çağırılarak meyvenin değerleri hesaplanıyor. Bu değerler bilgi kutusuna gönderiliyor.

                _skor++;
                
                SirayiIlerlet();                                         //Sıkılan meyve çıkarılarak sıradaki meyveler ilerletiyor ve sıranın sonuna bir tane rastgele meyve ekleniyor.
            }
            else
            {
                _skor--;
            }

            _labelSkor.Text = "Skor: " + _skor;
        }
    }

    public class BilgiKutusu
    {
        private double _vitaminA, _vitaminC, _agirlik;

        public Label LabelAgirlik { get; }

        public Label LabelVitaminA { get; }

        public Label LabelVitaminC { get; }

        public Label LabelBaslik { get; }

        public BilgiKutusu(int top, int left)               //Bilgi kutusunun forma ekleneceği koordinatların girildiği kurucu metod
        {
            LabelBaslik = new Label {AutoSize = true, Text = "Vitamin değerleri:", Left = left, Top = top};
            LabelVitaminA = new Label {AutoSize = true, Text = "Vitamin A: 0", Top = top + 25, Left = left};
            LabelVitaminC = new Label {AutoSize = true, Text = "Vitamin C: 0", Top = top + 50, Left = left};

            LabelAgirlik = new Label {Top = top + 75, Left = left, Text = "Toplam ağırlık: 0", AutoSize = true};
        }

        public void DegerEkle(double vitaminA, double vitaminC, int agirlik)             //Bilgi kutusuna sıkılan meyvenin değerlerini ekler.
        {
            _vitaminA += vitaminA;
            _vitaminC += vitaminC;
            _agirlik += agirlik;

            LabelVitaminA.Text = "Vitamin A: " + string.Format("{0:F2}",_vitaminA);
            LabelVitaminC.Text = "Vitamin C: " + string.Format("{0:F2}", _vitaminC);
            LabelAgirlik.Text = "Toplam ağırlık: " + string.Format("{0}", _agirlik);
        }

        public void Sifirla()                                                           //Bilgi kutusunun tüm değerlerini sıfırlar.
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