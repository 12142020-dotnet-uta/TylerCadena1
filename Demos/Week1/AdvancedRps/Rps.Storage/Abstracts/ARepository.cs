using System.Collections.Generic;
using System.Linq;

using Rps.Domain.Abstracts;
using Rps.Storage.Interfaces;
using Rps.Storage.Contexts;

namespace Rps.Storage.Abstracts {
	public abstract class ARepository<T> : IRepository<T> where T : AModel {
		protected MainContext Context;
		public ARepository(MainContext context) {
			Context = context;
		}
		public abstract List<T> All();
		public abstract T Get(int ID);
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
