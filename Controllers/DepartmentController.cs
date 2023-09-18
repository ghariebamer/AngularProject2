using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment dep;
        private readonly ILoggerManager logger;

        public DepartmentController(IDepartment dep , ILoggerManager logger)
        {
            this.dep = dep;
            this.logger = logger;
        }

        [HttpGet,Route("getallDepartment")]

        public IActionResult getDepartments()
        {
                var list = dep.getDepartments();
            if(list.Count>0)
                return Ok(list);
            return BadRequest("there is no Departments");
        }


        [HttpGet, Route("getDepartment")]

        public IActionResult getDepartmentsbyId( int id)
        {
            logger.LogInfo("return all department");
                var list = dep.getDepartment(id);
            if(list is not null)
                return Ok(list);
            return BadRequest("there is no Departments");
        }


        [HttpPut,Route("UpdateDepartment")]
        public IActionResult UPdateDepartment(Department department)
        {
            try
            {
                var list = dep.EditDepartment(department);
                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
                
            }
             

        }

        [HttpPost,Route("CreateDepartment")]

        public IActionResult CreateDepartment(Department department)
        {
            try
            {
                dep.createDepartment(department);
                return Ok("Created Successfully");
            }
            catch (Exception ex)
            {


                return BadRequest(ex.Message);
            }
           
        }

        [HttpDelete,Route("DeleteDepartment")]

        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                dep.deleteDepartment(id);
                return Ok("your Department is deleted");
            }
            catch (Exception ex) { 
            
            return BadRequest(ex.Message);
            
            }
            
        }
    }
}
