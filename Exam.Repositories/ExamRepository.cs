using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repositories
{
	public class ExamRepository<T> : IRepository<T> where T : class
	{
		private readonly DbContext _context;
		private readonly DbSet<T> _dbSet;

		public ExamRepository(DbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public int Add(T entity)
		{
			BaseModel? baseModel = _context.Entry(entity as BaseModel).Entity;
			baseModel.CreatedAt = baseModel.UpdatedAt = DateTime.UtcNow;
			var saved = _context.Add(entity);
			
			return _context.SaveChanges();
        }

		public void Update(T entity)
		{
			BaseModel? baseModel = _context.Entry(entity as BaseModel).Entity;
			baseModel.UpdatedAt = DateTime.UtcNow;
			_context.Entry(baseModel).State = EntityState.Modified;
			_context.SaveChanges();
        }

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void Add(List<T> entities)
		{
			foreach (var entity in entities)
			{
				BaseModel? baseModel = _context.Entry(entity as BaseModel).Entity;
				baseModel.CreatedAt = baseModel.UpdatedAt = DateTime.UtcNow;
			}
			_dbSet.AddRange(entities);
		}
	}
}