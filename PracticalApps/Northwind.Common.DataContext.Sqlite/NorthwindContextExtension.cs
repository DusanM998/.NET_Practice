using Microsoft.EntityFrameworkCore; // UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

namespace Packt.Shared;

// U ovoj klasi dodajemo prosireni metod koji dodaje kontekst
// Northwin b.p. u kolekciju servisa zavisnosti

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection.
    /// Uses SqLite database provider.
    /// </summary>
    /// <param name = "services"> </param>
    /// <param name = "relativePath"> Set to override default of ".." </param>
    /// <returns> An IServiceCollection that can be used to add more services. </returns>
    
    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Northwind.db");

        services.AddDbContext<NorthwindContext>(options =>
            options.UseSqlite($"Data Source={databasePath}"));

        return services;
    }
}