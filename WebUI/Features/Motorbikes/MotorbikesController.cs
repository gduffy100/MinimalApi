using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Features.Motorbikes
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorbikes()
        {
            var Motorbikes = new List<Motorbike>();
            var Motorbike1 = new Motorbike
            {
                TeamName = "team A",
                Speed = 100,
                MalfunctionChance = 0.2
            };
            var Motorbike2 = new Motorbike
            {
                TeamName = "team B",
                Speed = 90,
                MalfunctionChance = 0.1
            };
            Motorbikes.Add(Motorbike1);
            Motorbikes.Add(Motorbike2);

            return Ok(Motorbikes);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Motorbike> GetMotorbike(int id)
        {
            var Motorbike1 = new Motorbike
            {
                TeamName = "team A",
                Speed = 100,
                MalfunctionChance = 0.2
            };
            return Ok(Motorbike1);
        }

        //create Motorbike endpoint
        [HttpPost]
        public ActionResult<Motorbike> CreateMotorbike(Motorbike Motorbike)
        {
            var newMotorbike = new Motorbike
            {
                Id = Motorbike.Id,
                TeamName = Motorbike.TeamName,
                Speed = Motorbike.Speed,
                MalfunctionChance = Motorbike.MalfunctionChance,
                // DistanceCoveredInMiles = Motorbike.DistanceCoveredInMiles,
                //FinishedRace = Motorbike.FinishedRace,
                // RacedForHours = Motorbike.RacedForHours
            };

            return Ok(newMotorbike);
        }
        //update Motorbike
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Motorbike> UpdateMotorbike(Motorbike Motorbike)
        {
            var updateMotorbike = new Motorbike
            {
                Id = Motorbike.Id,
                TeamName = Motorbike.TeamName,
                Speed = Motorbike.Speed,
                MalfunctionChance = Motorbike.MalfunctionChance,
                // DistanceCoveredInMiles = Motorbike.DistanceCoveredInMiles,
                //FinishedRace = Motorbike.FinishedRace,
                // RacedForHours = Motorbike.RacedForHours
            };

            return Ok(updateMotorbike);
        }


        //delete Motorbike
        [HttpDelete]
        public ActionResult DeleteMotorbike(Motorbike motorbike)
        {
            return Ok($"Motorbike with id {id} was successfully deleted");
        }

    }
}

