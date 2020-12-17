using System.Linq;

using Rps.Storage.Abstracts;
using Rps.Storage.Models;

namespace Rps.Storage.Repository {
	public class PlayerRepository : ARepository<Player> {
		public PlayerRepository(AContext context) : base(context) {}
		public bool ExistsByHandle(string handle) {
			return Context.Set<Player>().Any(p => p.Handle == handle);
		}
		public Player GetByHandleAndPassword(string handle, string password) {
			return Context.Set<Player>().SingleOrDefault(p => p.Handle == handle && p.Password == password);
		}
		public Player GetComputerPlayer() {
			return Context.Set<Player>().SingleOrDefault(p => p.Computer);
		}
	}
}
