namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для информации о продажах
/// </summary>
public class SaleInfoDto
{
    /// <summary>
    /// Название продукта
    /// </summary>
    public required string ProductName { get; set; }
    /// <summary>
    /// Общая сумма продаж
    /// </summary>
    public double TotalAmount { get; set; }
}
