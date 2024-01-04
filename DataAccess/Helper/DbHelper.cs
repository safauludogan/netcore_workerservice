using DataAccess.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Helper
{
	public abstract class DbHelper
	{
		public virtual DbContextOptions<DataContext> GetOptions()
		{
			var optionBuilder = new DbContextOptionsBuilder<DataContext>();
			optionBuilder.UseSqlServer(AppSettings.ConnectionString);
			return optionBuilder.Options;
		}
	}
}
