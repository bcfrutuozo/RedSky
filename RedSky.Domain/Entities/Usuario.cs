using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;

namespace RedSky.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario : IEntity
    {
        public int? IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")] public virtual Empresa Empresa { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(32)]
        [Index(IsUnique = true)]
        public string Login { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Senha { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(36)]
        public string Hash { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool Parametrizador { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Email { get; set; }

        [Column(TypeName = "VarBinary")]
        public byte[] Picture { get; set; }

        public virtual ICollection<UsuarioPermissao> UsuarioPermissao { get; set; }

        public virtual ICollection<TaskUser> TaskUser { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUsuario")]
        public int Id { get; set; }
    }
}