using FOP.DataAccess.Abstract;
using FOP.Entities;
using FOP.Entities.Abstract;
using FOP.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FOP.DataAccess.Concrete
{
    public class JsonOyunKayitDal : IOyunKayitDal
    {
        private readonly string _dosyaYolu = "oyun_kaydi.json";

        public IResult OyunuKaydet()
        {
            try
            {
              
                OyunKayitVerisi anlikDurum = new OyunKayitVerisi
                {
                    TbmmAnahtariAlindi = IHarita_Özellik.tbmmAnahtariAlindi,
                    RomaHamamiAnahtariAlindi = IHarita_Özellik.romaHamamiAnahtariAlindi,
                    BossKesildi = IHarita_Özellik.bossKesildi,
                    GamaBossKesildi = IHarita_Özellik.gamaBossKesildi,
                    JurassicBitti = IHarita_Özellik.jurassicBitti
                  
                };

              
                string json = JsonSerializer.Serialize(anlikDurum);

               
                File.WriteAllText(_dosyaYolu, json);

               
                return new SuccessResult("Maceran karanlık başkentte güvenle kaydedildi!");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Kayıt başarısız: " + ex.Message);
            }
        }

        public IResult OyunuYukle()
        {
            try
            {
                if (!File.Exists(_dosyaYolu))
                    return new ErrorResult("Kayıtlı bir oyun bulunamadı!");

                string json = File.ReadAllText(_dosyaYolu);
                OyunKayitVerisi yuklenenDurum = JsonSerializer.Deserialize<OyunKayitVerisi>(json);

                if (yuklenenDurum != null)
                {
                    IHarita_Özellik.tbmmAnahtariAlindi = yuklenenDurum.TbmmAnahtariAlindi;
                    IHarita_Özellik.romaHamamiAnahtariAlindi = yuklenenDurum.RomaHamamiAnahtariAlindi;
                    IHarita_Özellik.bossKesildi = yuklenenDurum.BossKesildi;
                    IHarita_Özellik.gamaBossKesildi = yuklenenDurum.GamaBossKesildi;
                    IHarita_Özellik.jurassicBitti = yuklenenDurum.JurassicBitti;

                    return new SuccessResult("Kayıt yüklendi, savaşa geri dönüyorsun!");
                }
                return new ErrorResult("Dosya bozuk!");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Yükleme başarısız: " + ex.Message);
            }
        }
    }
}

