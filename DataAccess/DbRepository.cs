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

        public List<PersonelTransaction> GetAllPersonel()
        {
            using (_context = new DataContext(GetAllOptions()))
            {
                try
                {
                    var personels = _context.PersonelTransactions.AsNoTracking().ToList();
                    if (personels != null)
                        return personels;
                    else
                        return new List<PersonelTransaction>();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

		public List<MikroIdenfit> GetMicroDatas()
		{
			using (_context = new DataContext(GetAllOptions()))
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
			}
		}
	}
}
