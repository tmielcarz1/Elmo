using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Models.Exercise1
{
    public class Employee
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public int? SuperiorId { get; set; }
        public virtual Employee? Superior { get; set; }
    }

}
