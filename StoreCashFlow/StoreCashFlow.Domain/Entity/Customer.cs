using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreCashFlow.Domain.Entity;

/// <summary>
/// Покупатель
/// </summary>
[Table("customers")]
public class Customer
{
    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    [Key]
    [Column("customer_id")]
    public required int CustomerId { get; set; }
    /// <summary>
    /// Номер карты
    /// </summary>
    [Column("card_number")]
    [MaxLength(16)]
    [Required]
    public required string CardNumber { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    [Column("last_name")]
    [Required]
    public required string LastName { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    [Column("first_name")]
    [Required]
    public required string FirstName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    [Column("patronymic")]
    [Required]
    public required string Patronymic { get; set; }
}
