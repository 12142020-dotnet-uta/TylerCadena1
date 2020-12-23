using Microsoft.EntityFrameworkCore;

using Janken.Domain.Models;

namespace Janken.Domain.Contexts {
	public class DatabaseContext : DbContext {
		private DbSet<Player> Players;
		private DbSet<Choice> Choices;
		private DbSet<Round> Rounds;
		private DbSet<Match> Matches;
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
		public DatabaseContext() {}
		protected override void OnModelCreating(ModelBuilder builder) {
			Player[] players = Player.GenerateSeededData();
			builder.Entity<Player>().HasData(players);
			Choice[] choices = Choice.GenerateSeededData();
			builder.Entity<Choice>().HasData(choices);
		}
	}
}
