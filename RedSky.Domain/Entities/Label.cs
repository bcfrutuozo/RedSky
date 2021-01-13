using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Label")]
    public class Label : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdLabel")]
        public int Id { get; set; }

        public int? IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(16)]
        public string Description { get; set; }

        [Required]
        public int IdColor { get; set; }

        [ForeignKey("IdColor")]
        public virtual Color Color { get; set; }
    }
}
