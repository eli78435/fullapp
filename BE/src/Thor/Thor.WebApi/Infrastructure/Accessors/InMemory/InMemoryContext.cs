using Microsoft.EntityFrameworkCore;
using Thor.WebApi.Infrastructure.Accessors.InMemory.Dal;
using Thor.WebApi.Infrastructure.Accessors.MySql.Dal;

namespace Thor.WebApi.Infrastructure.Accessors.InMemory;

public class InMemoryContext : DbContext
{
    public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
    {}
    
    public DbSet<EmployeeDal> Employees { get; set; }
    public DbSet<UserDal> Users { get; set; }
}