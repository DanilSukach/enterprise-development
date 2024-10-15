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
    /// <returns>Список магазинов</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Store>> Get()
    {
        return Ok(storeService.GetAll());
    }

    /// <summary>
    /// Получить магазин по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор магазина</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Магазин</response>
    /// <response code="404">Магазин не найден</response>
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
    /// <param name="newStoreDTO">Данные для добавления</param>
    /// <returns>Добавленный магазин</returns>
    [HttpPost]
    public ActionResult<Store> Post(StoreCreateDTO newStoreDTO)
    {
        return Ok(storeService.Create(newStoreDTO));
    }

    /// <summary>
    /// Изменить магазин
    /// </summary>
    /// <param name="store">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
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
    /// <param name="id">Идентификатор магазина</param>
    /// <returns>Результат операции</returns>
    /// <response code = "200">Магазин успешно удален</response>
    /// <response code = "404">Магазин не найден</response>
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
