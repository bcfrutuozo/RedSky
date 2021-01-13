using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("TipoRecolhimento")]
    public class TipoRecolhimento : IEntity
    {

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(1)]
        public string Parametro { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTipoRecolhimento")]
        public int Id { get; set; }
    }
}