using Janken.Runtime.Contexts;
using Janken.Runtime.Models;

namespace Janken.Runtime.Repositories {
	public class MatchRepository : Repository<Match> {
		public MatchRepository(DatabaseContext db) : base(db) {}
	}
}
