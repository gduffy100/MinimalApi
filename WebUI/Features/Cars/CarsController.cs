using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Persistence;
using System.Linq;
using WebUI.Features.Cars.Models;

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
        public ActionResult<Car> CreateCar(CarCreateModel carModel)
        {
            var car = new Car
            {
                TeamName = carModel.TeamName,
                Speed = carModel.Speed,
                MalfunctionChance = carModel.MalfunctionChance
            };
            _context.Cars.Add(car);
            _context.SaveChanges();
            
            return Ok(car);
        }
        //update car
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateCar(CarUpdateModel carModel)
        {
            var dbCar = _context.Cars.FirstOrDefault(x => x.Id == carModel.Id);

            if (dbCar == null)
            {
                return NotFound($"Car with id:{carModel.Id} not found");
            }

            dbCar.TeamName = carModel.TeamName;
            dbCar.Speed = carModel.Speed;
            dbCar.MalfunctionChance = carModel.MalfunctionChance;
          
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
