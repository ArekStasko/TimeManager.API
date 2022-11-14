using TimeManager.DATA.Data;
using TimeManager.DATA.Data.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TimeManager.DATA.Services.interfaces;
using TimeManager.DATA.Services;
using TimeManager.DATA.Services.Publisher;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.Seq("http://seq:5341")
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IActivityProcessors, ActivityProcessors>();
builder.Services.AddScoped<ICategoryProcessors, CategoryProcessors>();
builder.Services.AddScoped<IPublisher, publisher>();

var app = builder.Build();

DatabaseManagerService.MigrationInitialization(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

