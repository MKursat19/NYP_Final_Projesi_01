using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOP.Core.Results;
using FOP.DataAccess.Concrete;


namespace FOP.DataAccess.Abstract
{
    public interface IOyunKayitDal
    {
        IResult OyunuKaydet();
        IResult OyunuYukle();
    }
}
