using System.Text.RegularExpressions;
using DesafioPicPay.Domain.ExceptionExtension;

namespace DesafioPicPay.Domain.ValueObjects
{
    public sealed record Email
    {
        public string Address { get; private set; }

        public Email
        (
            string address
        )
        {
            Address = address.Trim().ToLower();
            Validate();
        }

        private void Validate()
        {
            DomainException.When(!Regex.IsMatch(Address, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"), "Invalid email");
        }
    }
}