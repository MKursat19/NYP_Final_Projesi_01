using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities
{
    public abstract class Karakter_Base
    {
        public string İsim { get; set; }
        public int Can { get; set; }
        public int MaxCan { get; set; }
        public int Mana { get; set; }
        public int xp { get; set; }
        public int SaldırıGücü { get; set; }
        public int SavunmaGücü { get; set; }

    }
}
