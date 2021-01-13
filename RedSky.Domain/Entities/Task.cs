using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Task")]
    public class Task : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTask")]
        public int Id { get; set; }

        [Required]
        public int IdTaskGroup { get; set; }
        [ForeignKey("IdTaskGroup")]
        public virtual TaskGroup TaskGroup { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string TaskTitle { get; set; }

        public virtual ICollection<TaskCell> TaskCells { get; set; }

        //public int? IdStatusTask { get; set; }
        //[ForeignKey("IdStatusTask")]
        //public virtual StatusTask StatusTask { get; set; }

        //[Column(TypeName = "Date")]
        //public DateTime? InitialDate { get; set; }

        //[Column(TypeName = "Date")]
        //public DateTime? EndingDate { get; set; }

        //[Column(TypeName = "Decimal")]
        //[DecimalPrecision(15, 4)]
        //public Decimal? Number { get; set; }

        //[Column(TypeName = "VarChar")]
        //[MaxLength(255)]
        //public string Text { get; set; }

        //public virtual ICollection<TaskUser> TaskUser { get; set; }
    }
}
