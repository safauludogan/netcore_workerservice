using Service.Abstract;

namespace WindowsServiceDEKA
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly IAuthanticationService _authanticationService;

		public Worker(ILogger<Worker> logger, IAuthanticationService authanticationService)
		{
			_logger = logger;
			_authanticationService = authanticationService;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				if (_logger.IsEnabled(LogLevel.Information))
				{

				}
				await _authanticationService.Login();
				await Task.Delay(3000, stoppingToken);

			}
		}


		private async Task CreateEmployee(string token)
		{
			/*using (HttpClient httpClient = new HttpClient())
			{
				string apiUrl = "https://uatapi.idenfit.com/api/v1/employees?notifyLater=false";

				

				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
			}*/
		}
	}
}
