using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Thor.WebApi.Managers;
using Thor.WebApi.Models;
using Thor.WebApi.Requests;
using Thor.WebApi.ViewModels;

namespace Thor.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : Controller
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly IEmployeesManager _employeesManager;
    private readonly IMapper _mapper;

    public EmployeesController(ILogger<EmployeesController> logger, 
        IEmployeesManager employeesManager,
        IMapper mapper)
    {
        _logger = logger;
        _employeesManager = employeesManager;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _employeesManager.GetAllEmployees();
        var vm = employees.Select(e => _mapper.Map<EmployeeViewModel>(e)).ToList();
        return Ok(vm);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(AddEmployeeRequest request)
    {
        var addEmployee = new AddEmployee(request.Name, request.Position, request.Salary);
        var res = await _employeesManager.AddEmployee(addEmployee);
        return Ok(res);
    }
}