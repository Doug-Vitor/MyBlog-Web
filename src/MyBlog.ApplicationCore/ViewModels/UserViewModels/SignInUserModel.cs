using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class SignInUserModel : BaseUserViewModel
{
    [DisplayName("Senha")]
    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public SignInUserModel()
    {
    }
}
