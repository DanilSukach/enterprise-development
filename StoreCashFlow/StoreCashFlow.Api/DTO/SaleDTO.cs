using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для продажи
/// </summary>
public class SaleDTO
{
    /// <summary>
    /// Идентификатор покупки
    /// </summary>
    public int SaleId { get; set; }
    /// <summary>
    /// Магазин
    /// </summary>
    public required int StoreId { get; set; }
    /// <summary>
    /// Продукт
    /// </summary>
    public required string ProductId { get; set; }
    /// <summary>
    /// Количество
    /// </summary>
    public required double Quantity { get; set; }
    /// <summary>
    /// Дата продажи
    /// </summary>
    public required DateTime SaleDate { get; set; }
    /// <summary>
    /// Покупатель
    /// </summary>
    public required int CustomerId { get; set; }
}
