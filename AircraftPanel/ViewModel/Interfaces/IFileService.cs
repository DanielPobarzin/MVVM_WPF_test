namespace ViewModel.Interfaces
{
    public interface IFileService<T>
    {
        List<T> Open(string fileName);
    }
}
