using EmployeeManagement.DAL.Model;
using EmployeeManagement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DAL.Services;

public class EmployeeService(IEmployeeRepository emprepo) : IEmployeeServices
{
    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        return await emprepo.CreateAsync(employee);
    }

    public Task DeleteEmployeeAsync(int id)
    {
        return emprepo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await emprepo.GetALlAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await emprepo.GetByIdAsync(id);
    }

    public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
    {
        return await emprepo.UpdateAsync(employee);
    }
}
