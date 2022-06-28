using WebApplication1.Models;

namespace WebApplication1
{
    public interface IDepartment
    {
        public List<Department> getDepartments();

        public Department getDepartment(int id);


        public Department EditDepartment(Department department);


        public void createDepartment(Department department);

        public void deleteDepartment(int id);
    }
}
