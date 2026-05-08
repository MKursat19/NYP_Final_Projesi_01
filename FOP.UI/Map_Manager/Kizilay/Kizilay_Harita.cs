using FOP.Entities;
using FOP.UI.Map_Manager.Ulus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Kizilay
{
    public class Kizilay_Harita : IHarita_Özellik
    {
        public void HaritayiAc(Karakterler oyuncu)
        {
            while (MaceraDevamEdiyor)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n================ HARİTA ================");
                Console.ResetColor();
                Console.WriteLine("Şu an bulunduğun bölge: KIZILAY");
                Console.WriteLine("1. Büyülü Fener Sineması");
                Console.WriteLine("2. Gama İş Merkezi");
                Console.WriteLine("3. Kızılay Awm");
                Console.WriteLine("4. Karakter Durumu (İstatistikleri Gör)");
                Console.WriteLine("0. Oyunu Kapat");
                Console.Write("\nNereye gitmek istiyorsun? Seçim: ");

                string secim = Console.ReadLine();

                switch (secim)
                { 
                    case "1":
                        // Büyülü Fener Sineması'na git
                        break;
                    case "2":
                        // Gama İş Merkezi'ne git
                        break;
                    case "3":
                        // Kızılay Awm'ye git
                        break;
                    case "4":

                        Karakter_Bilgileri karakterBilgileri = new Karakter_Bilgileri();
                        karakterBilgileri.MenuAc(oyuncu);
                        break;
                    case "0":
                        MaceraDevamEdiyor = false;
                        Console.WriteLine("\nOyundan çıkılıyor...");
                        break;
                    default:
                        Console.WriteLine("\nGeçersiz seçim! Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
