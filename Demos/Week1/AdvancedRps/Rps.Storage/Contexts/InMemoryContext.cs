using Microsoft.EntityFrameworkCore;

using Rps.Storage.Abstracts;

namespace Rps.Storage.Contexts {
	public class InMemoryContext : AContext {
		public InMemoryContext() : base() {}
		protected override void OnConfiguring(DbContextOptionsBuilder options) {
			// options.UseInMemoryDatabase("rps-testing");
		}
	}
}
