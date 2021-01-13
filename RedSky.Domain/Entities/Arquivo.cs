using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Arquivo")]
    public class Arquivo : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "VarBinary")]
        public byte[] Dados { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdArquivo")]
        public int Id { get; set; }
    }
}