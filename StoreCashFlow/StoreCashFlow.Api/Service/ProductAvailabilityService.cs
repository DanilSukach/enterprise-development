using StoreCashFlow.Domain;
using StoreCashFlow.Api.DTO;
namespace StoreCashFlow.Api.Service;

public class ProductAvailabilityService(StoreService storeService, ProductService productService) : IEntityService<ProductAvailability, int, ProductAvailabilityCreateDTO, ProductAvailabilityDTO>
{
    private List<ProductAvailability> _productAvailabilities = [];
    private int _productAvailabilityId = 1;
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
            Id = _productAvailabilityId++,
            Store = store,
            Product = product,
            Quantity = newProductAvailabilityDTO.Quantity
        };
        _productAvailabilities.Add(newProductAvailability);
        return newProductAvailability;
    }

    public List<ProductAvailability> GetAll() => _productAvailabilities;

    public ProductAvailability? GetById(int id)
    {
        return _productAvailabilities.FirstOrDefault(c => c.Id == id);
    }

    public bool Delete(int id)
    {
        var productAvailability = GetById(id);
        if (productAvailability == null)
        {
            return false;
        }
        return _productAvailabilities.Remove(productAvailability);
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
        return true;
    }
}
