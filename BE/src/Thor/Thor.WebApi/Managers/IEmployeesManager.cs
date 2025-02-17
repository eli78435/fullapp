using System.Collections.Immutable;
using Thor.WebApi.Common;
using Thor.WebApi.Engines;
using Thor.WebApi.Models;
using Thor.WebApi.Requests;

namespace Thor.WebApi.Managers;

public interface IEmployeesManager
{
    Task<ImmutableList<Employee>> GetAllEmployees();
    Task<int?> AddEmployee(AddEmployee newEmployee);
}

internal class EmployeesManager : IEmployeesManager
{
    private readonly IEmployeesEngine _engine;

    public EmployeesManager(IEmployeesEngine engine)
    {
        _engine = engine;
    }
    
    public Task<ImmutableList<Employee>> GetAllEmployees()
    {
        return _engine.GetAllEmployees();
    }

    public Task<int?> AddEmployee(AddEmployee newEmployee)
    {
        return _engine.AddEmployee(newEmployee);
    }
}

