using Microsoft.EntityFrameworkCore;
using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain.Context;
using StoreCashFlow.Domain.Entity;

namespace StoreCashFlow.Api.Service;

public class ProductService (StoreCashFlowDbContext storeCashFlowDbContext, ProductTypeService productTypeService) : IEntityService<Product, string, ProductCreateDTO, ProductDTO>
{ 
    public Product? Create(ProductCreateDTO newProductDTO)
    {
        var product = GetById(newProductDTO.Barcode);
        if (product != null)
        {
            return null;
        }
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
        storeCashFlowDbContext.Products.Add(newProduct);
        storeCashFlowDbContext.SaveChanges();
        return newProduct;
    }

    public IEnumerable<Product> GetAll() => storeCashFlowDbContext.Products.Include(p => p.ProductType);

    public Product? GetById(string id)
    {
        return storeCashFlowDbContext.Products.Include(p => p.ProductType).FirstOrDefault(c => c.Barcode == id);
    }

    public bool Delete(string id)
    {
        var product = GetById(id);
        if (product == null)
        {
            return false;
        }
        storeCashFlowDbContext.Products.Remove(product);
        storeCashFlowDbContext.SaveChanges();
        return true;
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
        storeCashFlowDbContext.SaveChanges();
        return true;
    }
}