using DesafioPicPay.Domain.ExceptionExtension;

namespace DesafioPicPay.Domain.ValueObjects
{
    public sealed record MoneyValue
    {
        public double Value { get; private set; }

        public MoneyValue
        (
            double value
        )
        {
            Value = Math.Round(value, 2);

            Validate();
        }

        public void SubtractValue(double value)
        {
            DomainException.When(value == 0, "The value cannot be equal to zero");
            DomainException.When(Value < value, "You don't have enough balance");

            Value -= Math.Round(value, 2);

            Validate();
        }

        public void AddValue(double value)
        {
            DomainException.When(value == 0, "The value cannot be equal to zero");

            Value += Math.Round(value, 2);
        }

        private void Validate()
        {
            DomainException.When(Value < 0, "The value cannot be less than zero");
        }
    }
}