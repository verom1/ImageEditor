using System.Collections.Generic;

namespace ImageEditorApp.Repositories
{
    public interface IRepository<T, TKey> where T : class
    {
        T Get(TKey id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(TKey id);
    }
}
