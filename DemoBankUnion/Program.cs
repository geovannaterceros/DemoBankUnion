using DemoBank.BL.Interfaces;
using DemoBank.BL.Resources;
using DemoBank.DAL.Database;
using DemoBank.DAL.Interfaces;
using DemoBank.DAL.Resources;
using DemoBank.Models.Models;
using Microsoft.EntityFrameworkCore;
using static DemoBank.BL.Resources.ClientService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DatabaseConfiguration
builder.Services.AddDbContext<ProjectContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDB")));

//Data Access
builder.Services.AddScoped<IDataAccess<ClientDto>, ClientDataAccess>();
builder.Services.AddScoped<IDataAccess<AccountOpeningDto>, AccountOpeningDataAccess>();

//Bussiness Logic
builder.Services.AddScoped<IServices<ClientDto>, ClientsService>();
builder.Services.AddScoped<IServices<AccountOpeningDto>, AccountOpeningService>();

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProjectContext>();
    context.Database.Migrate();
}

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
