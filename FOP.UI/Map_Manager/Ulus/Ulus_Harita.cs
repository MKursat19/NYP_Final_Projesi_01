using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ulus
{
    public class Ulus_Harita : IHarita_Özellik
    {
        public void HaritayiAc(Karakterler oyuncu)
        {
            while (MaceraDevamEdiyor)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n================ HARİTA ================");
                Console.ResetColor();
                Console.WriteLine("Şu an bulunduğun bölge: ULUS");
                Console.WriteLine("1. Ankara Kalesi");
                Console.WriteLine("2. Roma Hamamı");
                Console.WriteLine("3. I. TBMM Binası");

               
                if (bossKesildi)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("4. Kızılay (AÇIK)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("4. Kızılay (KAPALI - Ulus Zindanı'ndaki tehlikeyi temizlemeden buraya geçemezsin!)");
                    Console.ResetColor();
                }

                Console.WriteLine("5. Karakter Durumu (İstatistikleri Gör)");
                Console.WriteLine("0. Oyunu Kapat");
                Console.Write("\nNereye gitmek istiyorsun? Seçim: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Ankara_kalesi kale = new Ankara_kalesi();
                        kale.MenuAc(oyuncu); 
                        break;
                    case "2":
                        Roma_Hamami hamam = new Roma_Hamami();
                        hamam.MenuAc(oyuncu);
                        break;
                    case "3":
                        Tbmm_Menusu tbmm = new Tbmm_Menusu();
                        tbmm.MenuAc(oyuncu); 
                        break;
                    case "4":
                        if (bossKesildi)
                        {
                            Console.Clear();
                            Console.WriteLine("\nKızılay Meydanı'na adım attın... ");
                            Console.WriteLine("Devam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\n[HATA] Kızılay yolu şu an kapalı! Önce Kale Zindanı'ndaki Boss'u yenmelisin.");
                            Console.WriteLine("Devam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        
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

