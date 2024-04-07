using DesafioPicPay.Infra.Data.Context;

namespace DesafioPicPay.Infra.Data.Integration.Uow
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}