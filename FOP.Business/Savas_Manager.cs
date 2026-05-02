using FOP.Entities;
using FOP.Entities.Karakter_Sınıfları;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Business
{
    public class Savas_Manager
    {
        Saldiri_Manager saldiriManager = new Saldiri_Manager();
        Yetenek_Manager yetenekManager = new Yetenek_Manager();
        Pot_Manager potManager = new Pot_Manager();
        XP_Manager xpManager = new XP_Manager();

        public bool SavasBaslat(Karakterler oyuncu, DüsmanOzellikleri dusman)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n!!! DÜŞMANLA KARŞILAŞTIN: {dusman.İsim.ToUpper()} !!!\n");
            Console.ResetColor();

            while (oyuncu.Can > 0 && dusman.Can > 0)
            {
                Console.WriteLine("==================================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[SEN] Can: {oyuncu.Can}/{oyuncu.MaxCan} | Mana: {oyuncu.Mana} | Potlar(Can/Mana): {oyuncu.CanPotuAdedi}/{oyuncu.ManaPotuAdedi}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{dusman.İsim.ToUpper()}] Can: {dusman.Can}");
                Console.ResetColor();
                Console.WriteLine("==================================================");

                bool turGecti = false;

                
                if (oyuncu is Savasci s && s.OzelYetenekKullanildiMi)
                {
                    Console.WriteLine("\n[SİSTEM] Savaşçı gücünü topladı ve saldırıya geçiyor!");

                   
                    saldiriManager.SavasciGucPatlamasi(s, dusman);
                    turGecti = true;

                    Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                   
                    Console.WriteLine("1. Düz Saldırı Yap");

                  
                    if (oyuncu.OzelYetenekAcildiMi)
                        Console.WriteLine("2. Özel Yetenek Kullan");
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("2. Özel Yetenek Kullan (KİLİTLİ - Gücünü Uyandırman Gerek)");
                    Console.ResetColor();

                    Console.WriteLine("3. Can Potu İç");
                    Console.WriteLine("4. Mana Potu İç");
                    Console.Write("Hamlen nedir? Seçim: ");

                    string secim = Console.ReadLine();
                    Console.Clear();

                    switch (secim)
                    {
                        case "1":
                            saldiriManager.DuzSaldiriYap(oyuncu, dusman);
                            turGecti = true;
                            break;
                        case "2":
                           
                            if (oyuncu.OzelYetenekAcildiMi)
                            {
                                turGecti = yetenekManager.OzelYetenekKullan(oyuncu, dusman, saldiriManager);
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n[KİLİTLİ] İçindeki kadim gücü henüz uyandıramadın! (Bunun için Roma Hamamı'ndaki yazıtları incelemelisin)");
                                Console.ResetColor();
                                turGecti = false; 
                            }
                            break;
                        case "3":
                            potManager.CanPotuKullan(oyuncu);
                            turGecti = true;
                            break;
                        case "4":
                            potManager.ManaPotuKullan(oyuncu);
                            turGecti = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Yanlış tuşa bastın, elin ayağına dolaştı ve sıranı kaybettin!");
                            Console.ResetColor();
                            turGecti = true;
                            break;
                    }
                }

             
                if (dusman.Can > 0 && turGecti)
                {
                    
                    if (dusman.YanmaSuresi > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n* {dusman.İsim} alevler içinde yanmaya devam ediyor! (10 Hasar) *");
                        dusman.Can -= 10;
                        dusman.YanmaSuresi--;
                        Console.ResetColor();
                    }

                   
                    if (dusman.Can > 0)
                    {
                        DusmanSaldırısı(dusman, oyuncu);
                    }
                }
            }

         
            if (oyuncu.Can > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n[ZAFER] {dusman.İsim} adlı düşmanı alt ettin!");
                Console.ResetColor();

                int kazanilanAltin = new Random().Next(20, 50);
                int kazanilanXp = new Random().Next(30, 60);

                oyuncu.Altin += kazanilanAltin;
                Console.WriteLine($"+ {kazanilanAltin} Altın kazandın! (Toplam Altın: {oyuncu.Altin})");
                xpManager.XpKazan(oyuncu, kazanilanXp);

                Console.WriteLine("\nHaritaya dönmek için bir tuşa bas...");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DusmanSaldırısı(DüsmanOzellikleri dusman, Karakterler oyuncu)
        {
            
            int netHasar = dusman.SaldırıGücü - oyuncu.SavunmaGücü;
            if (netHasar < 0) netHasar = 0;

            oyuncu.Can -= netHasar;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n[DÜŞMAN] {dusman.İsim} sana saldırdı ve {netHasar} hasar verdi! (Zırhın {oyuncu.SavunmaGücü} hasarı emdi)");
            Console.ResetColor();
        }
    }
}
