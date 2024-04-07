using System.Reflection;
using DesafioPicPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioPicPay.Infra.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfigurationsFromAssembly(modelBuilder);
        }

        private void ApplyConfigurationsFromAssembly(ModelBuilder modelBuilder)
        {
            var mappingTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces()
                    .Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var mappingType in mappingTypes)
            {
                dynamic mappingInstance = Activator.CreateInstance(mappingType);
                modelBuilder.ApplyConfiguration(mappingInstance);
            }
        }
    }
}