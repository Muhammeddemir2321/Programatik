namespace Core.Persistence.Repositories;

public interface IQuery<out T> where T : class
{
    IQueryable<T> Query();
}
