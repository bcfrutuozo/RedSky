using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    
    public class DBProviderViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Tamanho mínimo permitido de {0} caracteres")]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Namespace { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Tamanho mínimo permitido de {0} caracteres")]
        [MaxLength(32, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}