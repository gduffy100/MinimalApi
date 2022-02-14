using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebUI.Features.MotorbikeRaces.Models;

namespace WebUI.Features.MotorbikeRaces
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorbikeRacesController : ControllerBase
    {
            private readonly ApplicationDbContext _context;

            public MotorbikeRacesController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public ActionResult<MotorbikeRace> GetMotorbikeRaces()
            {
                var MotorbikeRaces = _context.MotorbikeRaces.Include(x => x.Motorbikes).ToList();
                return Ok(MotorbikeRaces);
            }

            [HttpGet]
            [Route("{id}")]
            public ActionResult GetMotorbikeRace(int id)
            {
                var MotorbikeRace = _context.MotorbikeRaces
                    .Include(x => x.Motorbikes)
                    .FirstOrDefault(x => x.Id == id);

                if (MotorbikeRace == null)
                {
                    return NotFound();
                }
                return Ok(MotorbikeRace);
            }

            [HttpPost]
            public ActionResult CreateMotorbikeRaces(MotorbikeRaceCreateModel MotorbikeRaceModel)
            {
                var newMotorbikeRace = new MotorbikeRace
                {
                    Name = MotorbikeRaceModel.Name,
                    Location = MotorbikeRaceModel.Location,
                    Distance = MotorbikeRaceModel.Distance,
                    TimeLimit = MotorbikeRaceModel.TimeLimit
                };

                _context.MotorbikeRaces.Add(newMotorbikeRace);
                _context.SaveChanges();

                return Ok(newMotorbikeRace);
            }

            [HttpPut]
            // [Route("{id}")]
            public ActionResult UpdateMotorbikeRace(MotorbikeRaceUpdateModel MotorbikeRaceModel)
            {
                var dbMotorbikeRace = _context.MotorbikeRaces
                    .Include(x => x.Motorbikes)
                    .FirstOrDefault(x => x.Id == MotorbikeRaceModel.Id);

                if (dbMotorbikeRace == null)
                {
                    return NotFound();
                }

                dbMotorbikeRace.Name = MotorbikeRaceModel.Name;
                dbMotorbikeRace.Location = MotorbikeRaceModel.Location;
                dbMotorbikeRace.Distance = MotorbikeRaceModel.Distance;
                dbMotorbikeRace.TimeLimit = MotorbikeRaceModel.TimeLimit;

                _context.SaveChanges();

                return Ok(dbMotorbikeRace);
            }

            [HttpPut]
            [Route("{MotorbikeRaceId}/addMotorbike/{MotorbikeId}")]
            public ActionResult AddMotorbikeToRace(int MotorbikeRaceId, int MotorbikeId)
            {
                var dbMotorbikeRace = _context.MotorbikeRaces
                    .Include(x => x.Motorbikes)
                    .FirstOrDefault(x => x.Id == MotorbikeRaceId);
                if (dbMotorbikeRace == null)
                {
                    return NotFound();
                }

                var dbMotorbike = _context.Motorbikes.SingleOrDefault(x => x.Id == MotorbikeId);

                if (dbMotorbike == null)
                {
                    return NotFound();
                }

                dbMotorbikeRace.Motorbikes.Add(dbMotorbike);
                _context.SaveChanges();
                return Ok(dbMotorbikeRace);
            }

            [HttpPut]
            [Route("{id}/start")]
            public ActionResult StartMotorbikeRace(int id)
            {
                var dbMotorbikeRace = _context.MotorbikeRaces
                    .Include(x => x.Motorbikes)
                    .FirstOrDefault(x => x.Id == id);
                if (dbMotorbikeRace == null)
                {
                    return NotFound($"Motorbike race with id: {id} not found");
                }

                dbMotorbikeRace.Status = "Started";
                _context.SaveChanges();

                return Ok(dbMotorbikeRace);
            }

            [HttpDelete]
            [Route("{id}")]
            public ActionResult DeleteMotorbikeRace(int id)
            {
                var dbMotorbikeRace = _context.MotorbikeRaces
                   .Include(x => x.Motorbikes)
                   .FirstOrDefault(x => x.Id == id);

                if (dbMotorbikeRace == null)
                {
                    return NotFound();
                }
                _context.Remove(dbMotorbikeRace);
                _context.SaveChanges();
                return Ok($"Motorbike Race with id: {id} has been deleted");
            }
        

    }
}
