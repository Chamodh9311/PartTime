namespace PartTimeV1.Data.Repository
{
    public interface IEFRepository<T> where T : Entity
    {
        T Create();
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        T FindById(params object[] keyValues);
    }
}
