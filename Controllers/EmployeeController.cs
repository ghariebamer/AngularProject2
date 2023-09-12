using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.interfaces;
using WebApplication1.Models;
using WebApplication1.Repositry;
using LoggerService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;


        private readonly ILoggerManager logger;

        public EmployeeController(IEmployee employee, ILoggerManager _Logger)
        {
            this.employee = employee;
            logger = _Logger;
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
                logger.LogError(ex.Message);
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
                logger.LogError(ex.Message);

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
                logger.LogError(ex.Message);

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

        [HttpPost,Route("UploadFile")]

        public IActionResult uploadfile(IFormFile file)
        {
            string response = employee.UploadImage(file);
            return Ok(response);
            //return Ok();

        }

        [HttpGet("ExportEmployeesExcel")]

        public ActionResult ExportEmployeesExcel()
        {
            var empData= employee.ExportFile();
            using (XLWorkbook wb = new XLWorkbook())
            {
               var sheet1= wb.AddWorksheet(empData, "EmployeeSheet");
                sheet1.Column(1).Style.Font.FontColor = XLColor.Red;
                using (MemoryStream sm = new MemoryStream())
                {
                    wb.SaveAs(sm);
                    return File(sm.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmployeeExport.xlsx");
                }
            }
        }


    }
}
