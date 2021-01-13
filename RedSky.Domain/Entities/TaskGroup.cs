using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("TaskGroup")]
    public class TaskGroup : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTaskGroup")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string TaskGroupTitle { get; set; }

        [Required]
        public int IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<TaskColumn> Columns { get; set; }
    }
}
