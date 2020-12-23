using Janken.Runtime.Contexts;
using Janken.Runtime.Repositories;

namespace Janken.Runtime.Services {
	public class DataService {
		private DatabaseContext Db;
		public PlayerRepository Players;
		public ChoiceRepository Choices;
		public RoundRepository Rounds;
		public MatchRepository Matches;
		public DataService() {
			Db = new DatabaseContext();
			Players = new PlayerRepository(Db);
			Choices = new ChoiceRepository(Db);
			Rounds = new RoundRepository(Db);
			Matches = new MatchRepository(Db);
		}
	}
}
