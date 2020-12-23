using System.Linq;

using Microsoft.EntityFrameworkCore;

using Janken.Domain.Models;

namespace Janken.Domain.Repositories {
	public class ChoiceRepository : Repository<Choice> {
		public ChoiceRepository(DbContext db) : base(db) {}
		public Choice Get(ChoiceType type) {
			int v = (int)type;
			return Db.Set<Choice>().Single(c => c.Value == v);
		}
	}
}
