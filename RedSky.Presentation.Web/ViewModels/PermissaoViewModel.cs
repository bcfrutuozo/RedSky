using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class PermissaoViewModel
    {
        [Key] [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Nome { get; set; }

        public bool IsEnabled { get; set; }
    }
}