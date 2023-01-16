using UseCaseMinimalAPI.Interfaces;
using UseCaseMinimalAPI.Model;

namespace UseCaseMinimalAPI.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public List<Customer> GetAll()
    {
        return _customers;
    }

    public Customer GetById(int id)
    {
        return _customers.FirstOrDefault(x => x.Id == id)!;
    }

    public Customer Add(Customer customer)
    {
        Customer c = new()
        {
            Id = _customers.Count + 1,
            Name = customer.Name,
            DateAdd = DateTimeOffset.Now
        };
        
        _customers.Add(c);
        return c;
    }

    public Customer Update(Customer customer)
    {
        Customer c = _customers.FirstOrDefault(x => x.Id == customer.Id)!;
        c.Name = customer.Name;
        return c;
    }

    public void Delete(int id)
    {
        var customer = _customers.FirstOrDefault(x => x.Id == id);

        if (customer is not null)
        {
            _customers.Remove(customer);
        }
    }
}