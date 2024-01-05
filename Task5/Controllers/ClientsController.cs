using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task5.Models.DTOs;
using Task5.Models.ORM;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ClientsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            using(var context = new AppDbContext())
            {
                var clients = context.Client.ToList();
                return Ok(clients);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using(var context = new AppDbContext())
            {
                var client = context.Client.FirstOrDefault(x => x.Id == id);
                if(client == null)
                {
                    return NotFound();
                }
                return Ok(client);
            }
        }


        [HttpPost]
        public IActionResult Post(ClientDTO clientDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using(var context = new AppDbContext())
            {
                var newClient = _mapper.Map<Client>(clientDTO);
                context.Client.Add(newClient);
                context.SaveChanges();
                return CreatedAtAction(nameof(Get), new {id = newClient.Id}, newClient);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using(var context = new AppDbContext())
            {
                var client = context.Client.FirstOrDefault(x => x.Id == id);
                if(client == null)
                {
                    return NotFound();
                }
                context.Client.Remove(client);
                context.SaveChanges();
                return NoContent();
            }
        }



    }
}
