using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task5.Models.ORM;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using(var context = new AppDbContext())
            {
                var companies = context.Company.ToList();
                return Ok(companies);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using(var context = new AppDbContext())
            {
                 var company = context.Company.FirstOrDefault(x => x.Id == id);
                 if(company == null)
                {
                      return NotFound();
                 }
                 return Ok(company);
                }
        }

        [HttpPost]
        public IActionResult Post(Company company)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using(var context = new AppDbContext())
            {
                context.Company.Add(company);
                context.SaveChanges();
                return CreatedAtAction(nameof(Get), new {id = company.Id}, company);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using(var context = new AppDbContext())
            {
                var company = context.Company.FirstOrDefault(x => x.Id == id);
                if(company == null)
                {
                    return NotFound();
                }
                context.Company.Remove(company);
                context.SaveChanges();
                return Ok(company);
            }
        }   
    }
}
