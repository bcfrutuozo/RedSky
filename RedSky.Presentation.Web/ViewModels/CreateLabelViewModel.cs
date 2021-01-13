using System;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class CreateLabelViewModel
    {
        [Key]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = @"Tamanho máximo permitido de {1} caracteres")]
        [Display(Name = "Label")]
        public string Description { get; set; }

        [Range(0, Int32.MaxValue)]
        public int IdEmpresa { get; set; }

        [Range(1, 20)]
        [Display(Name = "Color")]
        public int IdColor { get; set; }
    }
}