using Rps.Storage.Abstracts;
using Rps.Storage.Contexts;
using Rps.Storage.Repository;

namespace Rps.Storage.Services {
	public class LocalService {
		private AContext Context;
		public PlayerRepository Players;
		public RoundRepository Rounds;
		public LocalService() {
			Context = new SqliteContext();
			Players = new PlayerRepository(Context);
			Rounds = new RoundRepository(Context);
		}
	}
}
