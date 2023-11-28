using DataAccess;
using DataAccess.DBModel;
using Serilog;

namespace WindowsServiceDEKA
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DbRepository dbRepository;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            dbRepository = new DbRepository();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    
                }
                PrintUserInfo(dbRepository.GetAllPersonel());
                await Task.Delay(10000, stoppingToken);
            }
        }

        private void PrintUserInfo(List<PersonelTransaction> personels)
        {
            foreach (var personel in personels)
            {
                if (personel.Aktif != null && personel.Aktif.Equals("Evet"))
                    _logger.LogInformation($"PersonelID: {personel.PersonelID} --- Aktif durum: {personel.Kaynak} --- Tarih: {personel.Tarih}");
            }
        }
    }
}
