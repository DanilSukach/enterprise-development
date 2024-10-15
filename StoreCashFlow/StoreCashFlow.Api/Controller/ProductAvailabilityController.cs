using Microsoft.AspNetCore.Mvc;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Api.Service;
using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.Controller;

/// <summary>
/// Контроллер для работы с доступностью товаров
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductAvailabilityController(ProductAvailabilityService availabilityService) : ControllerBase
{
    /// <summary>
    /// Получить все доступные товары
    /// </summary>
    /// <returns>Список товаров</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ProductAvailability>> Get()
    {
        return Ok(availabilityService.GetAll());
    }

    /// <summary>
    /// Получить доступность товара по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор доступности товара</param>
    /// <returns>Доступность товара</returns>
    /// <response code="200">Доступность товара</response>
    /// <response code="404">Доступность товара не найдена</response>
    [HttpGet("{id}")]
    public ActionResult<ProductAvailability> Get(int id)
    {
        var productAvailability = availabilityService.GetById(id);
        if (productAvailability == null)
        {
            return NotFound();
        }
        return Ok(productAvailability);
    }

    /// <summary>
    /// Добавить доступность товара
    /// </summary>
    /// <param name="newProductAvailability">Данные для добавления</param>
    /// <returns>Добавленная доступность товара</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpPost]
    public ActionResult<ProductAvailability> Post(ProductAvailabilityCreateDTO newProductAvailability)
    {
        var productAvailability = availabilityService.Create(newProductAvailability);
        if (productAvailability == null)
        {
            return NotFound();
        }
        return Ok(productAvailability);
    }

    /// <summary>
    /// Изменить доступность товара
    /// </summary>
    /// <param name="productAvailability">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpPut]
    public IActionResult Put(ProductAvailabilityDTO productAvailability)
    {
        var result = availabilityService.Update(productAvailability);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить доступность товара
    /// </summary>
    /// <param name="id">Идентификатор доступности товара</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно удалены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result = availabilityService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
