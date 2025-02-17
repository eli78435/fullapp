namespace Thor.WebApi.Models;

public record Employee(int Id, string Name, string Position, decimal Salary);

public record AddEmployee(string Name, string Position, decimal Salary);