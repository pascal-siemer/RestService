using System.Data.SqlClient;
using RestService.DataMapper;

namespace RestService.DatabaseDriver;

public class MSSQLDriver : IDatabaseDriver, IDisposable
{
    private SqlConnection _connection;
    
    public MSSQLDriver(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
    
    public async IAsyncEnumerable<T> Read<T>(string query, IDataMapper<T> dataMapper)
    {
        await _connection.OpenAsync();
        
        await using var reader = await new SqlCommand(query, _connection).ExecuteReaderAsync();
        
        while (await reader.ReadAsync())
        {
            yield return dataMapper.Map(reader);
        }

        await _connection.CloseAsync();
    }

}
