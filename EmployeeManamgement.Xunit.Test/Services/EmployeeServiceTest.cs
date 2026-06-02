using EmployeeManagement.DAL.Model;
using EmployeeManagement.DAL.Repository;
using EmployeeManagement.DAL.Services;
using Moq;

namespace EmployeeManamgement.Xunit.Test.Services;

public class EmployeeServiceTest
{
    // arrange
    private readonly Mock<IEmployeeRepository> _repo;
    private readonly EmployeeService _service;
    public EmployeeServiceTest()
    {
        _repo = new Mock<IEmployeeRepository>();
        _service= new EmployeeService(_repo.Object);
    }


    [Fact]
    public async Task GetEmpById()
    {

        //arrange
        var emp = new Employee {
            Id = 1,
            Name = "Test",
            Salary= 12000
        };

        _repo.Setup(x=> x.GetByIdAsync(1)).ReturnsAsync(emp);
        //act
        var result = await _service.GetEmployeeByIdAsync(1);

        //assert
        Assert.Equal("Test", result.Name);
        Assert.NotNull(result);
    }

    [Fact]
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
        Assert.Equal(3,result.Count());
        Assert.NotNull(result);

    }


    [Fact]
    public async Task CheckCreateEmployee()
    {
        //arrange 
        var emp = new Employee
        {
            Id = 1,
            Name = "Test",
            Salary = 12000
        };

        _repo.Setup(x=> x.CreateAsync(emp)).ReturnsAsync(emp);



        //act
        await _service.CreateEmployeeAsync(emp);

        //assert
        _repo.Verify(x=> x.CreateAsync(emp),Times.Once);
        //mockrepo.Verify(x => x.CreateAsync(emp), Times.Never); // used to never call the repo
    }

    [Fact]
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
        _repo.Verify(x => x.UpdateAsync(emp),Times.Once);
    }

    [Fact]
    public async Task Check_delete()
    {
     
        //act
        await _service.DeleteEmployeeAsync(1);
        //asset
        _repo.Verify(x => x.DeleteAsync(1), Times.Once);
    }
}
