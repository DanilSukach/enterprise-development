using Microsoft.AspNetCore.Mvc;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Api.Service;
using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.Controller;

/// <summary>
/// Запросы
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestController(RequestService requestService) : ControllerBase
{
    /// <summary>
    /// Выводит сведения о всех товарах в заданном магазине
    /// </summary>
    /// <returns>Список товаров</returns>
    [HttpGet]
    [Route("return-all-products-in-store")]
    public ActionResult<IEnumerable<Product>> ReturnAllProductsInStore([FromQuery] int id)
    {
        return Ok(requestService.ReturnAllProductsInStore(id));
    }

    /// <summary>
    /// Для заданного товара выводит список магазинов, в котором он находится в наличии
    /// </summary>
    /// <returns>Список магазинов</returns>
    [HttpGet]
    [Route("return-stores-with-product-in-stoke")]
    public ActionResult<IEnumerable<Store>> ReturnStoresWithProductInStock([FromQuery] string barcode)
    {
        return Ok(requestService.ReturnStoresWithProductInStock(barcode));
    }

    /// <summary>
    /// Выводит информацию о средней стоимости товаров каждой товарной группы для каждого магазина
    /// </summary>
    /// <returns>Список средних цен</returns>
    [HttpGet]
    [Route("return-average-price-by-group-and-store")]
    public ActionResult<IEnumerable<ProductPriceInfoDto>> ReturnAveragePriceByGroupAndStore()
    {
        return Ok(requestService.ReturnAveragePriceByGroupAndStore());
    }

    /// <summary>
    /// Выводит топ 5 покупок по общей сумме продажи
    /// </summary>
    /// <returns>Список покупок</returns>
    [HttpGet]
    [Route("return-top-5-sales-by-total-amount")]
    public ActionResult<IEnumerable<SaleInfoDto>> ReturnTop5SalesByTotalAmount()
    {
        return Ok(requestService.ReturnTop5SalesByTotalAmount());
    }

    /// <summary>
    /// Выводит все сведения о товарах, превышающих предельную дату хранения, с указанием магазина
    /// </summary>
    /// <return>Список просроченных товаров</return>
    [HttpGet]
    [Route("return-expired-products")]
    public ActionResult<IEnumerable<ExpiredProductInfoDto>> ReturnExpiredProducts([FromQuery] DateTime expirationDate)
    {
        return Ok(requestService.ReturnExpiredProducts(expirationDate));
    }

    /// <summary>
    /// Выводит список магазинов, в которых за месяц было продано товаров на сумму, превышающую заданную
    /// </summary>
    /// <returns>Список магазинов</returns>
    [HttpGet]
    [Route("get-stores-with-high-sales")]
    public ActionResult<IEnumerable<HighSalesDto>> GetStoresWithHighSales([FromQuery] DateTime monfStart, [FromQuery] DateTime monfEnd, [FromQuery] double treshold)
    {
        return Ok(requestService.GetStoresWithHighSales(monfStart, monfEnd, treshold));
    }
}
