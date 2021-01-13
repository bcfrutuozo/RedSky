using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Operacao")]
    public class Operacao : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(1)]
        public string Parametro { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdOperacao")]
        public int Id { get; set; }
    }
}