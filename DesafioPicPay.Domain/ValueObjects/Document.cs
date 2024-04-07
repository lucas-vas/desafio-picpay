using DesafioPicPay.Domain.Enums;
using DesafioPicPay.Domain.ExceptionExtension;

namespace DesafioPicPay.Domain.ValueObjects
{
    public sealed record Document
    {
        public EDocumentType Type { get; private set; }
        public string Number { get; private set; }

        public Document
        (
            EDocumentType type,
            string number
        )
        {
            Type = type;
            Number = number;

            Validate();
        }

        private void Validate()
        {
            DomainException.When(Type.Equals(EDocumentType.NATURAL_PERSON) && Number.Length != 11, "For the natural person type, the number must contain 11 digits");
            DomainException.When(Type.Equals(EDocumentType.LEGAL_PERSON) && Number.Length != 14, "For the legal person type, the number must contain 14 digits");
        }
    }
}