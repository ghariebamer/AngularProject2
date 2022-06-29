using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{

        

    
    public class EmployeeRepo : IEmployee
    {
        public List<Employee> Employees { get; set; }

        public Employee employee;

        private string connection;
        private readonly IWebHostEnvironment environment;

        public EmployeeRepo(IOptions<Connection> db, IWebHostEnvironment _environment)
        {
            connection = db.Value.connectionstring;
            environment = _environment;
        }

        public void createEmployee(Employee employee)
        {
            if (employee != null)
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("sp_CreateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", employee.Name));
                cmd.Parameters.Add(new SqlParameter("@department", employee.Department));
                cmd.Parameters.Add(new SqlParameter("@dataofjoining", employee.dateofjoining));
                cmd.Parameters.Add(new SqlParameter("@phatoName", employee.photofileName));

                con.Open();
                cmd.ExecuteReader();
                con.Close();



            }

        }

        public void deleteEmployee(int id)
        {

            if (id != null)
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("sp_deleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                con.Open();
                cmd.ExecuteReader();

                con.Close();
            }
        }

        public Employee EditEmployee(Employee employee)
        {
            dynamic result;
            if (employee != null)
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", employee.Id));
                cmd.Parameters.Add(new SqlParameter("@name", employee.Name));
                cmd.Parameters.Add(new SqlParameter("@department", employee.Department));
                cmd.Parameters.Add(new SqlParameter("@dateofjoining", employee.dateofjoining));
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
            }
            result = this.getEmployee(employee.Id);
            return result;

        }

        public Employee getEmployee(int id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_getEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                Employee emp = new Employee();
                emp.Id = Convert.ToInt32(rd["id"]);
                emp.Name = rd["Name"].ToString();
                emp.Department = rd["Department"].ToString();
                emp.photofileName = rd["PhotoName"].ToString();
                emp.dateofjoining = rd["dateofjoining"].ToString();
                emp.CreateDate = rd["createddate"].ToString();
                emp.CreateBy = Convert.ToInt32(rd["createBy"]);

                employee = emp;
            }
            return employee;

        }

        public List<Employee> getEmployees()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_getallEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {

                List<Employee> employees = new List<Employee>();
                employees.Add(new Employee()
                {
                    Id = Convert.ToInt32(rd["id"]),
                    Name = rd["Name"].ToString(),
                    Department = rd["Department"].ToString(),
                    dateofjoining = rd["dateofjoining"].ToString(),
                    photofileName = rd["PhotoName"].ToString(),
                    CreateDate = rd["createddate"].ToString(),
                    CreateBy = Convert.ToInt32(rd["createBy"])

                });
                ;
                Employees = employees;
            }
            return Employees;

        }

        public string UploadImage(IFormFile file)
        {
            try { 
                    if (file.Length > 0)
                    {
                        if(!Directory.Exists(environment.WebRootPath+ "~\\Photos\\"))
                        {
                            Directory.CreateDirectory(environment.WebRootPath + "~\\Photos\\");
                        }
                        using(FileStream filestream=System.IO.File.Create(environment.WebRootPath + "~\\Photos\\" + file.FileName))
                        {
                            file.CopyTo(filestream);
                            filestream.Flush();
                            return "Photos" +file.FileName;
                        }
                    }
                    else
                    {
                        return "Failed";
                    }

            }catch (Exception ex)
            {
                 return ex.Message.ToString();
            }
        }
    }
}
