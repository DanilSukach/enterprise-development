namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для создания клиента
/// </summary>
public class CustomerCreateDTO
{
    /// <summary>
    /// Номер карты
    /// </summary>
    public required string CardNumber { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public required string LastName { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public required string Potronimic { get; set; }
}
