using Janken.Runtime.Contexts;
using Janken.Runtime.Models;

namespace Janken.Runtime.Repositories {
	public class RoundRepository : Repository<Round> {
		public RoundRepository(DatabaseContext db) : base(db) {}
	}
}
