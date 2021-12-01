public class HttpResponseViewModel
{
    public bool Success { get; set; }
    public ErrorViewModel ErrorViewModel { get; set; }

    public HttpResponseViewModel()
    {
    }

    public HttpResponseViewModel(bool success) => Success = success;

    public HttpResponseViewModel(bool success, ErrorViewModel errorViewModel) 
        => (Success, ErrorViewModel) = (success, errorViewModel);
}
