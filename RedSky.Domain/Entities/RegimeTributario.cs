using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("RegimeTributario")]
    public class RegimeTributario : IEntity
    {
        
        [Required]
        [MaxLength(32)]
        [Column(TypeName = "VarChar")]
        public string Nome { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdRegimeTributario")]
        public int Id { get; set; }
    }
}