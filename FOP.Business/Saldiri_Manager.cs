using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOP.Entities;
using FOP.Entities.Karakter_Sınıfları;
using FOP.Entities.Düsman;

namespace FOP.Business
{
    public class Saldiri_Manager
    {
        private Random rnd = new Random();

        public void DuzSaldiriYap(Karakterler saldirgan, DüsmanOzellikleri hedef)
        {
            bool kritikMi = false;
            int vurulacakHasar = saldirgan.SaldırıGücü;

            // Kritik İhtimali Hesaplama
            if (rnd.NextDouble() <= saldirgan.KiritikSansi)
            {
                kritikMi = true;
                vurulacakHasar *= 2;
            }

            // Savunma (Zırh) Mekaniği
            int netHasar = vurulacakHasar - hedef.SavunmaGücü;
            if (netHasar < 0) netHasar = 0; // Hasar eksiye düşmesin diye kontrol

            hedef.Can -= netHasar;

            if (kritikMi)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n*** KRİTİK VURUŞ! {hedef.İsim} adlı düşmana {netHasar} hasar verdin! (Zırhı {hedef.SavunmaGücü} hasarı emdi) ***");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"\n{hedef.İsim} adlı düşmana {netHasar} hasar verdin. (Zırhı {hedef.SavunmaGücü} hasarı emdi)");
            }
        }

        public void SavasciGucPatlamasi(Savasci savasci, DüsmanOzellikleri hedef)
        {
            savasci.OzelYetenekKullanildiMi = false; // Gücünü boşalttığı için bayrağı indiriyoruz
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[ÖFKE PATLAMASI] Savaşçı biriktirdiği güçle peş peşe 3 kez saldırıyor!");
            Console.ResetColor();

            // Peş peşe 3 kere düz saldırı metodunu çağırıyoruz
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"{i}. Vuruş:");
                DuzSaldiriYap(savasci, hedef);
            }
        }
    }
}
