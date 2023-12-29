using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task4.Models.Context;

namespace Task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebUsersController : ControllerBase
    {
        AppDbContext _context;
        public WebUsersController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _context.WebUsers.Include(x => x.Orders);
            return Ok(result);
        }
    }
}
