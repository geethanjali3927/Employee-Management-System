namespace EmployeeManagementSystem.API.DTOs;

public record EmployeeDto(
    int Id,
    string Name,
    string Email,
    string Phone,
    string JobTitle,
    decimal Salary,
    DateTime JoiningDate,
    int DepartmentId,
    string? DepartmentName
);

public record CreateEmployeeDto(
    string Name,
    string Email,
    string Phone,
    string JobTitle,
    decimal Salary,
    DateTime JoiningDate,
    int DepartmentId
);

public record UpdateEmployeeDto(
    string Name,
    string Email,
    string Phone,
    string JobTitle,
    decimal Salary,
    DateTime JoiningDate,
    int DepartmentId
);
