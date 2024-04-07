using DesafioPicPay.Domain.Aggregates.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPicPay.Infra.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("USER_TRANSACTION");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("ID");

            builder.Property(x => x.PayerId)
            .HasColumnName("USER_PAYER_ID");

            builder.Property(x => x.PayeeId)
            .HasColumnName("USER_PAYEE_ID");

            builder.Property(x => x.Value)
            .HasColumnName("VALUE");

            builder.Property(x => x.CreatedAt)
            .HasColumnName("CREATED_AT");
        }
    }
}