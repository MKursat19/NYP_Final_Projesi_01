using FOP.DataAccess.Abstract;
using FOP.DataAccess.Concrete;
using FOP.Entities.Abstract;
using FOP.Entities.Karakter_Sınıfları;
using FOP.UI.Map_Manager.Ulus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IKarakterDAL karakterDAL = new InMemoryKarakterDAL();

            Console.Title = "Ankara'nın Karanlık Yüzü - NYP Final Projesi";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("==================================================");
            Console.WriteLine("      ANKARA'NIN KARANLIK YÜZÜNE HOŞ GELDİN!      ");
            Console.WriteLine("==================================================\n");
            Console.ResetColor();

            Console.Write("Maceracı, adın nedir? : ");
            string isim = Console.ReadLine();

            Console.WriteLine("\nHangi sınıfla savaşmak istersin?");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Savaşçı (Yüksek Can, Yakın Dövüş Ustası)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Okçu (Çevik, Hızlı ve Kritik Hasar)");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3. Büyücü (Düşük Can ama Devasa Büyü Hasarı)");
            Console.ResetColor();
            Console.Write("\nSeçiminiz (1/2/3): ");

            string sinifSecimi = Console.ReadLine();


            Karakterler oyuncu = karakterDAL.GetirKarakter();

            switch (sinifSecimi)
            {
                case "1":
                    oyuncu = new Savasci { İsim = isim };
                    break;
                case "2":
                    oyuncu = new Okcu { İsim = isim };
                    break;
                case "3":
                    oyuncu = new Buyucu { İsim = isim };
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[HATA] Yanlış tuşa bastın. Seni Savaşçı olarak atıyoruz!");
                    Console.ResetColor();
                    oyuncu = new Savasci { İsim = isim };
                    break;
            }

            Console.WriteLine($"\nSeçim yapıldı! Sınıf: {oyuncu.GetType().Name}");
            Console.WriteLine($"Ulus Meydanı'na doğru yola çıkıyorsun {oyuncu.İsim}...");

            Console.WriteLine("\nOyuna başlamak için bir tuşa bas...");
            Console.ReadKey();
            Console.Clear();

          
            Ulus_Harita anaHarita = new Ulus_Harita();
            anaHarita.HaritayiAc(oyuncu);
        }
    }
}

