using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Projeto")]
    public class Projeto : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdProjeto")]
        public Int32 Id { get; set; }

        [Required]
        public Int32 IdEmpresa { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Identificacao { get; set; }

        [Required]
        [Column(TypeName = "NVarChar")]
        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFinal { get; set; }

        [Required]
        public int IdStatusProjeto { get; set; }
        [ForeignKey("IdStatusProjeto")]
        public virtual StatusProjeto StatusProjeto { get; set; }
    }
}
