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
    public class Lotr : IHarita_Özellik
    {
        Savas_Manager savasManager = new Savas_Manager();
        public void MenuAc(IKarakterler oyuncu)
        {
            Console.Clear();
            if (!lotrBitti)
            {
                Console.WriteLine("\nSalona girdin. Orta Dünya'nın savaş boruları çalıyor... Perdeden fırlayan bir ork üstüne atlıyor!");
                Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                Console.ReadKey();

                UrukHai dusman = new UrukHai();
                if (savasManager.SavasBaslat(oyuncu, dusman))
                {
                    lotrBitti = true;
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
