using RestService.Data;
using RestService.DatabaseDriver;
using RestService.DataMapper;
using RestService.Endpoint;

namespace RestService;

public static class Services
{
    private static readonly string _connectionString = "Data Source=(local);Initial Catalog=Calendar;Integrated Security=SSPI";
    
    public static void InitServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IDatabaseDriver>(new MSSQLDriver(_connectionString));
        builder.Services.AddSingleton<IDataMapper<User>>(new UserMapper());
        builder.Services.AddSingleton<UserEndpoint>();
    }
}