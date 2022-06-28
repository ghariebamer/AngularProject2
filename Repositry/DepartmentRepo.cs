using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{
    public class DepartmentRepo : IDepartment
    {

        public List<Department> Departments { get; set; }
        public Department dep;
        public string connection;
        public DepartmentRepo(IOptions<Connection> db)
        {
            connection = db.Value.connectionstring;
        }


        public List<Department> getDepartments()
        {


            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetDepartments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
           SqlDataReader rd= cmd.ExecuteReader();

            while(rd.Read()) {
                List<Department> departments = new List<Department>();
                departments.Add(new Department()
                {
                    Id=Convert.ToInt32(rd["id"]),
                    Name= rd["Name"].ToString(),
                    CreateBy= Convert.ToInt32(rd["createBy"]),
                    CreateDate= rd["createddate"].ToString()
                });
                Departments=departments;
                con.Close();

            }
            return Departments;

        }

        public Department getDepartment(int id)
        {

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("sp_GetDepartmentByID", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", id));
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read()) { 
              Department department = new Department();
                department.Id = Convert.ToInt32(rd["id"]);
                department.Name = rd["Name"].ToString();
                department.CreateDate = rd["createddate"].ToString();
                department.CreateBy = Convert.ToInt32(rd["createBy"]);
                dep = department;
            
            }
            con.Close();
            return dep;
        }

        public Department EditDepartment(Department department)
        {
            dynamic result;
            if (department != null)
            {
                int id= department.Id;
                string name= department.Name;
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("sp_UpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@name", name));

                con.Open();
                cmd.ExecuteReader();
            }
            result = this.getDepartment(department.Id);
            
            return result;
            
        }

        public void createDepartment(Department department)
        {
            string result;
            if (department != null)
            {
                string name = department.Name;
                int createby = department.CreateBy;
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("CreateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;   
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@createby", createby));

                con.Open();
                cmd.ExecuteReader();
            }     

        }

        public void deleteDepartment(int id)
        {
            dynamic resultAll;

            if (id != null)
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("sp_deleteDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                con.Open();
                cmd.ExecuteReader();

                con.Close();
            }
       
            


        }
    }

}
