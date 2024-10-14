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
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(productService.GetAll());
    }

    /// <summary>
    /// Добавить товар
    /// </summary>
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
    [HttpGet("{id}")]
    public ActionResult<Product> Get(string id)
    {
        var product = productService.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    /// <summary>
    /// Изменить товар
    /// </summary>
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