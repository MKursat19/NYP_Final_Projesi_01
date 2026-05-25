using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.UI.Map_Manager.Ozellik
{
    public class Gizli_Alt_Kat : IHarita_Özellik
    {
        public void MenuAc(Karakterler oyuncu)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n=== GAMA -1. KAT (GİZLİ ARŞİV) ===");
            Console.ResetColor();
            Console.WriteLine("Asansör zifiri karanlık bir depoya indi. Burası Gama'nın tüm gizli belgelerinin tutulduğu yer.");

            Console.WriteLine("\nTozlu klasörler arasında Ankara'nın neden karanlığa gömüldüğüne dair belgeler buldun.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[HİKAYE ÖĞESİ] 'Ankara'nın Sırları' belgesini çantana ekledin.");
            Console.ResetColor();

            Console.WriteLine("\nBurada daha fazla vakit kaybetmeden yukarı çıkmalısın.");
            Console.ReadKey();

        }
    }
}
