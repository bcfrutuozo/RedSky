using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("LoteRPS")]
    public class LoteRPS : IEntity
    {
        [Required] public int IdFilial { get; set; }

        [ForeignKey("IdFilial")] public virtual Filial Filial { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(10)]
        public string CodCidade { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(14)]
        public string CPFCNPJRemetente { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(120)]
        public string RazaoSocialRemetente { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool Transacao { get; set; }

        [Required] [Column(TypeName = "Date")] public DateTime DataPrimeiroRPS { get; set; }

        [Required] [Column(TypeName = "Date")] public DateTime DataUltimoRPS { get; set; }

        [Required] public int QuantidadeRPS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorTotalServicos { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorTotalDeducoes { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string Versao { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string MetodoEnvio { get; set; }

        [Required] public int IdStatusLoteRPS { get; set; }

        [ForeignKey("IdStatusLoteRPS")] public virtual StatusLoteRPS StatusLoteRPS { get; set; }

        [Column(TypeName = "BigInt")] public long? NumeroLote { get; set; }

        public virtual ICollection<RPS> RPS { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdLoteRPS")]
        public int Id { get; set; }
    }
}