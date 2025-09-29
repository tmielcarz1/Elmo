using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Domain.Entities
{
    public class VacationPackage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GrantedDays { get; set; }
        public int Year { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
