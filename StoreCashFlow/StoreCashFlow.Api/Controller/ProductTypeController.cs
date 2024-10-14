using Microsoft.AspNetCore.Mvc;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Api.Service;
using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.Controller;

/// <summary>
/// Контроллер для работы с типами товаров
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductTypeController(ProductTypeService productTypeService) : ControllerBase
{
    /// <summary>
    /// Получить все типы товаров
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ProductType>> Get()
    {
        return Ok(productTypeService.GetAll());
    }

    /// <summary>
    /// Получить тип товара по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<ProductType> Get(int id)
    {
        var productType = productTypeService.GetById(id);
        if (productType == null)
        {
            return NotFound();
        }
        return Ok(productType);
    }

    /// <summary>
    /// Добавить тип товара
    /// </summary>
    [HttpPost]
    public ActionResult<ProductType> Post(ProductTypeCreateDTO newProductType)
    {
        return Ok(productTypeService.Create(newProductType));
    }

    /// <summary>
    /// Изменить тип товара
    /// </summary>
    [HttpPut]
    public IActionResult Put(ProductTypeDTO productType)
    {
        var result = productTypeService.Update(productType);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить тип товара
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = productTypeService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
