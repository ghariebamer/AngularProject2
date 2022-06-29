using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        [HttpGet,Route("GetallEmployees")]
            
        public IActionResult GetEmployees()
        {
            try
            {
                var list = employee.getEmployees();
                return Ok(list);
            }
            catch (Exception  ex)
            {

                return BadRequest(ex.Message);  
            }
         
        }

        [HttpGet, Route("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var list = employee.getEmployee(id);
                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost,Route("updateEmployee")]
        
        public IActionResult UpdateEmployee(Employee emp)
        {

            try
            {
                var list= employee.EditEmployee(emp);
                return Ok(list);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete,Route("deleteEmployee")]

        public IActionResult deleteEmployee(int id)
        {
            employee.deleteEmployee(id);
            return Ok("your Employee is deleted");
        }

        [HttpPost,Route("createEmployee")]

        public IActionResult CreateEmployee( Employee emp)
        {
            employee.createEmployee(emp);
            return Ok("your Employee is created ");

        }
    }
}
