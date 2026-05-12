using FOP.Business;
using FOP.Entities.Abstract;
using FOP.Entities.Düsman;
using FOP.Entities.Karakter_Sınıfları;
using FOP.UI.Map_Manager.Ozellik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ulus
{
    public class Tbmm_Menusu : IHarita_Özellik 
    {
        Savas_Manager savasManager = new Savas_Manager();

        public void MenuAc(IKarakterler oyuncu)
        {
            bool tbmmde = true;
            while (tbmmde)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== I. TBMM BİNASI ===");
                Console.ResetColor();
                Console.WriteLine("1. Tüccar");
                Console.WriteLine("2. Müze");
                Console.WriteLine("0. Ulus Meydanı'na Dön");
                Console.Write("Seçim: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Tuccar_Menusu tuccar = new Tuccar_Menusu();
                        tuccar.MenuAc(oyuncu);
                        break;

                    case "2":
                        Console.Clear();
                        if (!zombiKesildi)
                        {
                            Console.WriteLine("\nMüzeye girdiğinde tarihi eserlerin arasında dolaşan bir Zombi gördün!");
                            Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                            Console.ReadKey();

                            Zombi zombi = new Zombi ();
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
    }
}
