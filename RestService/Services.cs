using RestService.Data;
using RestService.DatabaseDriver;
using RestService.DataMapper;
using RestService.Endpoint;

namespace RestService;

public static class Services
{
    private static readonly string _mssqlConnectionString = "Data Source=(local);Initial Catalog=Calendar;Integrated Security=SSPI";
    private static readonly string _sqliteConnectionString = "Data Source=/Users/pascal-siemer/Database/Sqlite/database.db";
    
    public static void InitServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IDatabaseDriver>(new SqliteDriver(_sqliteConnectionString));
        builder.Services.AddSingleton<IDataMapper<User>>(new UserMapper());
        builder.Services.AddSingleton<UserEndpoint>();
    }
}