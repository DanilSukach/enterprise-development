using StoreCashFlow.Api.DTO;
using StoreCashFlow.Domain.Context;
using StoreCashFlow.Domain.Entity;
namespace StoreCashFlow.Api.Service;

public class StoreService(StoreCashFlowDbContext storeCashFlowDbContext) : IEntityService<Store, int, StoreCreateDTO, StoreDTO>
{
    public Store Create(StoreCreateDTO newStoreDTO)
    {   
        var newStore = new Store
        {
            StoreId = 0,
            Location = newStoreDTO.Location
        };
        storeCashFlowDbContext.Store.Add(newStore);
        storeCashFlowDbContext.SaveChanges();
        return newStore;
    }

    public IEnumerable<Store> GetAll() => storeCashFlowDbContext.Store;

    public Store? GetById(int id)
    {
        return storeCashFlowDbContext.Store.FirstOrDefault(c => c.StoreId == id);
    }

    public bool Delete(int id)
    {
        var store = GetById(id);
        if (store == null)
        {
            return false;
        }
        storeCashFlowDbContext.Store.Remove(store);
        storeCashFlowDbContext.SaveChanges();
        return true;
    }

    public bool Update(StoreDTO updateStore)
    {
        var store = GetById(updateStore.StoreId);
        if (store == null)
        {
            return false;
        }
        store.Location = updateStore.Location;
        storeCashFlowDbContext.SaveChanges();
        return true;
    }
}
