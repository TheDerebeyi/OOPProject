using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOPProject.Classlar.Enum;

namespace OOPProject.Interfaceler
{
    public interface ISuyuCikarilabilen   //Suyu çıkarılabilenlerin arayüzü
    {
        Cesit Cesit { get; }
        Tip Tip { get; }
        PictureBox PictureBox { get; set; }
        int Agirlik { get; }
        int VitaminA { get; }
        int VitaminC { get; }

    }

    public interface ISikacak           //Sıkacakların arayüzü
    {
        PictureBox PictureBox { get; set; }         //Formda gözükecek picturebox

        void SuyunuCikar(ISuyuCikarilabilen suyuCikarilabilen, BilgiKutusu bilgiKutusu); //Suyu çıkarılabilen şeyi alıp sıkım değerlerini bilgi kutusuna aktarır
    }
}
