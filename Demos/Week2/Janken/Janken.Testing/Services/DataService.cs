using Janken.Domain.Contexts;
using Janken.Domain.Repositories;

using Janken.Testing.Factories;

namespace Janken.Testing.Services {
	public class DataService {
		private DatabaseContextFactory Factory;
		private DatabaseContext Db;
		public PlayerRepository Players;
		public ChoiceRepository Choices;
		public RoundRepository Rounds;
		public MatchRepository Matches;
		public DataService() {
			Factory = new DatabaseContextFactory();
			string[] args = new string[] {};
			Db = Factory.CreateDbContext(args);
			Db.Database.EnsureDeleted();
			Db.Database.EnsureCreated();
			Players = new PlayerRepository(Db);
			Choices = new ChoiceRepository(Db);
			Rounds = new RoundRepository(Db);
			Matches = new MatchRepository(Db);
		}
	}
}
