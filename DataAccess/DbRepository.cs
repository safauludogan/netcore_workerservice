using DataAccess.DBModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DbRepository
    {
        private DataContext _context;

        private DbContextOptions<DataContext> GetAllOptions()
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            optionBuilder.UseSqlServer(AppSettings.ConnectionString);
            return optionBuilder.Options;
        }

        public List<Employee> GetAllEmployees()
        {
            using (_context = new DataContext(GetAllOptions()))
            {
                try
                {
                    var employees = _context.Employees.AsNoTracking().ToList();
                    if (employees != null)
                        return employees;
                    else
                        return new List<Employee>();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

		public void GetMicroDatas()
		{
			/*using (_context = new DataContext(GetAllOptions()))
			{
				try
				{
					var microDatas = _context.MikroIdenfits.AsNoTracking().ToList();
					if (microDatas != null)
						return microDatas;
					else
						return new List<MikroIdenfit>();
				}
				catch (Exception ex)
				{
					throw;
				}
			}*/
		}
	}
}
