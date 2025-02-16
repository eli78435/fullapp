using Thor.WebApi.Common;

namespace Thor.WebApi.Infrastructure;

public class MySqlIdGenerator : IIdGenerator
{
    public string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}