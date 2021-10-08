using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalHeritageEF.Models
{
    public class VoitureA:VehiculeA
    {
        public string Couleur { get; set; }
        public int NbrPassagers { get; set; }
    }
}
