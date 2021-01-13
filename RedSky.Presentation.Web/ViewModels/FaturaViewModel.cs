using System;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class FaturaViewModel
    {
        [Key] [Range(0, int.MaxValue)] public int Id { get; set; }

        [Required]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; }

        [Display(Name = "Mês")] public int Mes { get; set; }

        public int Ano { get; set; }

        [Display(Name = "Filial")] public int IdFilial { get; set; }

        [Display(Name = "Cliente")] public int IdCliente { get; set; }

        [Display(Name = "É processável?")] public bool IsProcessavel { get; set; }

        [Display(Name = "Demonstrativo")] public int? IdDemonstrativo { get; set; }

        [Display(Name = "Atividade")] public int IdAtividade { get; set; }

        [Display(Name = "Possui Retenção")] public bool HasRetencao { get; set; }

        [Display(Name = "Estado")] public int IdEstadoPrestacao { get; set; }

        [Display(Name = "Cidade")] public int IdCidadePrestacao { get; set; }

        [Display(Name = "Tipo do Recolhimento")]
        public int IdTipoRecolhimento { get; set; }

        [Display(Name = "PIS")] public decimal AliquotaPIS { get; set; }

        [Display(Name = "COFINS")] public decimal AliquotaCOFINS { get; set; }

        [Display(Name = "INSS")] public decimal AliquotaINSS { get; set; }

        [Display(Name = "CSLL")] public decimal AliquotaCSLL { get; set; }

        [Display(Name = "IR")] public decimal AliquotaIR { get; set; }

        [Display(Name = "Alíquota ISS")] public decimal AliquotaISS { get; set; }

        [Display(Name = "ISS")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorISS { get; set; }

        public string Descritivo { get; set; }

        [Display(Name = "Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Competência")] public string Competencia { get; set; }

        public int IdStatusLoteRPS { get; set; }

        public bool IsFaturado { get; set; }
        public bool IsProcessado { get; set; }
    }
}