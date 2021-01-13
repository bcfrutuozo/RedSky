using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("StatusProjeto")]
    public class StatusProjeto : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdStatusProjeto")]
        public Int32 Id { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Descricao { get; set; }
    }
}
