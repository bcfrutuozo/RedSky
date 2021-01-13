using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class DeducaoRPSViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [Display(Name = "Dedução por")]
        public string DeducaoPor { get; set; }

        [Required]
        [Display(Name = "Tipo de dedução")]
        public string TipoDeducao { get; set; }

        [Display(Name = "CPF / CNPJ de referência")]
        public string CPFCNPJReferencia { get; set; }

        [Display(Name = "Nº da NF de referência")]
        public string NumeroNFReferencia { get; set; }

        [Display(Name = "Valor total de referência")]
        public decimal? ValorTotalReferencia { get; set; }

        [Required]
        [Display(Name = "Percentual a deduzir")]
        public decimal PercentualDeduzir { get; set; }

        [Required]
        [Display(Name = "Valor a deduzir")]
        public decimal ValorDeduzir { get; set; }

        [Required] public int IdRPS { get; set; }
    }
}