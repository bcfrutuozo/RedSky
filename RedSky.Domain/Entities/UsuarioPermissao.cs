using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("UsuarioPermissao")]
    public class UsuarioPermissao : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUsuarioPermissao")]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
        
        [Required]
        public int IdPermissao { get; set; }
        [ForeignKey("IdPermissao")]
        public virtual Permissao Permissao { get; set; }
    }
}
