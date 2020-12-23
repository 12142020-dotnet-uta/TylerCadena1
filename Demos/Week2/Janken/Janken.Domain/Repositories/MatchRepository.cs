using Microsoft.EntityFrameworkCore;

using Janken.Domain.Models;

namespace Janken.Domain.Repositories {
	public class MatchRepository : Repository<Match> {
		public MatchRepository(DbContext db) : base(db) {}
	}
}
