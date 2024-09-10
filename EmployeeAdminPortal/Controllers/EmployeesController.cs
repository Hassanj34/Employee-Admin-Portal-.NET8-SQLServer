using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Employees()
        {
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO employeeDTO) 
        {
            var employee = new Employee()
            {
                Name = employeeDTO.Name,
                Email = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                Salary = employeeDTO.Salary,
            };

            dbContext.Employees.Add(employee);

            dbContext.SaveChanges();

            return Ok(employee);
        }
    }
}
