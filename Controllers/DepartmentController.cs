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
            var list = dep.getDepartments();
            return Ok(list);
        }


        [HttpGet, Route("getDepartment")]

        public IActionResult getDepartmentsbyId( int id)
        {
            var list = dep.getDepartment(id);
            return Ok(list);
        }


        [HttpPut,Route("UpdateDepartment")]
        public IActionResult UPdateDepartment(Department department)
        {
            var list = dep.EditDepartment(department);
            return Ok(list);    

        }

        [HttpPost,Route("CreateDepartment")]

        public IActionResult CreateDepartment(Department department)
        {
            dep.createDepartment(department);
            return Ok("Created Successfully");
        }

        [HttpDelete,Route("DeleteDepartment")]

        public IActionResult DeleteDepartment(int id)
        {
             dep.deleteDepartment(id);
            return Ok("your Department is deleted");
        }
    }
}
