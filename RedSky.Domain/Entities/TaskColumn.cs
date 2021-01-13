using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("TaskColumn")]
    public class TaskColumn : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTaskColumn")]
        public int Id { get; set; }

        [Required]
        public int IdTaskGroup { get; set; }
        [ForeignKey("IdTaskGroup")]
        public virtual TaskGroup TaskGroup { get; set; }

        [Required]  
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string Header { get; set; }

        [Required]
        public int IdDataType { get; set; }
        [ForeignKey("IdDataType")]
        public virtual DataType DataType { get; set; }

        public virtual ICollection<TaskCell> TaskCells { get; set; }
    }
}
