using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class LoginViewModel
    {
        public string Empresa { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please fill this field")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(1, ErrorMessage = "Please fill this field")]
        public string Senha { get; set; }

        [Required] public bool RememberMe { get; set; }
    }
}