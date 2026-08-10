# Employee Management System

A full-stack-ready employee management backend built with C#, ASP.NET Core Web API, Entity Framework Core and SQL Server.

## Features
- Employee CRUD
- Department management
- Employee search
- Leave requests
- Leave approval/rejection
- SQL Server database
- Entity Framework Core
- RESTful Web API
- Swagger API documentation
- Dependency Injection
- Service layer architecture

## Tech Stack
C#, .NET 8, ASP.NET Core Web API, Entity Framework Core, SQL Server, Git/GitHub.

## Run
1. Install .NET 8 SDK and SQL Server LocalDB.
2. Open the solution.
3. Run:
   `dotnet restore`
4. Create the database:
   `dotnet ef migrations add InitialCreate --project EmployeeManagementSystem.API`
   `dotnet ef database update --project EmployeeManagementSystem.API`
5. Run:
   `dotnet run --project EmployeeManagementSystem.API`
6. Open the Swagger URL shown in the terminal.

## Resume description
Developed an Employee Management System using C#, ASP.NET Core Web API, Entity Framework Core and SQL Server, implementing RESTful CRUD APIs, employee/department management, leave workflows, validation, search and service-layer architecture.
