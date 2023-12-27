using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task3.Models;
using Task3.Models.Context;

namespace Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper)
        {
            _context = new AppDbContext();
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Employee employee)
        {

            if (ModelState.IsValid)
            {
                var employeeInDb = _context.Employees.Find(employee.Id);
                if (employeeInDb == null)
                {
                    return NotFound();
                }
                _mapper.Map<Employee,Employee>(employee,employeeInDb);
                _context.Employees.Update(employeeInDb);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted);
            }
            return BadRequest(ModelState);
        }
    }
}
