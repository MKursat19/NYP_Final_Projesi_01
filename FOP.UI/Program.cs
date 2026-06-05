using FOP.Business;
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
    class Program
    {
        static void Main(string[] args)
        {

            OyunKayitManager kayitManager = new OyunKayitManager(new JsonOyunKayitDal());
            IKarakterDAL karakterDAL = new InMemoryKarakterDAL();

            Console.Title = "Ankara'nın Karanlık Yüzü - NYP Final Projesi";

            bool anaMenu = true;
            while (anaMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("==================================================");
                Console.WriteLine("      ANKARA'NIN KARANLIK YÜZÜNE HOŞ GELDİN!      ");
                Console.WriteLine("==================================================\n");
                Console.ResetColor();

                Console.WriteLine("1. Yeni Oyun (Maceraya Sıfırdan Başla)");
                Console.WriteLine("2. Oyunu Yükle (Harita İlerlemesini Geri Getir)");
                Console.WriteLine("0. Çıkış");
                Console.Write("\nSeçiminiz: ");

                string anaSecim = Console.ReadLine();

                if (anaSecim == "0")
                {
                    anaMenu = false;
                    continue;
                }

                if (anaSecim == "2")
                {
                    var yuklemeSonucu = kayitManager.OyunuYukle();
                    if (yuklemeSonucu.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n[BİLGİ] " + yuklemeSonucu.Message);
                        Console.WriteLine("Kayıtlı harita verileri yüklendi. Şimdi karakterini oluşturup devam etmelisin.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n[HATA] " + yuklemeSonucu.Message);
                    }
                    Console.ResetColor();
                }
                else if (anaSecim != "1")
                {
                    Console.WriteLine("\nGeçersiz seçim yaptın!");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("\nMaceracı, adın nedir? : ");
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
}

