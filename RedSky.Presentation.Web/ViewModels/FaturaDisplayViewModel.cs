using System;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class FaturaDisplayViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Display(Name = "Nº da NF")] public long? NumeroNF { get; set; }

        [Display(Name = "Filial")] public string Filial { get; set; }

        [Display(Name = "Competência")] public string Competencia { get; set; }

        [Display(Name = "Arquivo")] public string NomeArquivo { get; set; }

        [Required]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }


        [Display(Name = "Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Recebimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? DataRecebimento { get; set; }

        [Display(Name = "Valor Bruto")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorBruto { get; set; }

        [Display(Name = "Valor Líquido")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorLiquido { get; set; }

        [Display(Name = "Valor Recebido")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorRecebido { get; set; }

        [Display(Name = "Valor Dedutível")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorDedutivel { get; set; }

        [Display(Name = "PIS")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorPIS { get; set; }

        [Display(Name = "COFINS")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorCOFINS { get; set; }

        [Display(Name = "INSS")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorINSS { get; set; }

        [Display(Name = "CSLL")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorCSLL { get; set; }

        [Display(Name = "IR")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorIR { get; set; }

        [Display(Name = "ISS")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorISS { get; set; }

        [Display(Name = "Valor dos Impostos Retidos na Fonte")]
        public decimal ValorImpostosRetidos =>
            ValorCOFINS + ValorCSLL + ValorINSS + ValorIR + ValorPIS;

        public int IdFilial { get; set; }

        public bool IsFaturado { get; set; }

        public bool IsProcessado { get; set; }

        public bool IsEdit { get; set; }

        public bool IsCancelada { get; set; }

        [Display(Name = "É processável?")] public bool IsProcessavel { get; set; }

        public int IdLoteRPS { get; set; }

        public int IdRPS { get; set; }

        public int IdStatusLoteRPS { get; set; }
    }
}