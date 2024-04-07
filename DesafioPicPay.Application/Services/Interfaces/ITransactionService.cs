namespace DesafioPicPay.Application.Services.Interfaces
{
    public interface ITransactionService
    {
        Task Transaction
        (
            long idPayer,
            long idPayee,
            double value
        );
    }
}