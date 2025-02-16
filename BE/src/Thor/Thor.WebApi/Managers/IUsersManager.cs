using System.Collections.Immutable;
using Thor.WebApi.Models;

namespace Thor.WebApi.Managers;

public interface IUsersManager
{
    Task<string> AddUser(User newUser);
    Task<ImmutableList<User>> GetAllUsers();
}