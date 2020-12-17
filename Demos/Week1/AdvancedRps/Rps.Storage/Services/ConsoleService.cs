using Rps.Storage.Abstracts;
using Rps.Storage.Contexts;
using Rps.Storage.Repository;

namespace Rps.Storage.Services {
	public class ConsoleService {
		private AContext Context;
		public PlayerRepository Players;
		public RoundRepository Rounds;
		public ConsoleService() {
			Context = new SqliteContext();
			Players = new PlayerRepository(Context);
			Rounds = new RoundRepository(Context);
		}
	}
}
