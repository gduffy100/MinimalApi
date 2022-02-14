using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebUI.Features.CarRaces
{
    [Route("api/CarRaces")]
    [ApiController]
    public class CarRacesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarRacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<CarRace> GetCarRaces()
        {
            var carRaces = _context.CarRaces.Include(x => x.Cars).ToList();
            return Ok(carRaces);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetCarRace(int id)
        {
            var carRace = _context.CarRaces
                .Include(x => x.Cars)
                .FirstOrDefault(x => x.Id == id);

            if (carRace == null)
            {
                return NotFound();
            }
            return Ok(carRace);
        }

        [HttpPost]
        public ActionResult CreateCarRaces(CarRaceCreateModel carRaceModel)
        {
            var newCarRace = new CarRace
            {
                Name = carRaceModel.Name,
                Location = carRaceModel.Location,
                Distance = carRaceModel.Distance,
                TimeLimit = carRaceModel.TimeLimit
            };

            _context.CarRaces.Add(newCarRace);
            _context.SaveChanges();

            return Ok(newCarRace);
        }

        [HttpPut]
        // [Route("{id}")]
        public ActionResult UpdateCarRace(CarRaceUpdateModel carRaceModel)
        {
            var dbCarRace = _context.CarRaces
                .Include(x => x.Cars)
                .FirstOrDefault(x => x.Id == carRaceModel.Id);

            if (dbCarRace == null)
            {
                return NotFound();
            }

            dbCarRace.Name = carRaceModel.Name;
            dbCarRace.Location = carRaceModel.Location;
            dbCarRace.Distance = carRaceModel.Distance;
            dbCarRace.TimeLimit = carRaceModel.TimeLimit;

            _context.SaveChanges();

            return Ok(dbCarRace);
        }

        [HttpPut]
        [Route("{carRaceId}/addCar/{carId}")]
        public ActionResult AddCarToRace(int carRaceId, int carId)
        {
            var dbCarRace = _context.CarRaces
                .Include(x => x.Cars)
                .FirstOrDefault(x => x.Id == carRaceId);
            if (dbCarRace == null)
            {
                return NotFound();
            }

            var dbCar = _context.Cars.SingleOrDefault(x => x.Id == carId);

            if (dbCar == null)
            {
                return NotFound();
            }

            dbCarRace.Cars.Add(dbCar);
            _context.SaveChanges();
            return Ok(dbCarRace);
        }

        [HttpPut]
        [Route("{id}/start")]
        public ActionResult StartCarRace(int id)
        {
            var dbCarRace = _context.CarRaces
                .Include(x => x.Cars)
                .FirstOrDefault(x => x.Id == id);
            if (dbCarRace == null)
            {
                return NotFound($"car race with id: {id} not found");
            }

            dbCarRace.Status = "Started";
            _context.SaveChanges();

            return Ok(dbCarRace);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCarRace(int id)
        {
            var dbCarRace = _context.CarRaces
               .Include(x => x.Cars)
               .FirstOrDefault(x => x.Id == id);

            if (dbCarRace == null)
            {
                return NotFound();
            }
            _context.Remove(dbCarRace);
            _context.SaveChanges();
            return Ok($"Car Race with id: {id} has been deleted");
        }
    }
}
