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
            Application.Run(new formVitaminDeposu());
        }
    }

    enum Meyveler
    {
        Elma,
        Portakal,
        Armut,
        Cilek,
        Mandalina,
        Greyfurt
    };

    enum Tip
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

    interface IMeyve
    {
        public Meyveler MeyveCesidi { get; set; }
        public Tip MeyveTipi { get; set; }

        public PictureBox PictureBox { get; set; }
        public int Agirlik { get; set; }
        public abstract int VitaminA();
        public abstract int VitaminC();

    }

    interface ISikacak
    {
        public PictureBox PictureBox { get; set; }
    }
}
