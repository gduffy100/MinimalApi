using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MotorbikeRace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Distance { get; set; }
        public int TimeLimit { get; set; }
        public string Status { get; set; }
        public List<Motorbike> Motorbikes { get; set; }

    }
}
