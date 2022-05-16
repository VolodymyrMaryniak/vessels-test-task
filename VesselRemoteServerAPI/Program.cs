using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VesselRemoteServerAPI.Data;
using VesselRemoteServerAPI.Data.Entities;
using VesselRemoteServerAPI.Data.Repositories;
using VesselRemoteServerAPI.Services;
using VesselRemoteServerAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Vessel Remote Server API"
    });
});
builder.Services.AddDbContext<VesselDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VesselDatabase")));
builder.Services.AddTransient<IVesselDataRepository, VesselDataRepository>();
builder.Services.AddTransient<IVesselDataService, VesselDataService>();

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
