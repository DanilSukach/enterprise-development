namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для типа товара
/// </summary>
public class ProductTypeDTO
{
    /// <summary>
    /// Идентификатор типа товара
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Тип товара
    /// </summary>
    public required string Name { get; set; }
}
