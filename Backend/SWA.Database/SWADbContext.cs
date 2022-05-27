using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace SWA.Database
{
	public class SWADbContext : DbContext
	{
		public SWADbContext(DbContextOptions<SWADbContext> options) : base(options) { }

		public DbSet<UserInfo>? UserInfo { get; set; }
		public DbSet<UserAuthData>? UserAuthData { get; set; }
		public DbSet<Roles>? Roles { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
