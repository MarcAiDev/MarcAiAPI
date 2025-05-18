namespace MarcAiAPI.Domain.Interfaces;

public interface IBaseRepository<TEntity>
{
    void Insert(TEntity obj);
    void Update(TEntity obj);
    void Delete(int id);
    IList<TEntity> GetAll();
    TEntity Find(int id);
}