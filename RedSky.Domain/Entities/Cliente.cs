using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Cliente")]
    public class Cliente : IEntity
    {
        [Required] public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")] public virtual Empresa Empresa { get; set; }

        [Required]
        [Column(TypeName = "NVarChar")]
        [MaxLength(32)]
        public string Apelido { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(14)]
        public string CPFCNPJ { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string RazaoSocial { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string InscricaoMunicipal { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string InscricaoEstadual { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(8)]
        public string CEP { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Logradouro { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(5)]
        public string Numero { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Complemento { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Bairro { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string DDD { get; set; }

        [Column(TypeName = "VarChar")]
        [MaxLength(9)]
        public string Telefone { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(60)]
        public string EmailNF { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        public string EmailsEnvio { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(16)]
        public string Sigla { get; set; }

        [Required] public int IdCidade { get; set; }

        [ForeignKey("IdCidade")] public virtual Cidade Cidade { get; set; }

        [Required] public int IdTipoLogradouro { get; set; }

        [ForeignKey("IdTipoLogradouro")] public virtual TipoLogradouro TipoLogradouro { get; set; }

        [Required] public int IdTipoBairro { get; set; }

        [ForeignKey("IdTipoBairro")] public virtual TipoBairro TipoBairro { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCliente")]
        public int Id { get; set; }
    }
}