using EmployeeManagement.DAL.Model;
using EmployeeManagement.DAL.Repository;
using EmployeeManagement.DAL.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Nunit.Test.Service;

[TestFixture]
public class EmployeeServiceTest
{
    [Test]
    public async Task GetEmpById()
    {
        //arrange
        var mockrepo = new Mock<IEmployeeRepository>();
        var emp = new Employee
        {
            Id = 1,
            Name = "Hello",
            Salary = 25000
        };

        mockrepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(emp);
        var service = new EmployeeService(mockrepo.Object);

        //act
        var result = await service.GetEmployeeByIdAsync(1);

        //assert
        Assert.That(result,Is.Not.Null);
        Assert.That(result.Name,Is.EqualTo("Hello"));
    }


    [TestCase("Shivang", 50000)]
    [TestCase("Sam", 0)]
    [TestCase("Pam", 10000)]
    public async Task CheckCreateEmployee(string name,decimal salary) 
    {
        //arrange
        var mockrepo = new Mock<IEmployeeRepository>();
        var emp = new Employee
        {
            Id=1,
            Name=name,
            Salary = salary
        };
        mockrepo.Setup(x=> x.CreateAsync(emp)).ReturnsAsync(emp);
        var service = new EmployeeService(mockrepo.Object);

        //act
        var result = await service.CreateEmployeeAsync(emp);

        //assert
        Assert.That(result, Is.Not.Null);
        mockrepo.Verify(x=> x.CreateAsync(emp),Times.Once);
    }
}
