using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Infrastructure.Context
{
    public interface IElmoDbInitializer
    {
        Task SeedData();
    }
}
