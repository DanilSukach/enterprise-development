using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain.Context;
using StoreCashFlow.Domain.Entity;

namespace StoreCashFlow.Api.Service;

public class CustomerService(StoreCashFlowDbContext storeCashFlowDbContext) : IEntityService<Customer, int, CustomerCreateDTO, CustomerDTO>
{
    public Customer Create(CustomerCreateDTO newCustomerDTO)
    {
        var newCustomer = new Customer
        {
            CustomerId = 0,
            CardNumber = newCustomerDTO.CardNumber,
            LastName = newCustomerDTO.LastName,
            FirstName = newCustomerDTO.FirstName,
            Potronimic = newCustomerDTO.Potronimic
        };
        storeCashFlowDbContext.Customers.Add(newCustomer);
        storeCashFlowDbContext.SaveChanges();
        return newCustomer;
    }

    public IEnumerable<Customer> GetAll() => storeCashFlowDbContext.Customers;

    public Customer? GetById(int id)
    {
        return storeCashFlowDbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
    }

    public bool Delete(int id)
    {
        var customer = GetById(id);
        if (customer == null)
        {
            return false;
        }
        storeCashFlowDbContext.Customers.Remove(customer);
        storeCashFlowDbContext.SaveChanges();
        return true;
    }

    public bool Update(CustomerDTO updateCustomer)
    {
        var customer = GetById(updateCustomer.CustomerId);
        if (customer == null)
        {
            return false;
        }

        customer.FirstName = updateCustomer.FirstName;
        customer.LastName = updateCustomer.LastName;
        customer.Potronimic = updateCustomer.Potronimic;
        customer.CardNumber = updateCustomer.CardNumber;

        storeCashFlowDbContext.SaveChanges();
        return true;
    }
}
