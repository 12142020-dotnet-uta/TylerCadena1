using Rps.Storage.Contexts;
using Rps.Storage.Repository;

namespace Rps.Storage.Services {
	public class DataService {
		public PlayerRepository Players;
		public RoundRepository Rounds;
		public DataService(MainContext context) {
			Players = new PlayerRepository(context);
			Rounds = new RoundRepository(context);
		}
	}
}
