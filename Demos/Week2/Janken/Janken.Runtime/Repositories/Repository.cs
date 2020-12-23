using System;
using System.Collections.Generic;
using System.Linq;

using Janken.Runtime.Contexts;
using Janken.Runtime.Models;

namespace Janken.Runtime.Repositories {
	public abstract class Repository<T> where T : Model {
		protected DatabaseContext Db;
		public Repository(DatabaseContext db) {
			Db = db;
		}
		public virtual List<T> All() {
			return Db.Set<T>().ToList();
		}
		public virtual T Get(Guid id) {
			return Db.Set<T>().SingleOrDefault(m => m.GetId() == id);
		}
		public virtual bool Create(T model) {
			Db.Set<T>().Add(model);
			return Db.SaveChanges() >= 1;
		}
		public virtual bool Update(T model) {
			Db.Set<T>().Update(model);
			return Db.SaveChanges() >= 1;
		}
		public virtual bool Remove(T model) {
			Db.Set<T>().Remove(model);
			return Db.SaveChanges() >= 1;
		}
		public bool Exists(Guid id) {
			return Db.Set<T>().Any(m => m.GetId() == id);
		}
	}
}
