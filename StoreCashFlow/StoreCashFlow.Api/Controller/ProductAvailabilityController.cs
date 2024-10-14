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
    /// Получить все доступные товаров
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ProductAvailability>> Get()
    {
        return Ok(availabilityService.GetAll());
    }

    /// <summary>
    /// Получить доступность товара по идентификатору
    /// </summary>
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
    /// Изменить доступность товара
    /// </summary>
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
