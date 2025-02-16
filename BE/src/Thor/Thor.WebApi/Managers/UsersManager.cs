using System.Collections.Immutable;
using Microsoft.AspNetCore.Identity;
using Thor.WebApi.Engines;
using Thor.WebApi.Models;

namespace Thor.WebApi.Managers;

internal class UsersManager : IUsersManager
{
    private readonly ILogger<UsersManager> _logger;
    private readonly IUsersEngine _usersEngine;

    public UsersManager(ILogger<UsersManager> logger, IUsersEngine usersEngine)
    {
        _logger = logger;
        _usersEngine = usersEngine;
    }
    
    public async Task<string> AddUser(User newUser)
    {
        var userId = await _usersEngine.AddUser(newUser);
        return userId;
    }

    public Task<ImmutableList<User>> GetAllUsers()
    {
        return _usersEngine.GetAllUsers();
    }
}