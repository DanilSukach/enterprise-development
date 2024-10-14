using Microsoft.AspNetCore.Mvc;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Api.Service;
using StoreCashFlow.Domain;
namespace StoreCashFlow.Api.Controller;

/// <summary>
/// Контроллер для работы с продажами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SaleController(SaleService saleService) : ControllerBase
{
    /// <summary>
    /// Получить все продажи
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Sale>> Get()
    {
        return Ok(saleService.GetAll());
    }

    /// <summary>
    /// Получить продажу по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Sale> Get(int id)
    {
        var sale = saleService.GetById(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }

    /// <summary>
    /// Добавить продажу
    /// </summary>
    [HttpPost]
    public ActionResult<Sale> Post(SaleCreateDTO newSaleDTO)
    {
        var newSale = saleService.Create(newSaleDTO);
        if (newSale == null)
        {
            return NotFound();
        }
        return Ok(newSale);
    }

    /// <summary>
    /// Изменить продажу
    /// </summary>
    [HttpPut]
    public IActionResult Put(SaleDTO sale)
    {
        var result = saleService.Update(sale);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить продажу
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = saleService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
