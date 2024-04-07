using DesafioPicPay.Domain.ExceptionExtension;

namespace DesafioPicPay.Domain.ValueObjects
{
    public sealed record Password
    {
        public string Value { get; private set; }

        public Password
        (
            string value
        )
        {
            Value = value.Trim();

            Validate();
        }

        private void Validate()
        {
            DomainException.When(Value.Length < 8, "The password must contain at least 8 digits");
        }
    }
}