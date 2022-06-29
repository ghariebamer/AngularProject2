using WebApplication1.Models;

namespace WebApplication1.interfaces
{
    public interface IEmployee
    {
        public List<Employee> getEmployees();

        public Employee getEmployee(int id);


        public Employee EditEmployee(Employee employee);


        public void createEmployee(Employee employee);

        public void deleteEmployee(int id);
    }
}
