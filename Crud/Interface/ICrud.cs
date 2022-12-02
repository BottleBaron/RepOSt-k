public interface ICrud<T>
{
    List<T> Read();
    int Create(T obj);
    void Update(T obj);
    void Delete(T obj);
}