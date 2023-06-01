using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// this enables us to access the values stored in appsettings.json in our code using the IConfiguration interface and accessing _configuration[KeyName]
builder.Configuration
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);

var connectionStringBuilder = new NpgsqlConnectionStringBuilder();
connectionStringBuilder.ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
connectionStringBuilder.Username = builder.Configuration["PostgreSqlConnection:UserID"];
connectionStringBuilder.Password = builder.Configuration["PostgreSqlConnection:Password"];

builder.Services.AddDbContext<CommandContext>(options =>
    options.UseNpgsql(connectionStringBuilder.ConnectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<ICommandAPIRepo, CommandAPIRepo>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.MapGet("/", () => "Hello World!!");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();