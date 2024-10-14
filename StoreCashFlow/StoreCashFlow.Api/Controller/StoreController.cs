using Microsoft.AspNetCore.Mvc;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Api.Service;
using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.Controller;

/// <summary>
/// Контроллер для работы с магазинами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class StoreController(StoreService storeService) : ControllerBase
{
    /// <summary>
    /// Получить все магазины
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Store>> Get()
    {
        return Ok(storeService.GetAll());
    }

    /// <summary>
    /// Получить магазин по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Store> Get(int id)
    {
        var store = storeService.GetById(id);
        if (store == null)
        {
            return NotFound();
        }
        return Ok(store);
    }

    /// <summary>
    /// Добавить магазин
    /// </summary>
    [HttpPost]
    public ActionResult<Store> Post(StoreCreateDTO newStoreDTO)
    {
        return Ok(storeService.Create(newStoreDTO));
    }

    /// <summary>
    /// Изменить магазин
    /// </summary>
    [HttpPut]
    public IActionResult Put(StoreDTO store)
    {
        var result = storeService.Update(store);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить магазин
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = storeService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
