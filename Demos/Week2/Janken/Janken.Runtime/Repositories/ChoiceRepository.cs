using System.Linq;

using Janken.Runtime.Contexts;
using Janken.Runtime.Models;

namespace Janken.Runtime.Repositories {
	public class ChoiceRepository : Repository<Choice> {
		public ChoiceRepository(DatabaseContext db) : base(db) {}
		public Choice Get(ChoiceType type) {
			int v = (int)type;
			return Db.Set<Choice>().Single(c => c.Value == v);
		}
	}
}
