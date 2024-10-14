namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для создания магазина
/// </summary>
public class StoreCreateDTO
{
    /// <summary>
    /// Местоположение магазина
    /// </summary>
    public required string Location { get; set; }
}
