using IntroAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IntroContext _context;
        
        public CarController(IntroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            var _cars = _context.Cars.ToList();
            return Ok(_cars);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (car != null)
            {
                return Ok(car);
            }
            else
            {
                return NotFound("No car was found on id: " + id);
            }
        }

        [HttpPost]
        public ActionResult<Car> Post(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return StatusCode(201, car);
        }

        //[HttpPut]
        //[Route("{id}")]
        //public ActionResult Put(int id, Car car)
        //{
        //    var tmpCar = cars.SingleOrDefault(c => c.Id == id);
        //    if (tmpCar != null) // Der findes en bil
        //    {
        //        tmpCar.Brand = car.Brand;

        //        // Update database med ny bil værdier
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return NotFound("No car was found on id: " + id);
        //    }

        //}

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var tmpCar = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (tmpCar != null)
            {
                _context.Remove(tmpCar);
                _context.SaveChanges();
                return Ok(tmpCar);
            }
            else
            {
                return NotFound("No car was found on id: " + id);
            }
        }
    }
}
