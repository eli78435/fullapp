using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Thor.WebApi.Common;
using Thor.WebApi.Managers;
using Thor.WebApi.Requests;
using Thor.WebApi.Models;
using Thor.WebApi.ViewModels;

namespace Thor.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IUsersManager _usersManager;
    private readonly IIdGenerator _idGenerator;

    public UsersController(ILogger<UsersController> logger,
        IMapper mapper,
        IUsersManager usersManager,
        IIdGenerator idGenerator)
    {
        _logger = logger;
        _mapper = mapper;
        _usersManager = usersManager;
        _idGenerator = idGenerator;
    }

    [HttpGet("operations/isAlive")]
    public async Task<IActionResult> IsAlive()
    {
        await Task.CompletedTask;
        return Ok($"alive {DateTime.Now}");
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _usersManager.GetAllUsers();
        var viewModels = users.Select(u => _mapper.Map<UserViewModel>(u)).ToList();
        return Ok(viewModels);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewUser([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest();
        }
        
        var user = new User(_idGenerator.GenerateId(), 
                    request.FirstName,
                    request.LastName,
            request.UserName, 
            request.Email,
            request.Password, 
            Roles.User);
        
        try
        {
            await _usersManager.AddUser(user);
            return Ok($"User {request.UserName} registered successfully.");
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}