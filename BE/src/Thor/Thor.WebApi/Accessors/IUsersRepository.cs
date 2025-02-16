using System.Collections.Immutable;
using Thor.WebApi.Models;

namespace Thor.WebApi.Accessors;

public interface IUsersRepository
{
    Task<string> AddUser(User newUser);
    Task<ImmutableList<User>> GetAllUsers();
}