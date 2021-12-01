public class HttpResponseViewModel
{
    public bool Success { get; set; }
    public UserViewModel UserViewModel { get; set; }
    public ErrorViewModel ErrorViewModel { get; set; }

    public HttpResponseViewModel()
    {
    }

    public HttpResponseViewModel(bool success, UserViewModel viewModel) 
        => (Success, UserViewModel) = (success, viewModel);

    public HttpResponseViewModel(bool success, ErrorViewModel errorViewModel) 
        => (Success, ErrorViewModel) = (success, errorViewModel);
}
