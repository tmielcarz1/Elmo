namespace Elmo.Infrastructure.Context
{
    public interface IElmoDbInitializer
    {
        Task SeedData();
    }
}
