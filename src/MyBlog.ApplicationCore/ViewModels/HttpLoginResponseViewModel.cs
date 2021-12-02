public class HttpLoginResponseViewModel : HttpResponseViewModel
{
    public string GeneratedToken { get; set; }

    public HttpLoginResponseViewModel()
    {
    }

    public HttpLoginResponseViewModel(bool success, string generatedToken) : base(success)
        => GeneratedToken = generatedToken;

    public HttpLoginResponseViewModel(bool success, ErrorViewModel errorViewModel) : base(success, errorViewModel)
    {
    }
}