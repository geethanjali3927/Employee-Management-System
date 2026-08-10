using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.API.Models;

public class LeaveRequest
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [MaxLength(250)]
    public string Reason { get; set; } = string.Empty;

    [MaxLength(30)]
    public string Status { get; set; } = "Pending";
}
