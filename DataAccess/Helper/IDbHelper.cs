using DataAccess.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Helper
{
	public interface IDbHelper
	{
		public DbContextOptions<DataContext> GetOptions();
	}
}
