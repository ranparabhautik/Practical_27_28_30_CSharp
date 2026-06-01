using EmployeeManagement.DAL.Model;
using EmployeeManagement.DAL.Repository;
using EmployeeManagement.DAL.Services;
using Moq;

namespace EmployeeManamgement.Xunit.Test.Services;

public class EmployeeServiceTest
{
    [Fact]
    public async Task GetEmpById()
    {

        //arrange
        var mockrepo = new Mock<IEmployeeRepository>();
        var emp = new Employee {
            Id = 1,
            Name = "Test",
            Salary= 12000
        };

        mockrepo.Setup(x=> x.GetByIdAsync(1)).ReturnsAsync(emp);
        var service = new EmployeeService(mockrepo.Object);

        //act
        var result = await service.GetEmployeeByIdAsync(1);

        //assert
        Assert.Equal("Test", result.Name);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task CheckCreateEmployee()
    {
        //arrange 
        var mockrepo = new Mock<IEmployeeRepository>();
        var emp = new Employee
        {
            Id = 1,
            Name = "Test",
            Salary = 12000
        };

        mockrepo.Setup(x=> x.CreateAsync(emp)).ReturnsAsync(emp);

        var services = new EmployeeService(mockrepo.Object);


        //act
        await services.CreateEmployeeAsync(emp);

        //assert
        mockrepo.Verify(x=> x.CreateAsync(emp),Times.Once);
        //mockrepo.Verify(x => x.CreateAsync(emp), Times.Never); // used to never call the repo
    }
}
