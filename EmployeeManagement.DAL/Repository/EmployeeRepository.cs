using EmployeeManagement.DAL.Data;
using EmployeeManagement.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repository;

public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public async Task<Employee> CreateAsync(Employee entity)
    {
        await context.Employees.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        context.Employees.Remove(existing);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Employee>> GetALlAsync()
    {
        return await context.Employees.AsNoTracking().ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await context.Employees.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
    }

    public async Task<Employee?> UpdateAsync(Employee entity)
    {
        var existing =await context.Employees.FirstOrDefaultAsync(x=> x.Id == entity.Id);
        if(existing is null)
        {
            return null;
        }
        existing.Name = entity.Name;
        existing.Salary = entity.Salary;
        await context.SaveChangesAsync();
        return existing;
    }
}
