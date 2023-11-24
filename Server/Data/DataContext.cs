using EmployeeCrud1.Shared;
using Microsoft.EntityFrameworkCore;
namespace EmployeeCrud1.Server.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

}