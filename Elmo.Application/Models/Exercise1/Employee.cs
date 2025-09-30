﻿namespace Elmo.Application.Models.Exercise1
{
    public class Employee
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public int? SuperiorId { get; set; }
        public virtual Employee? Superior { get; set; }
    }

}
