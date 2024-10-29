using Microsoft.EntityFrameworkCore;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain.Context;
using StoreCashFlow.Domain.Entity;
namespace StoreCashFlow.Api.Service;

public class RequestService(StoreCashFlowDbContext storeCashFlowDbContext)
{
    public List<Product> ReturnAllProductsInStore(int id)
    {
        return storeCashFlowDbContext.ProductAvailability
            .Where(pa => pa.Store.StoreId == id)
            .Include(pa => pa.Product)
            .ThenInclude(p => p.ProductType)
            .Select(pa => pa.Product)
            .ToList();
    }
    public List<Store> ReturnStoresWithProductInStock(string barcode)
    {
        return storeCashFlowDbContext.ProductAvailability
            .Where(pa => pa.Product.Barcode == barcode)
            .Select(pa => pa.Store)
            .ToList();
    }
    public List<ProductPriceInfoDto> ReturnAveragePriceByGroupAndStore()
    {
        return storeCashFlowDbContext.ProductAvailability
            .GroupBy(pa => new { pa.Store.StoreId, pa.Product.ProductGroupCode })
            .Select(group => new ProductPriceInfoDto
            {
                StoreId = group.Key.StoreId,
                ProductGroupCode = group.Key.ProductGroupCode,
                AvgPrice = group.Average(pa => pa.Product.Price)
            })
            .ToList();
    }
    public List<SaleInfoDto> ReturnTop5SalesByTotalAmount()
    {
        return storeCashFlowDbContext.Sale
            .Include(s => s.Product)
            .Include(s => s.Store)
            .Include(s => s.Customer)
            .GroupBy(s => s.Product.ProductGroupCode)
            .ToList()
            .Select(group => new SaleInfoDto
            {
                ProductName = group.First().Product.Name,
                TotalAmount = Math.Round(group.Sum(s => s.Product.Price * s.Quantity), 2)
            })
            .OrderByDescending(g => g.TotalAmount)
            .Take(5)
            .ToList();
    }
    public List<ExpiredProductInfoDto> ReturnExpiredProducts(DateTime expirationDate)
    {
        return storeCashFlowDbContext.ProductAvailability
            .Include(pa => pa.Product)
            .ThenInclude(p => p.ProductType)
            .Include(pa => pa.Store)
            .Where(pa => pa.Product.ExpirationDate < expirationDate)
            .Select(pa => new ExpiredProductInfoDto
            {
                Product = pa.Product,
                Store = pa.Store
            })
            .ToList();
    }
    public List<HighSalesDto> GetStoresWithHighSales(DateTime monthStart, DateTime monthEnd, double threshold)
    {
        return storeCashFlowDbContext.Sale
            .Include(s => s.Store)
            .Include(s => s.Product)
            .Include(s => s.Customer)
            .Where(s => s.SaleDate >= monthStart && s.SaleDate <= monthEnd)
            .GroupBy(s => s.Store.StoreId)
            .ToList()
            .Select(group => new HighSalesDto
            {
                StoreId = group.Key,
                TotalSales = Math.Round(group.Sum(s => s.Quantity * s.Product.Price), 2)
            })
            .Where(result => result.TotalSales > threshold)
            .ToList();
    }
}
