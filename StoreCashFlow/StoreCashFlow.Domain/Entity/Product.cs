using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreCashFlow.Domain.Entity;

/// <summary>
/// Товар
/// </summary>
[Table("products")]
public class Product
{
    /// <summary>
    /// Штрих-код
    /// </summary>
    [Column("barcode")]
    [MaxLength(13)]
    [Required]
    public required string Barcode { get; set; }
    /// <summary>
    /// Код товарной группы
    /// </summary>
    [Column("product_group_code")]
    [MaxLength(10)]
    [Required]
    public required string ProductGroupCode { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    [Column("name")]
    [MaxLength(100)]
    [Required]
    public required string Name { get; set; }
    /// <summary>
    /// Вес упаковки
    /// </summary>
    [Column("weight")]
    [Required]
    public required double Weight { get; set; }
    /// <summary>
    /// Тип (штучный, развесной)
    /// </summary>
    [Column("product_type")]
    [Required]
    public required ProductType ProductType { get; set; }
    /// <summary>
    /// Стоимость
    /// </summary>
    [Column("price")]
    [Required]
    public required double Price { get; set; }
    /// <summary>
    /// Предельную дату хранения
    /// </summary>
    [Column("expiration_date")]
    [Required]
    public DateTime ExpirationDate { get; set; }
}