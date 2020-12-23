using Microsoft.EntityFrameworkCore;

using Rps.Storage.Abstracts;

namespace Rps.Storage.Contexts {
	public class InMemoryContext : AContext {
		public InMemoryContext(DbContextOptions options) : base(options) {}
		protected override void OnModelCreating(ModelBuilder builder) {}
	}
}
