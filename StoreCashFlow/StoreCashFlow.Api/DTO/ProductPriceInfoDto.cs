namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для информации о средней стоимости товарной группы в магазине
/// </summary>
public class ProductPriceInfoDto
{
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public int StoreId { get; set; }
    /// <summary>
    /// Товарная группа
    /// </summary>
    public required string ProductGroupCode { get; set; }

    /// <summary>
    /// Средняя цена
    /// </summary>
    public double AvgPrice { get; set; }
}
