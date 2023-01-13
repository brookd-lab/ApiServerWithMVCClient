using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<Employee>> IEmployeeRepository.GetAllEmployees()
        {
            var employeeList = await _context.Employee.ToListAsync();
            return employeeList;
        }
        async Task<Employee> IEmployeeRepository.GetEmployeeById(int id)
        {
            Employee? employee = await _context.Employee.FindAsync(id);
            return employee;
        }

        async Task IEmployeeRepository.CreateEmployee(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        async Task IEmployeeRepository.UpdateEmployeeById(int id, Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        async Task IEmployeeRepository.DeleteEmployeeById(int id)
        {
            var employeeToDelete = await _context.Employee.FindAsync(id);
            if (employeeToDelete != null)
            {
                _context.Remove(employeeToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
