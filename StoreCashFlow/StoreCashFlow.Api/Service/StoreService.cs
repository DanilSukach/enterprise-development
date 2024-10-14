using StoreCashFlow.Domain;
using StoreCashFlow.Api.DTO;
namespace StoreCashFlow.Api.Service;

public class StoreService : IEntityService<Store, int, StoreCreateDTO, StoreDTO>
{
    private List<Store> _stores = [];
    private int _storeId = 1;
    public Store Create(StoreCreateDTO newStoreDTO)
    {   
        var newStore = new Store
        {
            StoreId = _storeId++,
            Location = newStoreDTO.Location
        };
        _stores.Add(newStore);
        return newStore;
    }

    public List<Store> GetAll() => _stores;

    public Store? GetById(int id)
    {
        return _stores.FirstOrDefault(c => c.StoreId == id);
    }

    public bool Delete(int id)
    {
        var store = GetById(id);
        if (store == null)
        {
            return false;
        }
        return _stores.Remove(store);
    }

    public bool Update(StoreDTO updateStore)
    {
        var store = GetById(updateStore.StoreId);
        if (store == null)
        {
            return false;
        }
        store.Location = updateStore.Location;
        return true;
    }
}
