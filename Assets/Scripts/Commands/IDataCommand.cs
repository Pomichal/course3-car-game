public interface IDataCommand<T>
{
    void Execute(T data);
}
