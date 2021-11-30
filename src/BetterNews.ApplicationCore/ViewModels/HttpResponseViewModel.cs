public class HttpResponseViewModel<TResponse>
{
    public TResponse HttpResponse { get; set; }
    public ErrorViewModel ErrorViewModel { get; set; }

    public HttpResponseViewModel()
    {
    }

    public HttpResponseViewModel(TResponse response) => HttpResponse = response;
    public HttpResponseViewModel(ErrorViewModel viewModel) => ErrorViewModel = viewModel;
}
