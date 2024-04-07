using DesafioPicPay.Domain.Entities;

namespace DesafioPicPay.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(long id);
    }
}