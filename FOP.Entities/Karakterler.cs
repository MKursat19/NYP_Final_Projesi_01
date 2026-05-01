using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities
{
    public class Karakterler : Karakter_Base
    {
        public int Altin { get; set; }
        public int CanPotuAdedi { get; set; }
        public int ManaPotuAdedi { get; set; }
        public int Seviye { get; set; } = 1;
        public int MaxXP { get; set; } = 100;
        public bool OzelYetenekKullanildiMi { get; set; } = false;
    }

}
