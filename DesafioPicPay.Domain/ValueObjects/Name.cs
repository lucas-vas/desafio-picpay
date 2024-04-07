using System.Text.RegularExpressions;
using DesafioPicPay.Domain.ExceptionExtension;

namespace DesafioPicPay.Domain.ValueObjects
{
    public sealed record Name
    {
        public string FullName { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public Name
        (
            string fullName
        )
        {
            FullName = fullName;
            SetFirstAndLastName();

            Validate();
        }

        private void SetFirstAndLastName()
        {
            var match = Regex.Match(FullName, @"^(\S+)\s+(\S+)$");

            if(match.Success)
            {
                FirstName = match.Groups[1].Value;
                LastName = match.Groups[2].Value;
            }
        }

        private void Validate()
        {
            DomainException.When(string.IsNullOrEmpty(FullName), "The name field cannot be null");
        }
    }
}
