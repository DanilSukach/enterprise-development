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
    /// <returns>Список продаж</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Sale>> Get()
    {
        return Ok(saleService.GetAll());
    }

    /// <summary>
    /// Получить продажу по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор продажи</param>
    /// <returns>Продажа</returns>
    /// <response code="200">Продажа</response>
    /// <response code="404">Продажа не найдена</response>
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
    /// <param name="newSaleDTO">Данные для добавления</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Продажа</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
    /// <param name="sale">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
    /// <param name="id">Идентификатор продажи</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно удалены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
