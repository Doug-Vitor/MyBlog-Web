using System.ComponentModel.DataAnnotations;

public class UserViewModel : BaseUserViewModel
{
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public UserViewModel()
    {
    }
}
