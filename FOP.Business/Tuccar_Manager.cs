using FOP.Entities;
using FOP.Entities.Karakter_Sınıfları;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Business
{
    public class Tuccar_Manager
    {
        private int canPotuFiyati = 40;
        private int manaPotuFiyati = 40;

        public void CanPotuSatinAl(Karakterler karakter)
        {
            if (karakter.Altin >= canPotuFiyati)
            {
                karakter.Altin -= canPotuFiyati;
                karakter.CanPotuAdedi++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[TÜCCAR] -> Başarıyla 1 adet Can Potu satın aldın!");
                Console.WriteLine($"Güncel Can Potu: {karakter.CanPotuAdedi} | Kalan Altın: {karakter.Altin}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[TÜCCAR] -> Yeterli altının yok! (Gereken Altın: {canPotuFiyati})");
                Console.ResetColor();
            }
        }

        public void ManaPotuSatinAl(Karakterler karakter)
        {
            if (karakter.Altin >= manaPotuFiyati)
            {
                karakter.Altin -= manaPotuFiyati;
                karakter.ManaPotuAdedi++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[TÜCCAR] -> Başarıyla 1 adet Mana Potu satın aldın!");
                Console.WriteLine($"Güncel Mana Potu: {karakter.ManaPotuAdedi} | Kalan Altın: {karakter.Altin}, Sende Olan: {karakter.Altin}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[TÜCCAR] -> Yeterli altının yok! (Gereken Altın: {manaPotuFiyati}, Sende Olan: {karakter.Altin})");
                Console.ResetColor();
            }
        }

        public void YeniEkipmanSatinAl(Karakterler karakter)
        {
           
            int yeniEkipmanFiyati = karakter.SilahSeviyesi * 100;

            if (karakter.Altin >= yeniEkipmanFiyati)
            {
                karakter.Altin -= yeniEkipmanFiyati;
                karakter.SilahSeviyesi++;
                karakter.SaldırıGücü += 10; 

               
                if (karakter is Savasci)
                {
                    Console.WriteLine("Tüccar sana daha keskin, çelik bir Kılıç ve ağır bir Zırh verdi.");
                }
                else if (karakter is Okcu)
                {
                    Console.WriteLine("Tüccar sana menzili daha uzun bir Yay ve zırh delici Oklar verdi.");
                }
                else if (karakter is Buyucu)
                {
                    Console.WriteLine("Tüccar sana ucu parlayan kadim bir Asa ve yeni bir Büyücü Cübbesi verdi.");
                }

                Console.WriteLine($"[BİLGİ] Yeni Ekipman Seviyesi: {karakter.SilahSeviyesi}");
                Console.WriteLine($"[BİLGİ] Yeni Saldırı Gücün: {karakter.SaldırıGücü} | Kalan Altının: {karakter.Altin}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[TÜCCAR] -> Yeterli altının yok! (Gereken Altın: {yeniEkipmanFiyati}, Sende Olan: {karakter.Altin})");
                Console.ResetColor();
            }
        }
    }
}
