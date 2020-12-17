using Microsoft.EntityFrameworkCore;

using Rps.Storage.Abstracts;

namespace Rps.Storage.Contexts {
	public class SqlServerContext : AContext {
		public SqlServerContext(DbContextOptions options) : base(options) {}
	}
}
