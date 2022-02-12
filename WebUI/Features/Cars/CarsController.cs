using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Entities;

namespace WebUI.Features.Cars
{
    [Route("api/cars")] // "api/[controller]" dynamic binding less safe than strongly typed
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            var cars = new List<Car>();
            var car1 = new Car
            {
                TeamName = "team A",
                Speed = 100,
                MalfunctionChance = 0.2
            };
            var car2 = new Car
            {
                TeamName = "team B",
                Speed = 90,
                MalfunctionChance = 0.1
            };
            cars.Add(car1);
            cars.Add(car2);

            return Ok(cars);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car1 = new Car
            {
                TeamName = "team A",
                Speed = 100,
                MalfunctionChance = 0.2
            };
            return Ok(car1);
        }

        //create car endpoint
        [HttpPost]
        public ActionResult<Car> CreateCar(Car car)
        {
            var newCar = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MalfunctionChance = car.MalfunctionChance,
                // DistanceCoveredInMiles = car.DistanceCoveredInMiles,
                //FinishedRace = car.FinishedRace,
                // RacedForHours = car.RacedForHours
            };

            return Ok(newCar);
        }
        //update car
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Car> UpdateCar(Car car)
        {
            var updateCar = new Car
            {
                Id = car.Id,
                TeamName = car.TeamName,
                Speed = car.Speed,
                MalfunctionChance = car.MalfunctionChance,
                // DistanceCoveredInMiles = car.DistanceCoveredInMiles,
                //FinishedRace = car.FinishedRace,
                // RacedForHours = car.RacedForHours
            };

            return Ok(updateCar);
        }


        //delete car
        [HttpDelete]
        public ActionResult DeleteCar(Car car)
        {
            return Ok("Car with id {id} was successfully deleted");
        }

    }
}
