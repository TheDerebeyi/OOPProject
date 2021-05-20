using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Classlar.Enum
{
    public enum Cesit  //Meyvenin çeşitleri
    {
        Elma,
        Portakal,
        Armut,
        Cilek,
        Mandalina,
        Greyfurt
    };

    public enum Tip     //Meyve tioleri
    {
        Narenciye,
        KatiMeyve
    }

    public enum VitaminA        //Meyve vitamin A değerleri
    {
        Portakal = 225,
        Mandalina = 681,
        Greyfurt = 3,
        Elma = 54,
        Armut = 25,
        Cilek = 12,
    }

    public enum VitaminC            //Meyve vitamin C değerleri
    {
        Portakal = 45,
        Mandalina = 26,
        Greyfurt = 44,
        Elma = 5,
        Armut = 5,
        Cilek = 60,
    }
}
