using DesafioPicPay.Domain.Aggregates.User;
using DesafioPicPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPicPay.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("ID");

            builder.OwnsOne(x => x.Name, name => {
                name.Property(y => y.FullName)
                .HasColumnName("FULL_NAME");

                name.Ignore(y => y.FirstName);
                name.Ignore(y => y.LastName);
            });

            builder.OwnsOne(x => x.Document, document => {
                document.Property(y => y.Type)
                .HasColumnName("TYPE_DOCUMENT")
                .HasConversion<int>();

                document.Property(y => y.Number)
                .HasColumnName("NUMBER_DOCUMENT");
            });

            builder.OwnsOne(x => x.Email, email => {
                email.Property(y => y.Address)
                .HasColumnName("EMAIL");
            });

            builder.OwnsOne(x => x.Password, password => {
                password.Property(y => y.Value)
                .HasColumnName("PASSWORD");
            });

            builder.HasOne(x => x.Wallet)
            .WithOne()
            .HasForeignKey<Wallet>(y => y.UserId);

            builder.HasMany(x => x.TransactionsPayer)
            .WithOne()
            .HasForeignKey(y => y.PayerId);

            builder.HasMany(x => x.TransactionsPayee)
            .WithOne()
            .HasForeignKey(y => y.PayeeId);
        }
    }
}