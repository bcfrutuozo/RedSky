using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Estado")]
    public class Estado : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(2)]
        public string Sigla { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdEstado")]
        public int Id { get; set; }
    }
}