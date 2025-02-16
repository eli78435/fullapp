using System.Collections.Immutable;
using Thor.WebApi.Models;

namespace Thor.WebApi.Engines;

public interface IUsersEngine
{
    Task<string> AddUser(User newUser);
    Task<ImmutableList<User>> GetAllUsers();
}