using System.Collections.Generic;
using System.Linq;

using Rps.Domain.Models;
using Rps.Storage.Abstracts;
using Rps.Storage.Contexts;

namespace Rps.Storage.Repository {
	public class PlayerRepository : ARepository<Player> {
		public PlayerRepository(MainContext context) : base(context) {}
		public override List<Player> All() {
			return Context.Set<Player>().ToList();
		}
		public override Player Get(int ID) {
			return Context.Set<Player>().SingleOrDefault(p => p.ID == ID);
		}
		public bool ExistsByHandle(string handle) {
			return Context.Set<Player>().Any(p => p.Handle == handle);
		}
	}
}
