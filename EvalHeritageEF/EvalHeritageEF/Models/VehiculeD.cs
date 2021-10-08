using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalHeritageEF.Models
{
    public abstract class VehiculeD
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LicencePlate { get; set; }
    }
}
