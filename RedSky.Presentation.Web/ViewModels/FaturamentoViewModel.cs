using System.ComponentModel.DataAnnotations;
using RedSky.Common;

namespace RedSky.Presentation.Web.ViewModels
{
    public class FaturamentoViewModel
    {
        [Key] [Range(1, int.MaxValue)] public int Id { get; set; }

        public bool IsChecked { get; set; }

        [Required] public int IdFatura { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = @"Tamanho máximo permitido de {0} caracteres")]
        public string Descritivo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C4}")]
        public decimal Quantidade { get; set; }

        [Required]
        [Display(Name = "Valor Unitário")]
        [DisplayFormat(DataFormatString = "{0:C4}", ApplyFormatInEditMode = true)]
        public decimal ValorUnitario { get; set; }

        [Required]
        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal ValorTotal => (Quantidade * ValorUnitario).DecimalTowardZero(2);
    }
}