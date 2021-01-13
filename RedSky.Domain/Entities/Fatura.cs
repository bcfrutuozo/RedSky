using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using RedSky.Common;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Security;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Fatura")]
    public class Fatura : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        public string Identificacao { get; set; }

        [Required] public int Mes { get; set; }

        [Required] public int Ano { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string NomeArquivo { get; set; }

        [Required] public int IdFilial { get; set; }

        [ForeignKey("IdFilial")] public virtual Filial Prestador { get; set; }

        [Required] public int IdCliente { get; set; }

        [ForeignKey("IdCliente")] public virtual Cliente Tomador { get; set; }

        public int? IdDemonstrativo { get; set; }

        [ForeignKey("IdDemonstrativo")] public virtual Demonstrativo Demonstrativo { get; set; }

        [Required] public int IdAtividade { get; set; }

        [ForeignKey("IdAtividade")] public virtual Atividade Atividade { get; set; }

        [Required] public int IdCidadePrestacao { get; set; }

        [ForeignKey("IdCidadePrestacao")] public virtual Cidade LocalPrestacao { get; set; }

        [Required] public int IdTipoRecolhimento { get; set; }

        [ForeignKey("IdTipoRecolhimento")] public virtual TipoRecolhimento TipoRecolhimento { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorBruto { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorLiquido { get; set; }

        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorRecebido { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorDedutivel { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaPIS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorPIS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaCOFINS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorCOFINS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaINSS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorINSS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaCSLL { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorCSLL { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaIR { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorIR { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaISS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorISS { get; set; }

        [Column(TypeName = "NVarChar")]
        [MaxLength(1024)]
        public string Descritivo { get; set; }

        [Required] [Column(TypeName = "Date")] public DateTime DataVencimento { get; set; }

        [Column(TypeName = "Date")] public DateTime? DataRecebimento { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(6)]
        public string Competencia { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsProcessado { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsFaturado { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsEdit { get; set; }

        public virtual ICollection<Faturamento> Faturamentos { get; set; }

        public virtual ICollection<RPS> RPS { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdFatura")]
        public int Id { get; set; }

        public RPS CriarRPS(int? idLoteRPS = null)
        {
            var novoRPS = new RPS
            {
                AliquotaAtividade = this.AliquotaISS,
                AliquotaCOFINS = this.AliquotaCOFINS,
                AliquotaCSLL = this.AliquotaCSLL,
                AliquotaINSS = this.AliquotaINSS,
                AliquotaIR = this.AliquotaIR,
                AliquotaPIS = this.AliquotaPIS,
                //Assinatura = Cryptography.GetBase64SHA1(assinatura.ToString()), -> RPS DEVE SER ASSINADO NA HORA DE SER ENVIADO COM O NUMERO SEQUENCIAL DO RPS.
                BairroTomador = this.Tomador.Bairro.TruncateLongString(50),
                CEPTomador = this.Tomador.CEP,
                // CPFCNPJIntermediario = ,
                CidadeTomador = this.Tomador.Cidade.Codigo,
                CidadeTomadorDescricao = this.Tomador.Cidade.Nome.TruncateLongString(50),
                CodigoAtividade = this.Atividade.CodigoAtividade.TruncateLongString(9),
                ComplementoEnderecoTomador = this.Tomador.Complemento.TruncateLongString(30),
                CPFCNPJTomador = this.Tomador.CPFCNPJ.Length <= 11
                    ? this.Tomador.CPFCNPJ.PadLeft(11, '0')
                    : this.Tomador.CPFCNPJ.PadLeft(14, '0'),
                DDDPrestador = this.Prestador.DDD.TruncateLongString(3),
                DDDTomador = this.Tomador.DDD.TruncateLongString(3),
                // DataEmissaoNFSeSubstituida = ,
                DataEmissaoRPS = DateTime.Now,
                // DeducaoRPS = ,
                DescricaoRPS = this.Descritivo
                    .Replace(@"@VENCIMENTO", this.DataVencimento.ToString("dd/MM/yyyy")).Replace(@"@COMPETENCIA",
                        new AccountingPeriod(this.Competencia).FullPeriod).ToUpper(),
                // DocTomadorEstrangeiro = ,
                EmailTomador = this.Tomador.EmailNF.TruncateLongString(60),
                IdFatura = this.Id,
                IdLoteRPS = idLoteRPS,
                InscricaoMunicipalPrestador = this.Prestador.InscricaoMunicipal.PadLeft(9, '0'),
                InscricaoMunicipalTomador = string.IsNullOrEmpty(this.Tomador.InscricaoMunicipal)
                    ? @"000000000"
                    : this.Tomador.InscricaoMunicipal.PadLeft(9, '0'),
                LogradouroTomador = this.Tomador.Logradouro.TruncateLongString(50),
                // MatriculaCEI = ,
                // MotivoCancelamento = ,
                MunicipioPrestacao = this.LocalPrestacao.Codigo,
                MunicipioPrestacaoDescricao = this.LocalPrestacao.Nome.TruncateLongString(50),
                NumeroEnderecoTomador = this.Tomador.Numero,
                // NumeroNFSeSubstituida = ,
                // NumeroRPS = numeroRPS, -> Inserido somente na hora de enviar o lote de forma sequêncial.
                // NumeroRPSSubstituido = ,
                Operacao = this.Atividade.Operacao.Parametro,
                RazaoSocialPrestador = this.Prestador.Empresa.RazaoSocial.TruncateLongString(120),
                RazaoSocialTomador = this.Tomador.RazaoSocial.TruncateLongString(120),
                SeriePrestacao = @"99",
                SerieRPS = @"NF",
                // SerieRPSSubstituido = ,
                SituacaoRPS = @"N", // N - Normal | C - Cancelado
                TelefonePrestador = this.Prestador.Telefone.TruncateLongString(8),
                TelefoneTomador = this.Tomador.Telefone.TruncateLongString(8),
                TipoBairroTomador = this.Tomador.TipoBairro.Descricao.TruncateLongString(10),
                TipoLogradouroTomador = this.Tomador.TipoLogradouro.Descricao.TruncateLongString(10),
                TipoRPS = @"RPS",
                TipoRecolhimento = this.TipoRecolhimento.Parametro,
                Tributacao = this.Atividade.Tributacao.Parametro,
                ValorCOFINS = this.ValorCOFINS,
                ValorCSLL = this.ValorCSLL,
                ValorINSS = this.ValorINSS,
                ValorIR = this.ValorIR,
                ValorPIS = this.ValorPIS
            };

            // Transforma os faturamentos atuais em itens da RPS
            IList<ItemRPS> itens = new List<ItemRPS>();
            foreach (var faturamento in this.Faturamentos)
                itens.Add(new ItemRPS
                {
                    RPS = novoRPS,
                    DiscriminacaoServico = faturamento.Descritivo,
                    Quantidade = faturamento.Quantidade,
                    ValorUnitario = faturamento.ValorUnitario,
                    ValorTotal = faturamento.ValorTotal,
                    Tributavel = @"S"
                });

            // Transforma os descontos atuais para as deduções da RPS.
            IList<DeducaoRPS> deducoes = new List<DeducaoRPS>();
            // TODO: lógica para criação de deduções.

            // Vincula os itens e deduções no RPS
            novoRPS.ItensRPS = itens;
            novoRPS.DeducaoRPS = deducoes;

            return novoRPS;
        }

        public static string GetBillingFullName(Fatura fatura)
        {
            string caminho;
            var competenciaTrabalho =
                new AccountingPeriod(fatura.Competencia.Substring(0, 2) + "/" + fatura.Competencia.Substring(2, 4));

            if (fatura.IdDemonstrativo.HasValue)
            {
                if (string.IsNullOrEmpty(fatura.Demonstrativo.Departamento))
                    caminho = Path.Combine(fatura.Prestador.Empresa.CaminhoRelatorio,
                        $"CLIENTE-{fatura.Tomador.Sigla.Split('-')[0]}",
                        "Faturamento",
                        competenciaTrabalho.Year.ToString(),
                        $"{competenciaTrabalho.Month:D2} - {competenciaTrabalho.FullMonthName}",
                        $"FAT_{fatura.Tomador.Sigla}_{new string(fatura.Demonstrativo.Cliente.CPFCNPJ.Where(char.IsDigit).ToArray())}_{competenciaTrabalho.Month:D2}_{competenciaTrabalho.Year}.xlsx");
                else
                    caminho = Path.Combine(fatura.Prestador.Empresa.CaminhoRelatorio,
                        $"CLIENTE-{fatura.Tomador.Sigla.Split('-')[0]}",
                        "Faturamento",
                        competenciaTrabalho.Year.ToString(),
                        $"{competenciaTrabalho.Month:D2} - {competenciaTrabalho.FullMonthName}",
                        fatura.Tomador.Sigla.Split('-')[1],
                        $"FAT_{fatura.Tomador.Sigla}_{fatura.Demonstrativo.Departamento.Replace(@"\", string.Empty).Replace(@"/", string.Empty)}_{competenciaTrabalho.Month:D2}_{competenciaTrabalho.Year}.xlsx");
            }
            else
            {
                caminho = Path.Combine(fatura.Prestador.Empresa.CaminhoRelatorio,
                    $"CLIENTE-{fatura.Tomador.Sigla.Split('-')[0]}",
                    "Faturamento",
                    competenciaTrabalho.Year.ToString(),
                    $"{competenciaTrabalho.Month:D2} - {competenciaTrabalho.FullMonthName}",
                    fatura.Tomador.Sigla.Split('-')[1],
                    $"FAT_{fatura.Tomador.Sigla}_{ string.Join("-", fatura.Identificacao.Split(Path.GetInvalidFileNameChars()))}_{competenciaTrabalho.Month:D2}_{competenciaTrabalho.Year}.xlsx");
            }

            return caminho;
        }
    }
}