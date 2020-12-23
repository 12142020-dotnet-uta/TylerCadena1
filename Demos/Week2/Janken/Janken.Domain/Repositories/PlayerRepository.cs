using System.Linq;

using Microsoft.EntityFrameworkCore;

using Janken.Domain.Models;

namespace Janken.Domain.Repositories {
	public class PlayerRepository : Repository<Player> {
		public PlayerRepository(DbContext db) : base(db) {}
		public Player GetComputer() {
			return Db.Set<Player>().Single(p => p.Computer);
		}
		public Player GetByHandleAndPassword(string handle, string password) {
			return Db.Set<Player>().SingleOrDefault(p => p.Handle == handle && p.Password == password);
		}
		public bool HandleExists(string handle) {
			return Db.Set<Player>().Any(p => p.Handle == handle);
		}
	}
}
