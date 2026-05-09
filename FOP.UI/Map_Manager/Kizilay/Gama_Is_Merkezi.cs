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
    public class Gama_Is_Merkezi : IHarita_Özellik
    {
        Savas_Manager Savas_Manager = new Savas_Manager();
        XP_Manager xpManager = new XP_Manager();

        public void MenuAc(Karakterler oyuncu)
        {
            bool gamada = true;
            while (gamada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== GAMA İŞ MERKEZİ ===");
                Console.ResetColor();
                Console.WriteLine("Devasa gökdelenin alt katındasın. Etraf kırık camlar ve devrilmiş turnikelerle dolu.");
                Console.WriteLine("Asansörler çalışmıyor. Yukarı çıkmanın tek yolu karanlık yangın merdivenleri...");

                Console.WriteLine("\n1. Yangın Merdivenlerinden Üst Katlara Çık");
                Console.WriteLine("2. Danışma Masasını Ara ");
                Console.WriteLine("0. Kızılay Meydanı'na Dön");
                Console.Write("Seçim: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Console.Clear();
                        if (!gamaTemizlendi)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Karanlık merdivenleri ağır ağır çıkarken üstüne bir gölge atladı!");
                            Console.WriteLine("Takım elbiseli, gözleri parlayan bir Plaza Zombisi sana saldırıyor!");
                            Console.ResetColor();
                            Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                            Console.ReadKey();

                            Zombi zombi = new Zombi();
                            bool kazanildiMi = Savas_Manager.SavasBaslat(oyuncu, zombi);

                            if (kazanildiMi)
                            {
                                gamaTemizlendi = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nZombiyi merdiven boşluğundan aşağı ittin! Yol artık güvenli.");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Merdivenlerde yendiğin zombinin kalıntıları duruyor. En üst kata çıktın.");
                            Console.WriteLine("Yönetici ofisine girdin...");

                            if (!gamaKasaAcildi)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n[BÜYÜK ÖDÜL] Duvardaki gizli kasayı açmayı başardın!");
                                Console.WriteLine("İçinden 'Gama Titanyum Zırhı' (Savunma +10) ve 200 Altın çıktı!");
                                Console.ResetColor();

                                oyuncu.SavunmaGücü += 10;
                                oyuncu.Altin += 200;
                                xpManager.XpKazan(oyuncu, 100); 

                                gamaKasaAcildi = true;
                            }
                            else
                            {
                                Console.WriteLine("\nKasayı zaten boşaltmıştın. Ofiste bakılacak başka bir şey kalmadı.");
                            }
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Danışma masasının arkasındaki çekmeceleri karıştırdın...");
                        Console.WriteLine("Biraz tozlu kağıt ve kırık bir telefon dışında işe yarar hiçbir şey yok.");
                        Console.ReadKey();
                        break;

                    case "0":
                        gamada = false;
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

