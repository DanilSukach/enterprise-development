namespace StoreCashFlow.Api.Service;

public interface IEntityService<TEntity, TKey, TCreateDto, TUpdateDto>
{
    public List<TEntity> GetAll();
    public TEntity? GetById(TKey id);
    public TEntity? Create(TCreateDto newEntity);
    public bool Update(TUpdateDto entity);
    public bool Delete(TKey id);
}
