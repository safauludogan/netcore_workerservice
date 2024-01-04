using DataAccess;
using DataAccess.DBModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WindowsServiceDEKA;
using Service;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Infinite)
    .WriteTo.Console()
    .MinimumLevel.Information()  // Minimum log seviyesi
    .CreateLogger();

try
{
    Log.Information("Starting application");

    var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddHostedService<Worker>();

            AppSettings.Configuration = context.Configuration;
            AppSettings.ConnectionString = context.Configuration.GetConnectionString("DefaultConnection")!;
            AppSettings.BaseUrl = context.Configuration["API:BaseUrl"];
			AppSettings.ApiUsername = context.Configuration["API:username"];
			AppSettings.ApiPassword = context.Configuration["API:password"];

			services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(AppSettings.ConnectionString));

            services.AddServices();
            //services.DataAccessServices();

		})
        .UseSerilog()
        .Build();

    host.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}