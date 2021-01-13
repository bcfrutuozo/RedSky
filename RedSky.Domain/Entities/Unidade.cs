using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Unidade")]
    public class Unidade : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Descricao { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUnidade")]
        public int Id { get; set; }
    }
}