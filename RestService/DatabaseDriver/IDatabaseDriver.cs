using RestService.DataMapper;

namespace RestService.DatabaseDriver;

public interface IDatabaseDriver
{
    public IAsyncEnumerable<T> Read<T>(string query, IDataMapper<T> dataMapper);
}