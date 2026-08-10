using EmployeeManagementSystem.API.DTOs;

namespace EmployeeManagementSystem.API.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAllAsync();
    Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto);
}
