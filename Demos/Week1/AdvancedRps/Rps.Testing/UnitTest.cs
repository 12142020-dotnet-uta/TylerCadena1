using Microsoft.EntityFrameworkCore;
using Xunit;

using Rps.Storage.Contexts;
using Rps.Storage.Models;
using Rps.Storage.Repository;

namespace Rps.Testing {
	public class UnitTest {
		[Fact]
		public void ComputerPlayer() {
			var options = new DbContextOptionsBuilder<InMemoryContext>()
				.UseInMemoryDatabase(databaseName: "computerplayerdb")
				.Options;
			InMemoryContext context = new InMemoryContext(options);
			PlayerRepository repository = new PlayerRepository(context);
			Player player = repository.GetComputerPlayer();
			Assert.NotNull(player);
			Assert.Equal(1, player.PlayerID);
			Assert.Equal("CPU", player.Handle);
			Assert.Equal("CPU", player.Password);
		}
	}
}
