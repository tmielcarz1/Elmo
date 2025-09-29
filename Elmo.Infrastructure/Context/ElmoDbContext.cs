using Elmo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
