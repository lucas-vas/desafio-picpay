using MediatR;

namespace DesafioPicPay.Application.Features.User.Commands.CreateTransaction
{
    public class CreateTransactionCommand : IRequest<string>
    {
        public long PayerId { get; set; }
        public long PayeeId { get; set; }
        public double Value { get; set; }
    }
}