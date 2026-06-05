using FOP.Core.Results;
using FOP.DataAccess.Abstract;
using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Business
{
    public class OyunKayitManager
    {
        private readonly IOyunKayitDal _oyunKayitDal;

        public OyunKayitManager(IOyunKayitDal oyunKayitDal)
        {
            _oyunKayitDal = oyunKayitDal;
        }

        public IResult OyunuKaydet()
        {
            return _oyunKayitDal.OyunuKaydet();
        }

        public IResult OyunuYukle()
        {
            return _oyunKayitDal.OyunuYukle();
        }
    }
}
