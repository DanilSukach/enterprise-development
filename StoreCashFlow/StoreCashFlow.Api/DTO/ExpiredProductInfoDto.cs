using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для информации о просроченном товаре
/// </summary>
public class ExpiredProductInfoDto
{
    /// <summary>
    /// Просроченный товар
    /// </summary>
    public required Product Product { get; set; }
    /// <summary>
    /// Магазин
    /// </summary>
    public required Store Store { get; set; }
}
