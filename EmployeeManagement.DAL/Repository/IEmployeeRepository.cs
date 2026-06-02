using EmployeeManagement.DAL.Model;

namespace EmployeeManagement.DAL.Repository;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(int id);
    Task<IEnumerable<Employee>> GetALlAsync();
    Task<Employee> CreateAsync(Employee entity);
    Task<Employee?> UpdateAsync(Employee entity);
    Task DeleteAsync(int id);
}
