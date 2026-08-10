namespace EmployeeManagementSystem.API.DTOs;

public record DepartmentDto(int Id, string Name);

public record CreateDepartmentDto(string Name);
