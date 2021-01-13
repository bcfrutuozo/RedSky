using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class GetTrackingsViewModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required(ErrorMessage = @"Preencha o campo Identificação")]
        [MinLength(4, ErrorMessage = "Mínimo de {1} caracteres")]
        [MaxLength(64, ErrorMessage = "Tamanho máximo permitido de {1} caracteres")]
        [Display(Name = "'Title")]
        public string TaskGroupTitle { get; set; }

        public IList<TaskDisplayViewModel> Tasks { get; set; }

        public IList<TaskColumnDisplayViewModel> Columns { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int IdEmpresa { get; set; }
    }
}