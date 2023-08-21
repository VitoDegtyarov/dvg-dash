using dvg.Data;
using dvg.Data.Repositories;
using dvg.Data.Repositories.Interfaces;
using dvg.Data.UnitOfWork;
using dvg.Mappers;
using dvg.Services;
using dvg.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDesignerRepository, DesignerRepository>();
builder.Services.AddScoped<Lazy<IDesignerRepository>>(provider => 
    new Lazy<IDesignerRepository>(provider.GetRequiredService<IDesignerRepository>));
builder.Services.AddScoped<IDesignerService, DesignerService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<Lazy<IClientRepository>>(provider => 
    new Lazy<IClientRepository>(provider.GetRequiredService<IClientRepository>));
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

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