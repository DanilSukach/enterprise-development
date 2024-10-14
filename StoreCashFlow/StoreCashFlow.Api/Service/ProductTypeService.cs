using StoreCashFlow.Domain;
using StoreCashFlow.Api.DTO;
namespace StoreCashFlow.Api.Service;

public class ProductTypeService : IEntityService<ProductType, int, ProductTypeCreateDTO, ProductTypeDTO>
{
    private List<ProductType> _productTypes = [];
    private int _productTypeId = 1;
    public ProductType Create(ProductTypeCreateDTO newProductTypeDTO)
    {
        var newProductType = new ProductType
        {
            Id = _productTypeId++,
            Name = newProductTypeDTO.Name
        };
        _productTypes.Add(newProductType);
        return newProductType;
    }

    public List<ProductType> GetAll() => _productTypes;

    public ProductType? GetById(int id)
    {
        return _productTypes.FirstOrDefault(c => c.Id == id);
    }

    public bool Delete(int id)
    {
        var productType = GetById(id);
        if (productType == null)
        {
            return false;
        }
        _productTypes.Remove(productType);
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
        return true;
    }
}
