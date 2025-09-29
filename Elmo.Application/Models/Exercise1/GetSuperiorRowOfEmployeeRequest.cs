using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Models.Exercise1
{
    public class GetSuperiorRowOfEmployeeRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeId musi być większe od 0.")]
        public int EmployeeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "SuperiorId musi być większe od 0.")]
        public int SuperiorId { get; set; }
    }
}
