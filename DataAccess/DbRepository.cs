using DataAccess.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
