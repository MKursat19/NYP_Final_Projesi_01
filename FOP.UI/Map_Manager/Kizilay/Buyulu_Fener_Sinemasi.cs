using FOP.Business;
using FOP.Entities.Abstract;
using FOP.UI.Map_Manager.Ozellik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Kizilay
{
    public class Buyulu_Fener_Sinemasi : IHarita_Özellik
    {
        public void MenuAc(Karakterler oyuncu)
        {
            bool sinemada = true;
            while (sinemada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== BÜYÜLÜ FENER SİNEMASI ===");
                Console.ResetColor();
                Console.WriteLine("İçerisi loş. Gişede takım elbiseli, yüzü bembeyaz bir adam duruyor.");
                Console.WriteLine("Gişe Görevlisi: 'Sinemamıza hoş geldin.Hangi filmi izlemek istersin?'");

                Console.WriteLine("\n1. Salon 1: Dinozor Dünyası");
                Console.WriteLine("2. Salon 2: Yüzüklerin Lordu");
                Console.WriteLine("3. Salon 3: Uzay Savaşları");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("4. Gişe Görevlisiyle Ticaret Yap ");
                Console.ResetColor();

                Console.WriteLine("0. Sinemadan Çık");
                Console.Write("\nSeçiminiz: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Jurassic_World jw = new Jurassic_World();
                        jw.MenuAc(oyuncu);
                        break;
                    case "2":
                        Lotr lotr = new Lotr();
                        lotr.MenuAc(oyuncu);
                        break;
                    case "3":
                        Star_Wars sw = new Star_Wars();
                        sw.MenuAc(oyuncu);
                        break;
                    case "4":
                        Tuccar_Menusu tuccar = new Tuccar_Menusu();
                        tuccar.MenuAc(oyuncu);
                        break;
                    case "0":
                        sinemada = false;
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
