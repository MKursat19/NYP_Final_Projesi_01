using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.DataAccess.Abstract
{
    public interface IKarakterDAL
    {
        void KarakterEkle(Karakterler karakter);

        Karakterler GetirKarakter();
    }
}
