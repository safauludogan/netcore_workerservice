using DataAccess;
using DataAccess.DBModel;
using DataAccess.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

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
				var token = await Login();
				await CreateEmployee(token);
				await Task.Delay(6000 * 15, stoppingToken);

			}
		}

		/*private void PrintMicroData(List<MikroIdenfit> datas)
		{
			foreach (var data in datas)
			{
				_logger.LogInformation($"Sicil No: {data.StaffNumber} --- AdSoyad: {data.FirstName} {data.LastName} --- Þirket: {data.Company}");
			}
		}
		*/
		private async Task<string> Login()
		{
			using (HttpClient httpClient = new HttpClient())
			{
				string apiUrl = "https://uatapi.idenfit.com/login";

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
						string responseContent = await response.Content.ReadAsStringAsync();
						_logger.LogInformation("Diðer API'den gelen veri: " + responseContent);
						Console.WriteLine("*******************************");

						// Bearer token'ý headers içerisinden alma
						if (response.Headers.TryGetValues("Authorization", out var tokenValues))
						{
							string bearerToken = tokenValues.First();
							_logger.LogInformation("Bearer Token: " + bearerToken);
							return bearerToken;
						}

					}
					else
					{
						_logger.LogInformation("Hata kodu: " + response.StatusCode);
					}
				}
				catch (Exception ex)
				{
					_logger.LogInformation("Hata: " + ex.Message);
				}
				return null;
			}
		}


		private async Task CreateEmployee(string token)
		{
			using (HttpClient httpClient = new HttpClient())
			{
				string apiUrl = "https://uatapi.idenfit.com/api/v1/employees?notifyLater=false";

				if (token.StartsWith("Bearer "))
				{
					token = token.Replace("Bearer ", "");
				}

				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


				//var employee = new EmployeeDto()
				//{
				//	staffNumber="6666",
				//	firstName = "Merve",
				//	lastName = "Uludoðan",
				//	identityNumber = "3212",
				//	phone = "5120015588",
				//	workEmail = "merve.uludogan@vibe.com",
				//	gender = "FEMALE",
				//	language = "TURKISH",
				//	birthDate ="2005-06-10",
				//	hiredDate = "2003-06-10",
				//	unit = "34ab1cf3-a496-48e1-be43-f8300a72cab4",
				//	branch = "7a128687-59c2-4808-8ec2-9685eece4981",
				//	role = "b24aad06-bd68-4048-b0f4-d010da0603e4",
				//	company = "86e80d5b-c371-4559-8fd0-5d25b64a00a5"
				//};
				try
				{


					var employees = dbRepository.GetAllEmployees();
					foreach (var employee in employees)
					{


					if (employee != null)
					{
						var employeeMap = new EmployeeDto()
						{
							staffNumber = employee.StaffNumber,
							firstName = employee.FirstName,
							lastName = employee.LastName,
							identityNumber = employee.IdentityNumber,
							phone = employee.Phone,
							workEmail = employee.WorkEmail,
							gender = employee.Gender,
							language = employee.Language,
							birthDate = employee.BirthDate,
							hiredDate = employee.HiredDate,
							unit = employee.Unit,
							branch = employee.Branch,
							role = employee.Role,
							company = employee.Company
						};

						var jsonContent = new StringContent(JsonSerializer.Serialize(employeeMap), Encoding.UTF8, "application/json");

						HttpResponseMessage response = await httpClient.PostAsync(apiUrl, jsonContent);

						if (response.IsSuccessStatusCode)
						{
							string responseContent = await response.Content.ReadAsStringAsync();
							_logger.LogInformation("Diðer API'den gelen veri: " + responseContent);
						}
						else
						{
							_logger.LogInformation("Hata kodu: " + response.StatusCode);
						}
					}
					}

				}
				catch (Exception ex)
				{
					_logger.LogInformation("Hata: " + ex.Message);
				}
			}
		}
	}
}
