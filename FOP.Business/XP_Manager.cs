using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOP.Entities;


namespace FOP.Business
{
    public class XP_Manager
    {
        public void XpKazan(Karakterler karakter, int kazanilanXp)
        {
            karakter.Xp += kazanilanXp;
            Console.ForegroundColor = ConsoleColor.Cyan;
            // XP kazanıldığında kullanıcıya bilgi verelim
            Console.WriteLine();
            Console.ResetColor();

            while (karakter.Xp >= karakter.MaxXP)
                SeviyeAtla(karakter);
        }

        private void SeviyeAtla(Karakterler karakter)
        {
            karakter.Xp -= karakter.MaxXP;
            karakter.Seviye++;
            karakter.MaxXP = (int)(karakter.MaxXP * 1.5);
            karakter.MaxCan += 20;
            karakter.Can = karakter.MaxCan;
            karakter.SaldırıGücü += 5;
            karakter.Mana += 10;
            karakter.SavunmaGücü += 2;

            Console.ForegroundColor = ConsoleColor.Yellow;
            // Seviye atlandığında kullanıcıya bilgi verelim
            Console.WriteLine();
            // Seviye atlandığında karakterin yeni özelliklerini gösterelim
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
