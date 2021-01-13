using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Security;

namespace RedSky.Domain.Entities
{
    [Table("ConexaoBanco")]
    public class ConexaoBanco : IEntity
    {
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Servidor { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string Database { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        public string UsuarioBanco { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string SenhaBanco { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(36)]
        public string Hash { get; set; }

        [Required] public int IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")] public virtual Empresa Empresa { get; set; }

        [Required] public int IdDBProvider { get; set; }

        [ForeignKey("IdDBProvider")] public virtual DBProvider DBProvider { get; set; }

        [NotMapped]
        public ConnectionStringSettings ConnectionString =>
            new ConnectionStringSettings(Nome,
                $"Server={Servidor};Database={Database};Usuario Id={UsuarioBanco};Password={Cryptography.DecryptWithSalt(SenhaBanco, Hash)}",
                DBProvider.Namespace);

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdConexaoBanco")]
        public int Id { get; set; }
    }
}