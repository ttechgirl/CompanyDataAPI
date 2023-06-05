using CompanyDataAPI;

var builder = WebApplication.CreateBuilder(args)
    .RegisterServices()
    .RegisterDI();

var app = builder.Build();

app.ConfigureMiddleware();
app.MapControllers();

app.Run();
