using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("NotaNegocio")]
    public class NotaNegocio : IEntity
    {
        [Required] public int IdNegocio { get; set; }

        [ForeignKey("IdNegocio")] public virtual Negocio Negocio { get; set; }

        [Required]
        [Column(TypeName = "NVarChar")]
        [MaxLength(4000)]
        public string Mensagem { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime Data { get; set; }

        [Required] public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")] public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Arquivo> Arquivos { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdNotaNegocio")]
        public int Id { get; set; }
    }
}