using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("NotaFiscal")]
    public class NotaFiscal : IEntity
    {
        [Required] public int IdRPS { get; set; }

        [ForeignKey("IdRPS")] public virtual RPS RPS { get; set; }

        [Required]
        [Column(TypeName = "BigInt")]
        public long NumeroNF { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(128)]
        public string CodigoVerificacao { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(128)]
        public string NomeArquivo { get; set; }

        [Column(TypeName = "VarChar(MAX)")] public string Link { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsCancelada { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime DataProcessamento { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(80)]
        public string MotivoCancelamento { get; set; }

        [NotMapped] public ICollection<EventoNFSe> Eventos { get; set; }

        [NotMapped] public long NumeroRPS { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdNotaFiscal")]
        public int Id { get; set; }

        public static string GetInvoiceFullName(NotaFiscal notaFiscal)
        {
            string caminho;
            var competenciaTrabalho =
                new AccountingPeriod(notaFiscal.RPS.Fatura.Competencia.Substring(0, 2) + "/" +
                                     notaFiscal.RPS.Fatura.Competencia.Substring(2, 4));

            if (notaFiscal.RPS.Fatura.Demonstrativo != null)
            {
                if (string.IsNullOrEmpty(notaFiscal.RPS.Fatura.Demonstrativo.Departamento))
                    caminho = Path.Combine(notaFiscal.RPS.Fatura.Prestador.Empresa.CaminhoRelatorio,
                        $"CLIENTE-{notaFiscal.RPS.Fatura.Tomador.Sigla.Split('-')[0]}",
                        "Faturamento",
                        competenciaTrabalho.Year.ToString(),
                        $"{competenciaTrabalho.Month:D2} - {competenciaTrabalho.FullMonthName}",
                        $"FAT_{notaFiscal.RPS.Fatura.Tomador.Sigla}_{new string(notaFiscal.RPS.CPFCNPJTomador.Where(char.IsDigit).ToArray())}_{competenciaTrabalho.Month:D2}_{competenciaTrabalho.Year}_{notaFiscal.NumeroNF:D8}.pdf");
                else
                    caminho = Path.Combine(notaFiscal.RPS.Fatura.Prestador.Empresa.CaminhoRelatorio,
                        $"CLIENTE-{notaFiscal.RPS.Fatura.Tomador.Sigla.Split('-')[0]}",
                        "Faturamento",
                        competenciaTrabalho.Year.ToString(),
                        $"{competenciaTrabalho.Month:D2} - {competenciaTrabalho.FullMonthName}",
                        notaFiscal.RPS.Fatura.Tomador.Sigla.Split('-')[1],
                        $"FAT_{notaFiscal.RPS.Fatura.Tomador.Sigla}_{notaFiscal.RPS.Fatura.Demonstrativo.Departamento.Replace(@"\", string.Empty).Replace(@"/", string.Empty)}_{competenciaTrabalho.Month:D2}_{competenciaTrabalho.Year}_{notaFiscal.NumeroNF:D8}.pdf");
            }
            else
            {
                int indexAdd = 0;

                if (notaFiscal.RPS.Fatura.Tomador.Sigla.Split('-').Length > 1)
                    indexAdd += 1;

                caminho = Path.Combine(notaFiscal.RPS.Fatura.Prestador.Empresa.CaminhoRelatorio,
                    $"CLIENTE-{notaFiscal.RPS.Fatura.Tomador.Sigla.Split('-')[0]}",
                    "Faturamento",
                    competenciaTrabalho.Year.ToString(),
                    $"{competenciaTrabalho.Month:D2} - {competenciaTrabalho.FullMonthName}",
                    notaFiscal.RPS.Fatura.Tomador.Sigla.Split('-')[indexAdd],
                    $"FAT_{notaFiscal.RPS.Fatura.Tomador.Sigla}_{new string(notaFiscal.RPS.CPFCNPJTomador.Where(char.IsDigit).ToArray())}_{string.Join("-", notaFiscal.RPS.Fatura.Identificacao.Split(Path.GetInvalidFileNameChars()))}_{competenciaTrabalho.Month:D2}_{competenciaTrabalho.Year}_{notaFiscal.NumeroNF:D8}.pdf");
            }

            return caminho;
        }
    }
}