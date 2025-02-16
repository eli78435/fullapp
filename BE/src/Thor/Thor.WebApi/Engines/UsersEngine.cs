using System.Collections.Immutable;
using Thor.WebApi.Accessors;
using Thor.WebApi.Models;

namespace Thor.WebApi.Engines;

internal class UsersEngine : IUsersEngine
{
    private readonly ILogger _logger;
    private readonly IUsersRepository _usersRepository;

    public UsersEngine(ILogger<UsersEngine> logger, IUsersRepository usersRepository)
    {
        _logger = logger;
        _usersRepository = usersRepository;
    }
    
    public Task<string> AddUser(User newUser)
    {
        return _usersRepository.AddUser(newUser);
    }

    public Task<ImmutableList<User>> GetAllUsers()
    {
        return _usersRepository.GetAllUsers();
    }
}