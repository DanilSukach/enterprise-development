﻿namespace StoreCashFlow.Api.DTO;

/// <summary>
/// DTO для высоких продаж
/// </summary>
public class HighSalesDto
{
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public int StoreId { get; set; }
    /// <summary>
    /// Указанная сумма продаж
    /// </summary>
    public double TotalSales { get; set; }
}
