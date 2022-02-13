using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Features.Cars.Models
{
    public class CarCreateModel
    {
        public string TeamName { get; set; }
        public int Speed { get; set; }
        public double MalfunctionChance { get; set; }
    }
}
