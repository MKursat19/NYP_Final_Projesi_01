using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Karakter_Sınıfları
{
    public class Savasci : Karakterler  
    {
        public Savasci()
        {
            İsim = "Savaşçı";
            MaxCan = 100;
            Can = 100;
            SaldırıGücü = 18;
            SavunmaGücü = 5;
            Mana = 50;
            KiritikSansi = 0.2;
            Altin = 150;
            Xp = 0;
        }
    }
}
