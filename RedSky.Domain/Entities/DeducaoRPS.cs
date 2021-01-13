using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("DeducaoRPS")]
    public class DeducaoRPS : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(20)]
        public string DeducaoPor { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(255)]
        public string TipoDeducao { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(255)]
        public string CPFCNPJReferencia { get; set; }

        [Column(TypeName = "BigInt")] public uint? NumeroNFReferencia { get; set; }

        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal? ValorTotalReferencia { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(5, 2)]
        public decimal PercentualDeduzir { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorDeduzir { get; set; }

        [Required] public int IdRPS { get; set; }

        [ForeignKey("IdRPS")] public virtual RPS RPS { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdDeducaoRPS")]
        public int Id { get; set; }
    }
}