using FOP.Business;
using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ulus
{
    public class Tuccar_Menusu
    {
        Tuccar_Manager tuccarManager = new Tuccar_Manager();
        public void MenuAc(Karakterler oyuncu)
        {
            bool dukkandaMi = true;
            while (dukkandaMi)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=== GİZEMLİ TÜCCAR ===");
                Console.ResetColor();
                Console.WriteLine($"Altının: {oyuncu.Altin} | Can Potu: {oyuncu.CanPotuAdedi} | Mana Potu: {oyuncu.ManaPotuAdedi} | Silah Seviyesi: {oyuncu.SilahSeviyesi}");
                Console.WriteLine("1. Can Potu Al (20 Altın)");
                Console.WriteLine("2. Mana Potu Al (25 Altın)");
                Console.WriteLine($"3. Yeni Ekipman Al ({oyuncu.SilahSeviyesi * 100} Altın)");
                Console.WriteLine("0. Çadırdan Çık");
                Console.Write("Seçim: ");

                string dukkanSecim = Console.ReadLine();

                switch (dukkanSecim)
                {
                    case "1":
                        tuccarManager.CanPotuSatinAl(oyuncu);
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "2":
                        tuccarManager.ManaPotuSatinAl(oyuncu);
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "3":
                        tuccarManager.YeniEkipmanSatinAl(oyuncu);
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "0":
                        dukkandaMi = false;
                        break;
                    default:
                        Console.WriteLine("\nGeçersiz seçim.");
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
