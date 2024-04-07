namespace DesafioPicPay.Domain.Aggregates.User
{
    public class Transaction
    {
        public long Id { get; private set; }
        public long PayerId { get; private set; }
        public long PayeeId { get; private set; }
        public double Value { get; private set; }
        public DateTime CreatedAt { get; private set; }

        protected Transaction() {}

        public Transaction
        (
            Entities.User payer,
            Entities.User payee,
            double value
        )
        {
            PayerId = payer.Id;
            PayeeId = payee.Id;
            Value = value;
            CreatedAt = DateTime.Now;

            payer.SendMoney(value);
            payee.ReceiveMoney(value);
        }
    }
}