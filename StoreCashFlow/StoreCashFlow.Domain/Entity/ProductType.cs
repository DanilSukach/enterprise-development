using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreCashFlow.Domain.Entity;

/// <summary>
/// Тип товара 
/// </summary>
[Table("product_types")]
public class ProductType
{
    /// <summary>
    /// Идентификатор типа товара
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// Тип товара
    /// </summary>
    [Column("name")]
    [MaxLength(50)]
    [Required]
    public required string Name { get; set; }
}

