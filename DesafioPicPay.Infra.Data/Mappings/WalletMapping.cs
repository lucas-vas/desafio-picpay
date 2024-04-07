using DesafioPicPay.Domain.Aggregates.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioPicPay.Infra.Data.Mappings
{
    public class WalletMapping : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("USER_WALLET");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .HasColumnName("ID");

            builder.Property(x => x.UserId)
            .HasColumnName("USER_ID");

            builder.OwnsOne(x => x.Value, moneyValue => {
                moneyValue.Property(y => y.Value)
                .HasColumnName("VALUE");
            });
        }
    }
}