using Microsoft.EntityFrameworkCore;

using Rps.Storage.Abstracts;

namespace Rps.Storage.Contexts {
	public class SqliteContext : AContext {
		public SqliteContext() : base() {}
		protected override void OnConfiguring(DbContextOptionsBuilder options) {
			options.UseSqlite("Data Source=record.db");
		}
	}
}
