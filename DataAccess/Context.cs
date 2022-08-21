using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class Context : DbContext
{
	public Context(DbContextOptions<Context> options) : base(options)
	{
		
	}

	public DbSet<Bus> Buses { get; set; }
	public DbSet<Car> Cars { get; set; }
	public DbSet<Boat> Boats { get; set; }
}