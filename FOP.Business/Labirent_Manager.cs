using FOP.Entities;
using FOP.Entities.Düsman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Business
{
    public class Labirent_Manager 
    {
        /// <summary>
        /// Oyuncunun verdiği cevabın o aşama için doğru olup olmadığını kontrol eden metot
        /// </summary>
        /// <param name="asama">Kontrol edilecek aşama numarası
        /// <param name="cevap">Oyuncunun verdiği cevap
        
        public bool CevapDogruMu(int asama, string cevap)
        {
            // 1. Aşamanın doğru cevabı: 2 (Aşağı İnen Merdiven)
            if (asama == 1 && cevap == "2")
                return true;

            // 2. Aşamanın doğru cevabı: 3 (Aynalı Berber Dükkanı)
            else if (asama == 2 && cevap == "3")
                return true;

            // 3. Aşamanın doğru cevabı: 1 (Kapıyı Kır)
            else if (asama == 3 && cevap == "1")
                return true;

            // Eğer cevap bunlardan biri değilse yanlıştır
            return false;
        }
    }
}
