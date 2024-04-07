using DesafioPicPay.Application.Services.Interfaces;
using MediatR;

namespace DesafioPicPay.Application.Features.User.Commands.CreateTransaction
{
    public class CreateTransactionHandler(ITransactionService transactionService) : IRequestHandler<CreateTransactionCommand, string>
    {
        private readonly ITransactionService _transactionService = transactionService;

        public async Task<string> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            await _transactionService.Transaction
            (
                idPayer: request.PayerId,
                idPayee: request.PayeeId,
                value: request.Value
            );

            return "Transaction completed.";
        }
    }
}