using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для наличия товара
/// </summary>
public class ProductAvailabilityDTO
{
    /// <summary>
    /// Идентификатор наличия товара
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Магазин
    /// </summary>
    public required int StoreId { get; set; }
    /// <summary>
    /// Товар
    /// </summary>
    public required string ProductId { get; set; }
    /// <summary>
    /// Количество
    /// </summary>
    public required double Quantity { get; set; }
}
