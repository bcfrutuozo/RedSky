using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedSky.Presentation.Web.ViewModels
{
    public class RPSViewModel
    {
        public RPSViewModel()
        {
            ItensRPS = new List<ItemRPSViewModel>();
            DeducaoRPS = new List<DeducaoRPSViewModel>();
            NotaFiscal = new List<NotaFiscalViewModel>();
        }

        [Key] [Range(1, int.MaxValue)] public int Id { get; set; }

        public bool IsChecked { get; set; }

        [Required] public int IdFatura { get; set; }

        [Display(Name = "Identificação")] public string Identificacao { get; set; }

        public long? IdLoteRPS { get; set; }

        public string Assinatura { get; set; }

        public string InscricaoMunicipalPrestador { get; set; }

        public string RazaoSocialPrestador { get; set; }

        public string TipoRPS { get; set; }

        public string SerieRPS { get; set; }

        [Display(Name = "Nº do RPS")] public long NumeroRPS { get; set; }

        public DateTime DataEmissaoRPS { get; set; }

        public string SituacaoRPS { get; set; }

        public string SerieRPSSubstituido { get; set; }

        public string NumeroNFSeSubstituida { get; set; }

        public string NumeroRPSSubstituido { get; set; }

        public DateTime? DataEmissaoNFSeSubstituida { get; set; }

        public string SeriePrestacao { get; set; }

        public string InscricaoMunicipalTomador { get; set; }

        [Display(Name = "CPF/CNPJ do Tomador")]
        public string CPFCNPJTomador { get; set; }

        [Display(Name = "Tomador")] public string RazaoSocialTomador { get; set; }

        public string DocTomadorEstrangeiro { get; set; }

        public string TipoLogradouroTomador { get; set; }

        public string LogradouroTomador { get; set; }

        public string NumeroEnderecoTomador { get; set; }

        public string ComplementoEnderecoTomador { get; set; }

        public string TipoBairroTomador { get; set; }

        public string BairroTomador { get; set; }

        public string CidadeTomador { get; set; }

        public string CidadeTomadorDescricao { get; set; }

        public string CEPTomador { get; set; }

        public string EmailTomador { get; set; }

        public int IdAtividade { get; set; }

        public decimal AliquotaAtividade { get; set; }

        public string TipoRecolhimento { get; set; }

        public string MunicipioPrestacao { get; set; }

        public string MunicipioPrestacaoDescricao { get; set; }

        public string Operacao { get; set; }

        public string Tributacao { get; set; }

        public decimal ValorPIS { get; set; }

        public decimal ValorCOFINS { get; set; }

        public decimal ValorINSS { get; set; }

        public decimal ValorIR { get; set; }

        public decimal ValorCSLL { get; set; }

        public decimal AliquotaPIS { get; set; }

        public decimal AliquotaCOFINS { get; set; }

        public decimal AliquotaINSS { get; set; }

        public decimal AliquotaIR { get; set; }

        public decimal AliquotaCSLL { get; set; }

        public string DescricaoRPS { get; set; }

        public string DDDPrestador { get; set; }

        public string TelefonePrestador { get; set; }

        public string DDDTomador { get; set; }

        public string TelefoneTomador { get; set; }

        public string MotivoCancelamento { get; set; }

        public string CPFCNPJIntermediario { get; set; }

        public string MatriculaCEI { get; set; }

        [Display(Name = "Valor Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorTotal { get; set; }

        [Display(Name = "Total de Deduções")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal DeducaoTotal { get; set; }

        public ICollection<ItemRPSViewModel> ItensRPS { get; set; }

        public ICollection<DeducaoRPSViewModel> DeducaoRPS { get; set; }

        public ICollection<NotaFiscalViewModel> NotaFiscal { get; set; }
    }
}