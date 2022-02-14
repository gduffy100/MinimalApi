using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Features.Motorbikes.Models
{
    public class MotorbikeCreateModel
    {
        public string TeamName { get; set; }
        public int Speed { get; set; }
        public double MalfunctionChance { get; set; }
    }
}
