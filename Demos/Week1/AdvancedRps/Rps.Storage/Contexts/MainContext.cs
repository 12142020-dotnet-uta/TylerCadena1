using Microsoft.EntityFrameworkCore;
using Rps.Domain.Models;

namespace Rps.Storage.Contexts {
	public class MainContext : DbContext {
		private DbSet<Player> Players { get; set; }
		private DbSet<Round> Rounds { get; set; }
		public MainContext(DbContextOptions options) : base(options) {}
		protected override void OnModelCreating(ModelBuilder builder) {
			// Seeding data
			Player[] players = new Player[] {
				new Player() {
					ID = 1,
					Handle = "CPU",
					Password = "CPU",
					Computer = true
				}
			};
			builder.Entity<Player>().HasData(players);
		}
	}
}
