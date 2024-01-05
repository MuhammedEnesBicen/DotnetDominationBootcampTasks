using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task5.Models.ORM;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using(var context = new AppDbContext())
            {
                var rooms = context.Room.ToList();
                return Ok(rooms);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using(var context = new AppDbContext())
            {
                var room = context.Room.FirstOrDefault(x => x.Id == id);
                if(room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
        }

        [HttpPost]
        public IActionResult Post(Room room)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using(var context = new AppDbContext())
            {
                context.Room.Add(room);
                context.SaveChanges();
                return CreatedAtAction(nameof(Get), new {id = room.Id}, room);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using(var context = new AppDbContext())
            {
                var room = context.Room.FirstOrDefault(x => x.Id == id);
                if(room == null)
                {
                    return NotFound();
                }
                context.Room.Remove(room);
                context.SaveChanges();
                return NoContent();
            }
        }
    }
}
