using EmployeeManagement.DAL.Model;

namespace EmployeeManagement.DAL.Services;

public interface IEmployeeServices
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();

    Task<Employee?> GetEmployeeByIdAsync(int id);

    Task<Employee> CreateEmployeeAsync(Employee employee);

    Task<Employee?> UpdateEmployeeAsync(Employee employee);

    Task DeleteEmployeeAsync(int id);
}
