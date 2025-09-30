using System.ComponentModel.DataAnnotations.Schema;

namespace Elmo.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public virtual Team? Team { get; set; }

        [ForeignKey(nameof(VacationPackage))]
        public int VacationPackageId { get; set; }

        public virtual VacationPackage? VacationPackage { get; set; }

        public virtual List<Vacation> Vacations { get; set; } = new List<Vacation>();
    }
}
