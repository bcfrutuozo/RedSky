using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Cidade")]
    public class Cidade : IEntity
    {
        [Required] public int IdEstado { get; set; }

        [ForeignKey("IdEstado")] public virtual Estado Estado { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(4)]
        public string Codigo { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCidade")]
        public int Id { get; set; }
    }
}