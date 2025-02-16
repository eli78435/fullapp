using Microsoft.EntityFrameworkCore;
using Thor.WebApi.Infrastructure.Accessors.MySql.Dal;

namespace Thor.WebApi.Infrastructure.Accessors.MySql;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

    public DbSet<UserDal> Users { get; set; }
}
