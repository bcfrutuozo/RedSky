using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class OperacaoViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(1, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        [Display(Name = "Parâmetro")]
        public string Parametro { get; set; }
    }
}