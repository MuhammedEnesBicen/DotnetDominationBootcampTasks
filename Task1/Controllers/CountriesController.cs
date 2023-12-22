using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new string[] { "Russia", "USA", "China", "Germany", "France", "Italy", "Spain", "Japan", "South Korea", "Canada", "Mexico", "Brazil", "Argentina", "Australia", "India", "Indonesia", "Turkey", "South Africa", "Egypt", "Nigeria" });
        }

        [HttpGet("{count}")]
        public IActionResult Get(int count)
        {
            if (count < 1)
            {
                return BadRequest();
            }
            string[] countries = new string[] { "Russia", "USA", "China", "Germany", "France", "Italy", "Spain", "Japan", "South Korea", "Canada", "Mexico", "Brazil", "Argentina", "Australia", "India", "Indonesia", "Turkey", "South Africa", "Egypt", "Nigeria" };
            if (count > countries.Length)
            {
                return StatusCode(StatusCodes.Status206PartialContent, countries);
            }
            return Ok(countries.Take(count));
        }   
    }
}
