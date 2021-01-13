using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Servico")]
    public class Servico : IEntity
    {
        [Required] public int IdDemonstrativo { get; set; }

        [ForeignKey("IdDemonstrativo")] public virtual Demonstrativo Demonstrativo { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Descricao { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(31)] // Limite máximo permitido pelo EXCEL
        public string NomePlanilha { get; set; }

        [Required] public int IdUnidade { get; set; }

        [ForeignKey("IdUnidade")] public virtual Unidade Unidade { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 4)]
        public decimal Valor { get; set; }

        [Required] public int IdConexaoBanco { get; set; }

        [ForeignKey("IdConexaoBanco")] public virtual ConexaoBanco ConexaoBanco { get; set; }

        [Required] public bool HasQueryRateio { get; set; }

        [Column(TypeName = "NVarChar(MAX)")] public string QueryRateio { get; set; }

        [Required] public bool HasQueryDados { get; set; }

        [Column(TypeName = "NVarChar(MAX)")] public string QueryDados { get; set; }

        [Required] public int Ordem { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdServico")]
        public int Id { get; set; }
    }
}