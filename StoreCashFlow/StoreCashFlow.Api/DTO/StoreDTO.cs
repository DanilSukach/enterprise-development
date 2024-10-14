namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для магазина
/// </summary>
public class StoreDTO
{
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public int StoreId { get; set; }
    /// <summary>
    /// Местоположение магазина
    /// </summary>
    public required string Location { get; set; }
}
