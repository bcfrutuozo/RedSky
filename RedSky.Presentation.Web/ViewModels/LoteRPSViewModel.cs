using System;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class LoteRPSViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required] [Display(Name = "Filial")] public int IdFilial { get; set; }

        [Required] [MaxLength(10)] public string CodCidade { get; set; }

        [Required]
        [MaxLength(14)]
        [Display(Name = "CPF / CNPJ")]
        public string CPFCNPJRemetente { get; set; }

        [Required]
        [MaxLength(120)]
        [Display(Name = "Remetente")]
        public string RazaoSocialRemetente { get; set; }

        [Required] public bool Transacao { get; set; }

        [Required]
        [Display(Name = "Data do Primeiro RPS")]
        public DateTime DataPrimeiroRPS { get; set; }

        [Required]
        [Display(Name = "Data do Último RPS")]
        public DateTime DataUltimoRPS { get; set; }

        [Required]
        [Display(Name = "Quantidade de RPS")]
        public int QuantidadeRPS { get; set; }

        [Required]
        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorTotalServicos { get; set; }

        [Required]
        [Display(Name = "Deduções")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorTotalDeducoes { get; set; }

        [Required] [MaxLength(3)] public string Versao { get; set; }

        [Required] [MaxLength(3)] public string MetodoEnvio { get; set; }

        [Required] [Display(Name = "Status")] public int IdStatusLoteRPS { get; set; }

        [Display(Name = "Status")]
        public string StatusLoteRPS { get; set; }

        [Display(Name = "Número do Lote")] public long NumeroLote { get; set; }
    }
}