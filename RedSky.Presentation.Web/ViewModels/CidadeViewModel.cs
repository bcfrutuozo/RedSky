using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class CidadeViewModel
    {
        public CidadeViewModel()
        {
            Estado = new EstadoViewModel();
        }

        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required] [Range(1, int.MaxValue)] public int IdEstado { get; set; }

        public EstadoViewModel Estado { get; set; }

        [Required] public string Nome { get; set; }

        [Required]
        [Display(Name = "Codigo SIAFI")]
        public string Codigo { get; set; }
    }
}