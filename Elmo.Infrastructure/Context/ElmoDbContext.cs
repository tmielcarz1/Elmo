using Elmo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Elmo.Infrastructure.Context
{
    public class ElmoDbContext : DbContext
    {
        public ElmoDbContext(DbContextOptions<ElmoDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<VacationPackage> VacationPackages { get; set; }
        public DbSet<Vacation> Vacations { get; set; }


    }
}
