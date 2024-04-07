using DesafioPicPay.Application.Services.Interfaces;
using DesafioPicPay.Domain.Interfaces;
using DesafioPicPay.Infra.Data.Integration.Uow;

namespace DesafioPicPay.Application.Services
{
    public class TransactionService
    (
        IAuthorizerTransactionService authorizerTransactionService,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    ) : ITransactionService
    {
        public async Task Transaction
        (
            long idPayer,
            long idPayee,
            double value
        )
        {
            var payer = await userRepository.GetUserById(idPayer);
            var payee = await userRepository.GetUserById(idPayee);

            await authorizerTransactionService.CheckAuthorization();

            payer.MakeTransaction(payee, value);

            await unitOfWork.CommitAsync();
        }
    }
}