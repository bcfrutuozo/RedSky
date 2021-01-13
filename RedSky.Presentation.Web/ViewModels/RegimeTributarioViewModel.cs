using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class RegimeTributarioViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage = "Tamanho máximo permitido de {0} caracteres")]
        public string Nome { get; set; }
    }
}