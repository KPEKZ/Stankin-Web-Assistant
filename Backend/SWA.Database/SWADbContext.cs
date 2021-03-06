using Microsoft.EntityFrameworkCore;
using Backend.Models;
using SWA.Database.Models;

namespace SWA.Database
{
	public class SWADbContext : DbContext
	{
		public SWADbContext(DbContextOptions<SWADbContext> options) : base(options) { }

		public DbSet<UserInfo>? UserInfo { get; set; }
		public DbSet<Problem>? Problem { get; set; }
		public DbSet<Reference>? Reference { get; set; }
		public DbSet<News>? News { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
