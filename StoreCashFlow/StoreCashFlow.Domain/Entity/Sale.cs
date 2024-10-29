using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreCashFlow.Domain.Entity;

/// <summary>
/// Продажи товаров покупателям
/// </summary>
[Table("sales")]
public class Sale
{
    /// <summary>
    /// Идентификатор покупки
    /// </summary>
    [Key]
    [Column("sale_id")]
    public int SaleId { get; set; }
    /// <summary>
    /// Магазин
    /// </summary>
    [Column("store_id")]
    [Required]
    public required Store Store { get; set; }
    /// <summary>
    /// Продукт
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
    /// <summary>
    /// Дата продажи
    /// </summary>
    [Column("sale_date")]
    [Required]
    public required DateTime SaleDate { get; set; }
    /// <summary>
    /// Покупатель
    /// </summary>
    [Column("customer_id")]
    [Required]
    public required Customer Customer { get; set; }

}