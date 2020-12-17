using Microsoft.EntityFrameworkCore;
using Rps.Storage.Models;

namespace Rps.Storage.Abstracts {
	public abstract class AContext : DbContext {
		private DbSet<Player> Players { get; set; }
		private DbSet<Round> Rounds { get; set; }
		public AContext() : base() {}
		public AContext(DbContextOptions options) : base(options) {}
		protected override void OnModelCreating(ModelBuilder builder) {
			// Seed data
			Player[] players = Player.GenerateSeededData();
			builder.Entity<Player>().HasData(players);
		}
	}
}
