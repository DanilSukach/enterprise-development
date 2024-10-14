using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain;

namespace StoreCashFlow.Api.Service;

public class SaleService(ProductService productService, StoreService storeService, CustomerService customerService) : IEntityService<Sale, int, SaleCreateDTO, SaleDTO>
{
    private List<Sale> _sales = [];
    private int _saleId = 1;
    public Sale? Create(SaleCreateDTO newSaleDTO)
    {
        var product = productService.GetById(newSaleDTO.ProductId);
        var store = storeService.GetById(newSaleDTO.StoreId);
        var customer = customerService.GetById(newSaleDTO.CustomerId);
        if (product == null || store == null || customer == null)
        {
            return null;
        }
        var newSale = new Sale
        {
            SaleId = _saleId++,
            SaleDate = newSaleDTO.SaleDate,
            Product = product,
            Quantity = newSaleDTO.Quantity,
            Store = store,
            Customer = customer
        };
        _sales.Add(newSale);
        return newSale;
    }

    public List<Sale> GetAll() => _sales;

    public Sale? GetById(int id)
    {
        return _sales.FirstOrDefault(c => c.SaleId == id);
    }

    public bool Delete(int id)
    {
        var sale = GetById(id);
        if (sale == null)
        {
            return false;
        }
        _sales.Remove(sale);
        return true;
    }

    public bool Update(SaleDTO updateSale)
    {
        var sale = GetById(updateSale.SaleId);
        if (sale == null)
        {
            return false;
        }
        var product = productService.GetById(updateSale.ProductId);
        var store = storeService.GetById(updateSale.StoreId);
        var customer = customerService.GetById(updateSale.CustomerId);
        if (product == null || store == null || customer == null)
        {
            return false;
        }
        sale.SaleDate = updateSale.SaleDate;
        sale.Product = product;
        sale.Quantity = updateSale.Quantity;
        sale.Store = store;
        sale.Customer = customer;
        return true;
    }
}
