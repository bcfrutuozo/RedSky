using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class EstadoViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        public string Nome { get; set; }

        [MinLength(2, ErrorMessage = @"Tamanho mínimo permitido de {0} caracteres")]
        [MaxLength(2, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        public string Sigla { get; set; }
    }
}