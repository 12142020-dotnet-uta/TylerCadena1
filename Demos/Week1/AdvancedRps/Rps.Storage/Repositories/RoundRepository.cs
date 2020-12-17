using System.Collections.Generic;
using System.Linq;

using Rps.Domain.Models;
using Rps.Storage.Abstracts;
using Rps.Storage.Contexts;

namespace Rps.Storage.Repository {
	public class RoundRepository : ARepository<Round> {
		public RoundRepository(MainContext context) : base(context) {}
		public override List<Round> All() {
			return Context.Set<Round>().ToList();
		}
		public override Round Get(int ID) {
			return Context.Set<Round>().SingleOrDefault(r => r.ID == ID);
		}
	}
}
