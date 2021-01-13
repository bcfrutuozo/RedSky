using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Atividade")]
    public class Atividade : IEntity
    {
        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(9)]
        [Index(IsUnique = true)]
        public string CodigoAtividade { get; set; }

        [Required]
        [Column(TypeName = "VarChar(MAX)")]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "VarChar(MAX)")]
        public string Servico { get; set; }

        [Required] public int IdIncidencia { get; set; }

        [ForeignKey("IdIncidencia")] public virtual Incidencia Incidencia { get; set; }

        [Required] public int IdTributacao { get; set; }

        [ForeignKey("IdTributacao")] public virtual Tributacao Tributacao { get; set; }

        [Required] public int IdOperacao { get; set; }

        [ForeignKey("IdOperacao")] public virtual Operacao Operacao { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsServico { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsImune { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsIsento { get; set; }

        [Required] public int IdItensServico { get; set; }

        [ForeignKey("IdItensServico")] public virtual ItensServico ItensServico { get; set; }

        [Required] public int IdUtilizacao { get; set; }

        [ForeignKey("IdUtilizacao")] public virtual Utilizacao Utilizacao { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(2)]
        public string Grupo { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdAtividade")]
        public int Id { get; set; }
    }
}