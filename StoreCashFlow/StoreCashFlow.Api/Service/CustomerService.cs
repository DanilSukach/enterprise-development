using StoreCashFlow.Domain;
using StoreCashFlow.Api.DTO;

namespace StoreCashFlow.Api.Service;

public class CustomerService() : IEntityService<Customer, int, CustomerCreateDTO, CustomerDTO>
{
    private List<Customer> _customers = [];
    private int _customerId = 1;
    public Customer Create(CustomerCreateDTO newCustomerDTO)
    {
        var newCustomer = new Customer
        {
            CustomerId = _customerId++,
            CardNumber = newCustomerDTO.CardNumber,
            LastName = newCustomerDTO.LastName,
            FirstName = newCustomerDTO.FirstName,
            Potronimic = newCustomerDTO.Potronimic
        };
        _customers.Add(newCustomer);
        return newCustomer;
    }

    public List<Customer> GetAll() => _customers;

    public Customer? GetById(int id)
    {
        return _customers.FirstOrDefault(c => c.CustomerId == id);
    }

    public bool Delete(int id)
    {
        var customer = GetById(id);
        if (customer == null)
        {
            return false;
        }
        return _customers.Remove(customer);
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
        return true;
    }
}
