using Microsoft.Extensions.DependencyInjection;
using Service.Idenfit.Login.Abstract;
using Service.Idenfit.Login.Concrete;

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
