using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOP.Entities;
using FOP.Entities.Karakter_Sınıfları;
using FOP.Entities.Düsman;

namespace FOP.Business
{
    public class Yetenek_Manager
    {
        public bool OzelYetenekKullan(Karakterler saldirgan, DüsmanOzellikleri hedef, Saldiri_Manager saldiriManager)
        {
            if (saldirgan is Savasci savasci)
            {
                if (savasci.Mana >= 20)
                {
                    savasci.Mana -= 20;
                    savasci.OzelYetenekKullanildiMi = true;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    // Savaşçının odaklanma yeteneği için yazı
                    Console.WriteLine();
                    // Savaşçının odaklanma yeteneği için yazı
                    Console.WriteLine();
                    Console.ResetColor();
                    return false; // Tur geçmez
                }
                // Yeterli mana yok
                Console.WriteLine();
                return false;
            }
            else if (saldirgan is Okcu okcu)
            {
                if (okcu.Mana >= 25)
                {
                    okcu.Mana -= 25;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    // Okçunun hançer ve ok yeteneği için yazı
                    Console.WriteLine();
                    Console.ResetColor();

                    // Okçu yeteneği için Saldırı Manager'dan düz vuruş çağırıyoruz
                    saldiriManager.DuzSaldiriYap(okcu, hedef);
                    saldiriManager.DuzSaldiriYap(okcu, hedef);
                    return true;
                }
                // Yeterli mana yok
                Console.WriteLine();
                return false;
            }
            else if (saldirgan is Buyucu buyucu)
            {
                if (buyucu.Mana >= 30)
                {
                    buyucu.Mana -= 30;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    // Büyücünün alev topu yeteneği için yazı
                    Console.WriteLine();
                    Console.ResetColor();

                    int alevHasari = (buyucu.SaldırıGücü * 2) - hedef.SavunmaGücü;
                    if (alevHasari < 0) alevHasari = 0;

                    hedef.Can -= alevHasari;
                    // Alev topu hasarı, büyücünün saldırı gücünün 2 katından hedefin savunma gücünü çıkararak hesaplanır
                    Console.WriteLine();

                    hedef.YanmaSuresi = 3;
                    // Hedefin yanma süresini 3 tura ayarlıyoruz
                    Console.WriteLine();

                    return true;
                }
                // Yeterli mana yok
                Console.WriteLine();
                return false;
            }

            return false;
        }
    }
}
