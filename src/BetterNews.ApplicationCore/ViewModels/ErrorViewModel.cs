using System.ComponentModel;

public class ErrorViewModel
{
    [DisplayName("Erros")]
    public List<string> ErrorsMessages { get; set; } = new();

    public ErrorViewModel()
    {
    }
}
