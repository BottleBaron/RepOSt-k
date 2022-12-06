interface ISelectWhere<T>
{
    T SelectSingle(int id);
    List<T> SelectWhere(int id);
}