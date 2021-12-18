public class HttpResponseViewModel<T> where T : class
{
    public bool Success { get; set; }
    public T ViewModel { get; set; }
    public ErrorViewModel ErrorViewModel { get; set; }

    public HttpResponseViewModel()
    {
    }

    public HttpResponseViewModel(bool success) => Success = success;

    public HttpResponseViewModel(bool success, T viewModel) 
        => (Success, ViewModel) = (success, viewModel);

    public HttpResponseViewModel(bool success, ErrorViewModel errorViewModel) 
        => (Success, ErrorViewModel) = (success, errorViewModel);
}