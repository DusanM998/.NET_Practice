using Packt.Shared; // Customer

namespace Northwind.WebApi.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> CreateAsync(Customer c);
    Task<IEnumerable<Customer>> RetriveAllAsync();
    Task<Customer?> RetriveAsync(string id);
    Task<Customer?> UpdateAsync(string id, Customer c);
    Task<bool?> DeleteAsync(string id);
}