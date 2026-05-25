using FOP.Business;
using FOP.Entities.Abstract;
using FOP.Entities.Düsman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ozellik
{
    public class Star_Wars : IHarita_Özellik
    {
    Savas_Manager Savas_Manager = new Savas_Manager();
        public void MenuAc(Karakterler oyuncu)
        {
            Console.Clear();
            if (!starWarsBitti)
            {
                Console.WriteLine("\nSalona girdin. Işın kılıcı sesleri yankılanıyor. Kendini bir anda Sith ile karşı karşıya buldun!");
                Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                Console.ReadKey();

                SithCiragi dusman = new SithCiragi();
                if (Savas_Manager.SavasBaslat(oyuncu, dusman))
                {
                    starWarsBitti = true;
                    oyuncu.Altin += 150;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n[FİLM BİTTİ] Perdenin içinden sağ salim döndün! (+150 Altın)");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nGişe Görevlisi: 'O filmi zaten izledin dostum. Başka seans seç.'");
                Console.ReadKey();
            }
        }
    }
}
