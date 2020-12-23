using Microsoft.EntityFrameworkCore;

using Rps.Storage.Abstracts;
using Rps.Storage.Contexts;
using Rps.Storage.Repository;

namespace Rps.Storage.Services {
	public class TestingService {
		private AContext Context;
		public PlayerRepository Players;
		public RoundRepository Rounds;
		public TestingService(string dbName) {
			DbContextOptionsBuilder<InMemoryContext> builder = new DbContextOptionsBuilder<InMemoryContext>();
			DbContextOptions<InMemoryContext> options = builder.UseInMemoryDatabase(databaseName: dbName).Options;
			Context = new InMemoryContext(options);
			Players = new PlayerRepository(Context);
			Rounds = new RoundRepository(Context);
		}
	}
}
