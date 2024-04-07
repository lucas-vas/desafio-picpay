using DesafioPicPay.Domain.Entities;
using DesafioPicPay.Domain.Interfaces;
using DesafioPicPay.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioPicPay.Infra.Data.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        public async Task<User> GetUserById(long id)
        {
            var user = await context.Users.Include(x => x.Wallet)
                                          .Include(x => x.TransactionsPayee)
                                          .Include(x => x.TransactionsPayer)
                                          .FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}