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

        public DepartmentController(IDepartment dep)
        {
            this.dep = dep;
        }

        [HttpGet,Route("getallDepartment")]

        public IActionResult getDepartments()
        {
            try
            {
                var list = dep.getDepartments();
                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }


        [HttpGet, Route("getDepartment")]

        public IActionResult getDepartmentsbyId( int id)
        {
            try
            {
                var list = dep.getDepartment(id);
                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
          
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
