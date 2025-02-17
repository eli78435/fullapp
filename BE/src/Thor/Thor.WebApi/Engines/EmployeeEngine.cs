using System.Collections.Immutable;
using Thor.WebApi.Accessors;
using Thor.WebApi.Models;

namespace Thor.WebApi.Engines;

public interface IEmployeesEngine
{
    Task<ImmutableList<Employee>> GetAllEmployees();
    Task<int?> AddEmployee(AddEmployee newEmployee);
}

internal class EmployeeEngine : IEmployeesEngine
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeEngine(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public Task<ImmutableList<Employee>> GetAllEmployees()
    {
        return _employeeRepository.GetAllEmployees();
    }
    
    public Task<int?> AddEmployee(AddEmployee newEmployee)
    {
        return _employeeRepository.AddEmployee(newEmployee);
    }
}