using EmployeeManagement.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
}
