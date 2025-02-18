using Microsoft.EntityFrameworkCore;
using VineyardAPI.Data;
using VineyardAPI.Interfaces.Repositories;
using VineyardAPI.Interfaces.Services;
using VineyardAPI.Repositories;
using VineyardAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VineyardContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddTransient<DataBaseSeeder>();

builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();
builder.Services.AddScoped<IGrapeRepository, GrapeRepository>();
builder.Services.AddScoped<IVineyardRepository, VineyardRepository>();

builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IGrapeService, GrapeService>();
builder.Services.AddScoped<IVineyardService, VineyardService>();




var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataBaseSeeder>();
    seeder.Seed();
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
