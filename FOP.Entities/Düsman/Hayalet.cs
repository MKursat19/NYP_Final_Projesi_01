using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Düsman
{
    public class Hayalet : IDüsmanOzellikleri
    {
        public Hayalet() : base("Hayalet", 60, 20, 0.1, 40) { }
    }
}
