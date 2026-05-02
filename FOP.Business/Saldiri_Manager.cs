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

          
            if (rnd.NextDouble() <= saldirgan.KiritikSansi)
            {
                kritikMi = true;
                vurulacakHasar *= 2;
            }

         
            int netHasar = vurulacakHasar - hedef.SavunmaGücü;
            if (netHasar < 0) netHasar = 0;

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
           
            savasci.OzelYetenekKullanildiMi = false;

          
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[ÖFKE PATLAMASI] Savaşçı biriktirdiği gücü serbest bırakıyor! Peş peşe 3 ölümcül darbe!");
            Console.ResetColor();

          
            for (int i = 1; i <= 3; i++)
            {
               
                if (hedef.Can <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"* {hedef.İsim} parçalandı! {i}. vuruşa gerek kalmadı. *");
                    Console.ResetColor();
                    break;
                }

                Console.Write($"\n{i}. Darbe: ");
                DuzSaldiriYap(savasci, hedef);
            }
        }
    }
}
