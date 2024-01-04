using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Concrete;

namespace Service
{
	public static class ServiceRegistration
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IAuthanticationService, AuthanticationService>();
		}
	}
}
