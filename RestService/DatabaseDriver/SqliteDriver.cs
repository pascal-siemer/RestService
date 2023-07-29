using Microsoft.Data.Sqlite;
using RestService.DataMapper;

namespace RestService.DatabaseDriver;

public class SqliteDriver: IDatabaseDriver, IDisposable, IAsyncDisposable
{
    private SqliteConnection _connection;

    public SqliteDriver(string connectionString)
    {
        _connection = new(connectionString);
        _connection.ConnectionString = connectionString;
    }
    
    public async IAsyncEnumerable<T> Read<T>(string query, IDataMapper<T> dataMapper)
    {
        await _connection.OpenAsync();

        var reader = await CreateReaderAsync(query);

        while (await reader.ReadAsync())
        {
            yield return dataMapper.Map(reader);
        }

        await _connection.CloseAsync();
    }

    private Task<SqliteDataReader> CreateReaderAsync(string query)
    {
        var command = _connection.CreateCommand();
        command.CommandText = query;
        return command.ExecuteReaderAsync();
    }

    public void Dispose()
    {
        _connection.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _connection.DisposeAsync();
    } 
    
}