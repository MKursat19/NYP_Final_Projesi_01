using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Karakter_Sınıfları
{
    public class Buyucu : Karakterler
    {
        public Buyucu()
        {
            İsim = "Büyücü";
            MaxCan = 60;
            Can = 60;
            SaldırıGücü = 30;
            SavunmaGücü = 2;
            Mana = 80;
            KiritikSansi = 0.1;
            Altin = 150;
            Xp = 0;
            
        }
    }
}
