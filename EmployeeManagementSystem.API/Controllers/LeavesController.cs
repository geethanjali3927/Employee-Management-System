using EmployeeManagementSystem.API.Data;
using EmployeeManagementSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeavesController(ApplicationDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetAll()
        => Ok(await db.LeaveRequests.Include(x => x.Employee).AsNoTracking().ToListAsync());

    [HttpPost]
    public async Task<ActionResult<LeaveRequest>> Create(LeaveRequest request)
    {
        if (request.EndDate < request.StartDate)
            return BadRequest(new { message = "End date cannot be before start date." });

        request.Id = 0;
        request.Status = "Pending";
        db.LeaveRequests.Add(request);
        await db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = request.Id }, request);
    }

    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
    {
        var leave = await db.LeaveRequests.FindAsync(id);
        if (leave is null) return NotFound();

        var allowed = new[] { "Pending", "Approved", "Rejected" };
        if (!allowed.Contains(status))
            return BadRequest(new { message = "Status must be Pending, Approved, or Rejected." });

        leave.Status = status;
        await db.SaveChangesAsync();
        return NoContent();
    }
}
