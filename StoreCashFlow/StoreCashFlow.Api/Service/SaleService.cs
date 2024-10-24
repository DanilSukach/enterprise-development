using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain.Context;
using StoreCashFlow.Domain.Entity;
using System.Collections.Generic;

namespace StoreCashFlow.Api.Service;

public class SaleService(StoreCashFlowDbContext storeCashFlowDbContext, ProductService productService, StoreService storeService, CustomerService customerService) : IEntityService<Sale, int, SaleCreateDTO, SaleDTO>
{
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
            SaleId = 0,
            SaleDate = newSaleDTO.SaleDate,
            Product = product,
            Quantity = newSaleDTO.Quantity,
            Store = store,
            Customer = customer
        };
        storeCashFlowDbContext.Sale.Add(newSale);
        storeCashFlowDbContext.SaveChanges();
        return newSale;
    }

    public IEnumerable<Sale> GetAll() => storeCashFlowDbContext.Sale;

    public Sale? GetById(int id)
    {
        return storeCashFlowDbContext.Sale.FirstOrDefault(c => c.SaleId == id);
    }

    public bool Delete(int id)
    {
        var sale = GetById(id);
        if (sale == null)
        {
            return false;
        }
        storeCashFlowDbContext.Sale.Remove(sale);
        storeCashFlowDbContext.SaveChanges();
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
        storeCashFlowDbContext.SaveChanges();
        return true;
    }
}
