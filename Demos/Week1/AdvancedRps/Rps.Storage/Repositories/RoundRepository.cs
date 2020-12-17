using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using Rps.Storage.Abstracts;
using Rps.Storage.Models;

namespace Rps.Storage.Repository {
	public class RoundRepository : ARepository<Round> {
		public RoundRepository(AContext context) : base(context) {}
		public override List<Round> All() {
			return Context.Set<Round>()
				.Include(r => r.Winner)
				.Include(r => r.Loser)
				.ToList();
		}
	}
}
