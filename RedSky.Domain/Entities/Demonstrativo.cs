using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Demonstrativo")]
    public class Demonstrativo : IEntity
    {
        [Required] public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")] public virtual Empresa Empresa { get; set; }

        [Required] public int IdCliente { get; set; }

        [ForeignKey("IdCliente")] public virtual Cliente Cliente { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal ValorMinimo { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool EnviaEmail { get; set; }

        [Required]
        [Column(TypeName = "NVarChar")]
        [StringLength(128)]
        public string AssuntoEmail { get; set; }

        [Required]
        [Column(TypeName = "NVarChar(MAX)")]
        public string DestinatariosEmail { get; set; }

        [Required]
        [Column(TypeName = "NVarChar(MAX)")]
        public string MensagemEmail { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Departamento { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool IsFaturavel { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; }

        public virtual ICollection<Fatura> Faturas { get; set; }

        [NotMapped] public bool HasFaturas => Faturas != null && Faturas.Count > 0 ? true : false;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdDemonstrativo")]
        public int Id { get; set; }
    }
}