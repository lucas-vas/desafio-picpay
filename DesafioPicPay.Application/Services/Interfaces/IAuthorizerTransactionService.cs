namespace DesafioPicPay.Application.Services.Interfaces
{
    public interface IAuthorizerTransactionService
    {
        Task CheckAuthorization();
    }
}