using Rps.Storage.Contexts;
using Rps.Storage.Repository;

namespace Rps.Storage.Services {
	public class WebAppService {
		private PlayerRepository Players;
		private RoundRepository Rounds;
		public WebAppService(SqliteContext context) {
			Players = new PlayerRepository(context);
			Rounds = new RoundRepository(context);
		}
		// TODO: Write API Functions
	}
}
