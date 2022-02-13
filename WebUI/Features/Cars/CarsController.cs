using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Linq;

namespace WebUI.Features.Cars
{
    [Route("api/cars")] // "api/[controller]" dynamic binding less safe than strongly typed
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = _context.Cars.ToList();

           

            return Ok(cars);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);

            
            if (car == null)
            {
                return NotFound($"Car with id:{id} not found");
            }
            return Ok(car);
        }

        //create car endpoint
        [HttpPost]
        public ActionResult<Car> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            
            return Ok(car);
        }
        //update car
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateCar(Car car)
        {
            var dbCar = _context.Cars.FirstOrDefault(x => x.Id == car.Id);

            if (dbCar == null)
            {
                return NotFound($"Car with id:{car.Id} not found");
            }

            dbCar.TeamName = car.TeamName;
            dbCar.Speed = car.Speed;
            dbCar.MalfunctionChance = car.MalfunctionChance;
          
            _context.SaveChanges();

            return Ok(dbCar);
        }


        //delete car
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var dbCar = _context.Cars.FirstOrDefault(x => x.Id == id);

            if (dbCar == null)
            {
                return NotFound($"Car with id:{id} not found");
            }
            _context.Remove(dbCar);
            _context.SaveChanges();

            return Ok($"Car with ID: {id} has been deleted");
        }

    }
}
