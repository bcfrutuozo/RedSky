using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class CreateColumnViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int IdTaskGroup { get; set; }

        [Required(ErrorMessage = @"Preencha o campo {0}")]
        [MinLength(4, ErrorMessage = "Mínimo de {1} caracteres")]
        [MaxLength(32, ErrorMessage = "Tamanho máximo permitido de {1} caracteres")]
        [Display(Name = "Header")]
        public string Header { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Data Type")]
        public int IdDataType { get; set; }
    }
}