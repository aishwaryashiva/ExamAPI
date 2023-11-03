using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repositories
{
	public interface IRepository<T> where T : class
    {
		T GetById(int id);
		IEnumerable<T> GetAll();
		int Add(T entity);
		void Add(List<T> entities);
		void Update(T entity);
		void Delete(T entity);
	}
}
