using Microsoft.EntityFrameworkCore;

using Janken.Domain.Models;

namespace Janken.Domain.Repositories {
	public class RoundRepository : Repository<Round> {
		public RoundRepository(DbContext db) : base(db) {}
	}
}
