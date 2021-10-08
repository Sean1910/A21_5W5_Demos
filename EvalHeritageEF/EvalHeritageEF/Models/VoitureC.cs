using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalHeritageEF.Models
{
    public class VoitureC:VehiculeC
    {
        public string Couleur { get; set; }
        public int NbrPassagers { get; set; }
    }
}
