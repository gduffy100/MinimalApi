using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Linq;

namespace WebUI.Features.Motorbikes
{
    [Route("api/Motorbikes")] // "api/[controller]" dynamic binding less safe than strongly typed
    [ApiController]
    public class MotorbikesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotorbikesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Motorbike>> GetMotorbikes()
        {
            var Motorbikes = _context.Motorbikes.ToList();



            return Ok(Motorbikes);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Motorbike> GetMotorbike(int id)
        {
            var Motorbike = _context.Motorbikes.FirstOrDefault(x => x.Id == id);


            if (Motorbike == null)
            {
                return NotFound($"Motorbike with id:{id} not found");
            }
            return Ok(Motorbike);
        }

        //create Motorbike endpoint
        [HttpPost]
        public ActionResult<Motorbike> CreateMotorbike(Motorbike Motorbike)
        {
            _context.Motorbikes.Add(Motorbike);
            _context.SaveChanges();

            return Ok(Motorbike);
        }
        //update Motorbike
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Motorbike> UpdateMotorbike(Motorbike Motorbike)
        {
            var dbMotorbike = _context.Motorbikes.FirstOrDefault(x => x.Id == Motorbike.Id);

            if (dbMotorbike == null)
            {
                return NotFound($"Motorbike with id:{Motorbike.Id} not found");
            }

            dbMotorbike.TeamName = Motorbike.TeamName;
            dbMotorbike.Speed = Motorbike.Speed;
            dbMotorbike.MalfunctionChance = Motorbike.MalfunctionChance;

            _context.SaveChanges();

            return Ok(dbMotorbike);
        }


        //delete Motorbike
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteMotorbike(int id)
        {
            var dbMotorbike = _context.Motorbikes.FirstOrDefault(x => x.Id == id);

            if (dbMotorbike == null)
            {
                return NotFound($"Motorbike with id:{id} not found");
            }
            _context.Remove(dbMotorbike);
            _context.SaveChanges();

            return Ok($"Motorbike with ID: {id} has been deleted");
        }

    }
}
