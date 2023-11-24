using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud1.Shared;

public class Employee
{
    public int Id { get; set; }
    
    [Required]
    public string Code { get; set; }
    
    [Required] 
    public string FullName { get; set; }
    
    public string? Address { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime JoiningDate { get; set; }
    
}