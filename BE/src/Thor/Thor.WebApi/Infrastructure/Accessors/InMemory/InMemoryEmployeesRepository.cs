using System.Collections.Immutable;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Thor.WebApi.Accessors;
using Thor.WebApi.Infrastructure.Accessors.InMemory.Dal;
using Thor.WebApi.Models;

namespace Thor.WebApi.Infrastructure.Accessors.InMemory;

public class InMemoryEmployeesRepository : IEmployeeRepository
{
    private readonly ILogger<InMemoryEmployeesRepository> _logger;
    private readonly IMapper _mapper;
    private readonly InMemoryContext _context;

    public InMemoryEmployeesRepository(ILogger<InMemoryEmployeesRepository> logger, 
        IMapper mapper,
        InMemoryContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ImmutableList<Employee>> GetAllEmployees()
    {
        var res = await _context.Employees.ToListAsync();
        var employees = res.Select(d => _mapper.Map<Employee>(d)).ToList();
        return employees.ToImmutableList();
    }

    public async Task<int?> AddEmployee(AddEmployee newEmployee)
    {
        var dal = new EmployeeDal
        {
            Name = newEmployee.Name,
            Position = newEmployee.Position,
            Salary = newEmployee.Salary
        };
        
        var res = await _context.Employees.AddAsync(dal);
        await _context.SaveChangesAsync();
        return res.Entity.Id;
    }
}