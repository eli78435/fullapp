using System.Collections.Immutable;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Thor.WebApi.Accessors;
using Thor.WebApi.Infrastructure.Accessors.MySql.Dal;
using Thor.WebApi.Models;

namespace Thor.WebApi.Infrastructure.Accessors.MySql;

public class MySqlUsersRepository : IUsersRepository
{
    private readonly ILogger<MySqlUsersRepository> _logger;
    private readonly IMapper _mapper;
    private readonly MySqlDbContext _context;

    public MySqlUsersRepository(ILogger<MySqlUsersRepository> logger,
        IMapper mapper,
        MySqlDbContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }

    public async Task<string> AddUser(User newUser)
    {
        var userDal = _mapper.Map<UserDal>(newUser);
        var res = await _context.Users.AddAsync(userDal);
        await _context.SaveChangesAsync();
        return res.Entity.Id;
    }

    public async Task<ImmutableList<User>> GetAllUsers()
    {
        var res = await _context.Users.ToListAsync();
        return res.Select(_mapper.Map<User>).ToImmutableList();
    }
}