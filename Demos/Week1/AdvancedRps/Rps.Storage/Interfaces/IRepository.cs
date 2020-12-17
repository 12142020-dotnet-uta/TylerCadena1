using System.Collections.Generic;

using Rps.Domain.Interfaces;

namespace Rps.Storage.Interfaces {
	public interface IRepository<T> where T : IModel {
		List<T> All();
		T Get(int ID);
		bool Post(T model);
		bool Put(T model);
		bool Delete(T model);
	}
}
