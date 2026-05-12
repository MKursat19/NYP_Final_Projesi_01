using FOP.Business;
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
    public class Gama_Is_Merkezi : IHarita_Özellik
    {
        public void MenuAc(IKarakterler oyuncu)
        {
            bool gamada = true;
            while (gamada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== GAMA İŞ MERKEZİ ===");
                Console.ResetColor();
                Console.WriteLine("Lobi darmadağın... Gökdelenin tepesine çıkan merdivenler ve karanlığa gömülmüş bir asansör var.");

                Console.WriteLine("\n1. En Üst Kat: Yönetici Ofisi ");

                if (gamaBossKesildi)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("2. -1. Kat: Gizli Arşiv ve Laboratuvar (AÇILDI)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("2. -1. Kat: ( - KİLİTLİ - )");
                    Console.ResetColor();
                }

                Console.WriteLine("0. Kızılay Meydanı'na Dön");
                Console.Write("\nSeçiminiz: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        
                        Yonetici_Ofisi ofis = new Yonetici_Ofisi();
                        ofis.MenuAc(oyuncu);
                        break;
                    case "2":
                        if (gamaBossKesildi)
                        {
                            
                            Gizli_Alt_Kat altKat = new Gizli_Alt_Kat();
                            altKat.MenuAc(oyuncu);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n[HATA] Asansör çalışmıyor. Bir yetki kartına ihtiyacın var!");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        gamada = false;
                        break;
                    default:
                        Console.WriteLine("\nGeçersiz seçim!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

