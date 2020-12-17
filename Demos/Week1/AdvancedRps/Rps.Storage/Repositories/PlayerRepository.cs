using System.Linq;

using Rps.Storage.Abstracts;
using Rps.Storage.Models;

namespace Rps.Storage.Repository {
	public class PlayerRepository : ARepository<Player> {
		public PlayerRepository(AContext context) : base(context) {}
		public bool ExistsByHandle(string handle) {
			return Context.Set<Player>().Any(p => p.Handle == handle);
		}
	}
}
