namespace EmployeeManagement.DAL.Model;

public class Employee
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public decimal Salary { get; set; }
}
