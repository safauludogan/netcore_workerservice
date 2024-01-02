using DataAccess;
using DataAccess.DBModel;

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
				//PrintUserInfo(dbRepository.GetAllPersonel());
				PrintMicroData(dbRepository.GetMicroDatas());
				await Task.Delay(3000, stoppingToken);
			}
		}

		private void PrintUserInfo(List<PersonelTransaction> personels)
		{
			foreach (var personel in personels)
			{
				if (personel.Aktif != null && personel.Aktif.Equals("Evet"))
					_logger.LogInformation($"PersonelID: {personel.PersonelId} --- Aktif durum: {personel.Kaynak} --- Tarih: {personel.Tarih}");

			}
		}

		private void PrintMicroData(List<MikroIdenfit> datas)
		{
			foreach (var data in datas)
			{
				_logger.LogInformation($"Sicil No: {data.StaffNumber} --- AdSoyad: {data.FirstName} {data.LastName} --- Þirket: {data.Company}");
			}
		}
	}
}
