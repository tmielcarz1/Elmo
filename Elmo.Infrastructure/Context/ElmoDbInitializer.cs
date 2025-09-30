using Elmo.Domain.Entities;

namespace Elmo.Infrastructure.Context
{
    public class ElmoDbInitializer : IElmoDbInitializer
    {
        private readonly ElmoDbContext _context;

        public ElmoDbInitializer(ElmoDbContext context)
        {
            _context = context;
        }


        public async Task SeedData()
        {
            //a) Jan Kowalski .Net 2019
            //b) Kamil Nowak od 1 do 5 - 5 dni
            //c) Javascript

            if (_context.Teams.Any())
                return;


            var team1 = new Team { Name = ".NET" };
            var team2 = new Team { Name = "Java" };
            var team3 = new Team { Name = "JavaScript" };

            _context.Teams.AddRange(team1, team2, team3);
            await _context.SaveChangesAsync();


            var package1 = new VacationPackage { Name = "2025 rok", GrantedDays = 26, Year = 2025 };
            var package2 = new VacationPackage { Name = "2019 rok", GrantedDays = 26, Year = 2019 };

            _context.VacationPackages.AddRange(package1, package2);
            await _context.SaveChangesAsync();


            var employee1 = new Employee { Name = "Jan Kowalski", TeamId = team1.Id, VacationPackageId = package2.Id };
            var employee2 = new Employee { Name = "Kamil Nowak", TeamId = team1.Id, VacationPackageId = package1.Id };
            var employee3 = new Employee { Name = "Anna Mariacka", TeamId = team2.Id, VacationPackageId = package1.Id };
            var employee4 = new Employee { Name = "Andrzej Abacki", TeamId = team2.Id, VacationPackageId = package1.Id };
            var employee5 = new Employee { Name = "Tomek Roztropek", TeamId = team3.Id, VacationPackageId = package1.Id };

            _context.Employees.AddRange(employee1, employee2, employee3, employee4, employee5);
            await _context.SaveChangesAsync();


            var vacations = new List<Vacation>
            {
                new Vacation { EmployeeId = employee1.Id, DateSince = new DateTime(2019, 06, 10), DateUntil = new DateTime(2019, 06, 15), NumberOfHours = 8, IsPartialVacation = false },
                new Vacation { EmployeeId = employee2.Id, DateSince = new DateTime(DateTime.Now.Year, 03, 01), DateUntil = new DateTime(DateTime.Now.Year, 03, 05), NumberOfHours = 8, IsPartialVacation = false },
                new Vacation { EmployeeId = employee3.Id, DateSince = new DateTime(2019, 07, 01), DateUntil = new DateTime(2019, 07, 03), NumberOfHours = 8, IsPartialVacation = false },
                new Vacation { EmployeeId = employee4.Id, DateSince = new DateTime(DateTime.Now.Year + 1, 01, 01), DateUntil = new DateTime(DateTime.Now.Year + 1, 01, 05), NumberOfHours = 8, IsPartialVacation = false },
                new Vacation { EmployeeId = employee5.Id, DateSince = new DateTime(2024, 02, 01), DateUntil = new DateTime(2024, 02, 03), NumberOfHours = 8, IsPartialVacation = false },
                new Vacation { EmployeeId = employee2.Id, DateSince = new DateTime(DateTime.Now.Year, 04, 10), DateUntil = new DateTime(DateTime.Now.Year, 04, 10), NumberOfHours = 4, IsPartialVacation = true },
                new Vacation { EmployeeId = employee3.Id, DateSince = new DateTime(DateTime.Now.Year, 05, 15), DateUntil = new DateTime(DateTime.Now.Year, 05, 15), NumberOfHours = 2, IsPartialVacation = true }

            };

            _context.Vacations.AddRange(vacations);
            await _context.SaveChangesAsync();
        }

    }
}
