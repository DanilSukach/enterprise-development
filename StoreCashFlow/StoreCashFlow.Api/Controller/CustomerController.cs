using Microsoft.AspNetCore.Mvc;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Api.Service;
using StoreCashFlow.Domain;
namespace StoreCashFlow.Api.Controller;

/// <summary>
/// Контроллер для работы с покупателями
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomerController(CustomerService customerService) : ControllerBase
{
    /// <summary>
    /// Получить всех покупателей
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> Get()
    {
        return Ok(customerService.GetAll());
    }

    /// <summary>
    /// Получить покупателя по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Customer> Get(int id)
    {
        var customer = customerService.GetById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    /// <summary>
    /// Добавить покупателя
    /// </summary>
    [HttpPost]
    public ActionResult<Customer> Post(CustomerCreateDTO newCustomer)
    {
        return Ok(customerService.Create(newCustomer));
    }

    /// <summary>
    /// Обновить покупателя
    /// </summary>
    [HttpPut]
    public IActionResult Put(CustomerDTO customer)
    {
        var result = customerService.Update(customer);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить покупателя
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = customerService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
