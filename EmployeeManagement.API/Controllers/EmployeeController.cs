using EmployeeManagement.DAL.Model;
using EmployeeManagement.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeServices service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAllEMployees()
    {
       var emp = await service.GetAllEmployeesAsync();
        return Ok(emp);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var emp = await service.GetEmployeeByIdAsync(id);
        if (emp != null) {
             return Ok(emp);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> CreateEmployee(Employee emp)
    {
        await service.CreateEmployeeAsync(emp);
        return Ok("Employee Created");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateEmployee( Employee emp)
    {
        var updated = await service.UpdateEmployeeAsync(emp);
        if(updated == null)
        {
            return NotFound();
        }
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await service.DeleteEmployeeAsync(id);
        return Ok("Employee Deleted ");
    }
}
