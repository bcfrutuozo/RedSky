using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class CreateTaskGroupViewModel
    {
        [Required(ErrorMessage = @"Preencha o campo {0}")]
        [MinLength(4, ErrorMessage = "Mínimo de {1} caracteres")]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {1} caracteres")]
        [Display(Name = "Title")]
        public string TaskGroupTitle { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int IdEmpresa { get; set; }
    }
}