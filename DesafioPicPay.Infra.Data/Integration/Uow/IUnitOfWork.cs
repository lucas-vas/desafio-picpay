namespace DesafioPicPay.Infra.Data.Integration.Uow
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Commit();
    }
}