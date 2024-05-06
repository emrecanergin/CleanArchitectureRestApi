using StackExchange.Redis;

namespace Application.Redis
{
    public interface IRedisService
    {
       IDatabase Database(int databaseId);
       void FlushDatabase(int databaseId);
    }
}
