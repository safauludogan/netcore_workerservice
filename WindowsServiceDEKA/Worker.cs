using DataAccess;
using DataAccess.DBModel;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

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
				//PrintMicroData(dbRepository.GetMicroDatas());
				await Login();
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

		private async Task Login()
		{
			using (HttpClient httpClient = new HttpClient())
			{
				string apiUrl = "https://uatapi.idenfit.com/login";

				// Burada gerektiðiniz headers, authentication vb. ayarlamalarý yapabilirsiniz.
				// httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer token");
				//httpClient.DefaultRequestHeaders.Add("From", "mobile");
				//httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
				
				httpClient.DefaultRequestHeaders.From = "mobile";
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

				var query = new Dictionary<string, string>
				{
					["username"] = "alper.tomacoglu@vibebilisim.com",
					["password"] = "123456",
				};

				// Veriyi form-urlencoded formatýna dönüþtürme
				var content = new FormUrlEncodedContent(query);

				try
				{
					HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

					if (response.IsSuccessStatusCode)
					{
						string responseContent = await response.Content .ReadAsStringAsync();
						Console.WriteLine("Diðer API'den gelen veri: " + responseContent);
						Console.WriteLine("*******************************");

						// Bearer token'ý headers içerisinden alma
						if (response.Headers.TryGetValues("Authorization", out var tokenValues))
						{
							string bearerToken = tokenValues.First();
							Console.WriteLine("Bearer Token: " + bearerToken);
						}

					}
					else
					{
						Console.WriteLine("Hata kodu: " + response.StatusCode);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Hata: " + ex.Message);
				}
			}
		}
	}
}
