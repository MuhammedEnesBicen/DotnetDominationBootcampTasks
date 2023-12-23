using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Category> categories = new List<Category>()
        {
            new Category(1,"Category 1"),
            new Category(2, "Category 2") };
        static List<Product> products = new List<Product>()
        {
            new Product(1,"Product 1",10,categories[0]),
            new Product(2,"Product 2",20,categories[0]),
            new Product(3,"Product 3",30,categories[0]),
            new Product(4,"Product 4",40,categories[1]),
            new Product(5,"Product 5",50,categories[1])
        };


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products.Take(4).ToList());

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            products.Add(product);
            return Created("", product);
            //return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            
        }

        [HttpDelete("{id}")] // HttpDelete  'i eklemediğimde , ambigious HTTP method hatasından dolayı swagger çalışmıyordu.
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }
    }
}
