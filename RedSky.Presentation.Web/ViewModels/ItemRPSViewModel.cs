using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class ItemRPSViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Display(Name = "Discriminação do Serviço")]
        [Required]
        public string DiscriminacaoServico { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:D4}")]
        public decimal Quantidade { get; set; }

        [Required]
        [Display(Name = "Valor Unitário")]
        [DisplayFormat(DataFormatString = "{0:C4}")]
        public decimal ValorUnitario { get; set; }

        [Required]
        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorTotal { get; set; }

        [Required]
        [Display(Name = "Tributável")]
        public string Tributavel { get; set; }

        [Required] public int IdRPS { get; set; }
    }
}