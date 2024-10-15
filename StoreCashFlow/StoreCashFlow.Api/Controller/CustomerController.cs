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
    /// <returns>Список покупателей</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> Get()
    {
        return Ok(customerService.GetAll());
    }

    /// <summary>
    /// Получить покупателя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор покупателя</param>
    /// <returns>Возвращает покупателя</returns>
    /// <response code="200">Покупатель</response>
    /// <response code="404">Покупатель не найден</response>
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
    /// Добавить нового покупателя
    /// </summary>
    /// <param name="newCustomer">Новый покупатель</param>
    /// <returns>Добавленный покупатель</returns>
    [HttpPost]
    public ActionResult<Customer> Post(CustomerCreateDTO newCustomer)
    {
        return Ok(customerService.Create(newCustomer));
    }

    /// <summary>
    /// Обновить данные покупателя
    /// </summary>
    /// <param name="customer">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
    /// <param name="id">Идентификатор покупателя</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
