using EmployeeManagementSystem.API.Data;
using EmployeeManagementSystem.API.DTOs;
using EmployeeManagementSystem.API.Interfaces;
using EmployeeManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.API.Services;

public class EmployeeService(ApplicationDbContext db) : IEmployeeService
{
    public async Task<IEnumerable<EmployeeDto>> GetAllAsync(string? search = null)
    {
        var query = db.Employees.Include(e => e.Department).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(e => e.Name.Contains(search) || e.Email.Contains(search));

        return await query
            .OrderBy(e => e.Id)
            .Select(e => new EmployeeDto(
                e.Id, e.Name, e.Email, e.Phone, e.JobTitle,
                e.Salary, e.JoiningDate, e.DepartmentId, e.Department!.Name))
            .ToListAsync();
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        return await db.Employees
            .Include(e => e.Department)
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(e => new EmployeeDto(
                e.Id, e.Name, e.Email, e.Phone, e.JobTitle,
                e.Salary, e.JoiningDate, e.DepartmentId, e.Department!.Name))
            .FirstOrDefaultAsync();
    }

    public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            JobTitle = dto.JobTitle,
            Salary = dto.Salary,
            JoiningDate = dto.JoiningDate,
            DepartmentId = dto.DepartmentId
        };

        db.Employees.Add(employee);
        await db.SaveChangesAsync();

        return (await GetByIdAsync(employee.Id))!;
    }

    public async Task<bool> UpdateAsync(int id, UpdateEmployeeDto dto)
    {
        var employee = await db.Employees.FindAsync(id);
        if (employee is null) return false;

        employee.Name = dto.Name;
        employee.Email = dto.Email;
        employee.Phone = dto.Phone;
        employee.JobTitle = dto.JobTitle;
        employee.Salary = dto.Salary;
        employee.JoiningDate = dto.JoiningDate;
        employee.DepartmentId = dto.DepartmentId;

        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await db.Employees.FindAsync(id);
        if (employee is null) return false;

        db.Employees.Remove(employee);
        await db.SaveChangesAsync();
        return true;
    }
}
