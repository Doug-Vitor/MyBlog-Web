using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class CreateUserInputModel : BaseUserViewModel
{
    [DisplayName("Senha")]
    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Campo {0} é obrigatório.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public CreateUserInputModel()
    {
    }
}
