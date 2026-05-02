using FOP.Business;
using FOP.Entities;
using FOP.Entities.Düsman;
using FOP.Entities.Karakter_Sınıfları;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI
{
    public class MapManager
    {
        Tuccar_Manager tuccarManager = new Tuccar_Manager();
        Savas_Manager savasManager = new Savas_Manager(); 
        
        private bool tbmmAnahtariAlindi = false;
        private bool romaHamamiAnahtariAlindi = false;
        private bool bossKesildi = false; 
        private bool goblinKesildi = false;
        private bool iskeletKesildi = false;
        private bool zombiKesildi = false;
        public void HaritayiAc(Karakterler oyuncu)
        {
            bool macerayaDevam = true;

            while (macerayaDevam)
            {
                Console.Clear(); 
                if (oyuncu.Can <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[OYUN BİTTİ] Karakterin öldü... Ankara karanlığa gömüldü.");
                    Console.ResetColor();
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n================ ANA HARİTA ================");
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
                        KaleMenusu(oyuncu);
                        break;
                    case "2":
                        RomaHamamiMenusu(oyuncu);
                        break;
                    case "3":
                        TBMMMenusu(oyuncu);
                        break;
                    case "4":
                        if (bossKesildi)
                            KizilayMenusu(oyuncu);
                        else
                        {
                            Console.WriteLine("\n[HATA] Kızılay yolu şu an kapalı! Önce Kale Zindanı'ndaki Boss'u yenmelisin.");
                            Console.WriteLine("Devam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        KarakterBilgileriniGoster(oyuncu);
                        break;
                    case "0":
                        macerayaDevam = false;
                        Console.WriteLine("\nOyundan çıkılıyor...");
                        break;
                    default:
                        Console.WriteLine("\nGeçersiz seçim! Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void KaleMenusu(Karakterler oyuncu)
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
                        Console.WriteLine("\nEski bir konağa girdin. Etraf sessiz...");
                        Console.WriteLine("Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        if (!goblinKesildi)
                        {
                            Console.WriteLine("\nAvluya adım attın! Karşına bir Goblin çıktı!");
                            Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                            Console.ReadKey();

                            Goblin goblin = new Goblin { İsim = "Vahşi Goblin", Can = 60, MaxCan = 60, SaldırıGücü = 15, SavunmaGücü = 2 };
                            bool kazanildiMi = savasManager.SavasBaslat(oyuncu, goblin);

                            if (kazanildiMi)
                            {
                                goblinKesildi = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nAvlu artık temizlendi.");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nAvlu bomboş. Yerde yendiğin Goblin'in bedeni duruyor.");
                            Console.WriteLine("Devam etmek için bir tuşa bas...");
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

                               
                                UlusZindanBoss boss = new UlusZindanBoss { İsim = "Dehşet Engiz Ulus Bossu", Can = 300, MaxCan = 300, SaldırıGücü = 40, SavunmaGücü = 15 };
                                bool kazanildiMi = savasManager.SavasBaslat(oyuncu, boss);

                                if (kazanildiMi)
                                {
                                    bossKesildi = true;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n[TEBRİKLER!] Zindan Boss'unu yok ettin! Kızılay'a giden yol artık güvenli.");
                                    Console.ResetColor();
                                    Console.WriteLine("Devam etmek için bir tuşa bas...");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nZindan artık bomboş. Devasa Boss'un cesedi yerde duruyor.");
                                Console.WriteLine("Devam etmek için bir tuşa bas...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n[KİLİTLİ] Zindanın kapısında 2 adet devasa kilit var.");
                            Console.ResetColor();
                            Console.WriteLine("Devam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        kalede = false;
                        break;
                }
            }
        }

        private void RomaHamamiMenusu(Karakterler oyuncu)
        {
            bool hamamda = true;
            while (hamamda)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== ROMA HAMAMI ===");
                Console.ResetColor();
                Console.WriteLine("1. Palaestra");
                Console.WriteLine("2. Hamam Kısmı");
                Console.WriteLine("3. Yazıt ");
                Console.WriteLine("0. Ulus Meydanı'na Dön");
                Console.Write("Seçim: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        if (!romaHamamiAnahtariAlindi)
                        {
                            romaHamamiAnahtariAlindi = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nPalaestra'nın yıkıntıları arasında parlayan bir şey buldun: ROMA HAMAMI ANAHTARI'nı aldın!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nBurası boş bir antrenman alanı. Anahtarı zaten buradan almıştın.");
                        }
                        Console.WriteLine("Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("\nEski hamam kısmındasın. Etraf hafif nemli...");
                        Console.WriteLine("Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        if (!iskeletKesildi)
                        {
                            Console.WriteLine("\nAntik yazıtları incelerken yer altından bir İskelet fırladı!");
                            Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                            Console.ReadKey();

                            Iskelet iskelet = new Iskelet { İsim = "Lanetli İskelet", Can = 80, MaxCan = 80, SaldırıGücü = 20, SavunmaGücü = 5 };
                            bool kazanildiMi = savasManager.SavasBaslat(oyuncu, iskelet);

                            if (kazanildiMi)
                            {
                                iskeletKesildi = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYazıtların etrafı artık güvenli.");
                                Console.ResetColor();

                               
                                if (!oyuncu.OzelYetenekAcildiMi)
                                {
                                    oyuncu.OzelYetenekAcildiMi = true; 

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("\n[GİZEMLİ GÜÇ UYANDI!]");
                                    Console.WriteLine("Düşmanı alt ettikten sonra antik yazıtların üzerindeki rünler parlamaya başladı...");
                                    Console.WriteLine("Bedenine tarifsiz bir enerji akın ediyor!");

                                    if (oyuncu is Savasci)
                                        Console.WriteLine(">> Artık savaşlarda 'Öfke Patlaması (Odaklanma)' yeteneğini kullanabilirsin!");
                                    else if (oyuncu is Okcu)
                                        Console.WriteLine(">> Artık okçular 'Hançer ve Ok' kombosunu kullanabilirsin!");
                                    else if (oyuncu is Buyucu)
                                        Console.WriteLine(">> Artık büyücüler 'Alev Topu' büyüsünü kullanabilirsin!");

                                    Console.ResetColor();
                                }
                               

                                Console.WriteLine("\nDevam etmek için bir tuşa bas...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nYazıtların orası güvenli. İskelet parçalanmış halde yerde yatıyor.");
                            Console.WriteLine("Devam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }

        private void TBMMMenusu(Karakterler oyuncu)
        {
            bool tbmmde = true;
            while (tbmmde)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== I. TBMM BİNASI ===");
                Console.ResetColor();
                Console.WriteLine("1. Tüccar");
                Console.WriteLine("2. Müze (Tehlike: Zombi)");
                Console.WriteLine("0. Ulus Meydanı'na Dön");
                Console.Write("Seçim: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        TuccarDukkani(oyuncu);
                        break;
                    case "2":
                        Console.Clear();
                        if (!zombiKesildi)
                        {
                            Console.WriteLine("\nMüzeye girdiğinde tarihi eserlerin arasında dolaşan bir Zombi gördün!");
                            Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                            Console.ReadKey();

                            
                            Zombi zombi = new Zombi { İsim = "Müze Bekçisi Zombi", Can = 100, MaxCan = 100, SaldırıGücü = 18, SavunmaGücü = 8 };
                            bool zombiKazanildiMi = savasManager.SavasBaslat(oyuncu, zombi);

                            if (zombiKazanildiMi)
                            {
                                zombiKesildi = true; 
                                tbmmAnahtariAlindi = true; 

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n[BİLGİ] Zombiyi yendin ve üzerinden parlayan TBMM ANAHTARI'nı aldın!");
                                Console.ResetColor();
                                Console.WriteLine("Devam etmek için bir tuşa bas...");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nMüze artık güvenli. Zombinin kalıntıları yerde duruyor. (Anahtarı zaten almıştın)");
                            Console.WriteLine("Devam etmek için bir tuşa bas...");
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                        tbmmde = false;
                        break;
                }
            }
        }

        private void KizilayMenusu(Karakterler oyuncu)
        {
            bool kizilayda = true;
            while (kizilayda)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== KIZILAY MEYDANI ===");
                Console.ResetColor();
                Console.WriteLine("1. Kızılay AVM");
                Console.WriteLine("2. Büyülü Fener Sineması");
                Console.WriteLine("3. Gama İş Merkezi");
                Console.WriteLine("0. Ulus Meydanı'na Dön");
                Console.Write("Seçim: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Console.WriteLine("\nKızılay AVM'ye girdin...");
                        Console.WriteLine("Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("\nBüyülü Fener Sineması'na girdin...");
                        Console.WriteLine("Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("\nGama İş Merkezi'ne girdin...");
                        Console.WriteLine("Devam etmek için bir tuşa bas...");
                        Console.ReadKey();
                        break;
                    case "0":
                        kizilayda = false;
                        break;
                }
            }
        }

        private void TuccarDukkani(Karakterler oyuncu)
        {
            bool dukkandaMi = true;
            while (dukkandaMi)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n=== GİZEMLİ TÜCCAR ===");
                Console.ResetColor();
                Console.WriteLine($"Altının: {oyuncu.Altin} | Can Potu: {oyuncu.CanPotuAdedi} | Mana Potu: {oyuncu.ManaPotuAdedi} | Silah Seviyesi: {oyuncu.SilahSeviyesi}");
                Console.WriteLine("1. Can Potu Al (40 Altın)");
                Console.WriteLine("2. Mana Potu Al (40 Altın)");
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

        private void KarakterBilgileriniGoster(Karakterler oyuncu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n=== KARAKTER DURUMU ===");
            Console.ResetColor();
            Console.WriteLine($"İsim: {oyuncu.İsim} (Seviye {oyuncu.Seviye})");
            Console.WriteLine($"Sınıf: {oyuncu.GetType().Name}");
            Console.WriteLine($"Can: {oyuncu.Can} / {oyuncu.MaxCan}");
            Console.WriteLine($"Mana: {oyuncu.Mana}");
            Console.WriteLine($"Saldırı Gücü: {oyuncu.SaldırıGücü}");
            Console.WriteLine($"Savunma Gücü: {oyuncu.SavunmaGücü}");
            Console.WriteLine($"Kritik Şansı: %{oyuncu.KiritikSansi * 100}");
            Console.WriteLine($"XP: {oyuncu.Xp} / {oyuncu.MaxXP}");
            Console.WriteLine($"Altın: {oyuncu.Altin}");
            Console.WriteLine("=======================");

            Console.WriteLine("\nHaritaya dönmek için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
