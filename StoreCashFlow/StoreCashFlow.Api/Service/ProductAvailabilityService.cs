using Microsoft.EntityFrameworkCore;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain.Context;
using StoreCashFlow.Domain.Entity;
namespace StoreCashFlow.Api.Service;

public class ProductAvailabilityService(StoreCashFlowDbContext storeCashFlowDbContext, StoreService storeService, ProductService productService) : IEntityService<ProductAvailability, int, ProductAvailabilityCreateDTO, ProductAvailabilityDTO>
{
    public ProductAvailability? Create(ProductAvailabilityCreateDTO newProductAvailabilityDTO)
    {
        var store = storeService.GetById(newProductAvailabilityDTO.StoreId);
        var product = productService.GetById(newProductAvailabilityDTO.ProductId);
        if (store == null || product == null)
        {
            return null;
        }
        var newProductAvailability = new ProductAvailability
        {
            Id = 0,
            Store = store,
            Product = product,
            Quantity = newProductAvailabilityDTO.Quantity
        };
        storeCashFlowDbContext.Add(newProductAvailability);
        storeCashFlowDbContext.SaveChanges();
        return newProductAvailability;
    }

    public IEnumerable<ProductAvailability> GetAll() => storeCashFlowDbContext.ProductAvailability.Include(p => p.Product).ThenInclude(p => p.ProductType).Include(p => p.Store);

    public ProductAvailability? GetById(int id)
    {
        return storeCashFlowDbContext.ProductAvailability.Include(p => p.Product).ThenInclude(p => p.ProductType).Include(p => p.Store).FirstOrDefault(c => c.Id == id);
    }

    public bool Delete(int id)
    {
        var productAvailability = GetById(id);
        if (productAvailability == null)
        {
            return false;
        }
        storeCashFlowDbContext.ProductAvailability.Remove(productAvailability);
        storeCashFlowDbContext.SaveChanges();
        return true;
    }

    public bool Update(ProductAvailabilityDTO updateProductAvailability)
    {
        var productAvailability = GetById(updateProductAvailability.Id);
        if (productAvailability == null)
        {
            return false;
        }
        var store = storeService.GetById(updateProductAvailability.StoreId);
        var product = productService.GetById(updateProductAvailability.ProductId);
        if (store == null || product == null)
        {
            return false;
        }
        productAvailability.Store = store;
        productAvailability.Product = product;
        productAvailability.Quantity = updateProductAvailability.Quantity;
        storeCashFlowDbContext.SaveChanges();
        return true;
    }
}
