using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Abstract
{
    public  class Karakterler 
    {
        public int Altin { get; set; }
        public int CanPotuAdedi { get; set; }
        public int ManaPotuAdedi { get; set; }
        public int Seviye { get; set; } = 1;
        public int MaxXP { get; set; } = 100;
        public bool OzelYetenekKullanildiMi { get; set; } = false;
        public int SilahSeviyesi { get; set; } = 1;
        public bool OzelYetenekAcildiMi { get; set; } = false;
        public string İsim { get; set; }
        public int Can { get; set; }
        public int MaxCan { get; set; }
        public int Mana { get; set; }
        public int Xp { get; set; }
        public int SaldırıGücü { get; set; }
        public int SavunmaGücü { get; set; }
        public double KiritikSansi { get; set; }
    }

}
