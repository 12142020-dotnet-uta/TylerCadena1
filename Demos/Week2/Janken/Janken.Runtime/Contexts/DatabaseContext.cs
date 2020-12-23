using Microsoft.EntityFrameworkCore;

using Janken.Runtime.Models;

namespace Janken.Runtime.Contexts {
	public class DatabaseContext : DbContext {
		private DbSet<Player> Players;
		private DbSet<Choice> Choices;
		private DbSet<Round> Rounds;
		private DbSet<Match> Matches;
		protected override void OnConfiguring(DbContextOptionsBuilder builder) {
			builder.UseSqlServer(@"server=localhost,1433;database=jankendb;user id=sa;password=Password12345;");
		}
		protected override void OnModelCreating(ModelBuilder builder) {
			Player[] players = Player.GenerateSeededData();
			builder.Entity<Player>().HasData(players);
			Choice[] choices = Choice.GenerateSeededData();
			builder.Entity<Choice>().HasData(choices);
		}
	}
}
