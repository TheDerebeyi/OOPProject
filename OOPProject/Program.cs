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

    interface IMeyve
    {
        public Meyveler MeyveCesidi { get; set; }
        public Tip MeyveTipi { get; set; }

        public PictureBox PictureBox { get; set; }
        public int Agirlik { get; set; }

    }

    interface ISikacak
    { 
        public PictureBox PictureBox { get; set; }
    }
}
