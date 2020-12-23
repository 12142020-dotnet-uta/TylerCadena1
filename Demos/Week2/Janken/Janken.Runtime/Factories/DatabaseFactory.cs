using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Janken.Domain.Contexts;

namespace Janken.Runtime.Factories {
	public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext> {
		public DatabaseContext CreateDbContext(string[] args) {
			var options = new DbContextOptionsBuilder<DatabaseContext>()
				.UseSqlServer(@"server=localhost,1433;database=jankendb;user id=sa;password=Password12345;")
				.Options;
			return new DatabaseContext(options);
		}
	}
}
