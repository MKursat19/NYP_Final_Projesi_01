using FOP.Entities.Abstract;
using FOP.Entities.Düsman;
using FOP.UI.Map_Manager.Ozellik;
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
                        Buyulu_Fener_Sinemasi buyulu_Fener_Sinemasi = new Buyulu_Fener_Sinemasi();
                        buyulu_Fener_Sinemasi.MenuAc(oyuncu);
                        break;
                    case "2":
                       Gama_Is_Merkezi gama_Is_Merkezi = new Gama_Is_Merkezi();
                        gama_Is_Merkezi.MenuAc(oyuncu);
                        break;
                    case "3":
                        Kizilay_Awm kizilay_Awm = new Kizilay_Awm();
                        kizilay_Awm.MenuAc(oyuncu);
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
