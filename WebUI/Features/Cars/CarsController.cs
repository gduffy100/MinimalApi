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
        public ActionResult<List<Car>> getCars()
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
    }
}
