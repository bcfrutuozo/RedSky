using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("DBProvider")]
    public class DBProvider : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Namespace { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string Descricao { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdDBProvider")]
        public int Id { get; set; }
    }
}