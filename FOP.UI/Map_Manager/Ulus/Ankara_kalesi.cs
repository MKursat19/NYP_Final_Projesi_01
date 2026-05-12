using FOP.Business;
using FOP.Entities.Abstract;
using FOP.Entities.Düsman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ulus
{
    public class Ankara_kalesi : IHarita_Özellik
    {
        Savas_Manager savasManager = new Savas_Manager();

        public void MenuAc(IKarakterler oyuncu)
        {
            bool kalede = true;
            while (kalede)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== ANKARA KALESİ ===");
                Console.ResetColor();
                Console.WriteLine("1. Konak");
                Console.WriteLine("2. Avlu ");
                Console.WriteLine("3. Zindan ");
                Console.WriteLine("0. Ulus Meydanı'na Dön");
                Console.Write("Seçim: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("\nEski bir konağa girdin. Etraf sessiz ve tozlu. Tarihin kokusunu içine çektin.");
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        if (!goblinKesildi)
                        {
                            Console.WriteLine("\nAvluya adım attın! Karşına bir Goblin çıktı!");
                            Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                            Console.ReadKey();

                            Goblin goblin = new Goblin();
                            bool kazanildiMi = savasManager.SavasBaslat(oyuncu, goblin);

                            if (kazanildiMi)
                            {
                                goblinKesildi = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nAvlu artık temizlendi.");
                                Console.ResetColor();
                                Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nAvlu bomboş. Yerde yendiğin Goblin'in bedeni duruyor.");
                            Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;

                    case "3":
                        Console.Clear();
                        if (tbmmAnahtariAlindi && romaHamamiAnahtariAlindi)
                        {
                            if (!bossKesildi)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nİki anahtarı da kilide soktun. Devasa zindan kapısı gıcırdıyarak açıldı!");
                                Console.WriteLine("ULUS ZİNDAN BOSS'U KARŞINDA!");
                                Console.ResetColor();
                                Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                                Console.ReadKey();

                                UlusZindanBoss boss = new UlusZindanBoss ();
                                bool kazanildiMi = savasManager.SavasBaslat(oyuncu, boss);

                                if (kazanildiMi)
                                {
                                    bossKesildi = true;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n[TEBRİKLER!] Zindan Boss'unu yok ettin! Kızılay'a giden yol artık güvenli.");
                                    Console.ResetColor();
                                    Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nZindan artık bomboş. Devasa Boss'un cesedi yerde duruyor.");
                                Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n[KİLİTLİ] Zindanın kapısında 2 adet devasa kilit var.");
                            Console.ResetColor();
                            Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;

                    case "0":
                        kalede = false;
                        break;
                }
            }
        }
    }
}
