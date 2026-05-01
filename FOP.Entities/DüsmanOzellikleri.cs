using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities
{
    public class DüsmanOzellikleri : Karakter_Base
    {
        public int YanmaSuresi { get; set; }
        public DüsmanOzellikleri(string isim, int maxCan, int SaldıGucu, double kritikSansi, int dusenXp)
        {
            İsim = isim;
            MaxCan = maxCan;
            Can = maxCan;
            SaldırıGücü = SaldıGucu;
            KiritikSansi = kritikSansi;
            Xp = dusenXp;
            YanmaSuresi = 0;
            SavunmaGücü = 0;
            Mana = 0;
        }
    }
}
