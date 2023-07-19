
using RestService.Data;
using RestService.DatabaseDriver;
using RestService.DataMapper;
using RestService.Endpoint;


var connectionString = "Data Source=(local);Initial Catalog=Calendar;Integrated Security=SSPI";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IDatabaseDriver>(new MSSQLDriver(connectionString));
builder.Services.AddSingleton<IDataMapper<User>>(new UserMapper());
builder.Services.AddSingleton<UserEndpoint>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/users", (UserEndpoint endpoint) => endpoint.Get().ToString());
app.Run();