using Microsoft.EntityFrameworkCore.ChangeTracking; // EntityEntry()
using Packt.Shared;
using System.Collections.Concurrent; // ConcurrentDictionary

namespace Northwind.WebApi.Repositories; 

public class CustomerRepository : ICustomerRepository
{
    // Use a static thread-safe dictionary field to cache the customer
    private static ConcurrentDictionary<string, Customer?> customersCache;

    // Use an instance data context field because it should not be
    // cached due to their internal caching
    private NorthwindContext db;

    public CustomerRepository(NorthwindContext injectedContext)
    {
        db = injectedContext;

        // Pre-load customers from database as a normal
        // Dictionary with CustomerId as the key,
        // then convert to a thread-safe ConcurrentDictionary
        if(customersCache is null)
        {
            customersCache = new ConcurrentDictionary<string, Customer>(
                db.Customers.ToDictionary(c => c.CustomerId));
        }
    }

    public async Task<Customer?> CreateAsync(Customer c)
    {
        // Normalize CustomerId into uppercase
        c.CustomerId = c.CustomerId.ToUpper();

        // Add to database using EF Core
        EntityEntry<Customer> added = await db.Customers.AddAsync(c);
        int affected = await db.SaveChangesAsync();
        if(affected == 1)
        {
            if(customersCache is null) return c;
            // if the customer is new, add it to cache
            // else, call UpdateCache method
            return customersCache.AddOrUpdate(c.CustomerId, c, UpdateCache);
        }
        else
        {
            return null;
        }
    }

    public Task<Customer?> RetriveAllAsync()
    {
        // For performance, get from cache 
        return Task.FromResult(customersCache is null ? Enumerable.Empty<Customer>()
            : customersCache.Values);
    }

    public Task<Customer?> RetriveAll()
    {
        // for performance, get from cache
        id = id.ToUpper();
        if(customersCache is null) return null!;
        customersCache.TryGetValues(id, out Customer? c);

        return Task.FromResult(c);
    }

    private Customer UpdateCache(string id, Customer c)
    {
        Customer? old;
        if(customersCache is not null)
        {
            if(customersCache.TryGetValues(id, out old))
            {
                if(customersCache.TryUpdate(id, c, old))
                {
                    return c;
                }
            }
        }
        return null;
    }

    public async Task<Customer?> UpdateAsync(string id, Customer c)
    {
        // Normalize customer Id
        id = id.ToUpper();
        c.CustomerId = c.CustomerId.ToUpper();

        // Update in database
        db.Customers.Update(c);
        int affected = await db.SaveChangesAsync();
        if(affected == 1)
        {
            // Update in cache
            return UpdateCache(id, c);
        }
        return null;
    }

    public async Task<bool?> DeleteAsync(string id)
    {
        id = id.ToUpper();

        // Remove from database
        Customer? c = db.Customers.Find(id);

        if(c is null) return null;

        db.Customers.Remove(c);
        
        int affected = await db.SaveChangesAsync();
        if(affected == 1)
        {
            if(customersCache is null) return null;

            // Remove from cache
            return customersCache.TryRemove(id, out c);
        }
        else
        {
            return null;
        }
    }
}