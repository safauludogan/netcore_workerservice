using DataAccess.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Helper
{
	public class DbHelper : IDbHelper
	{
		public DbContextOptions<DataContext> GetOptions()
		{
			var optionBuilder = new DbContextOptionsBuilder<DataContext>();
			optionBuilder.UseSqlServer(AppSettings.ConnectionString);
			return optionBuilder.Options;
		}
	}
}
