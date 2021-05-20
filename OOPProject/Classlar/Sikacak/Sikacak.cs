using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPProject.Interfaceler;

namespace OOPProject.Classlar.Sikacak
{
    public abstract class Sikacak : ISikacak
    {
        public PictureBox PictureBox { get; set; }
        public abstract void SuyunuCikar(ISuyuCikarilabilen suyuCikarilabilen, BilgiKutusu bilgiKutusu);
    }

    public class KatiMeyveSikacagi : Sikacak
    {
        public KatiMeyveSikacagi(int width, int height, int left, int top, bool allowDrop = false)  //PictureBox'ın konumu ve boyutlarını parametre olarak verebildiğimiz kurucu metod.
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
            double verim = random.Next(80, 96) / 100.0;   //Katı meyvede verim yüzde 80-95 arası

            bilgiKutusu.DegerEkle(suyuCikarilabilen.VitaminA * verim, suyuCikarilabilen.VitaminC * verim, suyuCikarilabilen.Agirlik); //aralık içinde rastgele üretilen verime göre vitamin değerleri ve meyvenin sıvı-püre karışık ağırılığı bilgi kutusuna gönderiliyor.
        }
    }

    public class NarenciyeSikacagi : Sikacak
    {
        public NarenciyeSikacagi(int width, int height, int left, int top, bool allowDrop = false) //PictureBox'ın konumu ve boyutlarını parametre olarak verebildiğimiz kurucu metod.
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
            double verim = random.Next(30, 71) / 100.0;  //Narenciyede verim yüzde 30-70 arası

            bilgiKutusu.DegerEkle(suyuCikarilabilen.VitaminA * verim, suyuCikarilabilen.VitaminC * verim, suyuCikarilabilen.Agirlik); //rastgele üretilen verime göre vitamin değerleri ve meyvenin sıvı-püre karışık ağırılığı bilgi kutusuna gönderiliyor.
        }
    }
}
