using DataAccess;
using DataAccess.Models;
using Microsoft.Extensions.Logging;
using Service.Idenfit.Login.Abstract;
using System.Net.Http.Headers;

namespace Service.Idenfit.Login.Concrete
{
    public class AuthanticationService : IAuthanticationService
    {
        private readonly ILogger<AuthanticationService> _logger;
        public AuthanticationService(ILogger<AuthanticationService> logger)
        {
            _logger = logger;
        }
        public async Task<Token> Login()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiUrl = $"{AppSettings.BaseUrl}/login";

                httpClient.DefaultRequestHeaders.From = "mobile";
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                var query = new Dictionary<string, string>
                {
                    ["username"] = AppSettings.ApiUsername,
                    ["password"] = AppSettings.ApiPassword,
                };

                var content = new FormUrlEncodedContent(query);

                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation("Diğer API'den gelen veri: " + responseContent);
                        Console.WriteLine();
                        Console.WriteLine("*******************************");
                        Console.WriteLine();
                        // Bearer token'ı headers içerisinden alma
                        if (response.Headers.TryGetValues("Authorization", out var tokenValues))
                        {
                            string bearerToken = tokenValues.First();
                            _logger.LogInformation("Bearer Token: " + bearerToken);
                            Console.WriteLine();
                            Console.WriteLine("*******************************");
                            Console.WriteLine();
                            if (bearerToken.StartsWith("Bearer "))
                            {
                                bearerToken = bearerToken.Replace("Bearer ", "");
                            }
                            return new Token() { AccessToken = bearerToken };
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
                return new();
            }
        }
    }
}
