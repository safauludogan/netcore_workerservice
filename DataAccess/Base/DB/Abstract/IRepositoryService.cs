using System.Linq.Expressions;

namespace DataAccess.Base.DB.Abstract
{
	public interface IRepositoryService<T> where T : class, IEntity,new()
	{
		Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
		T Get(Expression<Func<T, bool>> filter = null);
		T Add(T entity);
		T Update(T entity);
		void Delete(T entity);
	}
}
