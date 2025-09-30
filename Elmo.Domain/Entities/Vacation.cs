using System.ComponentModel.DataAnnotations.Schema;

namespace Elmo.Domain.Entities
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime DateSince { get; set; }
        public DateTime DateUntil { get; set; }
        public int NumberOfHours { get; set; }
        public bool IsPartialVacation { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

    }
}
