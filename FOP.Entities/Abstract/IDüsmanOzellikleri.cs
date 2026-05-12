using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Abstract
{
    public abstract class IDüsmanOzellikleri : IKarakterler
    {
        public int YanmaSuresi { get; set; }
        public IDüsmanOzellikleri(string isim, int maxCan, int SaldırıGucu, double kiritikSansi, int dusenXp)
        {
            İsim = isim;
            MaxCan = maxCan;
            Can = maxCan;
            SaldırıGücü = SaldırıGucu;
            KiritikSansi = kiritikSansi;
            Xp = dusenXp;
            YanmaSuresi = 0;
            SavunmaGücü = 0;
            Mana = 0;
        }
    }
}
