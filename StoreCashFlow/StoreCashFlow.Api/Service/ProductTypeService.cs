using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain.Context;
using StoreCashFlow.Domain.Entity;
namespace StoreCashFlow.Api.Service;

public class ProductTypeService(StoreCashFlowDbContext storeCashFlowDbContext) : IEntityService<ProductType, int, ProductTypeCreateDTO, ProductTypeDTO>
{
    public ProductType Create(ProductTypeCreateDTO newProductTypeDTO)
    {
        var newProductType = new ProductType
        {
            Id = 0,
            Name = newProductTypeDTO.Name
        };
        storeCashFlowDbContext.ProductTypes.Add(newProductType);
        storeCashFlowDbContext.SaveChanges();
        return newProductType;
    }

    public IEnumerable<ProductType> GetAll() => storeCashFlowDbContext.ProductTypes;

    public ProductType? GetById(int id)
    {
        return storeCashFlowDbContext.ProductTypes.FirstOrDefault(c => c.Id == id);
    }

    public bool Delete(int id)
    {
        var productType = GetById(id);
        if (productType == null)
        {
            return false;
        }
        storeCashFlowDbContext.Remove(productType);
        storeCashFlowDbContext.SaveChanges();
        return true;
    }

    public bool Update(ProductTypeDTO updateProductType)
    {
        var productType = GetById(updateProductType.Id);
        if (productType == null)
        {
            return false;
        }
        productType.Name = updateProductType.Name;
        storeCashFlowDbContext.SaveChanges();
        return true;
    }
}
