namespace Elmo.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
