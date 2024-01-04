using DataAccess.Base.DB.Abstract;
using DataAccess.DBModel;
using DataAccess.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Base.DB.Concrete
{
	public class RepositoryService<T> : IRepositoryService<T> where T : class, IEntity, new()
	{
		private IDbHelper _dbHelper;

		public RepositoryService(IDbHelper dbHelper)
		{
			_dbHelper = dbHelper;
		}
		public T Add(T entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public T Get(Expression<Func<T, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
		{
			using (var _context = new DataContext(_dbHelper.GetOptions()))
			{
				return filter == null ? await _context.Set<T>().ToListAsync() : await _context.Set<T>().Where(filter).ToListAsync();
			}
		}

		public T Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
