using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("TaskUser")]
    public class TaskUser : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTaskUser")]
        public int Id { get; set; }

        [Required]
        public int IdTask { get; set; }
        [ForeignKey("IdTask")]
        public virtual Task Task { get; set; }
        
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }
}
    }
