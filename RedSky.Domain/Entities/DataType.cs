using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("DataType")]
    public class DataType : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdDataType")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Type { get; set; }

        [Required]  
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string Name { get; set; }

        public virtual ICollection<TaskColumn> TaskColumns { get; set; }
    }
}
