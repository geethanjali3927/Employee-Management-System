using EmployeeManagementSystem.API.Data;
using EmployeeManagementSystem.API.DTOs;
using EmployeeManagementSystem.API.Interfaces;
using EmployeeManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Services;

public class DepartmentService(ApplicationDbContext db) : IDepartmentService
{
    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        return await db.Departments
            .AsNoTracking()
            .OrderBy(d => d.Name)
            .Select(d => new DepartmentDto(d.Id, d.Name))
            .ToListAsync();
    }

    public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto)
    {
        var department = new Department { Name = dto.Name.Trim() };
        db.Departments.Add(department);
        await db.SaveChangesAsync();

        return new DepartmentDto(department.Id, department.Name);
    }
}
