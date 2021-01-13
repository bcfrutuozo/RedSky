using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class LabelDisplayViewModel
    {
        [Key]
        [Range(1, int.MaxValue)] public int Id { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = @"Tamanho máximo permitido de {1} caracteres")]
        [Display(Name = "Label")]
        public string Description { get; set; }

        public ColorDisplayViewModel Color { get; set; }
    }
}