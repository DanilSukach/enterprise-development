using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для товара
/// </summary>
public class ProductDTO
{
    /// <summary>
    /// Штрих-код
    /// </summary>
    public required string Barcode { get; set; }
    /// <summary>
    /// Код товарной группы
    /// </summary>
    public required string ProductGroupCode { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Вес упаковки
    /// </summary>
    public required double Weight { get; set; }
    /// <summary>
    /// Тип (штучный, развесной)
    /// </summary>
    public required int ProductTypeId { get; set; }
    /// <summary>
    /// Стоимость
    /// </summary>
    public required double Price { get; set; }
    /// <summary>
    /// Предельную дату хранения
    /// </summary>
    public DateTime ExpirationDate { get; set; }
}
