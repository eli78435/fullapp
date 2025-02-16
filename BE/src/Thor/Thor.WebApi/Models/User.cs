namespace Thor.WebApi.Models;

public record User(string Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string Role);