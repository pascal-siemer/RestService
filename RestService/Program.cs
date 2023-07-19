using RestService;

var builder = WebApplication.CreateBuilder(args);
Services.InitServices(builder);

var app = builder.Build();
Router.InitRoutes(app);

app.Run();