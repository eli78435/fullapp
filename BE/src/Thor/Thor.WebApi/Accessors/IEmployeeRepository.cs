using System.Collections.Immutable;
using Thor.WebApi.Models;

namespace Thor.WebApi.Accessors;

public interface IEmployeeRepository
{
    Task<ImmutableList<Employee>> GetAllEmployees();
    Task<int?> AddEmployee(AddEmployee newEmployee);
}