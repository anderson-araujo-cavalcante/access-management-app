using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AleffGroup.WebMvc.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "Preencha o campo Login")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Preencha o campo Senha")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}