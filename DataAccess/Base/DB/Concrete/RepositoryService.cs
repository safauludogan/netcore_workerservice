using DataAccess.Base.DB.Abstract;
using DataAccess.DBModel;
using DataAccess.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Base.DB.Concrete
{
	public class RepositoryService<T> : IRepositoryService<T> where T : class, IEntity, new()
	{
		private DbHelper _dbHelper;

		public  RepositoryService(DbHelper dbHelper)
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
				return await _context.Set<T>().ToListAsync();
			}
		}

		public T Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
