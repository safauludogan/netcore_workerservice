using DataAccess.Base.DB.Concrete;
using DataAccess.DBModel;
using DataAccess.Helper;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Concrete
{
	public class EmployeeRepository : RepositoryService<Employee>, IEmployeeRepository
	{
		//private readonly DbHelper _dbHelper;
		public EmployeeRepository(DbHelper dbHelper) : base(dbHelper)
		{
			//_dbHelper = dbHelper;
		}
	}
}
