using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AleffGroup.WebMvc.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }

        [DisplayName("Nome do Usuário")]
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo Login")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }
    }
}