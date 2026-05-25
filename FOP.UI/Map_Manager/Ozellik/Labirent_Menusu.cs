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
    public class Labirent_Menusu : IHarita_Özellik
    {
        Savas_Manager savasManager = new Savas_Manager();
        XP_Manager xpManager = new XP_Manager();
        Labirent_Manager labirentManager = new Labirent_Manager();

        public void OyunuBaslat(Karakterler oyuncu)
        {
            int asama = 1;
            bool labirentte = true;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== AVM LABİRENTİ BAŞLIYOR ===");
            Console.ResetColor();
            Console.WriteLine("Doğru yolları seçerek illüzyonun merkezine ulaşmalısın. Yanlış yollar seni başa döndürür!");
            Console.ReadKey();

            while (labirentte && !AvmBuyusuKalkti)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[Aşama {asama}/3]");
                Console.ResetColor();

                string secim = "";

                if (asama == 1)
                {
                    Console.WriteLine("Karşına iki yürüyen merdiven çıktı. Hangisine bineceksin?");
                    Console.WriteLine("1. Yukarı Çıkan Merdiven");
                    Console.WriteLine("2. Aşağı İnen Merdiven");
                    Console.Write("Seçim: ");
                    secim = Console.ReadLine();
                }
                else if (asama == 2)
                {
                    Console.WriteLine("Koridorun sonunda üç farklı mağaza kapısı var. Hangisinden geçeceksin?");
                    Console.WriteLine("1. Oyuncakçı");
                    Console.WriteLine("2. Sinema Salonu Girişi");
                    Console.WriteLine("3. Aynalı Berber Dükkanı");
                    Console.Write("Seçim: ");
                    secim = Console.ReadLine();
                }
                else if (asama == 3)
                {
                    Console.WriteLine("Büyük, altın işlemeli bir kapının önüne geldin. İçeriden tuhaf fısıltılar geliyor.");
                    Console.WriteLine("Kapıyı açmaya hazır mısın?");
                    Console.WriteLine("1. Kapıyı Tekmeyle Kır ve İçeri Dal!");
                    Console.WriteLine("2. Kapıyı yavaşça aralayıp gizlice içeri bakmaya çalış.");
                    Console.WriteLine("3. Bu sesler hiç tekin değil, geri dönüp başka yol ara.");
                    Console.Write("Seçim: ");
                    secim = Console.ReadLine();
                }


                bool dogruMu = labirentManager.CevapDogruMu(asama, secim);

                if (dogruMu)
                {
                    if (asama == 1) Console.WriteLine("\nDoğru yol! Merdiven seni karanlık bir koridora indirdi.");
                    else if (asama == 2) Console.WriteLine("\nAynaların içinden geçerek gizli bir geçit buldun!");

                    if (asama == 3)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("İllüzyonların kaynağı olan Labirent Büyücüsü havada süzülerek sana bakıyor!");
                        Console.ResetColor();
                        Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                        Console.ReadKey();

                        Kızılay_Awm_Boss buyucu = new Kızılay_Awm_Boss();
                        bool kazanildiMi = savasManager.SavasBaslat(oyuncu, buyucu);

                        if (kazanildiMi)
                        {
                            AvmBuyusuKalkti = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n[İLLÜZYON BOZULDU!] Büyücünün asası yere düşüp parçalandı.");
                            Console.WriteLine("Duvarlar titredi, mağazalar gerçek yerlerine döndü. Kızılay AVM artık güvende!");
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n[GÖREV TAMAMLANDI] İllüzyonu kırdığın için kadim bir tecrübe kazandın!");
                            Console.ResetColor();

                            xpManager.XpKazan(oyuncu, 150);
                            oyuncu.Altin += 100;
                            Console.WriteLine("+ 100 Altın buldun!");
                        }
                        labirentte = false;
                    }
                    else
                    {
                        asama++;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYanlış seçim! Karanlık seni yuttu ve kendini tekrar girişte buldun.");
                    Console.ResetColor();
                    asama = 1;
                }

                Console.ReadKey();
            }
        }
    }

}

