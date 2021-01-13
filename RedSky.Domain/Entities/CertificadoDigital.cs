using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using RedSky.Domain.Interfaces.Entities;
using RedSky.Security;

namespace RedSky.Domain.Entities
{
    [Table("CertificadoDigital")]
    public class CertificadoDigital : IEntity
    {
        [NotMapped] private X509Certificate2 m_Certificate;

        [NotMapped] private X509Certificate m_CertP;

        [Required]
        [Column("Certificado", TypeName = "VarBinary(MAX)")]
        public byte[] X509CertificateData { get; set; }

        [Required] public int IdFilial { get; set; }

        [ForeignKey("IdFilial")] public virtual Filial Filial { get; set; }

        [Required]
        [Column(TypeName = "VarChar")]
        [StringLength(128)]
        public string SenhaCertificado { get; set; }

        [Required]
        [Column(TypeName = "Char")]
        [MaxLength(36)]
        public string HashCertificado { get; set; }

        [NotMapped]
        public X509Certificate2 Certificado
        {
            get
            {
                if (m_CertP == null)
                {
                    if (!string.IsNullOrEmpty(HashCertificado))
                        m_CertP = new X509Certificate(X509CertificateData,
                            Cryptography.DecryptWithSalt(SenhaCertificado, HashCertificado));

                    m_Certificate = new X509Certificate2(m_CertP.Handle);
                }

                return m_Certificate;
            }
        }

        [NotMapped] public string Subject => Certificado.Subject;

        [NotMapped] public string Issuer => Certificado.Issuer;

        [NotMapped] public int Version => Certificado.Version;

        [NotMapped] public DateTime ValidDate => Certificado.NotBefore;

        [NotMapped] public DateTime ExpiryDate => Certificado.NotAfter;

        [NotMapped] public string Thumbprint => Certificado.Thumbprint;

        [NotMapped] public string SerialNumber => Certificado.SerialNumber;

        [NotMapped] public string FriendlyName => Certificado.PublicKey.Oid.FriendlyName;

        [NotMapped] public string PublicKeyFormat => Certificado.PublicKey.EncodedKeyValue.Format(true);

        [NotMapped] public int RawDataLength => Certificado.RawData.Length;

        [NotMapped] public string NomeEmpresarial => Certificado.Subject.Split(',')[0].Replace("CN=", string.Empty);

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCertificadoDigital")]
        public int Id { get; set; }
    }
}