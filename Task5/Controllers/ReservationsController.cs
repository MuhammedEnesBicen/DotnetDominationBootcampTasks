using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task5.Models.DTOs;
using Task5.Models.ORM;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ReservationsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using(var context = new AppDbContext())
            {
                var reservations = context.Reservation.ToList();
                return Ok(reservations);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
               using(var context = new AppDbContext())
            {
                var reservation = context.Reservation.FirstOrDefault(x => x.Id == id);
                if(reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }
        }


        [HttpPost]
        public IActionResult Post(ReservationDTO reservationDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using(var context = new AppDbContext())
            {
                var reservation = _mapper.Map<Reservation>(reservationDTO);
                context.Reservation.Add(reservation);
                context.SaveChanges();
                return CreatedAtAction(nameof(Get), new {id = reservation.Id}, reservation);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using(var context = new AppDbContext())
            {
                var reservation = context.Reservation.FirstOrDefault(x => x.Id == id);
                if(reservation == null)
                {
                    return NotFound();
                }
                context.Reservation.Remove(reservation);
                context.SaveChanges();
                return NoContent();
            }
        }

    }
}
