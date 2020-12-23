using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Janken.Domain.Contexts;

namespace Janken.Testing.Factories {
	public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext> {
		public DatabaseContext CreateDbContext(string[] args) {
			var options = new DbContextOptionsBuilder<DatabaseContext>()
				.UseInMemoryDatabase("InMemory")
				.Options;
			return new DatabaseContext(options);
		}
	}
}
