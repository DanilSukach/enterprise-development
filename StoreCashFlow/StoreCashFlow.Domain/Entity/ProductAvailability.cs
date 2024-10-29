using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreCashFlow.Domain.Entity;

/// <summary>
/// Наличие товара в магазине
/// </summary>
[Table("product_availability")]
public class ProductAvailability
{
    /// <summary>
    /// Идентификатор наличия товара
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    /// <summary>
    /// Магазин
    /// </summary>
    [Column("store_id")]
    [Required]
    public required Store Store { get; set; }
    /// <summary>
    /// Товар
    /// </summary>
    [Column("product_id")]
    [Required]
    public required Product Product { get; set; }
    /// <summary>
    /// Количество
    /// </summary>
    [Column("quantity")]
    [Required]
    public required double Quantity { get; set; }
}
