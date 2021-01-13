using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Filial")]
    public class Filial : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Identificacao { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string NomeFantasia { get; set; }

        [Required] public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")] public virtual Empresa Empresa { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(14)]
        public string CPFCNPJ { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(8)]
        public string CEP { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Logradouro { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(5)]
        public string Numero { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Complemento { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Bairro { get; set; }

        [Required] public int IdCidade { get; set; }

        [ForeignKey("IdCidade")] public virtual Cidade Cidade { get; set; }

        [Required] public int IdTipoLogradouro { get; set; }

        [ForeignKey("IdTipoLogradouro")] public virtual TipoLogradouro TipoLogradouro { get; set; }

        [Required] public int IdTipoBairro { get; set; }

        [ForeignKey("IdTipoBairro")] public virtual TipoBairro TipoBairro { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string InscricaoMunicipal { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaISS { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string InscricaoEstadual { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string DDD { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(9)]
        public string Telefone { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Email { get; set; }

        [Required]
        public int QuantidadeRPSPorLote { get; set; }

        public virtual ICollection<CertificadoDigital> CertificadosDigitais { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdFilial")]
        public int Id { get; set; }
    }
}