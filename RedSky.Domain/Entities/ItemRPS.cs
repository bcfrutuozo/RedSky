using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("ItemRPS")]
    public class ItemRPS : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(80)]
        public string DiscriminacaoServico { get; set; }

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

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(1)]
        public string Tributavel { get; set; }

        [Required] public int IdRPS { get; set; }

        [ForeignKey("IdRPS")] public virtual RPS RPS { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdItemRPS")]
        public int Id { get; set; }
    }
}