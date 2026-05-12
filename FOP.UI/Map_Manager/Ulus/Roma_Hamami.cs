using FOP.Business;
using FOP.Entities.Abstract;
using FOP.Entities.Düsman;
using FOP.Entities.Karakter_Sınıfları;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ulus
{
    public class Roma_Hamami : IHarita_Özellik
    {
       Savas_Manager savasManager = new Savas_Manager();

        public void MenuAc(IKarakterler oyuncu)
        {
            bool hamamda = true;
            while (hamamda)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== ROMA HAMAMI ===");
                Console.ResetColor();
                Console.WriteLine("1. Palaestra (Antrenman Alanı)");
                Console.WriteLine("2. Hamam Kısmı");
                Console.WriteLine("3. Yazıt ");
                Console.WriteLine("0. Ulus Meydanı'na Dön");
                Console.Write("Seçim: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Console.Clear();
                        if (!romaHamamiAnahtariAlindi)
                        {
                            romaHamamiAnahtariAlindi = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nPalaestra'nın yıkıntıları arasında parlayan bir şey buldun: ROMA HAMAMI ANAHTARI'nı aldın!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nBurası boş bir antrenman alanı. Anahtarı zaten buradan almıştın.");
                        }
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nEski hamam kısmındasın. Etraf hafif nemli ve çok sessiz...");
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        if (!iskeletKesildi)
                        {
                            Console.WriteLine("\nAntik yazıtları incelerken yer altından bir İskelet fırladı!");
                            Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                            Console.ReadKey();

                            Iskelet iskelet = new Iskelet ();
                            bool kazanildiMi = savasManager.SavasBaslat(oyuncu, iskelet);

                            if (kazanildiMi)
                            {
                                iskeletKesildi = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYazıtların etrafı artık güvenli.");
                                Console.ResetColor();

                                if (!oyuncu.OzelYetenekAcildiMi)
                                {
                                    oyuncu.OzelYetenekAcildiMi = true;

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("\n[GİZEMLİ GÜÇ UYANDI!]");
                                    Console.WriteLine("Düşmanı alt ettikten sonra antik yazıtların üzerindeki rünler parlamaya başladı...");
                                    Console.WriteLine("Bedenine tarifsiz bir enerji akın ediyor!");

                                    if (oyuncu is Savasci)
                                        Console.WriteLine(">> Artık savaşlarda 'Öfke Patlaması (Odaklanma)' yeteneğini kullanabilirsin!");
                                    else if (oyuncu is Okcu)
                                        Console.WriteLine(">> Artık savaşlarda 'Hançer ve Ok' kombosunu kullanabilirsin!");
                                    else if (oyuncu is Buyucu)
                                        Console.WriteLine(">> Artık savaşlarda 'Alev Topu' büyüsünü kullanabilirsin!");

                                    Console.ResetColor();
                                }

                                Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nYazıtların orası güvenli. İskelet parçalanmış halde yerde yatıyor.");
                            Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;

                    case "0":
                        hamamda = false;
                        break;
                }
            }
        }
    }
}
