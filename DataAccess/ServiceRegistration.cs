using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
	public static class ServiceRegistration
	{
		
		public static void DataAccessServices(this IServiceCollection services)
		{
			services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
		}
	}
}
