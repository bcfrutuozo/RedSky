using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Net.Mail;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Security;
using RedSky.Utilities;

namespace RedSky.Domain.Entities
{
    [Table("Empresa")]
    public class Empresa : IEntity
    {
        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(64)]
        public string Identificacao { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(128)]
        public string RazaoSocial { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool Ativo { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaPIS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaCOFINS { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaCSLL { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaIR { get; set; }

        [Required]
        [Column(TypeName = "Decimal")]
        [DecimalPrecision(6, 4)]
        public decimal AliquotaINSS { get; set; }

        [Required] public int IdRegimeTributario { get; set; }

        [ForeignKey("IdRegimeTributario")] public virtual RegimeTributario RegimeTributario { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(128)]
        public string CaminhoRelatorio { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(64)]
        public string ServidorSMTP { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(128)]
        public string SenhaEmail { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [StringLength(36)]
        public string HashEmail { get; set; }

        [Required] public int Port { get; set; }

        [Required] public int TimeOut { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool UseDefaultCredentials { get; set; }

        [Required] [Column(TypeName = "Bit")] public bool EnableSSL { get; set; }

        [Column(TypeName = "Image")] public byte[] LogoEmail { get; set; }

        public virtual ICollection<Filial> Filiais { get; set; }

        public virtual ICollection<ConexaoBanco> ConexoesBanco { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Demonstrativo> Demonstrativos { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }

        public virtual ICollection<TaskGroup> TaskGroups { get; set; }

        public virtual ICollection<Label> Labels { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdEmpresa")]
        public int Id { get; set; }

        public SmtpClient GetSmtpClientConfiguration()
        {
            return new SmtpClient(this.ServidorSMTP)
            {
                UseDefaultCredentials = this.UseDefaultCredentials,
                Credentials = new NetworkCredential(this.Email,
                    Cryptography.DecryptWithSalt(this.SenhaEmail, this.HashEmail)),
                Port = this.Port,
                EnableSsl = this.EnableSSL,
                Timeout = this.TimeOut,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }
    }
}