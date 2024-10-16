using Microsoft.AspNetCore.Mvc;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Api.Service;
using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.Controller;

/// <summary>
/// Контроллер для работы с товарами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductController(ProductService productService) : ControllerBase
{
    /// <summary>
    ///  Получить все товары
    /// </summary>
    /// <returns>Список товаров</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(productService.GetAll());
    }

    /// <summary>
    /// Добавить товар
    /// </summary>
    /// <param name="newProduct">Новый товар</param>
    /// <returns>Добавленный товар</returns>
    /// <response code="200">Товар</response>
    /// <response code="404">Данные с указанным идентификатором не найдены или товар уже существует</response>
    [HttpPost]
    public ActionResult<Product> Post(ProductCreateDTO newProduct)
    {
        var product = productService.Create(newProduct);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    /// <summary>
    /// Получить товар по идентификатору
    /// </summary>
    /// <param name="barcode">Идентификатор товара</param>
    /// <returns>Возвращает товар</returns>
    /// <response code="200">Товар</response>
    /// <response code="404">Товар не найден</response>
    [HttpGet("{barcode}")]
    public ActionResult<Product> Get(string barcode)
    {
        var product = productService.GetById(barcode);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    /// <summary>
    /// Изменить товар
    /// </summary>
    /// <param name="product">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpPut]
    public IActionResult Put(ProductDTO product)
    {
        var result = productService.Update(product);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить товар
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно удалены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var result = productService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}