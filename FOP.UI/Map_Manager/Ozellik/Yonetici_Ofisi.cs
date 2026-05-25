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
    public class Yonetici_Ofisi : IHarita_Özellik
    {
        Savas_Manager savasManager = new Savas_Manager();
        XP_Manager xpManager = new XP_Manager();
         
        public void MenuAc(Karakterler oyuncu)
        {
            Console.Clear();
            if (!gamaBossKesildi)
            {
                Console.WriteLine("\nEn üst kata ulaştın. Lüks ofisin ortasında Gama'nın CEO'su seni bekliyor.");
                Console.WriteLine("\nSavaşa girmek için bir tuşa bas...");
                Console.ReadKey();

                Gama_Boss boss = new Gama_Boss();
                bool kazanildiMi = savasManager.SavasBaslat(oyuncu, boss);

                if (kazanildiMi)
                {
                    gamaBossKesildi = true;
                    gamaAltKatAcildi = true;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCEO'yu yendin! Masasının üzerindeki 'Master Key' kartını aldın.");
                    Console.WriteLine("Artık asansörle -1. Kat'a inebilirsin!");
                    Console.ResetColor();

                    xpManager.XpKazan(oyuncu, 200);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\nOfis sessiz. CEO'nun koltuğu boş duruyor.");
                Console.WriteLine("Dönebilirsin...");
                Console.ReadKey();
            }
        }
    }
}
