using EmployeeCrud1.Server.Data;
using EmployeeCrud1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud1.Server.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EmployeeController : ControllerBase
{
    private readonly DataContext _context;

    public EmployeeController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetAllEmployees()
    {
        var list = await _context.Employees.ToListAsync();

        return Ok(list);
    }

    [HttpPost]
    public async Task<ActionResult<List<Employee>>> AddEmployees(Employee empl)
    {
        _context.Employees.Add(empl);
        await _context.SaveChangesAsync();

        return await GetAllEmployees();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<Employee>>> UpdateEmployees(int id, Employee empl)
    {
        var dbEmployee = await _context.Employees.FindAsync(id);

        if (dbEmployee == null)
        {
            return NotFound("This Employee does not exist!");
        }

        dbEmployee.Id = empl.Id;
        dbEmployee.Code = empl.Code;
        dbEmployee.FullName = empl.FullName;
        dbEmployee.Address = empl.Address;
        dbEmployee.JoiningDate = empl.JoiningDate;
        _context.Employees.Update(empl);
        await _context.SaveChangesAsync();

        return await GetAllEmployees();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Employee>>> DeleteEmployees(int id)
    {
        var dbEmployee = await _context.Employees.FindAsync(id);
        if (dbEmployee == null)
        {
            return NotFound("This employee does not exist!");
        }

        _context.Employees.Remove(dbEmployee);
        await _context.SaveChangesAsync();

        return await GetAllEmployees();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Employee>>> GetEmployees(int id)
    {
        var dbEmployee = await _context.Employees.FindAsync(id);
        if (dbEmployee == null)
        {
            return NotFound("This employee does not exist!");
        }
        return Ok(dbEmployee);
    }
    
    
}