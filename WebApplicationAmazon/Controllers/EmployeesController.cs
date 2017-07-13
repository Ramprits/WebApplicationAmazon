using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAmazon.Database;

namespace WebApplicationAmazon.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private DhanaifruitsmartContext _context;

        public EmployeesController(DhanaifruitsmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _context.Employee.ToList();
            return Ok(employees);
        }
    }
}
