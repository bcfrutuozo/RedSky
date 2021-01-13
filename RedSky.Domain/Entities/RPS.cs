using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Security;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("RPS")]
    public class RPS : IEntity
    {
        [Required] public int IdFatura { get; set; }

        [ForeignKey("IdFatura")] public virtual Fatura Fatura { get; set; }

        public int? IdLoteRPS { get; set; }

        [ForeignKey("IdLoteRPS")] public virtual LoteRPS LoteRPS { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(2000)]
        public string Assinatura { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(11)]
        public string InscricaoMunicipalPrestador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(120)]
        public string RazaoSocialPrestador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(20)]
        public string TipoRPS { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(10)]
        public string SerieRPS { get; set; }

        [Column(TypeName = "BigInt")]
        public long? NumeroRPS { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime DataEmissaoRPS { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(1)]
        public string SituacaoRPS { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(10)]
        public string SerieRPSSubstituido { get; set; }

        [Column(TypeName = "BigInt")] public long? NumeroNFSeSubstituida { get; set; }

        [Column(TypeName = "BigInt")] public long? NumeroRPSSubstituido { get; set; }

        [Column(TypeName = "Date")] public DateTime? DataEmissaoNFSeSubstituida { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(2)]
        public string SeriePrestacao { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(11)]
        public string InscricaoMunicipalTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(14)]
        public string CPFCNPJTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(120)]
        public string RazaoSocialTomador { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(20)]
        public string DocTomadorEstrangeiro { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(10)]
        public string TipoLogradouroTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(50)]
        public string LogradouroTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(9)]
        public string NumeroEnderecoTomador { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(30)]
        public string ComplementoEnderecoTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(10)]
        public string TipoBairroTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(50)]
        public string BairroTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(10)]
        public string CidadeTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(50)]
        public string CidadeTomadorDescricao { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(8)]
        public string CEPTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(60)]
        public string EmailTomador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(9)]
        public string CodigoAtividade { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaAtividade { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(1)]
        public string TipoRecolhimento { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(10)]
        public string MunicipioPrestacao { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(30)]
        public string MunicipioPrestacaoDescricao { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(1)]
        public string Operacao { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(1)]
        public string Tributacao { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorPIS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorCOFINS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorINSS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorIR { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorCSLL { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaPIS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaCOFINS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaINSS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaIR { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaCSLL { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(1500)]
        public string DescricaoRPS { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string DDDPrestador { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(8)]
        public string TelefonePrestador { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string DDDTomador { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(8)]
        public string TelefoneTomador { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(80)]
        public string MotivoCancelamento { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(14)]
        public string CPFCNPJIntermediario { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(15)]
        public string MatriculaCEI { get; set; }

        [Column(TypeName = "NVarChar(MAX)")]
        public string StatusProcessamento { get; set; }

        public virtual ICollection<ItemRPS> ItensRPS { get; set; }
        public virtual ICollection<DeducaoRPS> DeducaoRPS { get; set; }
        public virtual ICollection<NotaFiscal> NotaFiscal { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdRPS")]
        public int Id { get; set; }

        public void AssinarRPS()
        {
            if(!NumeroRPS.HasValue)
                throw new ArgumentNullException($"O campo NumeroRPS do RPS de Id {Id} deve possuir um valor para poder assinar o RPS");

            /* Geração do campo ASSINATURA do RPS */
            var assinatura = new StringBuilder();
            assinatura.Append(InscricaoMunicipalPrestador.PadLeft(11, '0'));
            assinatura.Append(@"NF".PadRight(5, ' '));
            assinatura.Append(NumeroRPS.ToString().PadLeft(12, '0'));
            assinatura.Append(DataEmissaoRPS.ToString("yyyyMMdd"));
            assinatura.Append(Tributacao.PadRight(2, ' '));
            assinatura.Append(@"N"); // TODO: SITUAÇÃO RPS CANCELADA, IMPLEMENTADO SOMENTE NORMAL
            assinatura.Append(TipoRecolhimento == @"A" ? @"N" : @"S");
            assinatura.Append(ItensRPS.Sum(v => v.ValorTotal).ToString(CultureInfo.CurrentCulture).Replace(",", string.Empty)
                .Replace(".", string.Empty).PadLeft(15, '0'));
            assinatura.Append(DeducaoRPS.Sum(v => v.ValorDeduzir).ToString(CultureInfo.CurrentCulture).Replace(",", string.Empty)
                .Replace(".", string.Empty).PadLeft(15, '0'));
            assinatura.Append(CodigoAtividade.PadLeft(10, '0'));
            assinatura.Append(CPFCNPJTomador.PadLeft(14, '0'));

            Assinatura = Cryptography.GetBase64SHA1(assinatura.ToString());
        }
    }
}