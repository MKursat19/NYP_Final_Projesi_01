using FOP.DataAccess.Abstract;
using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FOP.DataAccess.Concrete
{
    public class InMemoryKarakterDAL : Abstract.IKarakterDAL
    {
        private string _dosyaYolu;

        public InMemoryKarakterDAL()
        {
            string dataKlasor = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(dataKlasor))
            {
                Directory.CreateDirectory(dataKlasor);
            }

            _dosyaYolu = Path.Combine(dataKlasor, "karakterler.json");

            //Dosya daha önce oluşturulmamışsa boş bir skor listesiyle başlatılır
            if (!File.Exists(_dosyaYolu))
            {
                File.WriteAllText(_dosyaYolu, "");
            }
        }
        public Karakterler GetirKarakter()
        {
            try
            {
                string json = File.ReadAllText(_dosyaYolu);
                if (string.IsNullOrEmpty(json))
                {
                    return new Karakterler(); // Boş bir karakter döndür
                }

              var karakter = JsonSerializer.Deserialize<Karakterler>(json);

                if (karakter != null)
                    return karakter;
                else
                    return new Karakterler(); // Boş bir karakter döndür
            }
            catch (Exception ex)
            {
                return new Karakterler(); // Hata durumunda da boş bir karakter döndür
            }
        }

        public void KarakterEkle(Karakterler karakter)
        {
            try
            {
                
                string json = JsonSerializer.Serialize(karakter     );

                File.WriteAllText(_dosyaYolu, json);

               
            }
            catch (Exception ex)
            {
                
            }
        }

        public void KarakterEkle()
        {
            throw new NotImplementedException();
        }
    }
}
