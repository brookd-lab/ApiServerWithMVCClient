using DAL.Models;

namespace DAL.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployeeById(int id, Employee employee);
        Task DeleteEmployeeById(int id);
    }
}
