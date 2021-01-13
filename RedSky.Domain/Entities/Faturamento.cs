using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Faturamento")]
    public class Faturamento : IEntity
    {
        [Required] public int IdFatura { get; set; }

        [ForeignKey("IdFatura")] public virtual Fatura Fatura { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Descritivo { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(10, 4)]
        public decimal Quantidade { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 4)]
        public decimal ValorUnitario { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorTotal { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdFaturamento")]
        public int Id { get; set; }
    }
}