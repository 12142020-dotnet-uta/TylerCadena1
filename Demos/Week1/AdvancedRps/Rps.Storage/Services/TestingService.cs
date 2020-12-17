using Rps.Storage.Abstracts;
using Rps.Storage.Contexts;
using Rps.Storage.Repository;

namespace Rps.Storage.Services {
	public class TestingService {
		private AContext Context;
		public PlayerRepository Players;
		public RoundRepository Rounds;
		public TestingService() {
			Context = new InMemoryContext();
			Players = new PlayerRepository(Context);
			Rounds = new RoundRepository(Context);
		}
	}
}
