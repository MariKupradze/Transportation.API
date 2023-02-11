using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transportation.API.Context;
using Transportation.API.Models;

namespace Transportation.API.Conrtollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly TransportContext db;

        public TransportController(TransportContext db)
        {
            this.db = db;
           
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAll()
        {
            return await this.db.Car.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetById(int id)
        {
            Car car = await this.db.Car.FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
                return NotFound();

            return new ObjectResult(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Create(Car car)
        {
            if (car == null)
                return this.BadRequest();

            db.Car.Add(car);

            await this.db.SaveChangesAsync();

            return Ok(car);
        }


        [HttpPut]
        public async Task<ActionResult<Car>> Update(Car car)
        {
            if (car == null)
                return this.BadRequest();

            if (!db.Car.Any(x => x.Id == car.Id))
                return this.NotFound();

            db.Car.Update(car);
            await db.SaveChangesAsync();

            return Ok(car);
        }


        [HttpDelete]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            Car car = await this.db.Car.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.Car.Remove(car);
            await db.SaveChangesAsync();
            return Ok(car);
        }
    }
}
