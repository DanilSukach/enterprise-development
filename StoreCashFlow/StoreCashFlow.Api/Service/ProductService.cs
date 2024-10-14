using StoreCashFlow.Domain;
using StoreCashFlow.Api.DTO;

namespace StoreCashFlow.Api.Service;

public class ProductService (ProductTypeService productTypeService) : IEntityService<Product, string, ProductCreateDTO, ProductDTO>
{
    private List<Product> _products = [];
    public Product? Create(ProductCreateDTO newProductDTO)
    {
        var productType = productTypeService.GetById(newProductDTO.ProductTypeId);
        if (productType == null)
        {
            return null;
        }
        var newProduct = new Product
        {
            Barcode = newProductDTO.Barcode,
            Name = newProductDTO.Name,
            Price = newProductDTO.Price,
            ProductGroupCode = newProductDTO.ProductGroupCode,
            ProductType = productType,
            Weight = newProductDTO.Weight,
            ExpirationDate = newProductDTO.ExpirationDate
        };
        _products.Add(newProduct);
        return newProduct;
    }

    public List<Product> GetAll() => _products;

    public Product? GetById(string id)
    {
        return _products.FirstOrDefault(c => c.Barcode == id);
    }

    public bool Delete(string id)
    {
        var product = GetById(id);
        if (product == null)
        {
            return false;
        }
        return _products.Remove(product);
    }

    public bool Update(ProductDTO updateProduct)
    {
        var product = GetById(updateProduct.Barcode);
        if (product == null)
        {
            return false;
        }
        var productType = productTypeService.GetById(updateProduct.ProductTypeId);
        if (productType == null)
        {
            return false;
        }
        product.Name = updateProduct.Name;
        product.Price = updateProduct.Price;
        product.ProductGroupCode = updateProduct.ProductGroupCode;
        product.ProductType = productType;
        product.Weight = updateProduct.Weight;
        product.ExpirationDate = updateProduct.ExpirationDate;
        return true;
    }
}