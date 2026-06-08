namespace SistemaDeTurnosWeb.Repositories;

public interface IRepository<T>
{
    T? GetById(int id);
    IEnumerable<T> GetAll();
    T Add(T entity);
    bool Cancel(int id) => false;
    bool Realizar(int id) => false;
}
