using System;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class ProjetoDisplayViewModel
    {
        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int IdEmpresa { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "O tamanho máximo permitido para o campo é de 128 caracteres")]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Finalização")]
        public DateTime? DataFinal { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
