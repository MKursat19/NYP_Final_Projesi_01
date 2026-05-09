using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Abstract
{
    public abstract class IHarita_Özellik
    {
        public static bool tbmmAnahtariAlindi = false;
        public static bool romaHamamiAnahtariAlindi = false;
        public static bool bossKesildi = false;
        public static bool goblinKesildi = false;
        public static bool iskeletKesildi = false;
        public static bool zombiKesildi = false;
        public static bool MaceraDevamEdiyor = true;
        public static bool AvmBuyusuKalkti = false;
        public static bool teknolojiMagazasiGezildi = false;
        public static bool gamaTemizlendi = false;
        public static bool gamaKasaAcildi = false;
    }
}
