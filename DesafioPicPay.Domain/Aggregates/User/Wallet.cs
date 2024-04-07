using DesafioPicPay.Domain.ValueObjects;

namespace DesafioPicPay.Domain.Aggregates.User
{
    public sealed class Wallet
    {
        public long Id { get; private set; }
        public long UserId { get; }
        public MoneyValue Value { get; private set; }

        protected Wallet() {}

        public Wallet
        (
            double value
        )
        {
            Value = new MoneyValue(value);
        }

        public void Debit(double value) => Value.SubtractValue(value);

        public void Receive(double value) => Value.AddValue(value);
    }
}