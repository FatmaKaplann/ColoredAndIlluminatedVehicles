using DataAccess;
using AlphaStellar.Controllers;
using Microsoft.EntityFrameworkCore;
using Business;

namespace AlphaStellar;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<CarService>();
        builder.Services.AddScoped<BusService>();
        builder.Services.AddScoped<BoatService>();

        var connStr = builder.Configuration.GetConnectionString("Local");
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer(connStr);
        }, ServiceLifetime.Scoped);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}