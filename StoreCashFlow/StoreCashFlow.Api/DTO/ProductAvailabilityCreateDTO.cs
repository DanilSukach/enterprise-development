using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для создания информации о наличии товара
/// </summary>
public class ProductAvailabilityCreateDTO
{
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
