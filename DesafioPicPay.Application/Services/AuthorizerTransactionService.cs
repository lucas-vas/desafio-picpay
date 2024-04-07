using System.Text.Json;
using DesafioPicPay.Application.ExceptionExtension;
using DesafioPicPay.Application.Services.Interfaces;
using DesafioPicPay.Application.Services.Responses;

namespace DesafioPicPay.Application.Services
{
    public class AuthorizerTransactionService
    (
        HttpClient httpClient
    ) : IAuthorizerTransactionService
    {
        public async Task CheckAuthorization()
        {
            var response = await httpClient.GetAsync("https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc");

            AppException.When(!response.IsSuccessStatusCode, "Invalid transaction");

            var content = await response.Content.ReadAsStringAsync();
            var authorizerTransactionResponse = JsonSerializer.Deserialize<AuthorizerTransactionResponse>(content);

            AppException.When(!authorizerTransactionResponse.IsAuthorized(), "Invalid transaction");
        }
    }
}