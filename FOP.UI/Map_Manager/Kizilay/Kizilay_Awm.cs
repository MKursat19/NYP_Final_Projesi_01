using FOP.Business;
using FOP.Entities.Abstract;
using FOP.Entities.Düsman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Kizilay
{
    public class Kizilay_Awm : IHarita_Özellik
    {
        XP_Manager xpManager = new XP_Manager();

        public void MenuAc(Karakterler oyuncu)
        {
            bool avmde = true;
            while (avmde)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== KIZILAY AVM ===");
                Console.ResetColor();

                if (!AvmBuyusuKalkti)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("İçeri adım attığın an kapılar arkandan kilitlendi!");
                    Console.WriteLine("Etraftaki mağazalar birbirine karışıyor, duvarlar yer değiştiriyor...");
                    Console.WriteLine("Korkunç bir illüzyonun, devasa bir labirentin içindesin!");
                    Console.ResetColor();

                    Console.WriteLine("\n1. Karanlık Koridorlara Gir (Labirenti Çöz)");
                    Console.WriteLine("0. Camı Kırıp Kaçmaya Çalış (Kızılay'a Dön)");
                    Console.Write("Seçim: ");

                    string secim = Console.ReadLine();
                    switch (secim)
                    {
                        case "1":
                         
                            Labirent_Menusu labirent = new Labirent_Menusu();
                            labirent.OyunuBaslat(oyuncu);
                            break;
                        case "0":
                            avmde = false;
                            break;
                        default:
                            Console.WriteLine("Geçersiz seçim.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Büyü kalktı! AVM artık sessiz ve güvenli. Mağazaları gezebilirsin.");
                    Console.WriteLine("1. Teknoloji Mağazası ");
                    Console.WriteLine("2. Yemek Katı ");
                    Console.WriteLine("3. Giyim Mağazası ");
                    Console.WriteLine("0. Kızılay Meydanı'na Dön");
                    Console.Write("Seçim: ");

                    string secim = Console.ReadLine();
                    switch (secim)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("\n[KEŞİF] Teknoloji mağazasının tozlu rafları arasında dolaşıyorsun...");

                            if (!teknolojiMagazasiGezildi)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Etraftaki eski devre kartlarını ve teknolojik donanımları incelemek sana yeni bir bakış açısı kazandırdı!");
                                Console.ResetColor();

                                xpManager.XpKazan(oyuncu, 50);
                                teknolojiMagazasiGezildi = true;
                            }
                            else
                            {
                                Console.WriteLine("Burası artık tanıdık geliyor. İşe yarar her şeyi daha önce incelemiştin.");
                            }

                            Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("\nYemek katında bozulmuş bir konserve buldun ");
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.WriteLine("\nGiyim mağazası darmadağın... İşe yarar bir şey yok.");
                            Console.ReadKey();
                            break;
                        case "0":
                            avmde = false;
                            break;
                        default:
                            Console.WriteLine("Geçersiz seçim.");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
}
