using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPProject
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormVitaminDeposu());
        }
    }

    public enum Cesit
    {
        Elma,
        Portakal,
        Armut,
        Cilek,
        Mandalina,
        Greyfurt
    };

    public enum Tip
    {
        Narenciye,
        KatiMeyve
    }

    enum VitaminA
    {
        Portakal = 225,
        Mandalina = 681,
        Greyfurt = 3,
        Elma = 54,
        Armut = 25,
        Cilek = 12,
    }

    enum VitaminC
    {
        Portakal = 45,
        Mandalina = 26,
        Greyfurt = 44,
        Elma = 5,
        Armut = 5,
        Cilek = 60,
    }

    public interface ISuyuCikarilabilen
    {
        Cesit Cesit { get;}
        Tip Tip { get;}
        PictureBox PictureBox { get; set; }
        int Agirlik { get;}
        int VitaminA { get; }
        int VitaminC { get; }

    }

    public interface ISikacak
    {
        PictureBox PictureBox { get; set; }

        void SuyunuCikar(ISuyuCikarilabilen suyuCikarilabilen, BilgiKutusu bilgiKutusu);
    }
}
