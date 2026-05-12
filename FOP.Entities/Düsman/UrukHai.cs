using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Düsman
{
    public class UrukHai : IDüsmanOzellikleri
    {
        public UrukHai() : base("Uruk-Hai Savaşçısı", 150, 30, 0.10, 120) { }
    }
}
