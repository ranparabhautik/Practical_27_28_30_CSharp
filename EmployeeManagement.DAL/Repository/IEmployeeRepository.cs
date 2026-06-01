using EmployeeManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DAL.Repository;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(int id);
    Task<IEnumerable<Employee>> GetALlAsync();
    Task<Employee> CreateAsync(Employee entity);
    Task<Employee?> UpdateAsync(Employee entity);
    Task DeleteAsync(int id);
}
