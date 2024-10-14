namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для создания типа товара
/// </summary>
public class ProductTypeCreateDTO
{
    /// <summary>
    /// Тип товара
    /// </summary>
    public required string Name { get; set; }
}
