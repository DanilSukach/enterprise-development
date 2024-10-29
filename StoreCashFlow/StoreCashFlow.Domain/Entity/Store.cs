using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreCashFlow.Domain.Entity;

/// <summary>
/// Магазин
/// </summary>
[Table("stores")]
public class Store
{
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    [Key]
    [Column("store_id")]
    public int StoreId { get; set; }
    /// <summary>
    /// Местоположение магазина
    /// </summary>
    [Column("location")]
    [Required]
    public required string Location { get; set; }
}

