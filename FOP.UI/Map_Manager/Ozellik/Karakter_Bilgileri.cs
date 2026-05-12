using FOP.Business;
using FOP.Entities.Abstract;
using FOP.Entities.Karakter_Sınıfları;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ozellik
{
    public class Karakter_Bilgileri
    {
        Pot_Manager potManager = new Pot_Manager();
        

        public void MenuAc(IKarakterler oyuncu)
        {
            bool menude = true;
            while (menude)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n=== KARAKTER DURUMU VE ÇANTA ===");
                Console.ResetColor();
                Console.WriteLine($"İsim: {oyuncu.İsim} (Seviye {oyuncu.Seviye})");
                Console.WriteLine($"Sınıf: {oyuncu.GetType().Name}");
                Console.WriteLine($"Can: {oyuncu.Can} / {oyuncu.MaxCan}");
                Console.WriteLine($"Mana: {oyuncu.Mana}");
                Console.WriteLine($"Saldırı Gücü: {oyuncu.SaldırıGücü} (Silah Seviyesi: {oyuncu.SilahSeviyesi})");
                Console.WriteLine($"Savunma Gücü: {oyuncu.SavunmaGücü}");
                Console.WriteLine($"Kritik Şansı: %{oyuncu.KiritikSansi * 100}");
                Console.WriteLine($"XP: {oyuncu.Xp} / {oyuncu.MaxXP}");
                Console.WriteLine($"Altın: {oyuncu.Altin}");
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Can Potu: {oyuncu.CanPotuAdedi}");
                Console.WriteLine($"Mana Potu: {oyuncu.ManaPotuAdedi}");
                Console.WriteLine("===============================");

                Console.WriteLine("1. Can Potu İç");
                Console.WriteLine("2. Mana Potu İç");
                Console.WriteLine("0. Haritaya Dön");
                Console.Write("\nSeçim: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        potManager.CanPotuKullan(oyuncu);
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "2":
                        potManager.ManaPotuKullan(oyuncu);
                        Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "0":
                        menude = false;
                        break;
                    default:
                        Console.WriteLine("\nGeçersiz seçim.");
                        Console.WriteLine("Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
