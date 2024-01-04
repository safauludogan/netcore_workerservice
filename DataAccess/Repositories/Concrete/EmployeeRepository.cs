using DataAccess.Base.DB.Concrete;
using DataAccess.DBModel;
using DataAccess.Helper;
using DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Concrete
{
	public class EmployeeRepository : RepositoryService<Employee>, IEmployeeRepository
	{
		//private readonly IDbHelper _dbHelper;
		public EmployeeRepository(IDbHelper dbHelper) : base(dbHelper)
		{
			//_dbHelper = dbHelper;
		}
	}
}
