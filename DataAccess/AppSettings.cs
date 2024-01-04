using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public static class AppSettings
    {
        public static IConfiguration Configuration { get; set; }
        public static string ConnectionString { get; set; }
        public static string BaseUrl { get; set;}
		public static string ApiUsername { get; set; }
		public static string ApiPassword { get; set; }
	}
}
