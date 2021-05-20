using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPProject.Classlar.Enum;
using OOPProject.Interfaceler;

namespace OOPProject.Classlar.Meyve
{
    public abstract class Meyve : ISuyuCikarilabilen
    {
        protected Tip _tip;                     //Meyvenin narenciye mi yoksa katı meyve mi olduğunu tutar.
        protected Cesit _cesit;                 //Meyvenin çeşidini tutar.
        protected int _agirlik;                 //Meyvenin ağırlığını tutar.

        public Cesit Cesit => _cesit;

        public Tip Tip => _tip;
        public PictureBox PictureBox { get; set; }      //Formda meyveyi temsil edecek PictureBox. Her meyvenin kendine özel bir picturbox'ı var.
        public int Agirlik => _agirlik;

        public abstract int VitaminA { get; }
        public abstract int VitaminC { get; }
    }

    public class Elma : Meyve           //Elma gibi meyveler üst meyve soyut sınıfından miras alıyor. Böylece ortak tüm property ve fieldlar bu sınıflara aktarılmış oluyor.
    {
        public override int VitaminA => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminA.Elma); //VitaminA.Elma'da meyvenin 100 gramındaki değerler tutuluyor biz bunları ağırlığa göre oranlayıp o ağırlıktaki meyve için değerleri buluyoruz.

        public override int VitaminC => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminC.Elma);

        public Elma(int width, int height, int left, int top, bool allowDrop = false) //Kurucu metodun parametreleri arasında picturebox'ın konumu ve boyutu gibi özellikler yer alıyor. allowDrop değişkeni ile meyvenin sürükle bırak sisteminde aktif olup olmadığını belirliyoruz.
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/elma.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Elma;
            _tip = Tip.KatiMeyve;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Elma(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)       //Bu kurucu metod parametre olarak verilen meyvenin pictureBox'ının konum verilerini alarak yeni meyveye aktarıyor.
        {
            PictureBox = new PictureBox
            {
                Size = suyuCikarilabilen.PictureBox.Size,
                Top = suyuCikarilabilen.PictureBox.Top,
                Left = suyuCikarilabilen.PictureBox.Left,
                ImageLocation = "img/elma.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Elma;
            _tip = Tip.KatiMeyve;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    public class Portakal : Meyve
    {
        public override int VitaminA => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminA.Portakal);

        public override int VitaminC => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminC.Portakal);

        public Portakal(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/portakal.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Portakal;
            _tip = Tip.Narenciye;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Portakal(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = suyuCikarilabilen.PictureBox.Size,
                Top = suyuCikarilabilen.PictureBox.Top,
                Left = suyuCikarilabilen.PictureBox.Left,
                ImageLocation = "img/portakal.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Portakal;
            _tip = Tip.Narenciye;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    public class Mandalina : Meyve
    {
        public override int VitaminA => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminA.Mandalina);

        public override int VitaminC => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminC.Mandalina);

        public Mandalina(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/mandalina.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Mandalina;
            _tip = Tip.Narenciye;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Mandalina(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = suyuCikarilabilen.PictureBox.Size,
                Top = suyuCikarilabilen.PictureBox.Top,
                Left = suyuCikarilabilen.PictureBox.Left,
                ImageLocation = "img/mandalina.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Mandalina;
            _tip = Tip.Narenciye;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    public class Greyfurt : Meyve
    {
        public override int VitaminA => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminA.Greyfurt);

        public override int VitaminC => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminC.Greyfurt);

        public Greyfurt(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/greyfurt.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Greyfurt;
            _tip = Tip.Narenciye;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Greyfurt(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = suyuCikarilabilen.PictureBox.Size,
                Top = suyuCikarilabilen.PictureBox.Top,
                Left = suyuCikarilabilen.PictureBox.Left,
                ImageLocation = "img/greyfurt.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Greyfurt;
            _tip = Tip.Narenciye;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    public class Armut : Meyve
    {
        public override int VitaminA => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminA.Armut);

        public override int VitaminC => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminC.Armut);

        public Armut(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/armut.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Armut;
            _tip = Tip.KatiMeyve;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Armut(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = suyuCikarilabilen.PictureBox.Size,
                Top = suyuCikarilabilen.PictureBox.Top,
                Left = suyuCikarilabilen.PictureBox.Left,
                ImageLocation = "img/armut.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Armut;
            _tip = Tip.KatiMeyve;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }

    public class Cilek : Meyve
    {
        public override int VitaminA => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminA.Cilek);

        public override int VitaminC => (int)(Agirlik / 100.0 * (int)OOPProject.Classlar.Enum.VitaminC.Cilek);

        public Cilek(int width, int height, int left, int top, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = new Size(width, height),
                Top = top,
                Left = left,
                ImageLocation = "img/cilek.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Cilek;
            _tip = Tip.KatiMeyve;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }

        public Cilek(ISuyuCikarilabilen suyuCikarilabilen, bool allowDrop = false)
        {
            PictureBox = new PictureBox
            {
                Size = suyuCikarilabilen.PictureBox.Size,
                Top = suyuCikarilabilen.PictureBox.Top,
                Left = suyuCikarilabilen.PictureBox.Left,
                ImageLocation = "img/cilek.png",
                SizeMode = PictureBoxSizeMode.StretchImage,
                AllowDrop = allowDrop
            };
            _cesit = Cesit.Cilek;
            _tip = Tip.KatiMeyve;
            Random random = new Random();
            _agirlik = random.Next(70, 121);
        }
    }
}
