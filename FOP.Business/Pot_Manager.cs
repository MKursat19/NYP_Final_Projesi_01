using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOP.Entities;


namespace FOP.Business
{
    public class Pot_Manager
    {
        public void CanPotuKullan(Karakterler karakter)
        {
            if (karakter.CanPotuAdedi <= 0)
            {
                //Hiçbir can potu kalmamış
                Console.WriteLine();
                return;
            }
            if (karakter.Can == karakter.MaxCan)
            {
                //Karakterin canı zaten tam
                Console.WriteLine();
                return;
            }
            karakter.CanPotuAdedi--;
            karakter.Can = Math.Min(karakter.MaxCan, karakter.Can + 50);
            //can 50 artar.
            Console.WriteLine();
          
        }

        public void ManaPotuKullan(Karakterler karakter)
        {
            if (karakter.ManaPotuAdedi <= 0)
            {
                //Hiçbir mana potu kalmamış
                Console.WriteLine();
                return;
            }
            karakter.ManaPotuAdedi--;
            karakter.Mana += 50;
            Console.WriteLine();
            // mana 50 artar
        }
    }
}
