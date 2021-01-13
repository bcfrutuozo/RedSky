using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("TaskCell")]
    public class TaskCell : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTaskCell")]
        public int Id { get; set; }

        [Required]
        public int IdTaskColumn { get; set; }
        [ForeignKey("IdTaskColumn")]
        public virtual TaskColumn TaskColumn { get; set; }

        [Required]
        public int IdTask { get; set; }
        [ForeignKey("IdTask")]
        public virtual Task Task { get; set; }

        [Column(TypeName = "NVarChar")]
        public string Value { get; set; }
    }
}
