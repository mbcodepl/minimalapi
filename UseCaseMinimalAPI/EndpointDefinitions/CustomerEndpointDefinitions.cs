using Microsoft.AspNetCore.Mvc;
using UseCaseMinimalAPI.Interfaces;
using UseCaseMinimalAPI.Interfaces;
using UseCaseMinimalAPI.Model;
using UseCaseMinimalAPI.Repositories;

namespace UseCaseMinimalAPI.EndpointDefinitions;

public class CustomerEndpointDefinitions : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/customers", GetAll);
        
        app.MapGet("/customers/{id}", GetById);
        
        app.MapPost("/customers", CreateCustomer);
        
        app.MapPut("/customers", UpdateCustomer);
        
        app.MapDelete("/customers/{id}", DeleteCustomer);
    }

    private async Task<IResult> GetAll(ICustomerRepository customerRepository)
    {
        await Task.Delay(1);
        List<Customer> customers = customerRepository.GetAll();
        return Results.Ok(customers);
    }
    
    private async Task<IResult> GetById(int id, ICustomerRepository customerRepository)
    {
        await Task.Delay(1);
        Customer customer = customerRepository.GetById(id);
        return Results.Ok(customer);
    }

    private async  Task<IResult> CreateCustomer(ICustomerRepository customerRepository, Customer customer)
    {
        await Task.Delay(1);
        Customer c = customerRepository.Add(customer);
        return Results.Ok(c);
    }
    
    private async  Task<IResult> UpdateCustomer(Customer customer, ICustomerRepository customerRepository) 
    {
        await Task.Delay(1);
        Customer c = customerRepository.Update(customer);
        return Results.Ok(c);
    }
    
    private async Task<IResult> DeleteCustomer(int id, ICustomerRepository customerRepository)
    {
        await Task.Delay(1);
        customerRepository.Delete(id);
        return Results.Ok();
    }
}