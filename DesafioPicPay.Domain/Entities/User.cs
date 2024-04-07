using DesafioPicPay.Domain.Aggregates.User;
using DesafioPicPay.Domain.Enums;
using DesafioPicPay.Domain.ExceptionExtension;
using DesafioPicPay.Domain.ValueObjects;

namespace DesafioPicPay.Domain.Entities
{
    public sealed class User
    {
        private readonly List<Transaction> _transactionsPayer = [];
        private readonly List<Transaction> _transactionsPayee = [];
        public long Id { get; private set; }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Wallet Wallet { get; private set; } = new Wallet(0);
        public IReadOnlyCollection<Transaction> TransactionsPayer => _transactionsPayer.AsReadOnly();
        public IReadOnlyCollection<Transaction> TransactionsPayee => _transactionsPayee.AsReadOnly();

        protected User() {}

        public User
        (
            string fullName,
            EDocumentType documentType,
            string documentNumber,
            string email,
            string password
        )
        {
            Name = new Name(fullName);
            Document = new Document(documentType, documentNumber);
            Email = new Email(email);
            Password = new Password(password);
        }

        public void SendMoney(double value)
        {
            DomainException.When(Document.Type.Equals(EDocumentType.LEGAL_PERSON), "Legal person cannot send value");
            Wallet.Debit(value);
        }

        public void ReceiveMoney(double value) => Wallet.Receive(value);
        
        public void MakeTransaction
        (
            User payee,
            double value
        )
        {
            _transactionsPayer.Add(
                new Transaction
                (
                    payer: this,
                    payee: payee,
                    value: value
                )
            );
        }
    }
}