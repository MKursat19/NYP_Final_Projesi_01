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
    public class Jurassic_World : IHarita_Özellik
    {
        Savas_Manager savas_Manager = new Savas_Manager();
        public void MenuAc(Karakterler oyuncu)
        {
            Console.Clear();
            if (!jurassicBitti)
            {
                Console.WriteLine("\nSalona girdin. Perdedeki dinozor kükremesi bir anda gerçek oldu ve seni içine çekti!");
                Console.WriteLine("Savaşa girmek için bir tuşa bas...");
                Console.ReadKey();

                Raptor dusman = new Raptor();
                if (savas_Manager.SavasBaslat(oyuncu, dusman))
                {
                    jurassicBitti = true;
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

