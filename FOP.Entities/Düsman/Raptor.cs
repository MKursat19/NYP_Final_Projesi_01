using FOP.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP.Entities.Düsman
{
    public class Raptor : IDüsmanOzellikleri
    {
        public Raptor() : base("Vahşi Velociraptor", 100, 25, 0.20, 80) { }
    }
}
