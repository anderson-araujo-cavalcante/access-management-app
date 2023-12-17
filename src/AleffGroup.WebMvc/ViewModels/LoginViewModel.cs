using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AleffGroup.WebMvc.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Login")]
        public string Login { get; set; }
       
        [DisplayName("Senha")]
        [Required(ErrorMessage = "Preencha o campo Senha")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}