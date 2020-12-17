using System.Collections.Generic;
using System.Linq;

using Rps.Storage.Interfaces;

namespace Rps.Storage.Abstracts {
	public abstract class ARepository<T> : IRepository<T> where T : AModel {
		protected AContext Context;
		public ARepository(AContext context) {
			Context = context;
		}
		public virtual List<T> All() {
			return Context.Set<T>().ToList();
		}
		public virtual T Get(int ID) {
			return Context.Set<T>().SingleOrDefault(m => m.GetID() == ID);
		}
		public virtual bool Post(T model) {
			Context.Set<T>().Add(model);
			return Context.SaveChanges() >= 1;
		}
		public virtual bool Put(T model) {
			Context.Set<T>().Update(model);
			return Context.SaveChanges() >= 1;
		}
		public virtual bool Delete(T model) {
			Context.Set<T>().Remove(model);
			return Context.SaveChanges() >= 1;
		}
		public bool Exists(int ID) {
			return Context.Set<T>().Any(m => m.GetID() == ID);
		}
	}
}
