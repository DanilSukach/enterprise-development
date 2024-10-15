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
    /// <returns>Список типов товаров</returns>
    [HttpGet]
    public ActionResult<IEnumerable<ProductType>> Get()
    {
        return Ok(productTypeService.GetAll());
    }

    /// <summary>
    /// Получить тип товара по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор типа товара</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Тип товара</response>
    /// <response code="404">Тип товара не найден</response>
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
    /// <param name="newProductType">Данные для добавления</param>
    /// <returns>Добавленный тип товара</returns>
    [HttpPost]
    public ActionResult<ProductType> Post(ProductTypeCreateDTO newProductType)
    {
        return Ok(productTypeService.Create(newProductType));
    }

    /// <summary>
    /// Изменить тип товара
    /// </summary>
    /// <param name="productType">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
    /// <param name="id">Идентификатор типа товара</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно удалены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
