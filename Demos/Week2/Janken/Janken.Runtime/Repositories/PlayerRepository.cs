using System.Linq;

using Janken.Runtime.Contexts;
using Janken.Runtime.Models;

namespace Janken.Runtime.Repositories {
	public class PlayerRepository : Repository<Player> {
		public PlayerRepository(DatabaseContext db) : base(db) {}
		public Player GetComputer() {
			return Db.Set<Player>().Single(p => p.Computer);
		}
		public bool HandleExists(string handle) {
			return Db.Set<Player>().Any(p => p.Handle == handle);
		}
	}
}
