using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Negocio")]
    public class Negocio : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string NomeContato { get; set; }


        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Empresa { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(15, 2)]
        public decimal Valor { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string DDD1 { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(9)]
        public string Telefone1 { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string DDD2 { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(9)]
        public string Telefone2 { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(3)]
        public string DDD3 { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(9)]
        public string Telefone3 { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(64)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [MaxLength(128)]
        public string Website { get; set; }

        [Required] public int IdUsuarioResponsavel { get; set; }

        [ForeignKey("IdUsuarioResponsavel")] public virtual Usuario UsuarioResponsavel { get; set; }

        [Required] public int IdEtapaVenda { get; set; }

        [ForeignKey("IdEtapaVenda")] public virtual EtapaVenda EtapaVenda { get; set; }

        public virtual ICollection<NotaNegocio> Notas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdNegocio")]
        public int Id { get; set; }
    }
}