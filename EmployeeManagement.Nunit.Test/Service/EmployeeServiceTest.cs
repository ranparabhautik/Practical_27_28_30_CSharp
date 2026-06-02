using EmployeeManagement.DAL.Model;
using EmployeeManagement.DAL.Repository;
using EmployeeManagement.DAL.Services;
using Moq;

namespace EmployeeManagement.Nunit.Test.Service;

[TestFixture]
public class EmployeeServiceTest
{
    private readonly Mock<IEmployeeRepository> _repo;
    private readonly EmployeeService _service;
    public EmployeeServiceTest()
    {
        _repo = new Mock<IEmployeeRepository>();
        _service = new EmployeeService(_repo.Object);
    }

    [Test]
    public async Task GetEmpById()
    {
        //arrange
        var emp = new Employee
        {
            Id = 1,
            Name = "Hello",
            Salary = 25000
        };

        _repo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(emp);

        //act
        var result = await _service.GetEmployeeByIdAsync(1);

        //assert
        Assert.That(result,Is.Not.Null);
        Assert.That(result.Name,Is.EqualTo("Hello"));
    }


    [TestCase("Shivang", 50000)]
    [TestCase("Sam", 200)]
    [TestCase("Pam", 10000)]
    public async Task CheckCreateEmployee(string name,decimal salary) 
    {
        //arrange
        var emp = new Employee
        {
            Id=1,
            Name=name,
            Salary = salary
        };
        _repo.Setup(x=> x.CreateAsync(emp)).ReturnsAsync(emp);

        //act
        var result = await _service.CreateEmployeeAsync(emp);

        //assert
        Assert.That(result, Is.Not.Null);
        _repo.Verify(x=> x.CreateAsync(emp),Times.Once);
    }


    [Test]
    public async Task GetAllEmp_ReturnAllEmp()
    {
        // arrange
        var employees = new List<Employee>()
        {
            new Employee{Id=1,Name="Ajay",Salary=2000},
            new Employee{Id=2,Name="Kunj",Salary=10000},
            new Employee{Id=3,Name="Rahul",Salary=5000},
        };

        _repo.Setup(x => x.GetALlAsync()).ReturnsAsync(employees);

        //act
        var result = await _service.GetAllEmployeesAsync();

        //assert
        Assert.That(result.Count(), Is.EqualTo(3));
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public async Task CheckUpdate()
    {
        //arrange
        var emp = new Employee
        {
            Id = 1,
            Name = "Sam",
            Salary = 60000
        };
        _repo.Setup(x => x.UpdateAsync(emp)).ReturnsAsync(emp);

        //act
        await _service.UpdateEmployeeAsync(emp);

        //assert
        _repo.Verify(x => x.UpdateAsync(emp), Times.Once);
    }

    [Test]
    public async Task Check_delete()
    {

        //act
        await _service.DeleteEmployeeAsync(1);
        //asset
        _repo.Verify(x => x.DeleteAsync(1), Times.Once);
    }

}
