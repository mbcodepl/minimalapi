using UseCaseMinimalAPI.Model;

namespace UseCaseMinimalAPI.Interfaces;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer GetById(int id);
    Customer Add(Customer customer);
    Customer Update(Customer customer);
    void Delete(int id);
}