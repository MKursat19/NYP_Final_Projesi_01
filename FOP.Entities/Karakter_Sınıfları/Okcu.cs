using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Karakter_Sınıfları
{
    public class Okcu : Karakterler
    {
        public Okcu()
        {
            İsim = "Okçu";
            MaxCan = 80;
            Can = 80;
            SaldırıGücü = 16;
            SavunmaGücü = 3;
            Mana = 60;
            KiritikSansi = 0.7;
            Altin = 150;
            Xp = 0;
        }
    }
}
